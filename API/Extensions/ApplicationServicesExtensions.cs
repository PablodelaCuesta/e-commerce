using System.Linq;
using API.Errors;
using Core.Data;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Models.Interfaces;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductRepository>();

            services.AddScoped<IOrderService, OrderService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            // Servicio Basket para Redis
            services.AddScoped<IBasketRepository, BasketRepository>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                    .Where(e => e.Value.Errors.Count > 0)
                                    .SelectMany(x => x.Value.Errors)
                                    .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}