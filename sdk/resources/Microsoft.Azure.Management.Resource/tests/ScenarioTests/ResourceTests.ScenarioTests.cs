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
using System;

namespace ResourceGroups.Tests
{
    public class LiveResourceTests : TestBase
    {
        const string WebResourceProviderVersion = "2018-02-01";
        const string SendGridResourceProviderVersion = "2015-01-01";

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
            return "West US";
        }

        public string GetMySqlLocation(ResourceManagementClient client)
        {
            return ResourcesManagementTestUtilities.GetResourceLocation(client, "SuccessBricks.ClearDB/databases");
        }

        [Fact]
        public void CreateResourceWithPlan()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                string password = TestUtilities.GenerateName("p@ss");
                var client = GetResourceManagementClient(context, handler);
                string mySqlLocation = "centralus";
                var groupIdentity = new ResourceIdentity
                    {
                        ResourceName = resourceName,
                        ResourceProviderNamespace = "Sendgrid.Email",
                        ResourceType = "accounts",
                        ResourceProviderApiVersion = SendGridResourceProviderVersion
                    };

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "centralus" });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, groupIdentity.ResourceProviderNamespace, "", groupIdentity.ResourceType, 
                    groupIdentity.ResourceName, groupIdentity.ResourceProviderApiVersion, 
                    new GenericResource
                    {
                        Location = mySqlLocation,
                        Plan = new Plan {Name = "free", Publisher= "Sendgrid",Product= "sendgrid_azure",PromotionCode="" },
                        Tags = new Dictionary<string, string> { { "provision_source", "RMS" } },
                        Properties = JObject.Parse("{'password':'" + password + "','acceptMarketingEmails':false,'email':'tiano@email.com'}"),
                    }
                );

                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(mySqlLocation, createOrUpdateResult.Location),
                    string.Format("Resource location for resource '{0}' does not match expected location '{1}'", createOrUpdateResult.Location, mySqlLocation));
                Assert.NotNull(createOrUpdateResult.Plan);
                Assert.Equal("free", createOrUpdateResult.Plan.Name);

                var getResult = client.Resources.Get(groupName, groupIdentity.ResourceProviderNamespace,
                    "", groupIdentity.ResourceType, groupIdentity.ResourceName, groupIdentity.ResourceProviderApiVersion);

                Assert.Equal(resourceName, getResult.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(mySqlLocation, getResult.Location),
                    string.Format("Resource location for resource '{0}' does not match expected location '{1}'", getResult.Location, mySqlLocation));
                Assert.NotNull(getResult.Plan);
                Assert.Equal("free", getResult.Plan.Name);
            }
        }

        [Fact]
        public void CreatedResourceIsAvailableInList()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context, handler);
                string location = GetWebsiteLocation(client);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                var createOrUpdateResult = client.Resources.CreateOrUpdate(groupName, "Microsoft.Web", "", "serverFarms",resourceName, WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
                    }
                );

                Assert.NotNull(createOrUpdateResult.Id);
                Assert.Equal(resourceName, createOrUpdateResult.Name);
                Assert.True(string.Equals("Microsoft.Web/serverFarms", createOrUpdateResult.Type, StringComparison.InvariantCultureIgnoreCase));
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(location, createOrUpdateResult.Location),
                    string.Format("Resource location for website '{0}' does not match expected location '{1}'", createOrUpdateResult.Location, location));

                var listResult = client.Resources.ListByResourceGroup(groupName);

                Assert.Single(listResult);
                Assert.Equal(resourceName, listResult.First().Name);
                Assert.True(string.Equals("Microsoft.Web/serverFarms", createOrUpdateResult.Type, StringComparison.InvariantCultureIgnoreCase));
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(location, listResult.First().Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.First().Location, location));

                listResult = client.Resources.ListByResourceGroup(groupName, new ODataQuery<GenericResourceFilter> { Top = 10 });

                Assert.Single(listResult);
                Assert.Equal(resourceName, listResult.First().Name);
                Assert.True(string.Equals("Microsoft.Web/serverFarms", createOrUpdateResult.Type, StringComparison.InvariantCultureIgnoreCase));
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(location, listResult.First().Location),
                    string.Format("Resource list location for website '{0}' does not match expected location '{1}'", listResult.First().Location, location));
            }
        }

        [Fact]
        public void CreatedResourceIsAvailableInListFilteredByTagName()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                string resourceNameNoTags = TestUtilities.GenerateName("csmr");
                string tagName = TestUtilities.GenerateName("csmtn");
                var client = GetResourceManagementClient(context, handler);
                string location = GetWebsiteLocation(client);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    string.Empty,
                    "serverFarms",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Tags = new Dictionary<string, string> { { tagName, "" } },
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
                    });
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    string.Empty,
                    "serverFarms",
                    resourceNameNoTags,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
                    });

                var listResult = client.Resources.ListByResourceGroup(groupName, new ODataQuery<GenericResourceFilter>(r => r.Tagname == tagName));

                Assert.Single(listResult);
                Assert.Equal(resourceName, listResult.First().Name);

                var getResult = client.Resources.Get(
                    groupName,
                    "Microsoft.Web",
                    string.Empty,
                    "serverFarms",
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

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                string resourceNameNoTags = TestUtilities.GenerateName("csmr");
                string tagName = TestUtilities.GenerateName("csmtn");
                string tagValue = TestUtilities.GenerateName("csmtv");
                var client = GetResourceManagementClient(context, handler);
                string location = GetWebsiteLocation(client);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = this.ResourceGroupLocation });
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "serverFarms",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Tags = new Dictionary<string, string> { { tagName, tagValue } },
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
                    }
                );
                client.Resources.CreateOrUpdate(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "serverFarms", 
                    resourceNameNoTags,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
                    }
                );

                var listResult = client.Resources.ListByResourceGroup(groupName,
                    new ODataQuery<GenericResourceFilter>(r => r.Tagname == tagName && r.Tagvalue == tagValue));

                Assert.Single(listResult);
                Assert.Equal(resourceName, listResult.First().Name);

                var getResult = client.Resources.Get(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "serverFarms",
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

            using (MockContext context = MockContext.Start(this.GetType()))
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
                    "serverfarms",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
                    }
                );

                var listResult = client.Resources.ListByResourceGroup(groupName);

                Assert.Equal(resourceName, listResult.First().Name);

                client.Resources.Delete(
                    groupName,
                    "Microsoft.Web",
                    "",
                    "serverfarms",
                    resourceName,
                    WebResourceProviderVersion);
            }
        }

        [Fact]
        public void CreatedAndDeleteResourceById()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string subscriptionId = "a1bfa635-f2bf-42f1-86b5-848c674fc321";
                string groupName = TestUtilities.GenerateName("csmrg");
                string resourceName = TestUtilities.GenerateName("csmr");
                var client = GetResourceManagementClient(context, handler);

                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));
                string location = this.GetWebsiteLocation(client);

                string resourceId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Web/serverFarms/{2}", subscriptionId, groupName, resourceName);
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = location });
                var createOrUpdateResult = client.Resources.CreateOrUpdateById(
                    resourceId,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
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

            using (MockContext context = MockContext.Start(this.GetType()))
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
                    "serverFarms",
                    resourceName,
                    WebResourceProviderVersion,
                    new GenericResource
                    {
                        Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "S1"
                        },
                        Properties = JObject.Parse("{}")
                    }
                );

                var listResult = client.Resources.List(new ODataQuery<GenericResourceFilter>(r => r.ResourceType == "Microsoft.Web/serverFarms"));

                Assert.NotEmpty(listResult);
                Assert.Equal(2, listResult.First().Tags.Count);
            }
        }
    }
}

