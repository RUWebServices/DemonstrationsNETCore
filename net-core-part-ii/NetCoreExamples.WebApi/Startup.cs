using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreExamples.Models.Dtos;
using NetCoreExamples.Models.Entities;
using NetCoreExamples.Models.InputModels;
using NetCoreExamples.Repositories;
using NetCoreExamples.Repositories.Implementations;
using NetCoreExamples.Repositories.Interfaces;
using NetCoreExamples.Services.Implementations;
using NetCoreExamples.Services.Interfaces;
using NetCoreExamples.WebApi.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace NetCoreExamples.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(opt => {
                opt.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Customer API",
                    Description = "This is used to fetch customers",
                    TermsOfService = "N/A",
                    Contact = new Contact
                    {
                        Name = "Arnar Leifsson",
                        Url = "https://arnarleifsson.com",
                        Email = "arnarl@ru.is"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            services.AddMvc();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ILogService, LogService>();
            services.AddSingleton<IDataProvider, DataProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(opt => {
                opt.RoutePrefix = "api-documentation";
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API");
            });
            app.ConfigureExceptionHandler();
            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerInputModel, Customer>();
            });
        }
    }
}
