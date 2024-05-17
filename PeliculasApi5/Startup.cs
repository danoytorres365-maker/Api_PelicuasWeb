namespace PeliculasApi5
{
   

//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;



    public class Startup

    {
        public Startup(IConfiguration configuration) // luego de le damos a control . para asignarlo como una propiedad 
        {


            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void configureServices(IServiceCollection services) // configuracion de servicios 
        {
            //Config. Automaper para no poner nuestra dependencias al aire libre 
            //services.AddAutoMapper(typeof(Startup));

            //services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();

            services.AddHttpContextAccessor();


            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); // configurando la bd 
           // IMvcBuilder mvcBuilder = services.AddControllers().AddNewtonsoftJson();



            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            //services.AddSwaggerGen();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(Endpoint =>
            {
                Endpoint.MapControllers();


            });


        }
    }
}
