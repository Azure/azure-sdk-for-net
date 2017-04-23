// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
#if FullNetFx
namespace TestFramework.Net45Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using Xunit;

    public class TestEnvTests
    {
        [Theory(Skip = "Interactive Tests, needs to be run manually")]
        [InlineData("AADTenant=<GetCSPtenantId>")]
        [InlineData("AADTenant=<GetCSPtenantId>;SubscriptionId=None;Environment=Prod")] //Test this with None as the SubId
        public void InteractiveLoginForCSP(string connStr)
        {
            // Use this test case to set connection string without username and password, which will prompt you to enter UserName and password
            // use CSP username/pwd that we have. This account has no subscription associated, hence throws exception.
            // TestEnv checks if the logged in user has the subscription that is provided in the connection string
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


        [Theory(Skip = "Interactive Tests, needs to be run manually")]
        [InlineData("AADTenant=<GetMsftTenantId>;SubscriptionId=<GetAnySubIdUnderYourAlias>;Environment=Prod")]
        public void InteractiveLoginKnownUserName(string connStr)
        {
            // Log in for this test case using your alias
            // the idea is to initiate auth even on 2FA tenant (in this case msft)
            // have a valid tenant id and subscription your alias has access to.
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string userId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.UserIdKey];
            Assert.EndsWith("microsoft.com", userId);
            Assert.False(string.IsNullOrEmpty(userId));
        }

        // Please update the connection string with the right information and then run the test
        [Theory(Skip = "Interactive Tests, needs to be run manually")]
        [InlineData("SubscriptionId=<subId>;" +
                "AADTenant=<tenantId for german cloud>;" +
                "HttpRecorderMode=Record;" +
                "Environment=Custom;" +
                "ResourceManagementUri=https://management.microsoftazure.de/;" +
                "ServiceManagementUri=https://management.core.cloudapi.de/;" +
                "GalleryUri=https://gallery.cloudapi.de/;" +
                "GraphUri=https://graph.cloudapi.de/;" +
                "AADAuthUri=https://login.microsoftonline.de/;" +
                "IbizaPortalUri=http://portal.microsoftazure.de/;" +
                "RdfePortalUri=https://management.core.cloudapi.de/;" +
                "GraphTokenAudienceUri=https://graph.cloudapi.de/;" +
                "AADTokenAudienceUri=https://management.core.cloudapi.de/"
            )]
        public void InteractiveLoginGermanCloud(string connStr)
        {
            // Log in for this test case using your alias
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string userId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.UserIdKey];
            Assert.EndsWith(".onmicrosoft.de", userId);
            Assert.False(string.IsNullOrEmpty(userId));
        }

        // Please update the connection string with the right information and then run the test, do not provide subscription Id
        [Theory(Skip = "Interactive Tests, needs to be run manually")]
        [InlineData("AADTenant=<valid German TenantId>;" +
                "HttpRecorderMode=Record;" +
                "Environment=Custom;" +
                "ResourceManagementUri=https://management.microsoftazure.de/;" +
                "ServiceManagementUri=https://management.core.cloudapi.de/;" +
                "GalleryUri=https://gallery.cloudapi.de/;" +
                "GraphUri=https://graph.cloudapi.de/;" +
                "AADAuthUri=https://login.microsoftonline.de/;" +
                "IbizaPortalUri=http://portal.microsoftazure.de/;" +
                "RdfePortalUri=https://management.core.cloudapi.de/;" +
                "GraphTokenAudienceUri=https://graph.cloudapi.de/;" +
                "AADTokenAudienceUri=https://management.core.cloudapi.de/"
            )]
        public void InteractiveGermanLoginNoSubscription(string connStr)
        {
            // Log in for this test case using your alias
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string subscriptionId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey];
            Assert.False(string.IsNullOrEmpty(subscriptionId));
        }
    }
}
#endif