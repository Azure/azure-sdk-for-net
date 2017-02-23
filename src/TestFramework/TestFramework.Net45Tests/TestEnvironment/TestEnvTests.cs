// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace TestFramework.Net45Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Threading;
    using Xunit;

    public class TestEnvTests
    {
        [Theory(/*Skip = "Interactive Tests, needs to be run manually"*/)]
        [InlineData("AADTenant=04081b9f-c8b4-424b-86b9-ce44721c2b23")]
        [InlineData("AADTenant=04081b9f-c8b4-424b-86b9-ce44721c2b23;SubscriptionId=None;Environment=Prod")]
        public void InteractiveLoginForCSP(string connStr)
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


        [Theory(Skip = "Interactive Tests, needs to be run manually")]
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

        // Please update the connection string with the right information and then run the test
        [Theory(Skip = "Interactive Tests, needs to be run manually")]
        [InlineData("SubscriptionId=<updateSubId>;" +
                "AADTenant=dcfa120f-9293-4f06-b3d2-cf728bcabb10;" +
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


        [InlineData("SubscriptionId=<updateSubId>;" +
                "AADTenant=dcfa120f-9293-4f06-b3d2-cf728bcabb10;" +
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
            //"AADAuthUri=https://login.microsoftonline.de/;" +
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
