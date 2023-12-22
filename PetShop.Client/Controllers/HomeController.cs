
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Client.Models;
using PetShop.Models.Entities;
using PetShop.Services.Services;
using System.Data;
using System.Diagnostics;


namespace PetShop.Client.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAnimalService _animalService;
        private readonly ICommentService _commentService;
        private readonly IWebHostEnvironment _webHost;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICategoryService categoryService, IAnimalService animalService, ICommentService commentService, IWebHostEnvironment webHost, ILogger<HomeController> logger)
        {
            _categoryService = categoryService;
            _animalService = animalService;
            _commentService = commentService;
            _webHost = webHost;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string message)
        {
            var comments = await _commentService.GetAllCommentsAsync();
            var topAnimals = comments.GroupBy(comment => comment.AnimalId)
                .Select(group => new
                {
                    AnimalId = group.Key,
                    CommentCount = group.Count()
                })
                .OrderByDescending(result => result.CommentCount).Take(2).ToList();

            var animalsWithMostComments = new List<Animal>();

            foreach (var animalInfo in topAnimals)
            {
                var animal = (await _animalService.GetAllAnimalsAsync()).FirstOrDefault(a => a.AnimalId == animalInfo.AnimalId);
                if (animal != null)
                {
                    animal.CommentCount = animalInfo.CommentCount;
                    animalsWithMostComments.Add(animal);
                }
            }
            if (message != null)


                ViewBag.authenticationMessage = message;
            else
                ViewBag.authenticationMessage = TempData["authenticationMessage"] as string;

            return View(animalsWithMostComments);
        }

        public async Task<IActionResult> Catalogue(string name)
        {
            if (name == null)
            {
                ViewBag.animalsInCategory = await _animalService.GetAllAnimalsAsync();
            }
            else
            {
                var category = await _categoryService.GetCategoryByNameAsync(name);

                var animalsInCategory = (await _animalService.GetAllAnimalsAsync())
                            .Where(a => a.CategoryId == category.CategoryId)
                            .ToList();

                ViewBag.animalsInCategory = animalsInCategory;
                ViewBag.CategoryName = name;
            }
            return View(await _categoryService.GetAllCategoriesAsync());
        }

        public async Task<IActionResult> Animal(string name)
        {
            var intId = int.Parse(name);

            var animals = (await _animalService.GetAllAnimalsAsync()).ToList();
            var categories = (await _categoryService.GetAllCategoriesAsync()).ToList();

            var joinedData = categories
                .Join(
                      animals,
                      category => category.CategoryId,
                      animal => animal.CategoryId,
                      (category, animal) => new
                      {
                          categoryId = category.CategoryId,
                          animalId = animal.AnimalId,
                          categoryName = category.Name,
                          animalName = animal.Name,
                          animalLifespan = animal.Lifespan,
                          animalDescription = animal.Description,
                          animalComments = animal.Comments
                      })
                .Where(data => data.animalId == intId).FirstOrDefault();
            ViewBag.animalData = joinedData;

            Comment comment = new Comment();

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {

            if (ModelState.IsValid)
            {
                await _commentService.AddCommentAsync(comment);

            }

            string strId = comment.AnimalId.ToString();

            return RedirectToAction("Animal", new { name = strId });
        }

        [CustomAuthorize("Administrator")]
        public async Task<IActionResult> CommentEdit(int commentId)
        {


            var comment = await _commentService.GetCommentByIdAsync(commentId);


            return View(comment);
        }
        public async Task<IActionResult> CommentUpdate(Comment comment)
        {
            string? strId = null;
            if (comment != null)
            {
                await _commentService.UpdateCommentAsync(comment);

                strId = comment.AnimalId.ToString();
            }

            return RedirectToAction("Animal", "Home", new { name = strId });
        }
        public async Task<IActionResult> DeleteComment(Comment comment)
        {
            string? strId = null;
            if (comment != null)
            {
                await _commentService.DeleteCommentAsync(comment.CommentId);

                strId = comment.AnimalId.ToString();
            }
            return RedirectToAction("Animal", "Home", new { name = strId });
        }

        [CustomAuthorize("Administrator")]
        public async Task<IActionResult> Administrator(string name)
        {

            if (name == null)
            {
                ViewBag.animalsInCategory = await _animalService.GetAllAnimalsAsync();
            }
            else
            {
                var category = await _categoryService.GetCategoryByNameAsync(name);

                var animalsInCategory = (await _animalService.GetAllAnimalsAsync())
                            .Where(a => a.CategoryId == category.CategoryId)
                            .ToList();

                ViewBag.animalsInCategory = animalsInCategory;
                ViewBag.CategoryName = name;
            }

            return View(await _categoryService.GetAllCategoriesAsync());
        }
        //[HttpPut]
        public async Task<IActionResult> Edit(int animalId)
        {
            var animal = await _animalService.GetAnimalByIdAsync(animalId);

            ViewBag.CurrentCategory = await _categoryService.GetCategoryByIdAsync(animal.CategoryId);


            ViewBag.AllCategories = _categoryService.GetAllCategoriesAsync();
            return View(animal);
        }
        public async Task<IActionResult> UpdateAnimal(Animal animal, IFormFile? imgFile)
        {
            if (imgFile != null)
            {
                var saveimg = Path.Combine(_webHost.WebRootPath, "Images", imgFile.FileName);

                using (var uploading = new FileStream(saveimg, FileMode.Create))
                {
                    await imgFile.CopyToAsync(uploading);
                }
            }
            if (ModelState.IsValid)
            {
                //var animal = await _animalRepository.GetAnimalByIdAsync(animalId);
                await _animalService.UpdateAnimalAsync(animal);
            }

            return RedirectToAction("Administrator");
        }
        //[HttpDelete]
        public async Task<IActionResult> Delete(int animalId)
        {
            await _animalService.DeleteAnimalAsync(animalId);

            return RedirectToAction("Administrator");
        }


        public async Task<IActionResult> NewAnimal()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

            var animal = new Animal();
            return View(animal);
        }

        public IActionResult NewAnimal222(Animal animal)
        {
            ViewBag.Categories = _categoryService.GetAllCategoriesAsync();


            return View("NewAnimal", animal);
        }



        [HttpPost]
        public async Task<IActionResult> AddAnimal(Animal animal, string selectedCategory, IFormFile imgFile)
        {
            var category = await _categoryService.GetCategoryByNameAsync(selectedCategory);
            animal.CategoryId = category.CategoryId;

            if (imgFile != null)
            {
                var saveimg = Path.Combine(_webHost.WebRootPath, "Images", imgFile.FileName);

                string imgext = Path.GetExtension(imgFile.FileName);
                using (var uploading = new FileStream(saveimg, FileMode.Create))
                {
                    await imgFile.CopyToAsync(uploading);
                }
            }
            else
            {
                return RedirectToAction("NewAnimal");
            }

            if (ModelState.IsValid)
            {
                await _animalService.AddAnimalAsync(animal);
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    var errorMessage = error.ErrorMessage;
                    // Log or debug the error message
                }
                return RedirectToAction("NewAnimal222", animal);
            }

            return RedirectToAction("Administrator");
        }














        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
