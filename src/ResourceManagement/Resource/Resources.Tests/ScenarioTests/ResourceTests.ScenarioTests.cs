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
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.TransientFaultHandling;
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

        public static ResourceIdentity CreateResourceIdentity(GenericResource resource)
        {
            string[] parts = resource.Type.Split('/');
            return new ResourceIdentity { ResourceType = parts[1], ResourceProviderNamespace = parts[0], ResourceName = resource.Name, ResourceProviderApiVersion = WebResourceProviderVersion };
        }

        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClientWithHandler(handler);
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
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var groups = client.ResourceGroups.List();
                foreach (var group in groups.Value)
                {
                    var resources = client.ResourceGroups.ListResources(group.Name, r => r.ResourceType == "Microsoft.Web/sites");
                    foreach (var resource in resources.Value)
                    {
                        client.Resources.Delete(group.Name, 
                            CreateResourceIdentity(resource).ResourceProviderNamespace, 
                            string.Empty,
                            CreateResourceIdentity(resource).ResourceType,
                            resource.Name,
                            CreateResourceIdentity(resource).ResourceProviderApiVersion);
                    }
                    client.ResourceGroups.BeginDelete(group.Name);
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

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, groupIdentity.ResourceProviderNamespace, "", groupIdentity.ResourceType, 
                    groupIdentity.ResourceName, groupIdentity.ResourceProviderApiVersion, 
                    new GenericResource
                    {
                        Location = mySqlLocation,
                        Plan = new Plan {Name = "Free"},
                        Tags = new Dictionary<string, string> { { "provision_source", "RMS" } }
                    }
                );

                Assert.Equal(resourceName, createOrUpdateResult.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(mySqlLocation, createOrUpdateResult.Location),
                    string.Format("Resource location for resource '{0}' does not match expected location '{1}'", createOrUpdateResult.Location, mySqlLocation));
                Assert.NotNull(createOrUpdateResult.Plan);
                Assert.Equal("Mercury", createOrUpdateResult.Plan.Name);

                var getResult = client.Resources.Get(groupName, groupIdentity.ResourceProviderNamespace,
                    "", groupIdentity.ResourceType, groupIdentity.ResourceName, groupIdentity.ResourceProviderApiVersion);

                Assert.Equal(resourceName, getResult.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(mySqlLocation, getResult.Location),
                    string.Format("Resource location for resource '{0}' does not match expected location '{1}'", getResult.Location, mySqlLocation));
                Assert.NotNull(getResult.Plan);
                Assert.Equal("Mercury", getResult.Plan.Name);
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
                string websiteLocation = GetWebsiteLocation(client);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, "Microsoft.Web", "", "sites",resourceName, WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}",
                    }
                );

                Assert.NotNull(createOrUpdateResult.Id);
                Assert.Equal(resourceName, createOrUpdateResult.Name);
                Assert.Equal("Microsoft.Web/sites", createOrUpdateResult.Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, createOrUpdateResult.Location),
                    string.Format("Resource location for website '{0}' does not match expected location '{1}'", createOrUpdateResult.Location, websiteLocation));

                var listResult = client.ResourceGroups.ListResources(groupName);

                Assert.Equal(1, listResult.Value.Count);
                Assert.Equal(resourceName, listResult.Value[0].Name);
                Assert.Equal("Microsoft.Web/sites", listResult.Value[0].Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, listResult.Value[0].Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.Value[0].Location, websiteLocation));

                listResult = client.ResourceGroups.ListResources(groupName, top: 10);

                Assert.Equal(1, listResult.Value.Count);
                Assert.Equal(resourceName, listResult.Value[0].Name);
                Assert.Equal("Microsoft.Web/sites", listResult.Value[0].Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, listResult.Value[0].Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.Value[0].Location, websiteLocation));
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
                string websiteLocation = GetWebsiteLocation(client);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    string.Empty,
                    "sites",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Tags = new Dictionary<string, string> { { tagName, "" } },
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    });
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    string.Empty,
                    "sites",
                    resourceNameNoTags,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceNameNoTags + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    });

                var listResult = client.ResourceGroups.ListResources(groupName, r => r.Tagname == tagName);

                Assert.Equal(1, listResult.Value.Count);
                Assert.Equal(resourceName, listResult.Value[0].Name);

                var getResult = client.Resources.Get(
                    groupName,
                    "Microsoft.Web",
                    string.Empty,
                    "sites",
                    resourceName,
                    WebResourceProviderVersion);

                Assert.Equal(resourceName, getResult.Name);
                Assert.True(getResult.Tags.Keys.Contains(tagName));
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
                string websiteLocation = GetWebsiteLocation(client);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "sites",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Tags = new Dictionary<string, string> { { tagName, tagValue } },
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "sites", 
                    resourceNameNoTags,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = websiteLocation,
                        Properties = "{'name':'" + resourceNameNoTags + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                var listResult = client.ResourceGroups.ListResources(groupName, 
                    r => r.Tagname == tagName && r.Tagvalue == tagValue);

                Assert.Equal(1, listResult.Value.Count);
                Assert.Equal(resourceName, listResult.Value[0].Name);

                var getResult = client.Resources.Get(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "sites",
                    resourceName,
                    WebResourceProviderVersion);

                Assert.Equal(resourceName, getResult.Name);
                Assert.True(getResult.Tags.Keys.Contains(tagName));
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

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));
                string location = this.GetWebsiteLocation(client);
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = location });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "sites",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                var listResult = client.ResourceGroups.ListResources(groupName);

                Assert.Equal(resourceName, listResult.Value[0].Name);

                client.Resources.Delete(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "sites",
                    resourceName,
                    WebResourceProviderVersion);
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
                string location = this.GetWebsiteLocation(client);
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = location });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "sites",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                        Properties = "{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"
                    }
                );

                var listResult = client.Resources.List(r => r.ResourceType == "Microsoft.Web/sites");

                Assert.NotEmpty(listResult.Value);
                Assert.Equal(2, listResult.Value[0].Tags.Count);
            }
        }
    }
}
