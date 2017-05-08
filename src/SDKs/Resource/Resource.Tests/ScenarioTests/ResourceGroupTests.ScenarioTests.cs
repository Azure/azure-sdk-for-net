// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;

namespace ResourceGroups.Tests
{
    public class LiveResourceGroupTests : TestBase
    {
        const string DefaultLocation = "South Central US";

        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetResourceManagementClientWithHandler(context, handler);
            return client;
        }

        [Fact]
        public void DeleteResourceGroupRemovesGroupResources()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

                var client = GetResourceManagementClient(context, handler);
                string location = "WestUS";
                var resourceGroupName = TestUtilities.GenerateName("csmrg");
                var resourceName = TestUtilities.GenerateName("csmr");
                var createResult = client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
                var createResourceResult = client.Resources.CreateOrUpdate(
                    resourceGroupName,
                    "Microsoft.Web",
                    string.Empty,
                    "sites",
                    resourceName,
                    "2014-04-01",
                    new GenericResource
                    {
                        Location = location,
                        Properties = JObject.Parse("{'name':'" + resourceName + "','siteMode': 'Standard','computeMode':'Shared'}")
                    });

                client.ResourceGroups.Delete(resourceGroupName);
                var listGroupsResult = client.ResourceGroups.List(null);

                Assert.Throws<CloudException>(() => client.Resources.ListByResourceGroup(resourceGroupName));

                Assert.False(listGroupsResult.Any(rg => rg.Name == resourceGroupName));
            }
        }

        [Fact]
        public void CanCreateResourceGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                ResourceManagementClient client = this.GetResourceManagementClient(context, new RecordedDelegatingHandler());
                var result = client.ResourceGroups.CreateOrUpdate(groupName, 
                    new ResourceGroup
                        {
                            Location = DefaultLocation,
                            Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                        });
                var listResult = client.ResourceGroups.List();
                var listedGroup = listResult.FirstOrDefault((g) => string.Equals(g.Name, groupName, StringComparison.Ordinal));
                Assert.NotNull(listedGroup);
                Assert.Equal("finance", listedGroup.Tags["department"]);
                Assert.Equal("tagvalue", listedGroup.Tags["tagname"]);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(DefaultLocation, listedGroup.Location),
                   string.Format("Expected location '{0}' did not match actual location '{1}'", DefaultLocation, listedGroup.Location));
                var gottenGroup = client.ResourceGroups.Get(groupName);
                Assert.NotNull(gottenGroup);
                Assert.Equal<string>(groupName, gottenGroup.Name);
                Assert.True(ResourcesManagementTestUtilities.LocationsAreEqual(DefaultLocation, gottenGroup.Location),
                    string.Format("Expected location '{0}' did not match actual location '{1}'", DefaultLocation, gottenGroup.Location));
            }
        }

        [Fact]
        public void CheckExistenceReturnsCorrectValue()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string groupName = TestUtilities.GenerateName("csmrg");
                var client = GetResourceManagementClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var checkExistenceFirst = client.ResourceGroups.CheckExistence(groupName);
                Assert.False(checkExistenceFirst);

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = DefaultLocation });

                var checkExistenceSecond = client.ResourceGroups.CheckExistence(groupName);

                Assert.True(checkExistenceSecond);
            }
        }

        [Fact]
        public void DeleteResourceGroupRemovesGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

                var client = GetResourceManagementClient(context, handler);

                var resourceGroupName = TestUtilities.GenerateName("csmrg");
                var createResult = client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = DefaultLocation });
                var getResult = client.ResourceGroups.Get(resourceGroupName);
                var deleteResult =
                    client.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupName).Result;
                var listResult = client.ResourceGroups.List(null);

                Assert.Equal(HttpStatusCode.OK, deleteResult.Response.StatusCode);
                Assert.False(listResult.Any(rg => rg.Name == resourceGroupName && rg.Properties.ProvisioningState != "Deleting"));
            }
        }
    }
}
