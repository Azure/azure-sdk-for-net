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

using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using System.Net;
using Xunit;

namespace Authorization.Tests
{
    public class PermissionsTests : TestBase
    {
        const string RESOURCE_TEST_LOCATION = "westus"; 
        const string WEBSITE_RP_VERSION = "2014-04-01";

        public ResourceManagementClient GetResourceManagementClient()
        {
            var client = TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory()); 
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        public AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            var client = TestBase.GetServiceClient<AuthorizationManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void GetResourceGroupPermissions()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                var resourceClient = GetResourceManagementClient();
                var authzClient = GetAuthorizationManagementClient();

                resourceClient.ResourceGroups.CreateOrUpdate(groupName, new Microsoft.Azure.Management.Resources.Models.ResourceGroup
                    { Location = RESOURCE_TEST_LOCATION });
                var resourcePermissions = authzClient.Permissions.ListForResourceGroup(groupName);

                Assert.NotNull(resourcePermissions);
                Assert.Equal(HttpStatusCode.OK, resourcePermissions.StatusCode);
                Assert.NotNull(resourcePermissions.Permissions);
                Assert.NotNull(resourcePermissions.Permissions[0]);
                Assert.NotNull(resourcePermissions.Permissions[0].Actions);
                Assert.NotNull(resourcePermissions.Permissions[0].NotActions);
                Assert.Equal("*", resourcePermissions.Permissions[0].Actions[0]);
            }
        }

        [Fact]
        public void GetNonExistentResourceGroupPermissions()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var authzClient = GetAuthorizationManagementClient();

                var resourcePermissions = authzClient.Permissions.ListForResourceGroup("NonExistentResourceGroup");

                Assert.NotNull(resourcePermissions);
                Assert.Equal(HttpStatusCode.OK, resourcePermissions.StatusCode);
                Assert.NotNull(resourcePermissions.Permissions);
                Assert.NotNull(resourcePermissions.Permissions[0]);
                Assert.NotNull(resourcePermissions.Permissions[0].Actions);
                Assert.Equal("*", resourcePermissions.Permissions[0].Actions[0]);
            }
        }

        [Fact]
        public void GetResourcePermissions()
        {
            // NEXT environment variables used to record the mock

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient();
                var location = RESOURCE_TEST_LOCATION;

                client.ResourceGroups.CreateOrUpdate(groupName, 
                    new Microsoft.Azure.Management.Resources.Models.ResourceGroup { Location = location });

                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName,
                    new ResourceIdentity
                    {
                        ResourceName = resourceName,
                        ResourceProviderNamespace = "Microsoft.Web",
                        ResourceType = "sites",
                        ResourceProviderApiVersion = WEBSITE_RP_VERSION
                    },
                    new Microsoft.Azure.Management.Resources.Models.GenericResource()
                    {
                        Location = location,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                var authzClient = GetAuthorizationManagementClient();

                var resourcePermissions = authzClient.Permissions.ListForResource(groupName, 
                    new ResourceIdentity
                    {
                        ResourceName = resourceName,
                        ResourceProviderNamespace = "Microsoft.Web",
                        ResourceType = "sites",
                    }
                );

                Assert.NotNull(resourcePermissions);
                Assert.Equal(HttpStatusCode.OK, resourcePermissions.StatusCode);
                Assert.NotNull(resourcePermissions.Permissions);
                Assert.NotNull(resourcePermissions.Permissions[0]);
                Assert.NotNull(resourcePermissions.Permissions[0].Actions);
                Assert.NotNull(resourcePermissions.Permissions[0].NotActions);
                Assert.Equal("*", resourcePermissions.Permissions[0].Actions[0]);
            }
        }

        [Fact]
        public void GetNonExistentResourcePermissions()
        {
            // NEXT environment variables used to record the mock

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string resourceName = TestUtilities.GenerateName("csmr");
                var authzClient = GetAuthorizationManagementClient();

                try
                {
                    authzClient.Permissions.ListForResource(
                        "NonExistentResourceGroup",
                        new ResourceIdentity
                        {
                            ResourceName = resourceName,
                            ResourceProviderNamespace = "Microsoft.Web",
                            ResourceType = "sites",
                        });
                }
                catch (CloudException ce)
                {
                    Assert.Equal("ResourceGroupNotFound", ce.Error.Code);
                }
            }
        }
    }
}
