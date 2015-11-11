using System;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace GDev.Umbraco.Testing.Controllers
{
    public abstract class BaseHybridController : SurfaceController, IRenderMvcController
    {
        protected UmbracoContext Context { get; private set; }

        private readonly UmbracoHelper _umbraco;
        public override UmbracoHelper Umbraco
        {
            get { return this._umbraco ?? base.Umbraco; }
        }

        protected BaseHybridController()
        {
            this.Context = UmbracoContext.Current;
        }

        protected BaseHybridController(UmbracoContext context) : base(context)
        {
            this.Context = context;
        }

        protected BaseHybridController(UmbracoContext context, UmbracoHelper helper) : base(context)
        {
            this.Context = context;
            this._umbraco = helper;
        }

        public ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }

        protected ActionResult CurrentTemplate<T>(T model)
        {
            var template = ControllerContext.RouteData.Values["action"].ToString();
            if (EnsurePhsyicalViewExists(template) == false)
            {
                throw new Exception("No physical template file was found for template " + template);
            }

            return View(template, model);
        }

        private bool EnsurePhsyicalViewExists(string template)
        {
            var result = ViewEngines.Engines.FindView(ControllerContext, template, null);
            if (result.View == null)
            {
                LogHelper.Warn<RenderMvcController>("No physical template file was found for template " + template);
                return false;
            }

            return true;
        }
    }
}
