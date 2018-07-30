// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    using System.Threading;
    public partial class ScenarioTests
    {
        [Fact]
        public void DisasterRecoveryCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = "West Central US";
                var location2 = "West Central US";

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName =  TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                // Create namespace 1
                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Premium,
                            Tier = SkuTier.Premium,
                            Capacity = 1
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);
                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);

                //// Create namespace 2
                var namespaceName2 = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);
                var createNamespaceResponse2 = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName2,
                    new SBNamespace()
                    {
                        Location = location2,
                        Sku = new SBSku
                        {
                            Name = SkuName.Premium,
                            Tier = SkuTier.Premium,
                            Capacity = 1
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

                // Create a namespace AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(ServiceBusManagementHelper.AuthorizationRulesPrefix);                
                var createAutorizationRuleParameter = new SBAuthorizationRule()
                {
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var createNamespaceAuthorizationRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Any(r => r == right));
                }
                
                // Get created namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                var getNamespaceAuthorizationRulesListKeysResponse = ServiceBusManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);

                // Create a Disaster Recovery -
                var disasterRecoveryName = TestUtilities.GenerateName(ServiceBusManagementHelper.DisasterRecoveryPrefix);

                //CheckNameavaliability for Alias
                var checknameAlias = ServiceBusManagementClient.DisasterRecoveryConfigs.CheckNameAvailabilityMethod(resourceGroup, namespaceName, new CheckNameAvailability(disasterRecoveryName));

                Assert.True(checknameAlias.NameAvailable, "The Alias Name: '"+ disasterRecoveryName + "' is not avilable");

                //CheckNameAvaliability for Alias with same as namespace name (alternateName will be used in this case)
                var checknameAliasSame = ServiceBusManagementClient.DisasterRecoveryConfigs.CheckNameAvailabilityMethod(resourceGroup, namespaceName, new CheckNameAvailability(namespaceName));

                Assert.True(checknameAliasSame.NameAvailable, "The Alias Name: '" + namespaceName + "' is not avilable");


                var DisasterRecoveryResponse = ServiceBusManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, disasterRecoveryName, new ArmDisasterRecovery()
                {
                    PartnerNamespace = createNamespaceResponse2.Id
                });
                Assert.NotNull(DisasterRecoveryResponse);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //// Get the created DisasterRecovery config - Primary
                var disasterRecoveryGetResponse = ServiceBusManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);
                Assert.NotNull(disasterRecoveryGetResponse);
                Assert.Equal(disasterRecoveryGetResponse.Role, RoleDisasterRecovery.Primary);

                //// Get the created DisasterRecovery config - Secondary
                var disasterRecoveryGetResponse_Sec = ServiceBusManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName2, disasterRecoveryName);
                Assert.NotNull(disasterRecoveryGetResponse_Sec);
                Assert.Equal(disasterRecoveryGetResponse_Sec.Role, RoleDisasterRecovery.Secondary);

                //Get authorization rule thorugh Alias 

                var getAuthoRuleAliasResponse = ServiceBusManagementClient.DisasterRecoveryConfigs.GetAuthorizationRule(resourceGroup, namespaceName, disasterRecoveryName, authorizationRuleName);
                Assert.Equal(getAuthoRuleAliasResponse.Name, getNamespaceAuthorizationRulesResponse.Name);

                var getAuthoruleListKeysResponse = ServiceBusManagementClient.DisasterRecoveryConfigs.ListKeys(resourceGroup, namespaceName, disasterRecoveryName, authorizationRuleName);
                                
                var disasterRecoveryGetResponse_Accepted = ServiceBusManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);

                while (ServiceBusManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }
                
                //// Break Pairing
                ServiceBusManagementClient.DisasterRecoveryConfigs.BreakPairing(resourceGroup, namespaceName, disasterRecoveryName);
                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                while (ServiceBusManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }

                var DisasterRecoveryResponse_update = ServiceBusManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, disasterRecoveryName, new ArmDisasterRecovery()
                {
                    PartnerNamespace = createNamespaceResponse2.Id
                });

                Assert.NotNull(DisasterRecoveryResponse_update);
                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                while (ServiceBusManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }

                // Fail over
                ServiceBusManagementClient.DisasterRecoveryConfigs.FailOver(resourceGroup, namespaceName2, disasterRecoveryName);

                TestUtilities.Wait(TimeSpan.FromSeconds(10));

                while (ServiceBusManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName2, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));
                }
                
                // Get all Disaster Recovery for a given NameSpace
                var getListisasterRecoveryResponse = ServiceBusManagementClient.DisasterRecoveryConfigs.List(resourceGroup, namespaceName2);
                Assert.NotNull(getListisasterRecoveryResponse);
                Assert.True(getListisasterRecoveryResponse.Count<ArmDisasterRecovery>() >= 1);

                // Delete the DisasterRecovery 
                ServiceBusManagementClient.DisasterRecoveryConfigs.Delete(resourceGroup, namespaceName2, disasterRecoveryName);

                // Delete Namespace using Async
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);

                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName2, null, new CancellationToken()).ConfigureAwait(false);
            }
        }
    }
}