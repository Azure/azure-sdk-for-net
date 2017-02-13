// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
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
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create Namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "Standard",
                            Tier = "Standard"
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceState.Active, getNamespaceResponse.Status);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = ServiceBusManagementClient.Namespaces.ListByResourceGroupAsync(resourceGroup).Result;
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.True(getAllNamespacesResponse.Any(ns => ns.Name == namespaceName));
                Assert.True(getAllNamespacesResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = ServiceBusManagementClient.Namespaces.ListBySubscriptionAsync().Result;
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.True(getAllNamespacesResponse.Any(ns => ns.Name == namespaceName));

                // Update namespace tags
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

                var updateNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName, updateNamespaceParameter);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the updated namespace
                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(namespaceName, getNamespaceResponse.Name);
                Assert.Equal(getNamespaceResponse.Tags.Count, 4);
                foreach (var tag in updateNamespaceParameter.Tags)
                {
                    Assert.True(getNamespaceResponse.Tags.Any(t => t.Key.Equals(tag.Key)));
                    Assert.True(getNamespaceResponse.Tags.Any(t => t.Value.Equals(tag.Value)));
                }
                
                try
                {
                    // Delete namespace
                    ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
            }
        }
    }
}
