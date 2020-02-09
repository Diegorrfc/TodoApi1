using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Context;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api
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
      services.AddControllers();
      //services.AddTransient - toda vez que precisar de um item, ele vai criar.
      //services.AddScoped - um singleton por requisição - perfeito para base (banco de dados).
      //services.AddSingleton uma instancia(Coloca na memória e fica lá para para ser ser consultado) para todo a aplicação. Para uma
      // banco n daria certo pois a conexão ficaria ativa

      services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
      // services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
      services.AddTransient<ITodoRepository, TodoRepository>();
      services.AddTransient<TodoHandler, TodoHandler>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(X => X
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
      );
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
