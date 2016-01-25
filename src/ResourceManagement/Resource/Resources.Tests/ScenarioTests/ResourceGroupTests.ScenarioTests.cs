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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Hyak.Common.TransientFaultHandling;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;

namespace ResourceGroups.Tests
{
    public class LiveResourceGroupTests : TestBase
    {
        const string DefaultLocation = "South Central US";

        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetResourceManagementClient();
            client = client.WithHandler(handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void DeleteResourceGroupRemovesGroupResources()
        {
            TestUtilities.StartTest();
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            var client = GetResourceManagementClient(handler);
            string location = "westus";
            var resourceGroupName = TestUtilities.GenerateName("csmrg");
            var resourceName = TestUtilities.GenerateName("csmr");
            var createResult = client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var createResourceResult = client.Resources.CreateOrUpdate(resourceGroupName, new ResourceIdentity
                {
                    ResourceName = resourceName,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = "2014-04-01"
                },
                new GenericResource
                    {
                        Location = location,
                        Properties = "{'name':'" + resourceName + "','siteMode': 'Standard','computeMode':'Shared'}"
                    });
            var deleteResult = client.ResourceGroups.Delete(resourceGroupName);
            var listGroupsResult = client.ResourceGroups.List(null);

            Assert.Throws<CloudException>(() => client.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = resourceGroupName
                }));

            Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
            Assert.False(listGroupsResult.ResourceGroups.Any(rg => rg.Name == resourceGroupName));
            TestUtilities.EndTest();
        }

        [Fact]
        public void CanCreateResourceGroup()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                ResourceManagementClient client = this.GetResourceManagementClient(new RecordedDelegatingHandler());
                ResourceGroupCreateOrUpdateResult result = client.ResourceGroups.CreateOrUpdate(groupName, 
                    new ResourceGroup
                        {
                            Location = DefaultLocation,
                            Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                        });
                var listResult = client.ResourceGroups.List(new ResourceGroupListParameters());
                var listedGroup = listResult.ResourceGroups.FirstOrDefault((g) => string.Equals(g.Name, groupName, StringComparison.Ordinal));
                Assert.NotNull(listedGroup);
                Assert.Equal("finance", listedGroup.Tags["department"]);
                Assert.Equal("tagvalue", listedGroup.Tags["tagname"]);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(DefaultLocation, listedGroup.Location),
                   string.Format("Expected location '{0}' did not match actual location '{1}'", DefaultLocation, listedGroup.Location));
                var gottenGroup = client.ResourceGroups.Get(groupName);
                Assert.NotNull(gottenGroup);
                Assert.Equal<string>(groupName, gottenGroup.ResourceGroup.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(DefaultLocation, gottenGroup.ResourceGroup.Location),
                    string.Format("Expected location '{0}' did not match actual location '{1}'", DefaultLocation, gottenGroup.ResourceGroup.Location));
            }
        }

        [Fact]
        public void CheckExistenceReturnsCorrectValue()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                var client = GetResourceManagementClient(handler);
                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                var checkExistenceFirst = client.ResourceGroups.CheckExistence(groupName);
                Assert.False(checkExistenceFirst.Exists);

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = DefaultLocation });

                var checkExistenceSecond = client.ResourceGroups.CheckExistence(groupName);

                Assert.True(checkExistenceSecond.Exists);
            }
        }

        [Fact(Skip = "Not yet implemented.")]
        public void ListResourceGroupsWithTagNameFilter()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string tagName = TestUtilities.GenerateName("csmtn");
                var client = GetResourceManagementClient(handler);

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup
                    {
                        Location = DefaultLocation,
                        Tags = new Dictionary<string, string> { { tagName, "" } }
                    });

                var listResult = client.ResourceGroups.List(new ResourceGroupListParameters
                    {
                        TagName = tagName
                    });

                foreach (var group in listResult.ResourceGroups)
                {
                    Assert.True(group.Tags.Keys.Contains(tagName));
                }
            }
        }

        [Fact(Skip = "Not yet implemented.")]
        public void ListResourceGroupsWithTagNameAndValueFilter()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string tagName = TestUtilities.GenerateName("csmtn");
                string tagValue = TestUtilities.GenerateName("csmtv");
                var client = GetResourceManagementClient(handler);

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup
                {
                    Location = DefaultLocation,
                    Tags = new Dictionary<string, string> { { tagName, tagValue } }
                });

                var listResult = client.ResourceGroups.List(new ResourceGroupListParameters
                {
                    TagName = tagName,
                    TagValue = tagValue
                });

                foreach (var group in listResult.ResourceGroups)
                {
                    Assert.True(group.Tags.Keys.Contains(tagName));
                    Assert.Equal(tagValue, group.Tags[tagName]);
                }
            }
        }

        [Fact]
        public void DeleteResourceGroupRemovesGroup()
        {
            TestUtilities.StartTest();
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            var client = GetResourceManagementClient(handler);

            var resourceGroupName = TestUtilities.GenerateName("csmrg");
            var createResult = client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = DefaultLocation });
            var getResult = client.ResourceGroups.Get(resourceGroupName);
            var deleteResult = client.ResourceGroups.Delete(resourceGroupName);
            var listResult = client.ResourceGroups.List(null);

            Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
            Assert.False(listResult.ResourceGroups.Any(rg => rg.Name == resourceGroupName && rg.ProvisioningState != ProvisioningState.Deleting));
            TestUtilities.EndTest();
        }
    }
}
