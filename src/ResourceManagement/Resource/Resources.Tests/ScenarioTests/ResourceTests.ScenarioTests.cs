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

using System.Collections.Generic;
using System.Net;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Hyak.Common.TransientFaultHandling;
using Microsoft.Azure.Test;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveResourceTests : TestBase
    {
        const string WebResourceProviderVersion = "2014-04-01";
        const string StoreResourceProviderVersion = "2014-04-01-preview";

        string ResourceGroupLocation
        {
            get { return "South Central US"; }
        }

        public static ResourceIdentity CreateResourceIdentity(GenericResourceExtended resource)
        {
            string[] parts = resource.Type.Split('/');
            return new ResourceIdentity { ResourceType = parts[1], ResourceProviderNamespace = parts[0], ResourceName = resource.Name, ResourceProviderApiVersion = WebResourceProviderVersion };
        }

        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClient().WithHandler(handler);
        }

        public string GetWebsiteLocation(ResourceManagementClient client)
        {
            return ResourcesManagementTestUtilities.GetResourceLocation(client, "Microsoft.Web/sites");
        }

        public string GetMySqlLocation(ResourceManagementClient client)
        {
            return ResourcesManagementTestUtilities.GetResourceLocation(client, "SuccessBricks.ClearDB/databases");
        }

        [Fact]
        public void CleanupAllResources()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                var groups = client.ResourceGroups.List(null);
                foreach (var group in groups.ResourceGroups)
                {
                    TracingAdapter.Information("Deleting resources for RG {0}", group.Name);
                    var resources = client.Resources.List(new ResourceListParameters { ResourceGroupName = group.Name, ResourceType = "Microsoft.Web/sites" });
                    foreach (var resource in resources.Resources)
                    {
                        var response = client.Resources.Delete(group.Name, CreateResourceIdentity(resource));
                    }
                    var groupResponse = client.ResourceGroups.BeginDeleting(group.Name);
                }
            }

        }

        [Fact]
        public void CreateResourceWithPlan()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {

                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(handler);
                string mySqlLocation = GetMySqlLocation(client);
                var groupIdentity = new ResourceIdentity
                    {
                        ResourceName = resourceName,
                        ResourceProviderNamespace = "SuccessBricks.ClearDB",
                        ResourceType = "databases",
                        ResourceProviderApiVersion = StoreResourceProviderVersion
                    };

                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, groupIdentity,
                    new GenericResource
                    {
                        Location = mySqlLocation,
                        Plan = new Plan {Name = "Free"},
                        Tags = new Dictionary<string, string> { { "provision_source", "RMS" } }
                    }
                );

                Assert.Equal(HttpStatusCode.OK, createOrUpdateResult.StatusCode);
                Assert.Equal(resourceName, createOrUpdateResult.Resource.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(mySqlLocation, createOrUpdateResult.Resource.Location),
                    string.Format("Resource location for resource '{0}' does not match expected location '{1}'", createOrUpdateResult.Resource.Location, mySqlLocation));
                Assert.NotNull(createOrUpdateResult.Resource.Plan);
                Assert.Equal("Free", createOrUpdateResult.Resource.Plan.Name);

                var getResult = client.Resources.Get(groupName, groupIdentity);

                Assert.Equal(HttpStatusCode.OK, getResult.StatusCode);
                Assert.Equal(resourceName, getResult.Resource.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(mySqlLocation, getResult.Resource.Location),
                    string.Format("Resource location for resource '{0}' does not match expected location '{1}'", getResult.Resource.Location, mySqlLocation));
                Assert.NotNull(getResult.Resource.Plan);
                Assert.Equal("Free", getResult.Resource.Plan.Name);
            }
        }

        [Fact]
        public void CreatedResourceIsAvailableInList()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {

                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(handler);
                string websiteLocation = "westus";

                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, new ResourceIdentity
                    {
                        ResourceName = resourceName,
                        ResourceProviderNamespace = "Microsoft.Web",
                        ResourceType = "sites",
                        ResourceProviderApiVersion = WebResourceProviderVersion
                    },
                    new GenericResource
                    {
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}",
                    }
                );

                Assert.Equal(HttpStatusCode.OK, createOrUpdateResult.StatusCode);
                Assert.NotNull(createOrUpdateResult.Resource.Id);
                Assert.Equal(resourceName, createOrUpdateResult.Resource.Name);
                Assert.Equal("Microsoft.Web/sites", createOrUpdateResult.Resource.Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, createOrUpdateResult.Resource.Location),
                    string.Format("Resource location for website '{0}' does not match expected location '{1}'", createOrUpdateResult.Resource.Location, websiteLocation));

                var listResult = client.Resources.List(new ResourceListParameters
                    {
                        ResourceGroupName = groupName
                    });

                Assert.Equal(1, listResult.Resources.Count);
                Assert.Equal(resourceName, listResult.Resources[0].Name);
                Assert.Equal("Microsoft.Web/sites", listResult.Resources[0].Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, listResult.Resources[0].Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.Resources[0].Location, websiteLocation));

                listResult = client.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = groupName,
                    Top = 10
                });

                Assert.Equal(1, listResult.Resources.Count);
                Assert.Equal(resourceName, listResult.Resources[0].Name);
                Assert.Equal("Microsoft.Web/sites", listResult.Resources[0].Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, listResult.Resources[0].Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.Resources[0].Location, websiteLocation));
            }
        }

        [Fact]
        public void CreatedResourceIsAvailableInListFilteredByTagName()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {

                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                string resourceNameNoTags = TestUtilities.GenerateName("csmr");
                string tagName = TestUtilities.GenerateName("csmtn");
                var client = GetResourceManagementClient(handler);
                string websiteLocation = "westus";

                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                client.Resources.CreateOrUpdate(groupName, new ResourceIdentity
                {
                    ResourceName = resourceName,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                },
                    new GenericResource
                    {
                        Tags = new Dictionary<string, string> { { tagName, "" } },
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );
                client.Resources.CreateOrUpdate(groupName, new ResourceIdentity
                {
                    ResourceName = resourceNameNoTags,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                },
                    new GenericResource
                    {
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceNameNoTags + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                var listResult = client.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = groupName,
                    TagName = tagName
                });

                Assert.Equal(1, listResult.Resources.Count);
                Assert.Equal(resourceName, listResult.Resources[0].Name);

                var getResult = client.Resources.Get(groupName, new ResourceIdentity
                {
                    ResourceName = resourceName,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                });

                Assert.Equal(resourceName, getResult.Resource.Name);
                Assert.True(getResult.Resource.Tags.Keys.Contains(tagName));
            }
        }

        [Fact]
        public void CreatedResourceIsAvailableInListFilteredByTagNameAndValue()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {

                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                string resourceNameNoTags = TestUtilities.GenerateName("csmr");
                string tagName = TestUtilities.GenerateName("csmtn");
                string tagValue = TestUtilities.GenerateName("csmtv");
                var client = GetResourceManagementClient(handler);
                string websiteLocation = "westus";

                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                client.Resources.CreateOrUpdate(groupName, new ResourceIdentity
                {
                    ResourceName = resourceName,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                },
                    new GenericResource
                    {
                        Tags = new Dictionary<string, string> { { tagName, tagValue } },
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );
                client.Resources.CreateOrUpdate(groupName, new ResourceIdentity
                {
                    ResourceName = resourceNameNoTags,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                },
                    new GenericResource
                    {
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceNameNoTags + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                var listResult = client.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = groupName,
                    TagName = tagName,
                    TagValue = tagValue
                });

                Assert.Equal(1, listResult.Resources.Count);
                Assert.Equal(resourceName, listResult.Resources[0].Name);

                var getResult = client.Resources.Get(groupName, new ResourceIdentity
                {
                    ResourceName = resourceName,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                });

                Assert.Equal(resourceName, getResult.Resource.Name);
                Assert.True(getResult.Resource.Tags.Keys.Contains(tagName));
            }
        }

        [Fact]
        public void CreatedAndDeleteResource()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(handler);

                client.SetRetryPolicy(new RetryPolicy<DefaultHttpErrorDetectionStrategy>(1));
                string location = "westus";
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = location });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, new ResourceIdentity
                {
                    ResourceName = resourceName,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                },
                new GenericResource
                    {
                        Location = location,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                Assert.Equal(HttpStatusCode.OK, createOrUpdateResult.StatusCode);

                var listResult = client.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = groupName
                });

                Assert.Equal(resourceName, listResult.Resources[0].Name);

                var deleteResult = client.Resources.Delete(groupName, new ResourceIdentity
                    {
                        ResourceName = resourceName,
                        ResourceProviderNamespace = "Microsoft.Web",
                        ResourceType = "sites",
                        ResourceProviderApiVersion = WebResourceProviderVersion
                    });

                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
            }
        }

        [Fact]
        public void CreatedAndListResource()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(handler);
                string location = "westus";
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = location });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, new ResourceIdentity
                {
                    ResourceName = resourceName,
                    ResourceProviderNamespace = "Microsoft.Web",
                    ResourceType = "sites",
                    ResourceProviderApiVersion = WebResourceProviderVersion
                },
                new GenericResource
                    {
                        Location = location,
                        Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                Assert.Equal(HttpStatusCode.OK, createOrUpdateResult.StatusCode);

                var listResult = client.Resources.List(new ResourceListParameters
                    {
                        ResourceType = "Microsoft.Web/sites"
                    });

                Assert.NotEmpty(listResult.Resources);
                Assert.Equal(2, listResult.Resources[0].Tags.Count);
            }
        }
    }
}
