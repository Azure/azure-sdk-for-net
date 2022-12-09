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
            using (MockContext context = MockContext.Start(this.GetType()))
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

                //Check namespace name available
                var checknamespaceavailable = ServiceBusManagementClient.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability() { Name = namespaceName });

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                        MinimumTlsVersion = "1.2",
                        PublicNetworkAccess = "Enabled"
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);
                Assert.Equal("Standard",createNamespaceResponse.Sku.Name);
                Assert.Equal("Standard", createNamespaceResponse.Sku.Tier);
                Assert.Equal("1.2", createNamespaceResponse.MinimumTlsVersion);
                Assert.Equal("Enabled", createNamespaceResponse.PublicNetworkAccess);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = ServiceBusManagementClient.Namespaces.ListByResourceGroupAsync(resourceGroup).Result;
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);
                Assert.True(getAllNamespacesResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = ServiceBusManagementClient.Namespaces.List();
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
               
                if (getAllNamespacesResponse.ToList().Find(item => item.Name == getNamespaceResponse.Name).Equals(null))
                {
                    getAllNamespacesResponse = ServiceBusManagementClient.Namespaces.ListNext(getAllNamespacesResponse.NextPageLink);
                }
               
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);

                //Update namespace tags
                var updateNamespaceParameter = new SBNamespaceUpdateParameters()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag3", "value3"},
                            {"tag4", "value4"}
                        }
                };

                var updateNamespaceResponse = ServiceBusManagementClient.Namespaces.Update(resourceGroup, namespaceName, updateNamespaceParameter);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the updated namespace
                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
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
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
            }
        }
    }
}