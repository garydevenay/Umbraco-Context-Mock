using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace GDev.Umbraco.Testing.Controllers
{
    public abstract class BaseSurfaceController : SurfaceController
    {
        protected UmbracoContext Context { get; private set; }

        private readonly UmbracoHelper _umbraco;
        public override UmbracoHelper Umbraco
        {
            get { return this._umbraco ?? base.Umbraco; }
        }

        protected BaseSurfaceController()
        {
            this.Context = UmbracoContext.Current;
        }

        protected BaseSurfaceController(UmbracoContext context) : base(context)
        {
            this.Context = context;
        }

        protected BaseSurfaceController(UmbracoContext context, UmbracoHelper helper) : base(context)
        {
            this.Context = context;
            this._umbraco = helper;
        }
    }
}
