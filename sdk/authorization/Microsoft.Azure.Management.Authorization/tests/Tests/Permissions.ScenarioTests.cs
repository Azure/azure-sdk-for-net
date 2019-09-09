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
                string groupName = TestUtilities.GenerateName("csmrg");
                var resourceClient = GetResourceManagementClient(context);
                var authzClient = GetAuthorizationManagementClient(context);

                resourceClient.ResourceGroups.CreateOrUpdate(groupName, new Microsoft.Azure.Management.Resources.Models.ResourceGroup
                { Location = RESOURCE_TEST_LOCATION });
                var resourcePermissions = authzClient.Permissions
                    .ListForResourceGroupWithHttpMessagesAsync(groupName)
                    .ConfigureAwait(false).GetAwaiter().GetResult();

                Assert.NotNull(resourcePermissions);
                Assert.Equal(HttpStatusCode.OK, resourcePermissions.Response.StatusCode);
                var permissions = ((IPage<Permission>)resourcePermissions.Body);
                Assert.NotNull(permissions);
                var permission = permissions.FirstOrDefault();
                Assert.NotNull(permission);
                Assert.NotNull(permission.Actions);
                Assert.NotNull(permission.NotActions);
                Assert.Equal("*", permission.Actions[0]);
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
                Assert.Equal("*", permission.Actions[0]);
            }
        }

        // Test fails when running with SPN auth method in Record mode
        [Fact]
        public void GetResourcePermissions()
        {
            // NEXT environment variables used to record the mock

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "resourceId").ToString();
                var client = GetResourceManagementClient(context);
                var location = RESOURCE_TEST_LOCATION;

                client.ResourceGroups.CreateOrUpdate(groupName,
                    new Microsoft.Azure.Management.Resources.Models.ResourceGroup { Location = location });

                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName,
                        "Microsoft.Authorization",
                        "",
                        "roleAssignments",
                        resourceName,
                        "2017-09-01",
                    new Microsoft.Azure.Management.Resources.Models.GenericResource()
                    {
                        Location = location,
                        Properties = JObject.Parse("{'roleDefinitionId':'/subscriptions/4004a9fd-d58e-48dc-aeb2-4a4aec58606f/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7','principalId':'f8d526a0-54eb-4941-ae69-ebf4a334d0f0'}")
                    }
                );

                var authzClient = GetAuthorizationManagementClient(context);

                var resourcePermissions = authzClient.Permissions.ListForResource(groupName,
                    "Microsoft.Authorization",
                    "",
                    "roleAssignments",
                    resourceName
                );

                Assert.NotNull(resourcePermissions);
                var permission = resourcePermissions.FirstOrDefault();
                Assert.NotNull(permission);
                Assert.NotNull(permission.Actions);
                Assert.NotNull(permission.NotActions);
                Assert.Equal("*", permission.Actions[0]);
            }
        }

        [Fact]
        public void GetNonExistentResourcePermissions()
        {
            // NEXT environment variables used to record the mock

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
                catch (CloudException ce)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ce.Response.StatusCode);
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
