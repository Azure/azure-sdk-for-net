// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new EHNamespace()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                        IsAutoInflateEnabled = true,
                        MaximumThroughputUnits = 10
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = EventHubManagementClient.Namespaces.ListByResourceGroupAsync(resourceGroup).Result;
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);
                Assert.True(getAllNamespacesResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = EventHubManagementClient.Namespaces.List();
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);

                // Update namespace tags and make the namespace critical
                var updateNamespaceParameter = new EHNamespace()
                {
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag3", "value3"},
                            {"tag4", "value4"}
                        }
                };

                // Will uncomment the assertions once the service is deployed
                var updateNamespaceResponse = EventHubManagementClient.Namespaces.Update(resourceGroup, namespaceName, updateNamespaceParameter);
                Assert.NotNull(updateNamespaceResponse);
                Assert.True(updateNamespaceResponse.ProvisioningState.Equals("Active", StringComparison.CurrentCultureIgnoreCase) ||
                updateNamespaceResponse.ProvisioningState.Equals("Updating", StringComparison.CurrentCultureIgnoreCase));
                Assert.Equal(namespaceName, updateNamespaceResponse.Name);

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
                TestUtilities.Wait(TimeSpan.FromSeconds(10));
                // Delete namespace
                EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
            }
        }
    }
}
