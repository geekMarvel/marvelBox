using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PetShop.Client.CustomAuthorize;
using PetShop.Data.Contexts;
using PetShop.Data.Repositories;
using PetShop.Services.Services;
using PetShop.PasswordHashers;



//using Serilog;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
//builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

//string conectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;



builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(CustomAuthorizationFilter));
    options.Filters.Add(new CustomAuthorizationFilter());
});

builder.Services.AddSession(options =>
{
    // Configure session options as needed
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});




builder.Services.AddDbContext<PetShopDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default"),
    sqlServerOptions => sqlServerOptions.MigrationsAssembly("PetShop.Client")));



//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
builder.Services.AddAuthentication
(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(options =>
       {
           options.Cookie.Name = "YourAppCookieName";
           options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
           options.LoginPath = "/Home/Index"; // Your login path
           options.Events = new CookieAuthenticationEvents
           {
               OnRedirectToAccessDenied = context =>
               {
                   // Use TempData to store and retrieve the custom message
                   context.Response.Redirect(context.RedirectUri + "?message=" + Uri.EscapeDataString(context.Properties.Items["Message"]!));
                   return Task.CompletedTask;
               }
           };
       });




builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalService, AnimalService>();

builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IPasswordHasher, BCryptPasswordHasher>();

var app = builder.Build();

////////////if (!app.Environment.IsDevelopment())
////////////{
////////////    app.UseExceptionHandler("/Error");
////////////}



using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
    ctx.Database.Migrate();
}
//using (var scope = app.Services.CreateScope())
//{
//    var ctx = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
//    ctx.Database.EnsureDeleted();
//    ctx.Database.EnsureCreated();
//}
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{name?}");

app.Run();

