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

        [Fact]
        public void DefaultTenantInTestEnvironment()
        {
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=2c224e7e-57b-4662e3a6;ServicePrincipal=4c9b80e8e4-73383b4e;ServicePrincipalSecret=kzSjRsX8uQe7yZY=;Environment=Prod");
            HttpMockServer.Mode = HttpRecorderMode.Playback;
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
    }
}
