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
    public class TopologyTests : TestBase
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

        #region Topology Tests
        [Fact]
        public void Topology_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var topologiesResources = securityCenterClient.Topology.List();
                ValidateTopologiesResources(topologiesResources);
            }
        }

        [Fact]
        public void Topology_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var topologyResource = securityCenterClient.Topology.Get("MyResourceGroup", "virtualNetworks");
                ValidateTopologyResource(topologyResource);
            }
        }

        #endregion

        #region Validations

        private void ValidateTopologiesResources(IPage<TopologyResource> topologiesResources)
        {
            Assert.True(topologiesResources.IsAny());

            topologiesResources.ForEach(ValidateTopologyResource);
        }

        private void ValidateTopologyResource(TopologyResource topologyResource)
        {
            Assert.NotNull(topologyResource);
            Assert.NotNull(topologyResource.CalculatedDateTime);
            topologyResource.TopologyResources?.ForEach(singleTopologyResource =>
                {
                    Assert.NotNull(singleTopologyResource);
                    Assert.NotNull(singleTopologyResource.ResourceId);
                    Assert.NotNull(singleTopologyResource.RecommendationsExist);
                    Assert.NotNull(singleTopologyResource.TopologyScore);
                    Assert.NotNull(singleTopologyResource.NetworkZones);
                });
        }

        #endregion
    }
}
