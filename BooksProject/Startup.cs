using BooksProject.BusinessLogic;
using BooksProject.Commands;
using BooksProject.Consumers;
using BooksProject.Models;
using BooksProject.Services;
using BooksProject.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BooksProject
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<GetBooksRequestHandler>();
            services.AddScoped<GetBookRequestHandler>();
            services.AddScoped<InsertBookRequestHandler>();
            services.AddScoped<UpdateBookRequestHandler>();
            services.AddScoped<DeleteBookRequestHandler>();
            services.AddScoped<IBookService, BookService>();
            
            services.AddScoped<InsertBookConsumer>();

            services.AddMassTransit(x =>
            {
               
                x.AddConsumer<InsertBookConsumer>();
                x.AddBus(provider => MassTransit.Bus.Factory.CreateUsingInMemory(cfg =>
                {
                    cfg.ReceiveEndpoint("insert-book-queue", ep =>
                    {
                        ep.ConfigureConsumer<InsertBookConsumer>(provider);
                        EndpointConvention.Map<InsertBookCommand>(ep.InputAddress);
                    });
                }));

                x.AddRequestClient<InsertBookCommand>();
                
            });
            
            services.AddSingleton<IHostedService, BusService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}