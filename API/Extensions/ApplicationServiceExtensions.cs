using API.Abstract;
using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddControllers();
    services.AddCors();
    services.AddDbContext<DataContext>(opt =>
    {
      opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
    });
    services.AddScoped<ITokenService, TokenService>();

    return services;
  }
}
