using MyApi.Services;

namespace MyApi.Register
{
    public static class RegisterServices
    {
        public static void ServicesRegistration(IServiceCollection services)
        {
            // Add your services here
            services.AddScoped<ICardsService, CardsService>();

            // Add more services as needed
        }
    }
}
