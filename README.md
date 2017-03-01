# Umbraco Context Mock
Umbraco Context Mock is a small package to help developers quickly access mocked versions of the UmbracoContext and ApplicationContext throughout their application unit tests without recreating these objects constantly.

**This package should be compatible with any unit testing solutions, though I have only tested with NUnit**

### Install via NuGet
Into your unit testing project, we will want to install the testing package.
`PM> Install-Package GDev.Umbraco.Testing`

Into your web project (that contains Umbraco) we will want to install the web package
`PM> Install-Package GDev.Umbraco.Testing.Web`

## Implementation
Umbraco Context Mock contains three base controller classes (**BaseSurfaceController**, **BaseUmbracoApiController** and **BaseRenderMvcController**) to be inherited by your controller classes. Each base controllers contains three constructors which are used for initializing the controller for specific purposes.

```C#
using GDev.Umbraco.Web.Controllers;
using Umbraco.Web;

namespace GDev.Umbraco.Tests.Controllers
{
    public class MyRenderMvcController : BaseRenderMvcController
    {
        public MyRenderMvcController() { }
        public MyRenderMvcController(UmbracoContext context) : base(context) { }
        public MyRenderMvcController(UmbracoContext context, UmbracoHelper helper) : base(context, helper) { }
    }
}
```

## Unit Testing
Using this approach, you are able to inject your stub context object into your controller when tests are run and test your controller actions as your would in a normal MVC application.

```C#
using GDev.Umbraco.Test;
using NUnit.Framework;
using GDev.Umbraco.Web.Controllers;

namespace GDev.Umbraco.Tests
{
    [TestFixture]
    public class ControllerTests
    {
        private ContextMocker _mocker;

        [SetUp]
        public void SetUp()
        {
            this._mocker = new ContextMocker();
        }

        [Test]
        public void CanInitializeRenderMvcController()
        {
            Assert.DoesNotThrow(() => new MyRenderMvcController(this._mocker.UmbracoContextMock));
        }
    }
}
```

## Accessing UmbracoHelper and UmbracoContext
As we require our UmbracoHelper and UmbracoContext to behave consistently between our live controllers and unit tests, we should ensure to access these object in the following way:

```C#
using System.Web.Mvc;
using GDev.Umbraco.Web.Controllers;
using Umbraco.Web;

namespace GDev.Umbraco.Tests.Controllers
{
    public class MyRenderMvcController : BaseRenderMvcController
    {
        public MyRenderMvcController() { }
        public MyRenderMvcController(UmbracoContext context) : base(context) { }
        public MyRenderMvcController(UmbracoContext context, UmbracoHelper helper) : base(context, helper) { }

        public ActionResult MyAction()
        {
            //Our standard umbraco context
            var context = this.UmbracoContext;

            //Our standard umbraco helper
            var helper = this.Umbraco;
        }
    }
}

```

## Injecting Extra Constructor Services
When injecting your own services into your Umbraco controllers using Dependency Injection you must remember to implement all three constructors, adding your service logic to each.

```C#
using GDev.Umbraco.Web.Controllers;
using log4net;
using Umbraco.Web;

namespace GDev.Umbraco.Tests.Controllers
{
    public class MyRenderMvcController : BaseRenderMvcController
    {
        private readonly ILog _logger;

        public MyRenderMvcController(ILog logger)
        {
            this._logger = logger;
        }

        public MyRenderMvcController(UmbracoContext context, ILog logger) : base(context)
        {
            this._logger = logger;
        }

        public MyRenderMvcController(UmbracoContext context, UmbracoHelper helper, ILog logger) : base(context, helper)
        {
            this._logger = logger;
        }
    }
}
```
