using InventoryAPI.Data;
using InventoryAPI.Data.Repositories;
using InventoryAPI.Helpers;
using InventoryAPI.Interfaces;
using InventoryAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<ICreditNoteService, CreditNoteService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddScoped<ICreditNoteRepository, CreditNoteRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
			var connectionString = config.GetConnectionString("DefaultConnection");
			services.AddDbContextFactory<DataContext>(options => options.UseSqlServer(
				connectionString, sqlServerOptionsAction: sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure();

				}), ServiceLifetime.Transient);
			return services;
		}
	}
}
