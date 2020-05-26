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
    using System.Threading;
    public partial class ScenarioTests
    {
        [Fact]
        public void DisasterRecoveryAlertnateNameCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = "South Central US";
                var location2 = "North Central US";

                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                try
                {
                    // Create namespace 1
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
                            Location = location2,
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
                            }
                        });

                    Assert.NotNull(createNamespaceResponse2);
                    Assert.Equal(createNamespaceResponse2.Name, namespaceName2);
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Create a namespace AuthorizationRule
                    var authorizationRuleName = TestUtilities.GenerateName(EventHubManagementHelper.AuthorizationRulesPrefix);
                    var createAutorizationRuleParameter = new AuthorizationRule()
                    {
                        Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
                    };

                    var createNamespaceAuthorizationRuleResponse = EventHubManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                        authorizationRuleName, createAutorizationRuleParameter);
                    Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                    Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                    foreach (var right in createAutorizationRuleParameter.Rights)
                    {
                        Assert.Contains(createNamespaceAuthorizationRuleResponse.Rights, r => r == right);
                    }

                    // Get created namespace AuthorizationRules
                    var getNamespaceAuthorizationRulesResponse = EventHubManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                    Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                    Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                    foreach (var right in createAutorizationRuleParameter.Rights)
                    {
                        Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == right);
                    }

                    var getNamespaceAuthorizationRulesListKeysResponse = EventHubManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);

                    // Create a Disaster Recovery -
                    var alternateName = TestUtilities.GenerateName(EventHubManagementHelper.DisasterRecoveryPrefix);

                    //CheckNameavaliability for Alias

                    var checknameAlias = EventHubManagementClient.DisasterRecoveryConfigs.CheckNameAvailability(resourceGroup, namespaceName, new CheckNameAvailabilityParameter(namespaceName));

                    Assert.True(checknameAlias.NameAvailable, "The Alias Name: '" + namespaceName + "' is not avilable");


                    var DisasterRecoveryResponse = EventHubManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, namespaceName, new ArmDisasterRecovery()
                    {
                        PartnerNamespace = createNamespaceResponse2.Id,
                        AlternateName = alternateName

                    });
                    Assert.NotNull(DisasterRecoveryResponse);

                    TestUtilities.Wait(TimeSpan.FromSeconds(30));

                    //// Get the created DisasterRecovery config - Primary
                    var disasterRecoveryGetResponse = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, namespaceName);
                    Assert.NotNull(disasterRecoveryGetResponse);
                    Assert.Equal(RoleDisasterRecovery.Primary, disasterRecoveryGetResponse.Role);

                    //// Get the created DisasterRecovery config - Secondary
                    var disasterRecoveryGetResponse_Sec = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName2, namespaceName);
                    Assert.NotNull(disasterRecoveryGetResponse_Sec);
                    Assert.Equal(RoleDisasterRecovery.Secondary, disasterRecoveryGetResponse_Sec.Role);

                    //Get authorization rule thorugh Alias 

                    var getAuthoRuleAliasResponse = EventHubManagementClient.DisasterRecoveryConfigs.GetAuthorizationRule(resourceGroup, namespaceName, namespaceName, authorizationRuleName);
                    Assert.Equal(getAuthoRuleAliasResponse.Name, getNamespaceAuthorizationRulesResponse.Name);

                    var getAuthoruleListKeysResponse = EventHubManagementClient.DisasterRecoveryConfigs.ListKeys(resourceGroup, namespaceName, namespaceName, authorizationRuleName);


                    var disasterRecoveryGetResponse_Accepted = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, namespaceName);

                    while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, namespaceName).ProvisioningState != ProvisioningStateDR.Succeeded)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    }

                    //// Break Pairing
                    EventHubManagementClient.DisasterRecoveryConfigs.BreakPairing(resourceGroup, namespaceName, namespaceName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));

                    while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, namespaceName).ProvisioningState != ProvisioningStateDR.Succeeded)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    }

                    var DisasterRecoveryResponse_update = EventHubManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, namespaceName, new ArmDisasterRecovery()
                    {
                        PartnerNamespace = createNamespaceResponse2.Id,
                        AlternateName = alternateName
                    });

                    Assert.NotNull(DisasterRecoveryResponse_update);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));

                    while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, namespaceName).ProvisioningState != ProvisioningStateDR.Succeeded)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    }

                    // Fail over
                    EventHubManagementClient.DisasterRecoveryConfigs.FailOver(resourceGroup, namespaceName2, namespaceName);

                    TestUtilities.Wait(TimeSpan.FromSeconds(10));

                    while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName2, namespaceName).ProvisioningState != ProvisioningStateDR.Succeeded)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    }

                    // Get all Disaster Recovery for a given NameSpace
                    var getListisasterRecoveryResponse = EventHubManagementClient.DisasterRecoveryConfigs.List(resourceGroup, namespaceName2);
                    Assert.NotNull(getListisasterRecoveryResponse);
                    Assert.True(getListisasterRecoveryResponse.Count<ArmDisasterRecovery>() >= 1);

                    // Delete the DisasterRecovery 
                    EventHubManagementClient.DisasterRecoveryConfigs.Delete(resourceGroup, namespaceName2, namespaceName);

                    // Delete Namespace using Async
                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);

                    EventHubManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroup, namespaceName2, null, new CancellationToken()).ConfigureAwait(false);
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