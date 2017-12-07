// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using System.Linq;
using Microsoft.Azure;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Microsoft.Rest.Azure.OData;

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

        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClientWithHandler(context, handler);
        }

        public string GetWebsiteLocation(ResourceManagementClient client)
        {
            return "WestUS";
        }

        public string GetMySqlLocation(ResourceManagementClient client)
        {
            return ResourcesManagementTestUtilities.GetResourceLocation(client, "SuccessBricks.ClearDB/databases");
        }

        [Fact]
        public void CleanupAllResources()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetResourceManagementClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var groups = client.ResourceGroups.List();
                foreach (var group in groups)
                {
                    var resources = client.Resources.ListByResourceGroup(group.Name, new ODataQuery<GenericResourceFilter>(r => r.ResourceType == "Microsoft.Web/sites"));
                    foreach (var resource in resources)
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context, handler);
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
                Assert.Equal("Free", createOrUpdateResult.Plan.Name);

                var getResult = client.Resources.Get(groupName, groupIdentity.ResourceProviderNamespace,
                    "", groupIdentity.ResourceType, groupIdentity.ResourceName, groupIdentity.ResourceProviderApiVersion);

                Assert.Equal(resourceName, getResult.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(mySqlLocation, getResult.Location),
                    string.Format("Resource location for resource '{0}' does not match expected location '{1}'", getResult.Location, mySqlLocation));
                Assert.NotNull(getResult.Plan);
                Assert.Equal("Free", getResult.Plan.Name);
            }
        }

        [Fact]
        public void CreatedResourceIsAvailableInList()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context, handler);
                string websiteLocation = GetWebsiteLocation(client);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, "Microsoft.Web", "", "sites",resourceName, WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = websiteLocation,
                        Properties = JObject.Parse("{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}"),
                    }
                );

                Assert.NotNull(createOrUpdateResult.Id);
                Assert.Equal(resourceName, createOrUpdateResult.Name);
                Assert.Equal("Microsoft.Web/sites", createOrUpdateResult.Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, createOrUpdateResult.Location),
                    string.Format("Resource location for website '{0}' does not match expected location '{1}'", createOrUpdateResult.Location, websiteLocation));

                var listResult = client.Resources.ListByResourceGroup(groupName);

                Assert.Equal(1, listResult.Count());
                Assert.Equal(resourceName, listResult.First().Name);
                Assert.Equal("Microsoft.Web/sites", listResult.First().Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, listResult.First().Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.First().Location, websiteLocation));

                listResult = client.Resources.ListByResourceGroup(groupName, new ODataQuery<GenericResourceFilter> { Top = 10 });

                Assert.Equal(1, listResult.Count());
                Assert.Equal(resourceName, listResult.First().Name);
                Assert.Equal("Microsoft.Web/sites", listResult.First().Type);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(websiteLocation, listResult.First().Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.First().Location, websiteLocation));
            }
        }

        [Fact]
        public void CreatedResourceIsAvailableInListFilteredByTagName()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                string resourceNameNoTags = TestUtilities.GenerateName("csmr");
                string tagName = TestUtilities.GenerateName("csmtn");
                var client = GetResourceManagementClient(context, handler);
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
                        Properties = JObject.Parse("{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}")
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
                        Properties = JObject.Parse("{'name':'" + resourceNameNoTags + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}")
                    });

                var listResult = client.Resources.ListByResourceGroup(groupName, new ODataQuery<GenericResourceFilter>(r => r.Tagname == tagName));

                Assert.Equal(1, listResult.Count());
                Assert.Equal(resourceName, listResult.First().Name);

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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                string resourceNameNoTags = TestUtilities.GenerateName("csmr");
                string tagName = TestUtilities.GenerateName("csmtn");
                string tagValue = TestUtilities.GenerateName("csmtv");
                var client = GetResourceManagementClient(context, handler);
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
                        Properties = JObject.Parse("{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}")
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
                        Properties = JObject.Parse("{'name':'" + resourceNameNoTags + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}")
                    }
                );

                var listResult = client.Resources.ListByResourceGroup(groupName,
                    new ODataQuery<GenericResourceFilter>(r => r.Tagname == tagName && r.Tagvalue == tagValue));

                Assert.Equal(1, listResult.Count());
                Assert.Equal(resourceName, listResult.First().Name);

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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context, handler);

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
                        Properties = JObject.Parse("{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}")
                    }
                );

                var listResult = client.Resources.ListByResourceGroup(groupName);

                Assert.Equal(resourceName, listResult.First().Name);

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
        public void CreatedAndDeleteResourceById()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string subscriptionId = "89ec4d1d-dcc7-4a3f-a701-0a5d074c8505";
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context, handler);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));
                string location = this.GetWebsiteLocation(client);

                string resourceId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Web/sites/{2}", subscriptionId, groupName, resourceName);
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = location });
                var createOrUpdateResult = client.Resources.CreateOrUpdateById(
                    resourceId,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Properties = JObject.Parse("{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}")
                    }
                );

                var listResult = client.Resources.ListByResourceGroup(groupName);

                Assert.Equal(resourceName, listResult.First().Name);

                client.Resources.DeleteById(
                    resourceId,
                    WebResourceProviderVersion);
            }
        }

        [Fact]
        public void CreatedAndListResource()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context, handler);
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
                        Properties = JObject.Parse("{'name':'" + resourceName + "','siteMode':'Limited','computeMode':'Shared', 'sku':'Free', 'workerSize': 0}")
                    }
                );

                var listResult = client.Resources.List(new ODataQuery<GenericResourceFilter>(r => r.ResourceType == "Microsoft.Web/sites"));

                Assert.NotEmpty(listResult);
                Assert.Equal(2, listResult.First().Tags.Count);
            }
        }
    }
}
