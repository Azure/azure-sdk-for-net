using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class AllowedConnectionsTests : TestBase
    {
        #region Test setup

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "westcentralus";

            return securityCenterClient;
        }

        #endregion

        #region AllowedConnections tests

        [Fact]
        public void AllowedConnections_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var allowedConnectionsResources = securityCenterClient.AllowedConnections.List();
                ValidateAllowedConnectionsResources(allowedConnectionsResources);
            }
        }

        [Fact]
        public void AllowedConnections_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var allowedConnectionsResource = securityCenterClient.AllowedConnections.Get("MyResourceGroup", "internal");
                ValidateAllowedConnectionsResource(allowedConnectionsResource);
            }
        }

        #endregion

        #region Validations

        private void ValidateAllowedConnectionsResources(IPage<AllowedConnectionsResource> allowedConnectionsResources)
        {
            Assert.True(allowedConnectionsResources.IsAny());

            allowedConnectionsResources.ForEach(ValidateAllowedConnectionsResource);
        }

        private void ValidateAllowedConnectionsResource(AllowedConnectionsResource allowedConnectionsResource)
        {
            Assert.NotNull(allowedConnectionsResource);
            
            Assert.NotNull(allowedConnectionsResource.CalculatedDateTime);
            allowedConnectionsResource.ConnectableResources?.ForEach(connectableResource =>
            {
                Assert.NotNull(connectableResource.Id);
                Assert.NotNull(connectableResource.InboundConnectedResources);
                Assert.NotNull(connectableResource.OutboundConnectedResources);
            });
        }

        #endregion
    }
}
