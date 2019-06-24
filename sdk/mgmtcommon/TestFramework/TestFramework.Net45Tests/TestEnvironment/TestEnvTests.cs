// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace TestFramework.Net45Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using Xunit;

    public class TestEnvTests
    {
        const string ENV_VARIABLE_NAME = "TEST_CSM_ORGID_AUTHENTICATION";

        [Theory(Skip = "Interactive Tests, needs to be run manually")]
        [InlineData("AADTenant=<GetCSPtenantId>")]
        [InlineData("AADTenant=<GetCSPtenantId>;SubscriptionId=None;Environment=Prod")] //Test this with None as the SubId
        public void InteractiveLoginForCSP(string connStr)
        {
            // Use this test case to set connection string without username and password, which will prompt you to enter UserName and password
            // use CSP username/pwd that we have. This account has no subscription associated, hence throws exception.
            // TestEnv checks if the logged in user has the subscription that is provided in the connection string
            Environment.SetEnvironmentVariable(ENV_VARIABLE_NAME, connStr);
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
        [InlineData(@"AADTenant=<GetMsftTenantId>;SubscriptionId=<GetAnySubIdUnderYourAlias>;Environment=Prod;")]
        public void InteractiveLoginKnownUserName(string connStr)
        {
            // Log in for this test case using your alias
            // the idea is to initiate auth even on 2FA tenant (in this case msft)
            // have a valid tenant id and subscription your alias has access to.
            Environment.SetEnvironmentVariable(ENV_VARIABLE_NAME, connStr);
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
            Environment.SetEnvironmentVariable(ENV_VARIABLE_NAME, connStr);
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
            Environment.SetEnvironmentVariable(ENV_VARIABLE_NAME, connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string subscriptionId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey];
            Assert.False(string.IsNullOrEmpty(subscriptionId));
        }

        [Theory(Skip = "Interactive Test")]
        [InlineData("SubscriptionId=<subId>;RawToken=<rawToken_ciOiJSUzI1NiIsIng1dCI6InowMzl6ZHNGdWl6cEJmQlZLMVRuMjVRSFciOiJSUzI1NiIsIng1dCWl6cEJmQlZLMVRuMjVRSFlPMCJ9.1hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC81NDgyNmIyMi0zOGQ2LTRmYjItYmFkOS1iN2I5M2EzZTljNWEvIiwiaWF0IjoxNDk1NTY4NDcyLCJuYmYiOjE0OTU1Njg0NzIsImV4cCI6MTQ5NTU3MjM3MiwiYWNyIjoiMSIsImFpbyI6IlkyWmdZSERKVEJBNEVwZTJjZnNqcVEwWmRuZjkvcktMMXNZdzhSOXk4bFBXV2FhVWZ3Z0EiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiMTk1MGEyNTgtMjI3Yi00ZTMxLWE5Y2YtNzE3NDk1OTQ1ZmMyIiwiYXBwaWRhY3IiOiIwIiwiZV9leHAiOjI2MjgwMCwiZ2l2ZW5fbmFtZSI6IkFkbWluIiwiZ3JvdXBzIjpbImU0YmIwYjU2LTEwMTQtNDBmOC04OGFiLTNkOGE4Y2IwZTA4NiIsImQ3NThhMDY5LTUyY2MtNDdmNi1iYzAwLTk2MWNlYTE3YmUzOSJdLCJpcGFkZHIiOiIxNjcuMjIwLjEuMTM4IiwibmFtZSI6IkFkbWluIiwib2lkIjoiN2E5MzhhMzAtNDIyNi00MjBlLTk5NmYtNGQ0OGJjYTZkNTM3IiwicGxhdGYiOiIzIiwicHVpZCI6IjEwMDMzRkZGOTU5NzY4MzEiLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiJaaXFkNnA1OVNPQlJMbzdXalotaERHcUM2YVJhbDhpY1NFb2t0dGZsMmljIiwidGlkIjoiNTQ4MjZiMjItMzhkNi00ZmIyLWJhZDktYjdiOTNhM2U5YzVhIiwidW5pcXVlX25hbWUiOiJhZG1pbkBBenVyZVNES1RlYW0ub25taWNyb3NvZnQuY29tIiwidXBuIjoiYWRtaW5AQXp1cmVTREtUZWFtLm9ubWljcm9zb2Z0LmNvbSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIl19.Eb_YXz_mY3Mcec04sTsvT7-wvmQuJlHibTDr7wlrj__8riP3FNXiRi_tb0yGWVQkKCkGwJHTrBPi1aD2Gd_3j542OlgOJ4ETb2Gr_froo44eCHv1Z-84h3s9v_K6A-aaNbRC4NOZIbd2dqJJ6CDcVu_ow6hPzhTo1_VNkZ5OygBUii-yKizRcFPGbiVlj2IbOMFA9TN9NtPm8lVPI8hjbEpeXWqFVPuPiJUpkn3XXKrgpNZTsy-o_TG4GcP2ETnyPS0gYTJHQRC-11vIx0DRXMSF_q1H7hdcj174jL6WveZellXrD6e39iNuTToHTY>")]
        //[InlineData("SubscriptionId=<subId>;AADTenant=<tenantId>;UserId=<uid.onmicrosoft.com;Password=<pwd>")]
        public void LoginUsingRawToken(string connStr)
        {
            // Use the commented out InlineData to get RawToken by first logging in using the username/password. Once you get the RawToken, then use the other
            // Inline data connection string to inject your raw token to run this test.
            // We use the subscription Id to verify if the RawToken can get the subscription information and hence verifies if the RawToken can be used for Auth purpose

            Environment.SetEnvironmentVariable(ENV_VARIABLE_NAME, connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string subscriptionId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey];
            Assert.False(string.IsNullOrEmpty(subscriptionId));
        }


        [Theory(Skip = "Interactive Test")]
        //[Theory]
        [InlineData("<ConnectionString>")]
        //[InlineData("SubscriptionId=<subId>;AADTenant=<tenantId>;UserId=<uid.onmicrosoft.com;Password=<pwd>")]
        public void AdHocAuthTest(string connStr)
        {
            // Use the commented out InlineData to get RawToken by first logging in using the username/password. Once you get the RawToken, then use the other
            // Inline data connection string to inject your raw token to run this test.
            // We use the subscription Id to verify if the RawToken can get the subscription information and hence verifies if the RawToken can be used for Auth purpose

            Environment.SetEnvironmentVariable(ENV_VARIABLE_NAME, connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string subscriptionId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey];
            Assert.False(string.IsNullOrEmpty(subscriptionId));
        }
    }
}
