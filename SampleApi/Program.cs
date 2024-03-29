using ApplicationLayer.Helpers;
using BusinessAccessLayer.IServices;
using BusinessAccessLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Repository.IRepository;
using DataAccessLayer.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace SampleApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(
				builder.Configuration.GetConnectionString("DefaultConnection")
				));

			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IUnitTypeService, UnitTypeService>();
			builder.Services.AddAutoMapper(option=>option.AddProfile(new MapperProfile()));

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddCors();

			var app = builder.Build();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseCors(option=>option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
			app.UseRouting();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}