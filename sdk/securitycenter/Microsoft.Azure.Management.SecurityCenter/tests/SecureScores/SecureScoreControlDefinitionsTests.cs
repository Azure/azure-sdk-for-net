using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Management.SecurityCenter.Tests.SecureScores
{
    public class SecureScoreControlDefinitionsTests : TestBase
    {
        #region Test setup
        private static readonly string AscLocation = "centralus";
        private static TestEnvironment TestEnvironment { get; set; }
        #endregion

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

            securityCenterClient.AscLocation = AscLocation;

            return securityCenterClient;
        }

        #region Tests
        [Fact]
        public void SecureScoreControlDefinitions_ListAll()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                Assert.Throws<CloudException>(() => securityCenterClient.SecureScoreControlDefinitions.List());
            }
        }

        [Fact]
        public void SecureScoreControlDefinitions_ListBySubscription()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SecureScoreControlDefinitions.ListBySubscription();
                ValidateSecureScoreControlDefinitionsList(ret);
            }
        }

        #endregion

        #region Validations
        private static void ValidateSecureScoreControlDefinitionsList(IPage<SecureScoreControlDefinitionItem> ret)
        {
            Assert.True(ret.IsAny(), "Got empty list");
            foreach (var item in ret)
            {
                ValidateSecureScoreControlItem(item);
            }
        }

        private static void ValidateSecureScoreControlItem(SecureScoreControlDefinitionItem item)
        {
            Assert.NotNull(item);
            Assert.NotNull(item.DisplayName);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.AssessmentDefinitions);
            Assert.NotNull(item.MaxScore);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Source);
            Assert.Equal("Microsoft.Security/secureScoreControlDefinitions", item.Type);
            Assert.NotEmpty(item.AssessmentDefinitions);
        }
        #endregion
    }
}
