using System.Web.Mvc;

namespace QualityCaps.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Home_default",
                "Home/{controller}/{action}/{id}",
                new {  action = "Index",Controller="Home", id = UrlParameter.Optional },

                new string[] { "QualityCaps.Controllers" }
            );
        }
    }
}