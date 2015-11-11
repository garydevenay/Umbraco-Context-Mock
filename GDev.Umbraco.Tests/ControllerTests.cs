using GDev.Umbraco.Testing;
using NUnit.Framework;
using GDev.Umbraco.Tests.Controllers;

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
        public void CanInitializeSurfaceController()
        {
            Assert.DoesNotThrow(() => new MySurfaceController(this._mocker.UmbracoContextMock));
        }

        [Test]
        public void CanInitializeRenderMvcController()
        {
            Assert.DoesNotThrow(() => new MyRenderMvcController(this._mocker.UmbracoContextMock));
        }

        [Test]
        public void CanInitializeHybridController()
        {
            Assert.DoesNotThrow(() => new MyHybridController(this._mocker.UmbracoContextMock));
        }

        [Test]
        public void CanInitializeUmbracoApiController()
        {
            Assert.DoesNotThrow(() => new MyUmbracoApiController(this._mocker.UmbracoContextMock));
        }
    }
}
