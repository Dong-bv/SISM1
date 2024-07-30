using Microsoft.EntityFrameworkCore;
using SISM.Repository;

var builder = WebApplication.CreateBuilder(args);
//Connection db
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "course",
    pattern: "{controller=Home}/{action=Course}/{id?}");

app.MapControllerRoute(
    name: "courseManagement",
    pattern: "{controller=Course}/{action=CourseManagement}/{id?}");


app.Run();
