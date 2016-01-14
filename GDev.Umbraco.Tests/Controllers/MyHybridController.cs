using GDev.Umbraco.Web.Controllers;
using Umbraco.Web;

namespace GDev.Umbraco.Tests.Controllers
{
    public class MyHybridController : BaseHybridController
    {
        public MyHybridController(UmbracoContext context) : base(context) { }
        public MyHybridController(UmbracoContext context, UmbracoHelper helper) : base(context, helper) { }
    }
}
