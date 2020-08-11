using System.Collections.Generic;
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
    public class AdaptiveNetworkHardeningsTests : TestBase
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

        #region AdaptiveNetworkHardenings Tests
        [Fact]
        public void AdaptiveNetworkHardenings_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var adaptiveNetworkHardeningResource = securityCenterClient.AdaptiveNetworkHardenings.Get("MyResourceGroup", "Microsoft.Compute", "virtualMachines", "MyVm", "default");
                ValidateAdaptiveNetworkHardeningResource(adaptiveNetworkHardeningResource);
            }
        }

        [Fact]
        public void AdaptiveNetworkHardenings_Enforce()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var response = securityCenterClient.AdaptiveNetworkHardenings.BeginEnforceWithHttpMessagesAsync(
                    "MyResourceGroup",
                    "Microsoft.Compute",
                    "virtualMachines",
                    "MyVm",
                    "default",
                    new List<Rule>()
                    {
                       new Rule("SystemGenerated", "Inbound", 3389, new List<string>() { "TCP"}, new List<string>())
                    },
                    new[] { "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/MyResourceGroup/providers/Microsoft.Network/networkSecurityGroups/MyNsg" }).Result;

                Assert.Equal(HttpStatusCode.Accepted, response.Response.StatusCode);
            }
        }

        #endregion

        #region Validations

        private void ValidateAdaptiveNetworkHardeningResource(AdaptiveNetworkHardening adaptiveNetworkHardeningResource)
        {
            Assert.NotNull(adaptiveNetworkHardeningResource);
            Assert.NotEmpty(adaptiveNetworkHardeningResource.EffectiveNetworkSecurityGroups);
            Assert.NotEmpty(adaptiveNetworkHardeningResource.Rules);
            Assert.NotNull(adaptiveNetworkHardeningResource.RulesCalculationTime);
        }

        #endregion
    }
}
