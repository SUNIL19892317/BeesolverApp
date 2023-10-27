using MyApi.Register;

namespace MyApi
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices.ServicesRegistration(services);
        }
       
    }
}
