using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
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
                var appWhitelistingGroups = securityCenterClient.AdaptiveApplicationControls.List();
                ValidateAppWhitelistingGroups(appWhitelistingGroups);
            }
        }

        [Fact]
        public void AdaptiveApplicationControls_Put()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var appWhitelistingGroup = new AppWhitelistingGroup(
                    name: "TestGroup",
                    protectionMode: new ProtectionMode("Audit", "None", "None"),
                    configurationStatus: "NoStatus",
                    sourceSystem: "Azure_AppLocker");

                var createdGroup = securityCenterClient.AdaptiveApplicationControls.Put("TestGroup", appWhitelistingGroup);

                ValidateCreatedApplicationWhitelistingGroup(createdGroup, securityCenterClient.AscLocation, "TestGroup");
            }
        }

        [Fact]
        public void AdaptiveApplicationControls_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var group = securityCenterClient.AdaptiveApplicationControls.Get("TestGroup");

                ValidateApplicationWhitelistingGroup(group);
            }
        }

        #endregion

        #region Validations


        private void ValidateAppWhitelistingGroups(AppWhitelistingGroups appWhitelistingGroups)
        {
            Assert.NotEmpty(appWhitelistingGroups.Value);

            appWhitelistingGroups.Value.ForEach(ValidateApplicationWhitelistingGroup);
        }

        private void ValidateApplicationWhitelistingGroup(AppWhitelistingGroup appWhitelistingGroup)
        {
            Assert.NotNull(appWhitelistingGroup);
            Assert.NotNull(appWhitelistingGroup.VmRecommendations);
            Assert.NotNull(appWhitelistingGroup.PathRecommendations);
            Assert.NotNull(appWhitelistingGroup.ConfigurationStatus);
            Assert.NotNull(appWhitelistingGroup.EnforcementMode);
            Assert.NotNull(appWhitelistingGroup.Issues);
            Assert.NotNull(appWhitelistingGroup.ProtectionMode);
            Assert.NotNull(appWhitelistingGroup.SourceSystem);
        }

        private void ValidateCreatedApplicationWhitelistingGroup(AppWhitelistingGroup appWhitelistingGroup, string ascLocation, string groupName)
        {
            Assert.NotNull(appWhitelistingGroup);
            Assert.NotNull(appWhitelistingGroup.Id);
            Assert.Equal(groupName, appWhitelistingGroup.Name);
            Assert.Equal("Microsoft.Security/applicationWhitelistings", appWhitelistingGroup.Type);
            Assert.Equal(ascLocation, appWhitelistingGroup.Location);
        }

        #endregion
    }
}
