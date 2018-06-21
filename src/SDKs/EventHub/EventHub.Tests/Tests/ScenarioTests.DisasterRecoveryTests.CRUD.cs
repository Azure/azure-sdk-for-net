// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void DisasterRecoveryCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = "South Central US";// this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = "Default-EventHub-SouthCentralUS";//this.ResourceManagementClient.TryGetResourceGroup(location);
                //if (string.IsNullOrWhiteSpace(resourceGroup))
                //{
                //    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                //    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                //}

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                
                // Create namespace 1
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
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create namespace 2
                var namespaceName2 = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);
                var createNamespaceResponse2 = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName2,
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
                        }
                    });

                Assert.NotNull(createNamespaceResponse2);
                Assert.Equal(createNamespaceResponse2.Name, namespaceName2);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create a Disaster Recovery -
                var disasterRecoveryName = TestUtilities.GenerateName(EventHubManagementHelper.DisasterRecoveryPrefix);

                var DisasterRecoveryResponse = EventHubManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, disasterRecoveryName, new ArmDisasterRecovery()
                {
                    PartnerNamespace = namespaceName2
                });
                Assert.NotNull(DisasterRecoveryResponse);
                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                //// Get the created DisasterRecovery config - Primary
                var disasterRecoveryGetResponse = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);
                Assert.NotNull(disasterRecoveryGetResponse);
                Assert.Equal(disasterRecoveryGetResponse.Role, RoleDisasterRecovery.Primary);

                //// Get the created DisasterRecovery config - Secondary
                var disasterRecoveryGetResponse_Sec = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName2, disasterRecoveryName);
                Assert.NotNull(disasterRecoveryGetResponse_Sec);
                Assert.Equal(disasterRecoveryGetResponse_Sec.Role, RoleDisasterRecovery.Secondary);

                var disasterRecoveryGetResponse_Accepted = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);

                while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }

                //// Break Pairing
                EventHubManagementClient.DisasterRecoveryConfigs.BreakPairing(resourceGroup, namespaceName, disasterRecoveryName);
                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }
                
                var DisasterRecoveryResponse_update = EventHubManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, disasterRecoveryName, new ArmDisasterRecovery()
                {
                    PartnerNamespace = namespaceName2
                });
                Assert.NotNull(DisasterRecoveryResponse_update);
                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }

                // Fail over
                EventHubManagementClient.DisasterRecoveryConfigs.FailOver(resourceGroup, namespaceName2, disasterRecoveryName);
                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName2, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }
               
                // Get all Disaster Recovery for a given NameSpace
                var getListisasterRecoveryResponse = EventHubManagementClient.DisasterRecoveryConfigs.List(resourceGroup, namespaceName2);
                Assert.NotNull(getListisasterRecoveryResponse);
                Assert.True(getListisasterRecoveryResponse.Count<ArmDisasterRecovery>() >= 1);
                
                // Delete the DisasterRecovery 
                EventHubManagementClient.DisasterRecoveryConfigs.Delete(resourceGroup, namespaceName2, disasterRecoveryName);
                TestUtilities.Wait(TimeSpan.FromSeconds(10));                
            }
        }
    }
}