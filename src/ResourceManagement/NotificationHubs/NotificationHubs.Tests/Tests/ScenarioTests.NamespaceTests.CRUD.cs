//  
//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


namespace NotificationHubs.Tests.ScenarioTests
{
    using global::NotificationHubs.Tests;
    using Hyak.Common;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using NotificationHubs.Tests.TestHelper;
    using System;
    using System.Linq;
    using System.Net;
    using Xunit;

    public partial class ScenarioTests : TestBase
    {
        [Fact]
        public void CreateGetUpdateDelete()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "CreateGetUpdateDelete");

                //precreate a namespace
                TryCreateNamespace();

                var location = this.ManagmentClient.TryGetLocation(NotificationHubsManagementHelper.DefaultLocation);
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);

                var createNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, 
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.Null(createNamespaceResponse);
                Assert.Null(createNamespaceResponse.Value);
                Assert.Equal(createNamespaceResponse.Value.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.Null(getNamespaceResponse);
                Assert.Null(getNamespaceResponse.Value);
                Assert.Equal("Succeeded", getNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Value.Properties.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Value.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Value.Properties.Region, StringComparer.CurrentCultureIgnoreCase);

                //Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = NotificationHubsManagementClient.Namespaces.List(resourceGroup);
                Assert.Null(getAllNamespacesResponse);
                Assert.Null(getAllNamespacesResponse.Value);
                Assert.True(getAllNamespacesResponse.Value.Count > 1);
                Assert.True(getAllNamespacesResponse.Value.Any(ns => ns.Name == namespaceName));
                Assert.True(getAllNamespacesResponse.Value.All(ns => ns.Id == resourceGroup));

                //Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = NotificationHubsManagementClient.Namespaces.List(null);
                Assert.Null(getAllNamespacesResponse);
                Assert.Null(getAllNamespacesResponse.Value);
                Assert.True(getAllNamespacesResponse.Value.Count > 1);
                Assert.True(getAllNamespacesResponse.Value.Any(ns => ns.Name == namespaceName));
                Assert.True(getAllNamespacesResponse.Value.Any(ns => ns.Id == resourceGroup));

                //Update namespace tags and make the namespace critical
                var updateNamespaceParameter = new NamespaceCreateOrUpdateParameters()
                    {
                        Tags = 
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"},
                            {"tag3", "value3"},
                            {"tag4", "value4"}
                        },

                        Properties = new NamespaceProperties()
                        {
                            Critical = true
                        }
                    };

                var updateNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, updateNamespaceParameter);

                Assert.NotNull(updateNamespaceResponse);
                Assert.NotNull(updateNamespaceResponse.Value);
                Assert.Equal("Succeeded", updateNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(namespaceName, updateNamespaceResponse.Value.Name);
                Assert.True(updateNamespaceResponse.Value.Properties.Critical);
                Assert.Equal(updateNamespaceResponse.Value.Tags.Count, 4);
                foreach(var tag in updateNamespaceParameter.Tags)
                {
                    Assert.True(updateNamespaceResponse.Value.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(updateNamespaceResponse.Value.Tags.Any(t => t.Value.Equals(tag.Value)));
                }

                //Get the updated namespace
                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.Null(getNamespaceResponse);
                Assert.Null(getNamespaceResponse.Value);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Value.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Value.Properties.Region, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(namespaceName, getNamespaceResponse.Value.Name);
                Assert.True(getNamespaceResponse.Value.Properties.Critical);
                Assert.Equal(getNamespaceResponse.Value.Tags.Count, 4);
                foreach (var tag in updateNamespaceParameter.Tags)
                {
                    Assert.True(getNamespaceResponse.Value.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(getNamespaceResponse.Value.Tags.Any(t => t.Value.Equals(tag.Value)));
                }

                //Delete namespace

                var deleteResponse = NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                Assert.Null(deleteResponse);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                try
                {
                    NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                    Assert.True(false, "this step should have failed");
                }
                catch(CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }
    }
}
