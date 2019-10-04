// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace NotificationHubs.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Linq;
    using TestHelper;
    using Xunit;
    using System.Collections.Generic;
    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = NotificationHubsManagementHelper.DefaultLocation;
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        NamespaceType = NamespaceType.NotificationHub,
                        Sku = new Sku { Name = SkuName.Standard }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Standard", getNamespaceResponse.Sku.Name, StringComparer.CurrentCultureIgnoreCase);

                //Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = NotificationHubsManagementClient.Namespaces.List(resourceGroup);
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);
                Assert.True(getAllNamespacesResponse.All(ns => ns.Id.Contains(resourceGroup)));

                //Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = NotificationHubsManagementClient.Namespaces.ListAll();
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);

                //Update namespace tags and make the namespace critical
                var updateNamespaceParameter = new NamespaceCreateOrUpdateParameters()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"},
                            {"tag3", "value3"},
                            {"tag4", "value4"}
                        }
                };

                var updateNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, updateNamespaceParameter);

                Assert.NotNull(updateNamespaceResponse);
                Assert.True(updateNamespaceResponse.ProvisioningState.Equals("Active", StringComparison.CurrentCultureIgnoreCase) ||
                    updateNamespaceResponse.ProvisioningState.Equals("Succeeded", StringComparison.CurrentCultureIgnoreCase));
                Assert.Equal(namespaceName, updateNamespaceResponse.Name);
                //Regression in the service . uncomment after the fix goes out 
                Assert.Equal(4, updateNamespaceResponse.Tags.Count);
                foreach (var tag in updateNamespaceParameter.Tags)
                {
                    Assert.Contains(updateNamespaceResponse.Tags, t => t.Key.Equals(tag.Key));
                    Assert.Contains(updateNamespaceResponse.Tags, t => t.Value.Equals(tag.Value));
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the updated namespace
                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(namespaceName, getNamespaceResponse.Name);
                Assert.Equal(4, getNamespaceResponse.Tags.Count);
                foreach (var tag in updateNamespaceParameter.Tags)
                {
                    Assert.Contains(getNamespaceResponse.Tags, t => t.Key.Equals(tag.Key));
                    Assert.Contains(getNamespaceResponse.Tags, t => t.Value.Equals(tag.Value));
                }

                var updateNamespacePatchParameter = new NamespacePatchParameters()
                {
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag5", "value5"},
                            {"tag6", "value6"},
                        },
                    Sku = new Sku { Name = SkuName.Basic}
                };

                var updateNamespacePatchResponse = NotificationHubsManagementClient.Namespaces.Patch(resourceGroup, namespaceName, updateNamespacePatchParameter);

                Assert.NotNull(updateNamespacePatchResponse);
                Assert.Equal(2, updateNamespacePatchResponse.Tags.Count);
                foreach (var tag in updateNamespacePatchParameter.Tags)
                {
                    Assert.Contains(updateNamespacePatchParameter.Tags, t => t.Key.Equals(tag.Key));
                    Assert.Contains(updateNamespacePatchParameter.Tags, t => t.Value.Equals(tag.Value));
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.Equal("Basic", getNamespaceResponse.Sku.Name, StringComparer.CurrentCultureIgnoreCase);

                try
                    {
                        //Delete namespace
                        NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                    }
                    catch (Exception ex)
                    {
                        Assert.Contains("NotFound", ex.Message);
                    }
            }
        }
    }
}

