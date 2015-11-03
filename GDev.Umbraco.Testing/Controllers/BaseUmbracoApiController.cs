using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace GDev.Umbraco.Testing.Controllers
{
    public abstract class BaseUmbracoApiController : UmbracoApiController
    {
        protected UmbracoContext Context { get; private set; }

        private readonly UmbracoHelper _umbraco;
        public override UmbracoHelper Umbraco
        {
            get { return this._umbraco ?? base.Umbraco; }
        }

        protected BaseUmbracoApiController()
        {
            this.Context = UmbracoContext.Current;
        }

        protected BaseUmbracoApiController(UmbracoContext context)
        {
            this.Context = context;
        }

        protected BaseUmbracoApiController(UmbracoContext context, UmbracoHelper helper)
        {
            this.Context = context;
        }
    }
}
