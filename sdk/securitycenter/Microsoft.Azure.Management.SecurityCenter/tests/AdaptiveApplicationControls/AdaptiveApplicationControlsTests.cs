using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class AdaptiveApplicationControlsTests : TestBase
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

            securityCenterClient.AscLocation = "centralus";

            return securityCenterClient;
        }

        #endregion

        #region AdaptiveApplicationControls Tests
        [Fact]
        public void AdaptiveApplicationControls_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var adaptiveApplicationControlGroups = securityCenterClient.AdaptiveApplicationControls.List();
                ValidateApplicationControlGroups(adaptiveApplicationControlGroups);
            }
        }

        [Fact]
        public void AdaptiveApplicationControls_Put()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var adaptiveApplicationControlGroup = new AdaptiveApplicationControlGroup(
                    name: "TestGroup",
                    protectionMode: new ProtectionMode("Audit", "None", "None"),
                    configurationStatus: "NoStatus",
                    sourceSystem: "Azure_AppLocker");

                var createdGroup = securityCenterClient.AdaptiveApplicationControls.Put("TestGroup", adaptiveApplicationControlGroup);

                ValidateCreatedAdaptiveApplicationControlGroup(createdGroup, securityCenterClient.AscLocation, "TestGroup");
            }
        }

        [Fact]
        public void AdaptiveApplicationControls_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var group = securityCenterClient.AdaptiveApplicationControls.Get("TestGroup");

                ValidateAdaptiveApplicationControlGroup(group);
            }
        }

        #endregion

        #region Validations


        private void ValidateApplicationControlGroups(AdaptiveApplicationControlGroups adaptiveApplicationControlGroups)
        {
            Assert.NotNull(adaptiveApplicationControlGroups.Value);

            adaptiveApplicationControlGroups.Value.ForEach(ValidateAdaptiveApplicationControlGroup);
        }

        private void ValidateAdaptiveApplicationControlGroup(AdaptiveApplicationControlGroup adaptiveApplicationControlGroup)
        {
            Assert.NotNull(adaptiveApplicationControlGroup);
            Assert.NotNull(adaptiveApplicationControlGroup.VmRecommendations);
            Assert.NotNull(adaptiveApplicationControlGroup.PathRecommendations);
            Assert.NotNull(adaptiveApplicationControlGroup.ConfigurationStatus);
            Assert.NotNull(adaptiveApplicationControlGroup.EnforcementMode);
            Assert.NotNull(adaptiveApplicationControlGroup.Issues);
            Assert.NotNull(adaptiveApplicationControlGroup.ProtectionMode);
            Assert.NotNull(adaptiveApplicationControlGroup.SourceSystem);
        }

        private void ValidateCreatedAdaptiveApplicationControlGroup(AdaptiveApplicationControlGroup adaptiveApplicationControlGroup, string ascLocation, string groupName)
        {
            Assert.NotNull(adaptiveApplicationControlGroup);
            Assert.NotNull(adaptiveApplicationControlGroup.Id);
            Assert.Equal(groupName, adaptiveApplicationControlGroup.Name);
            Assert.Equal("Microsoft.Security/applicationWhitelistings", adaptiveApplicationControlGroup.Type);
            Assert.Equal(ascLocation, adaptiveApplicationControlGroup.Location);
        }

        #endregion
    }
}