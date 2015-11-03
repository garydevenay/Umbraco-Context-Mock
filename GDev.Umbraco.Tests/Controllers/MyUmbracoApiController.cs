using System.Web.Http;
using GDev.Umbraco.Testing.Controllers;
using Umbraco.Web;
using Umbraco.Core.Models;

namespace GDev.Umbraco.Tests.Controllers
{
    public class MyUmbracoApiController : BaseUmbracoApiController
    {
        public MyUmbracoApiController(UmbracoContext context) : base(context) { }
        public MyUmbracoApiController(UmbracoContext context, UmbracoHelper helper) : base(context, helper) { }

        [HttpGet]
        public string SayHello()
        {
            IPublishedContent content = Umbraco.TypedContent(1);

            return content.GetPropertyValue<string>("hello");
        }
    }
}
