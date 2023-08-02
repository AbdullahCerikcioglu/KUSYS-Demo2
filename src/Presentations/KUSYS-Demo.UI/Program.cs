using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;


var builder = WebApplication.CreateBuilder(args);
{
    //var DefaultConnection = string.Empty;
    //builder.Services.AddDbContext<EfDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(DefaultConnection))));
    builder.Services.AddPersistenceService();
    builder.Services.AddControllersWithViews();
    builder.Services.AddMediatR(typeof(Program));
}


var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Courses}/{action=Index}/{id?}");

    app.Run();
}



