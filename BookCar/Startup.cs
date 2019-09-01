using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookCar.Startup))]
namespace BookCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
