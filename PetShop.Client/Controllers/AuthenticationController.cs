using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models.Entities;
using PetShop.Models.Requests;
using PetShop.PasswordHashers;
using PetShop.Services.Services;
using System.Security.Claims;

namespace PetShop.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticationController(IUserService userService, IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _httpContextAccessor = httpContextAccessor;
        }

        //[HttpPost]
        [CustomAuthorize("Administrator")]
        public IActionResult Check(string message)
        {
            ViewBag.step1 = "1 step success";
            ViewBag.step2 = User.Identity.IsAuthenticated;



            if (User.Identity!.IsAuthenticated)
            {
                // Allow access for authenticated users
                ViewBag.V = "Jackpot!!";
                ViewBag.D = User.Identity.Name;
                ViewBag.C = User.Identity.IsAuthenticated;
                ViewBag.Q = User.Identity.AuthenticationType;


                // Additional logic for authenticated users
                // ...
            }
            else
            {
                ViewBag.V = "boo!";
            }

            return View();
        }
        public IActionResult Index(string message)
        {
            ViewBag.ErrorMessages = message;
            var registerRequest = new RegisterRequest();

            return View(registerRequest);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (ModelState.IsValid)
            {
                User? existingUserByEmail = await _userService.GetByEmail(registerRequest.Email!);
                User? existingUserByUsername = await _userService.GetByUsername(registerRequest.Username!);

                if (existingUserByEmail != null)
                {
                    ModelState.AddModelError(nameof(registerRequest.Email), "Email is already taken.");
                    return View("Index", registerRequest);
                }
                if (existingUserByUsername != null)
                {
                    ModelState.AddModelError(nameof(registerRequest.Username), "Username is already taken.");
                    return View("Index", registerRequest);
                }

            }
            else
            {
                return View("Index", ViewBag.ErrorMessages);
            }



            if (registerRequest.Password != registerRequest.ConfirmPassword)
            {
                return RedirectToAction("Index", new { Message = "Password does not match confirm password." });
            }


            if (registerRequest.Password != null)
            {
                string passwordHash = _passwordHasher.HashPassword(registerRequest.Password);

                User registrationUser = new User()
                {
                    Email = registerRequest.Email,
                    Username = registerRequest.Username,
                    PasswordHash = passwordHash,
                    Role = registerRequest.Role
                };



                await _userService.Create(registrationUser);
            }
            return RedirectToAction("Index", new { Message = "Registration successful" });
        }
        //[HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            User? existingUserByUsername = await _userService.GetByUsername(username!);


            //existingUserByUsername?.Role.ToString();
            //var userRoles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

            if (existingUserByUsername != null && _passwordHasher.VerifyPassword(existingUserByUsername.PasswordHash!, password))
            {
                // Authentication successful, implement your logic (e.g., set authentication cookie)
                // Redirect to a protected resource or return success
                var user = existingUserByUsername;
                SetUserPrincipal(user);

                TempData["authenticationMessage"] = "Logged in successfully:)";

                return RedirectToAction("Index", "Home");
            }

            // Authentication failed, handle accordingly (e.g., return to login page with error)


            //return RedirectToAction("Administrator","Home");


            TempData["authenticationMessage"] = "Wrong details, try again!";


            return RedirectToAction("Index", "Home"); ;
        }
        private void SetUserPrincipal(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.Role, user.Role!)

                 // Add other claims as needed
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            _httpContextAccessor.HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            _httpContextAccessor.HttpContext!.Session.SetString("IsAuthenticated", "true");
        }

        public async Task<IActionResult> Logout()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                _httpContextAccessor.HttpContext.Session.Remove("IsAuthenticated");
                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["authenticationMessage"] = "Logged out..";
            }
            // Optionally, you can redirect the user to a specific page after logging out
            return RedirectToAction("Index", "Home");
        }

    }
}




