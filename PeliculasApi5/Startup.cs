namespace PeliculasApi5
{

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
    using PeliculasApi5.helperts;

    public class Startup

    {
        public Startup(IConfiguration configuration) // luego de le damos a control . para asignarlo como una propiedad 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) // configuracion de servicios 
        {



            //Configurando automapper


            services.AddAutoMapper(typeof(Startup)); // pasandole el proyecto del perfil de automapper o esta misma clase 


            


            services.AddControllers(

                 options =>
                 {
                     options.SuppressAsyncSuffixInActionNames = false;

                 }


                );



            services.AddEndpointsApiExplorer();

            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); // configurando la bd , para que pueda realizar la migracion o creacion de tablas, tenemos que colocar esta linea de codigo 


            services.AddControllers()

                .AddNewtonsoftJson(); // instanciando AddNewtonsoftJson que nos permite usar el metodo path 



        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            
          }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();


            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();


            });

        }
    }
}
