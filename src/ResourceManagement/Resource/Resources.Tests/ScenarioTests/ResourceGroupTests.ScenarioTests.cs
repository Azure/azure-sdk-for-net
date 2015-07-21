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
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveResourceGroupTests : TestBase
    {
        const string DefaultLocation = "South Central US";

        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetResourceManagementClientWithHandler(handler);
           
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
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
            string location = ResourcesManagementTestUtilities.GetResourceLocation(client, "Microsoft.Web/sites");
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
                    Properties = "{'name':'" + resourceName + "','siteMode': 'Standard','computeMode':'Shared'}"
                });

            client.ResourceGroups.Delete(resourceGroupName);
            var listGroupsResult = client.ResourceGroups.List(null);

            Assert.Throws<CloudException>(() => client.ResourceGroups.ListResources(resourceGroupName));

            Assert.False(listGroupsResult.Any(rg => rg.Name == resourceGroupName));
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

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string groupName = TestUtilities.GenerateName("csmrg");
                var client = GetResourceManagementClient(handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var checkExistenceFirst = client.ResourceGroups.CheckExistence(groupName);
                Assert.False(checkExistenceFirst.Value);

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = DefaultLocation });

                var checkExistenceSecond = client.ResourceGroups.CheckExistence(groupName);

                Assert.True(checkExistenceSecond.Value);
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
            var deleteResult =
                client.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupName).Result;
            var listResult = client.ResourceGroups.List(null);

            Assert.Equal(HttpStatusCode.OK, deleteResult.Response.StatusCode);
            Assert.False(listResult.Any(rg => rg.Name == resourceGroupName && rg.Properties.ProvisioningState != "Deleting"));
            TestUtilities.EndTest();
        }
    }
}
