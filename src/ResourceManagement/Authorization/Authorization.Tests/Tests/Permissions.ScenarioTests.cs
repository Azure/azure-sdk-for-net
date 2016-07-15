//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

        [Fact]
        public void GetResourcePermissions()
        {
            // NEXT environment variables used to record the mock

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context);
                var location = RESOURCE_TEST_LOCATION;

                client.ResourceGroups.CreateOrUpdate(groupName, 
                    new Microsoft.Azure.Management.Resources.Models.ResourceGroup { Location = location });

                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName,
                        "Microsoft.Web",
                        "",
                        "sites",
                        resourceName,
                        WEBSITE_RP_VERSION,
                    new Microsoft.Azure.Management.Resources.Models.GenericResource()
                    {
                        Location = location,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                var authzClient = GetAuthorizationManagementClient(context);

                var resourcePermissions = authzClient.Permissions.ListForResource(groupName,
                    "Microsoft.Web",
                    "",
                    "sites",
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
    }
}
