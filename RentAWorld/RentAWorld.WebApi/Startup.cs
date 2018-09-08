using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;
using RentAWorld.Models.InputModels;
using RentAWorld.WebApi.Resolvers;

namespace RentAWorld.WebApi
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Rental, RentalDto>()
                    .ForMember(m => m.AuthorStamp, opt => opt.ResolveUsing<AuthorStampResolver>());
                cfg.CreateMap<RentalDto, Rental>();
                cfg.CreateMap<RentalInputModel, Rental>()
                    .ForMember(m => m.DateCreated, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("RentalAdmin"));
            });
        }
    }
}
