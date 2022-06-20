// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                try
                {      

                    var operationsResponse = EventHubManagementClient.Operations.List();

                    var checkNameAvailable = EventHubManagementClient.Namespaces.CheckNameAvailability(namespaceName);

                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                        new EHNamespace()
                        {
                            Location = location,
                            Sku = new Sku
                            {
                                Name = SkuName.Standard,
                                Tier = SkuTier.Standard,
                                Capacity = 1
                            },
                            Tags = new Dictionary<string, string>()
                            {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                            },
                            IsAutoInflateEnabled = true,
                            MaximumThroughputUnits = 10,
                            
                        });

                    

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(createNamespaceResponse.Name, namespaceName);
                    Assert.Equal(SkuName.Standard, createNamespaceResponse.Sku.Name);
                    Assert.Equal(SkuName.Standard, createNamespaceResponse.Sku.Tier);
                    Assert.Equal(1, createNamespaceResponse.Sku.Capacity);
                    Assert.Equal(new Dictionary<string, string>() { { "tag1", "value1" }, { "tag2", "value2" } },
                                    createNamespaceResponse.Tags);
                    Assert.True(createNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(10, createNamespaceResponse.MaximumThroughputUnits);
                    Assert.Equal("Enabled", createNamespaceResponse.PublicNetworkAccess);

                    createNamespaceResponse.PublicNetworkAccess = "Disabled";

                    createNamespaceResponse = EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, createNamespaceResponse);

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(createNamespaceResponse.Name, namespaceName);
                    Assert.Equal(SkuName.Standard, createNamespaceResponse.Sku.Name);
                    Assert.Equal(SkuName.Standard, createNamespaceResponse.Sku.Tier);
                    Assert.Equal(1, createNamespaceResponse.Sku.Capacity);
                    Assert.Equal(new Dictionary<string, string>() { { "tag1", "value1" }, { "tag2", "value2" } },
                                    createNamespaceResponse.Tags);
                    Assert.True(createNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(10, createNamespaceResponse.MaximumThroughputUnits);
                    Assert.Equal("Disabled", createNamespaceResponse.PublicNetworkAccess);

                    var getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                    Assert.NotNull(getNamespaceResponse);
                    Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                    Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                    
                    // Get all namespaces created within a resourceGroup
                    var getAllNamespacesResponse = EventHubManagementClient.Namespaces.ListByResourceGroupAsync(resourceGroup).Result;
                    Assert.NotNull(getAllNamespacesResponse);
                    Assert.True(getAllNamespacesResponse.Count() == 1);
                    Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);
                    Assert.Contains(getAllNamespacesResponse, ns => ns.Id.Contains(resourceGroup));

                    // Get all namespaces created within the subscription irrespective of the resourceGroup
                    getAllNamespacesResponse = EventHubManagementClient.Namespaces.List();
                    Assert.NotNull(getAllNamespacesResponse);
                    Assert.True(getAllNamespacesResponse.Count() >= 1);

                    // Update namespace tags and make the namespace critical
                    var updateNamespaceParameter = new EHNamespace()
                    {
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag3", "value3"},
                            {"tag4", "value4"}
                        }
                    };


                    var updateNamespaceResponse = EventHubManagementClient.Namespaces.Update(resourceGroup, namespaceName, updateNamespaceParameter);

                    Assert.NotNull(updateNamespaceResponse);
                    Assert.Equal(updateNamespaceResponse.Name, namespaceName);
                    Assert.Equal(SkuName.Standard, updateNamespaceResponse.Sku.Name);
                    Assert.Equal(new Dictionary<string, string>() { { "tag3", "value3" }, { "tag4", "value4" } },
                                    updateNamespaceResponse.Tags);
                    Assert.True(updateNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(10, updateNamespaceResponse.MaximumThroughputUnits);

                    // Will uncomment the assertions once the service is deployed
                    TestUtilities.Wait(10000);

                    updateNamespaceResponse.DisableLocalAuth = true;

                    updateNamespaceResponse = EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, updateNamespaceResponse);
                    
                    Assert.NotNull(updateNamespaceResponse);
                    Assert.Equal(updateNamespaceResponse.Name, namespaceName);
                    Assert.Equal(SkuName.Standard, updateNamespaceResponse.Sku.Name);
                    Assert.Equal(new Dictionary<string, string>() { { "tag3", "value3" }, { "tag4", "value4" } },
                                    updateNamespaceResponse.Tags);
                    Assert.True(updateNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(10, updateNamespaceResponse.MaximumThroughputUnits);
                    Assert.True(updateNamespaceResponse.DisableLocalAuth);

                    updateNamespaceResponse.DisableLocalAuth = false;

                    updateNamespaceResponse = EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, updateNamespaceResponse);

                    Assert.NotNull(updateNamespaceResponse);
                    Assert.Equal(updateNamespaceResponse.Name, namespaceName);
                    Assert.Equal(SkuName.Standard, updateNamespaceResponse.Sku.Name);
                    Assert.Equal(new Dictionary<string, string>() { { "tag3", "value3" }, { "tag4", "value4" } },
                                    updateNamespaceResponse.Tags);
                    Assert.True(updateNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(10, updateNamespaceResponse.MaximumThroughputUnits);
                    Assert.False(updateNamespaceResponse.DisableLocalAuth);

                    // Will uncomment the assertions once the service is deployed
                    TestUtilities.Wait(10000);

                    // Get the updated namespace and also verify the Tags. 
                    getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                    Assert.NotNull(getNamespaceResponse);
                    Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                    Assert.Equal(namespaceName, getNamespaceResponse.Name);
                    Assert.Equal(2, getNamespaceResponse.Tags.Count);
                    foreach (var tag in updateNamespaceParameter.Tags)
                    {
                        Assert.Contains(getNamespaceResponse.Tags, t => t.Key.Equals(tag.Key));
                        Assert.Contains(getNamespaceResponse.Tags, t => t.Value.Equals(tag.Value));
                    }

                    // Delete namespace
                    EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD IPFilter Rules test");
                }

            }
        }
    }
}
