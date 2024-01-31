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
        public void DisasterRecoveryCreateGetUpdateDelete()
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

                    //var createNamespaceResponse = this.EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);

                    //// Create namespace 2
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
                        authorizationRuleName, createAutorizationRuleParameter.Rights);
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
                    var disasterRecoveryName = TestUtilities.GenerateName(EventHubManagementHelper.DisasterRecoveryPrefix);

                    //CheckNameavaliability for Alias

                    var checknameAlias = EventHubManagementClient.DisasterRecoveryConfigs.CheckNameAvailability(resourceGroup, namespaceName, disasterRecoveryName);

                    Assert.True(checknameAlias.NameAvailable, "The Alias Name: '" + disasterRecoveryName + "' is not available");

                    //CheckNameAvaliability for Alias with same as namespace name (alternateName will be used in this case)
                    var checknameAliasSame = EventHubManagementClient.DisasterRecoveryConfigs.CheckNameAvailability(resourceGroup, namespaceName, namespaceName);

                    // Assert.True(checknameAliasSame.NameAvailable, "The Alias Name: '" + namespaceName + "' is not available");


                    var DisasterRecoveryResponse = EventHubManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, disasterRecoveryName, createNamespaceResponse2.Id);
                    Assert.NotNull(DisasterRecoveryResponse);

                    TestUtilities.Wait(TimeSpan.FromSeconds(30));

                    //// Get the created DisasterRecovery config - Primary
                    var disasterRecoveryGetResponse = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);
                    Assert.NotNull(disasterRecoveryGetResponse);
                    if (disasterRecoveryGetResponse.PendingReplicationOperationsCount.HasValue)
                        Assert.True(disasterRecoveryGetResponse.PendingReplicationOperationsCount >= 0);
                    else
                        Assert.False(disasterRecoveryGetResponse.PendingReplicationOperationsCount.HasValue);
                    
                    Assert.Equal(RoleDisasterRecovery.Primary, disasterRecoveryGetResponse.Role);

                    //// Get the created DisasterRecovery config - Secondary
                    var disasterRecoveryGetResponse_Sec = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName2, disasterRecoveryName);
                    Assert.Equal(RoleDisasterRecovery.Secondary, disasterRecoveryGetResponse_Sec.Role);

                    //Get authorization rule thorugh Alias 

                    var getAuthoRuleAliasResponse = EventHubManagementClient.DisasterRecoveryConfigs.GetAuthorizationRule(resourceGroup, namespaceName, disasterRecoveryName, authorizationRuleName);
                    Assert.Equal(getAuthoRuleAliasResponse.Name, getNamespaceAuthorizationRulesResponse.Name);

                    var getAuthoruleListKeysResponse = EventHubManagementClient.DisasterRecoveryConfigs.ListKeys(resourceGroup, namespaceName, disasterRecoveryName, authorizationRuleName);
                    Assert.True(string.IsNullOrEmpty(getAuthoruleListKeysResponse.PrimaryConnectionString));
                    Assert.True(string.IsNullOrEmpty(getAuthoruleListKeysResponse.SecondaryConnectionString));

                    while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    }

                    disasterRecoveryGetResponse = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);

                    if (disasterRecoveryGetResponse.PendingReplicationOperationsCount.HasValue)
                        Assert.True(disasterRecoveryGetResponse.PendingReplicationOperationsCount >= 0);
                    else
                        Assert.False(disasterRecoveryGetResponse.PendingReplicationOperationsCount.HasValue);

                    //// Break Pairing
                    EventHubManagementClient.DisasterRecoveryConfigs.BreakPairing(resourceGroup, namespaceName, disasterRecoveryName);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));

                    while (EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName).ProvisioningState != ProvisioningStateDR.Succeeded)
                    {
                        TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    }

                    var DisasterRecoveryResponse_update = EventHubManagementClient.DisasterRecoveryConfigs.CreateOrUpdate(resourceGroup, namespaceName, disasterRecoveryName, createNamespaceResponse2.Id);

                    Assert.NotNull(DisasterRecoveryResponse_update);
                    TestUtilities.Wait(TimeSpan.FromSeconds(10));

                    var getGeoDRResponse = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);

                    while (getGeoDRResponse.ProvisioningState != ProvisioningStateDR.Succeeded)
                    {
                        getGeoDRResponse = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);
                        TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    }

                    getGeoDRResponse = EventHubManagementClient.DisasterRecoveryConfigs.Get(resourceGroup, namespaceName, disasterRecoveryName);

                    if (getGeoDRResponse.PendingReplicationOperationsCount.HasValue)
                        Assert.True(getGeoDRResponse.PendingReplicationOperationsCount >= 0);
                    else
                        Assert.False(getGeoDRResponse.PendingReplicationOperationsCount.HasValue);

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