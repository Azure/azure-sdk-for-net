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
    public class SecureScoreControlTests : TestBase
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
        public void SecureScoreControls_ListAll()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SecureScoreControls.List(expand: "definitions");
                ValidateSecureScoreControlsList(ret, false);
            }
        }

        [Fact]
        public void SecureScoreControls_ListAllWithDefinitions()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SecureScoreControls.List(expand: "definition");
                ValidateSecureScoreControlsList(ret, true);
            }
        }

        [Fact]
        public void SecureScores_Get()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.SecureScoreControls.ListBySecureScore("ascScore");
                ValidateSecureScoreControlsList(ret, false);
            }
        }

        [Fact]
        public void SecureScores_Get_Unknown()
        {
            using (var context = MockContext.Start(GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var a = securityCenterClient.SecureScoreControls.ListBySecureScore("unknown");
                Assert.Empty(a);
            }
        }
        #endregion

        #region Validations
        private static void ValidateSecureScoreControlsList(IPage<SecureScoreControlDetails> ret, bool expectedMetadata)
        {
            Assert.True(ret.IsAny(), "Got empty list");
            foreach (var item in ret)
            {
                ValidateSecureScoreControlItem(item, expectedMetadata);
            }
        }

        private static void ValidateSecureScoreControlItem(SecureScoreControlDetails item, bool expectedMetadata)
        {
            Assert.NotNull(item);
            Assert.NotNull(item.DisplayName);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.Current);
            Assert.NotNull(item.Max);
            Assert.NotNull(item.Weight);
            Assert.NotNull(item.Percentage);
            Assert.Equal(expectedMetadata, item.Definition != null);
            Assert.True(item.Max >= 0);
            Assert.Equal("Microsoft.Security/secureScores/secureScoreControls", item.Type);
            Assert.True(item.Current >= 0.00 && item.Current <= item.Max);
            Assert.True(item.Weight >= 0);
            Assert.True(item.Percentage >= 0.00 && item.Percentage <= 1.00);
        }
        #endregion
    }
}
