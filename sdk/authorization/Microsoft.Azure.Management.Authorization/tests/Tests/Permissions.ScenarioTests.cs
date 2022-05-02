// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;

namespace Authorization.Tests
{
    public class PermissionsTests : TestBase
    {
        const string RESOURCE_TEST_LOCATION = "westus";
        const string WEBSITE_RP_VERSION = "2014-04-01";
        public static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            var client = context.GetServiceClient<ResourceManagementClient>();
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        public PermissionsTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
        }

        public AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            var client = context.GetServiceClient<AuthorizationManagementClient>();
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void GetResourceGroupPermissions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var authzClient = GetAuthorizationManagementClient(context);

                var resourcePermissions = authzClient.Permissions.ListForResourceGroup("AzureAuthzSDK");

                Assert.NotNull(resourcePermissions);

                var permission = resourcePermissions.FirstOrDefault();
                Assert.NotNull(permission);
                Assert.NotNull(permission.Actions);
                Assert.Equal("*/read", permission.Actions[0]); // Even if the RG does not exist this is a valid result if you have */read at subscription level
            }
        }

        [Fact]
        public void GetNonExistentResourceGroupPermissions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var authzClient = GetAuthorizationManagementClient(context);

                var resourcePermissions = authzClient.Permissions.ListForResourceGroup("NonExistentResourceGroup");

                Assert.NotNull(resourcePermissions);

                var permission = resourcePermissions.FirstOrDefault();
                Assert.NotNull(permission);
                Assert.NotNull(permission.Actions);
                Assert.Equal("*/read", permission.Actions[0]); // Even if the RG does not exist this is a valid result if you have */read at subscription level
            }
        }

        [Fact]
        public void GetResourcePermissions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var authzClient = GetAuthorizationManagementClient(context);

                var permissions = authzClient.Permissions.ListForResource(
                    "AzureAuthzSDK",
                    "Microsoft.DataLakeAnalytics",
                    "",
                    "accounts",
                    "uiest"
                );

                Assert.NotNull(permissions);

                var permission = permissions.FirstOrDefault();
                Assert.NotNull(permission);
                Assert.NotNull(permission.Actions);
                Assert.Equal("*/read", permission.Actions[0]);
            }
        }

        [Fact]
        public void GetNonExistentResourcePermissions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceName = TestUtilities.GenerateName("csmr");
                var authzClient = GetAuthorizationManagementClient(context);

                try
                {
                    authzClient.Permissions.ListForResource(
                        "NonExistentResourceGroup",
                        "Microsoft.Web",
                        "",
                        "sites",
                        resourceName
                    );
                }
                catch (ErrorResponseException e)
                {
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }

        private static T GetValueFromTestContext<T>(Func<T> constructor, Func<string, T> parser, string mockName)
        {
            T retValue = default(T);

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                retValue = constructor.Invoke();
                HttpMockServer.Variables[mockName] = retValue.ToString();
            }
            else
            {
                if (HttpMockServer.Variables.ContainsKey(mockName))
                {
                    retValue = parser.Invoke(HttpMockServer.Variables[mockName]);
                }
            }

            return retValue;
        }
    }
}
