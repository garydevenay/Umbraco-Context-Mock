using System.Web;
using Moq;
using Umbraco.Core;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Core.Logging;
using Umbraco.Core.Profiling;
using Umbraco.Web;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;
using System.Linq;

namespace GDev.Umbraco.Testing
{
    public class ContextMocker
    {
        public ApplicationContext ApplicationContextMock { get; private set; }
        public UmbracoContext UmbracoContextMock { get; private set; }

        public ContextMocker()
        {
            ILogger loggerMock = Mock.Of<ILogger>();
            IProfiler profilerMock = Mock.Of<IProfiler>();
            HttpContextBase contextBaseMock = Mock.Of<HttpContextBase>();
            WebSecurity webSecurityMock = new Mock<WebSecurity>(null, null).Object;
            IUmbracoSettingsSection umbracoSettingsSectionMock = Mock.Of<IUmbracoSettingsSection>();

            this.ApplicationContextMock = new ApplicationContext(CacheHelper.CreateDisabledCacheHelper(), new ProfilingLogger(loggerMock, profilerMock));
            this.UmbracoContextMock = UmbracoContext.EnsureContext(contextBaseMock, this.ApplicationContextMock, webSecurityMock, umbracoSettingsSectionMock, Enumerable.Empty<IUrlProvider>(), true);
        }
    }
}
