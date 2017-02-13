
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Threading;
using Xunit;


namespace TestFramework.Net45Tests
{
    public class TestEnvTests
    {
        [Theory]
        [InlineData("AADTenant=04081b9f-c8b4-424b-86b9-ce44721c2b23;UserName=azpowershellpartner;Environment=Prod")]
        [InlineData("AADTenant=04081b9f-c8b4-424b-86b9-ce44721c2b23;SubscriptionId=None;Environment=Prod")]
        public void InteractiveLoginUsingAzPowershellpartner(string connStr)
        {
            // Use this test case to set connection string without username and password, which will prompt you to enter UserName and password
            // verify if the test environment has non empty username
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            try
            {
                // If you use azpowershellpartner username, as it is not associated with any subscription, it throws
                TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            }
            catch(Exception ex)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InlineData("AADTenant=04081b9f-c8b4-424b-86b9-ce44721c2b23;SubscriptionId=6b085460-5f21-477e-ba44-1035046e9101;Environment=Prod")]
        public void InteractiveLoginKnownUserName(string connStr)
        {
            // Log in for this test case using your alias
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string userId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.UserIdKey];
            Assert.Equal("abhishah@microsoft.com", userId);
            Assert.False(string.IsNullOrEmpty(userId));
        }

        [Theory]
        [InlineData("SubscriptionId=18b0dcf-550319fa5eac;" +
                "AADTenant=72f988bf-2d7cd011db47;" +
                "HttpRecorderMode=Record;" +
                "Environment=Prod;" +
                "ResourceManagementUri=https://management.microsoftazure.de/;" +
                "ServiceManagementUri=https://management.core.cloudapi.de/;" +
                "GalleryUri=https://gallery.cloudapi.de/;" +
                "GraphUri=https://graph.cloudapi.de/;" +
                "AADAuthUri=https://login.microsoftonline.de/;" +
                "IbizaPortalUri=http://portal.microsoftazure.de/;" +
                "RdfePortalUri=https://management.core.cloudapi.de/")]
        public void InteractiveLoginGermanCloud(string connStr)
        {
            // Log in for this test case using your alias
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string userId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.UserIdKey];
            Assert.Equal("markcowl@BFDevOpsNonRestricted.onmicrosoft.de", userId);
            Assert.False(string.IsNullOrEmpty(userId));
        }
    }
}
