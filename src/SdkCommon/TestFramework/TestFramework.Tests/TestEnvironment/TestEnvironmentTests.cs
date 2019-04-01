// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace TestFramework.Tests.TestEnvironment
{
    using Xunit;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using Microsoft.Azure.Test.HttpRecorder;

    public class TestEnvironmentTests
    {
        [Fact]
        public void EmptyTestEnvironment()
        {
            TestEnvironment env = new TestEnvironment();
            Assert.Equal<int>(5, env.EnvEndpoints.Count);
        }

        [Fact(Skip ="Live Test")]
        public void DefaultTenantInTestEnvironment()
        {
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "<connstr>");
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.AADTenantKey];
            Assert.False(string.IsNullOrEmpty(tenantId));
            Assert.Equal<string>("72f988bf-86f1-41af-91ab-2d7cd011db47", tenantId);
        }

        [Fact]
        public void LoadCustomEnvironment()
        {
            string cnnStr = @"SubscriptionId=18b0dcf-550319fa5eac;" +
                "AADTenant=72f988bf-2d7cd011db47;" +
                "HttpRecorderMode=Playback;" +
                "Environment=Custom;" +
                "ResourceManagementUri=https://brazilus.management.azure.com/;" +
                "ServiceManagementUri=https://brazilus.management.azure.com/";

            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", cnnStr);
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string resMgrUri = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.ResourceManagementUriKey];
            string SvcMgrUri = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServiceManagementUriKey];
            string ibizaUri = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.IbizaPortalUriKey];

            Assert.Equal<string>("https://brazilus.management.azure.com/", resMgrUri);
            Assert.Equal<string>("https://brazilus.management.azure.com/", SvcMgrUri);
            Assert.Equal<string>("", ibizaUri);
        }

        [Theory]
        [InlineData("SubscriptionId=18b0dcf-550319fa5eac;" +
                "AADTenant=72f988bf-2d7cd011db47;" +
                "HttpRecorderMode=Playback;" +
                "Environment=Prod;" +
                "ResourceManagementUri=https://brazilus.management.azure.com/;" +
                "ServiceManagementUri=https://brazilus.management.azure.com/")]

        public void UpdateExistingEnvironmentUri(string connStr)
        {
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string resMgrUri = env.Endpoints.ResourceManagementUri.AbsoluteUri;
            string SvcMgrUri = env.Endpoints.ServiceManagementUri.AbsoluteUri;
            string ibizaUri = env.Endpoints.IbizaPortalUri.AbsoluteUri;

            Assert.Equal<string>("https://brazilus.management.azure.com/", resMgrUri);
            Assert.Equal<string>("https://brazilus.management.azure.com/", SvcMgrUri);
            Assert.Equal<string>("https://portal.azure.com/", ibizaUri);
        }

        [Theory(Skip = "Interactive Test")]
        [InlineData("SubscriptionId=<subId>;RawToken=<rawToken.by2BGzn_-fzC4K-JWNRdG56MEBQtb1dGwxIeYY5jn_YgetUkkBR-jn8xjZQr_8-qAJ1ZwOlPdFAgvYsiw72Be7iBzo_9NTyJTUw4cGgSFI9Rtqx4IYGvJ_CcPpQWU4c1YFMqkUopU8I9eAOxtmcCpTx82Zq1uiWaVL62gdzBBC9I6WjOONSPoLVnK0LU5VmuZuS86efmdEpVhJ95llwAqAgoeFHeCx4ZJmj5y1ncOaSeQWHTfj5ovfPTMKGsWGWlbkbYDAzF0LBFo7Cau2wfkZf9nFmc9mcH05SPOnmQUwijpZSQ2CAXqK4f0EJnXI2ZenoNGfDYXQ>")]
        //[InlineData("SubscriptionId=<subId>;AADTenant=<tenantId>;UserId=<uid.onmicrosoft.com;Password=<pwd>")]
        public void LoginUsingRawToken(string connStr)
        {
            // Use the commented out InlineData to get RawToken by first logging in using the username/password. Once you get the RawToken, then use the other
            // Inline data connection string to inject your raw token to run this test.
            // We use the subscription Id to verify if the RawToken can get the subscription information and hence verifies if the RawToken can be used for Auth purpose

            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connStr);
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string subscriptionId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey];
            Assert.False(string.IsNullOrEmpty(subscriptionId));
        }
    }
}
