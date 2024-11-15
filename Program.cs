using Microsoft.EntityFrameworkCore;

namespace TestSearchAutoComplete;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(builder
                        .Configuration
                        .GetConnectionString("DefaultConnection")));
        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseRouting();
        app.MapControllers();
        app.UseStaticFiles();
        app.Run();
    }
}
