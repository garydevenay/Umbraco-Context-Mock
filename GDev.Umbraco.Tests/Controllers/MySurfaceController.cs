using GDev.Umbraco.Testing.Controllers;
using Umbraco.Web;

namespace GDev.Umbraco.Tests.Controllers
{
    public class MySurfaceController : BaseSurfaceController
    {
        public MySurfaceController(UmbracoContext context) : base(context) { }
        public MySurfaceController(UmbracoContext context, UmbracoHelper helper) : base(context, helper) { }
    }
}
