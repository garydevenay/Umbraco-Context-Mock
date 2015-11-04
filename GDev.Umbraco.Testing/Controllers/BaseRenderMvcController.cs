using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace GDev.Umbraco.Testing.Controllers
{
    public abstract class BaseRenderMvcController : RenderMvcController
    {
        protected UmbracoContext Context { get; private set; }

        private readonly UmbracoHelper _umbraco;
        public override UmbracoHelper Umbraco
        {
            get { return this._umbraco ?? base.Umbraco; }
        }

        protected BaseRenderMvcController()
        {
            this.Context = UmbracoContext.Current;
        }

        protected BaseRenderMvcController(UmbracoContext context)
        {
            this.Context = context;
        }

        protected BaseRenderMvcController(UmbracoContext context, UmbracoHelper helper)
        {
            this.Context = context;
            this._umbraco = helper;
        }
    }
}
