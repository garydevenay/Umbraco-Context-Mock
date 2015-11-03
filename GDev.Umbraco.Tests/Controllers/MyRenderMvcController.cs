using GDev.Umbraco.Testing.Controllers;
using Umbraco.Web;

namespace GDev.Umbraco.Tests.Controllers
{
    public class MyRenderMvcController : BaseRenderMvcController
    {
        public MyRenderMvcController(UmbracoContext context) : base(context) { }
        public MyRenderMvcController(UmbracoContext context, UmbracoHelper helper) : base(context, helper) { }
    }
}
