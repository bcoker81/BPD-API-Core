using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPD01_WebApi_Core.Entities;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BPD01_WebApi_Core.UnitOfWork;
using Newtonsoft.Json.Serialization;

namespace Bpd01_webapi_core
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
            services.AddDbContext<BpdDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddTransient<IUow, BpdUnitOfWork>();
            services.AddCors(o => o.AddPolicy("BPDPolicy", builder =>{
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            })
            );
            services.AddMvc()
            .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver())
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("BPDPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
