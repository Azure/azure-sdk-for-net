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
        public void NamespacePremiumGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = "West US 2";

                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                var namespaceNamestandard = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                var namespaceNameZone = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

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
                                Name = SkuName.Premium,
                                Tier = SkuTier.Premium
                            },
                            Tags = new Dictionary<string, string>()
                            {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                            }

                        });

                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(createNamespaceResponse.Name, namespaceName);
                    Assert.Equal(createNamespaceResponse.Sku.Name, SkuName.Premium);
                    Assert.Equal(createNamespaceResponse.Sku.Tier, SkuTier.Premium);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));

                    // Standard Namespace 

                    //TEST AUTOINFLATE and MINTLS
                    var createNamespaceStandardResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceNamestandard,
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
                            MaximumThroughputUnits = 40,
                            MinimumTlsVersion = "1.2"

                        });

                    Assert.NotNull(createNamespaceStandardResponse);
                    Assert.Equal(createNamespaceStandardResponse.Name, namespaceNamestandard);
                    Assert.Equal(40, createNamespaceStandardResponse.MaximumThroughputUnits);
                    Assert.Equal(createNamespaceStandardResponse.Sku.Name, SkuName.Standard);
                    Assert.Equal(createNamespaceStandardResponse.Sku.Tier, SkuTier.Standard);
                    Assert.True(createNamespaceStandardResponse.IsAutoInflateEnabled);
                    Assert.Equal("1.2", createNamespaceStandardResponse.MinimumTlsVersion);

                    createNamespaceStandardResponse.MinimumTlsVersion = "1.1";

                    createNamespaceStandardResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceNamestandard, createNamespaceStandardResponse);

                    Assert.NotNull(createNamespaceStandardResponse);
                    Assert.Equal(createNamespaceStandardResponse.Name, namespaceNamestandard);
                    Assert.Equal(40, createNamespaceStandardResponse.MaximumThroughputUnits);
                    Assert.Equal(createNamespaceStandardResponse.Sku.Name, SkuName.Standard);
                    Assert.Equal(createNamespaceStandardResponse.Sku.Tier, SkuTier.Standard);
                    Assert.True(createNamespaceStandardResponse.IsAutoInflateEnabled);
                    Assert.Equal("1.1", createNamespaceStandardResponse.MinimumTlsVersion);

                    createNamespaceStandardResponse.MinimumTlsVersion = "1.0";

                    createNamespaceStandardResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceNamestandard, createNamespaceStandardResponse);

                    Assert.NotNull(createNamespaceStandardResponse);
                    Assert.Equal(createNamespaceStandardResponse.Name, namespaceNamestandard);
                    Assert.Equal(40, createNamespaceStandardResponse.MaximumThroughputUnits);
                    Assert.Equal(createNamespaceStandardResponse.Sku.Name, SkuName.Standard);
                    Assert.Equal(createNamespaceStandardResponse.Sku.Tier, SkuTier.Standard);
                    Assert.True(createNamespaceStandardResponse.IsAutoInflateEnabled);
                    Assert.Equal("1.0", createNamespaceStandardResponse.MinimumTlsVersion);


                    // Standard Namespace 
                    var createNamespaceZoneResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceNameZone,
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
                            MaximumThroughputUnits = 40,
                            ZoneRedundant = true

                        });

                    Assert.NotNull(createNamespaceZoneResponse);
                    Assert.Equal(createNamespaceZoneResponse.Name, namespaceNameZone);
                    Assert.True(createNamespaceZoneResponse.ZoneRedundant);
                    Assert.Equal(40, createNamespaceZoneResponse.MaximumThroughputUnits);
                    Assert.Equal(createNamespaceZoneResponse.Sku.Name, SkuName.Standard);
                    Assert.Equal(createNamespaceZoneResponse.Sku.Tier, SkuTier.Standard);

                    // Delete namespace
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, default(CancellationToken)).ConfigureAwait(false);
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceNamestandard, null, default(CancellationToken)).ConfigureAwait(false);
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceNameZone, null, default(CancellationToken)).ConfigureAwait(false);
                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD  test");
                }

            }
        }
    }
}
