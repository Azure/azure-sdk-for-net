// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs.Tests;

using NUnit.Framework;

namespace Azure.Management.EventHub.Tests
{
    public partial class ScenarioTests : EventHubsManagementClientBase
    {
        [Test]
        public async Task DisasterRecoveryCreateGetUpdateDelete()
        {
            var location = "South Central US";
            var location2 = "North Central US";
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations,location, resourceGroup);
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            // Create namespace 1
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroup, namespaceName,
                new EHNamespace()
                {
                    Location = location,
                    Sku = new Sku(SkuName.Standard)
                    {
                        Tier = SkuTier.Standard,
                        Capacity = 1
                    },
                    Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                }
                );
            var np1 = (await WaitForCompletionAsync(createNamespaceResponse)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np1.Name, namespaceName);
            DelayInTest(5);

            // Create namespace 2
            var namespaceName2 = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var createNamespaceResponse2 = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroup, namespaceName2,
               new EHNamespace()
               {
                   Location = location2,
                   //Sku = new Sku
                   //{
                   //    Name = SkuName.Standard,
                   //    Tier = SkuTier.Standard,
                   //    Capacity = 1
                   //},
                   Tags = new Dictionary<string, string>()
                       {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                       }
               }
               );
            var np2 = (await WaitForCompletionAsync(createNamespaceResponse2)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np2.Name, namespaceName2);
            DelayInTest(5);

            // Create a namespace AuthorizationRule
            var authorizationRuleName = Recording.GenerateAssetName(Helper.AuthorizationRulesPrefix);
            var createAutorizationRuleParameter = new AuthorizationRule()
            {
                Rights = new List<AccessRights>() { AccessRights.Listen, AccessRights.Send }
            };

            var createNamespaceAuthorizationRuleResponse = await NamespacesOperations.CreateOrUpdateAuthorizationRuleAsync(resourceGroup, namespaceName,
                authorizationRuleName, createAutorizationRuleParameter);
            Assert.NotNull(createNamespaceAuthorizationRuleResponse);
            Assert.True(createNamespaceAuthorizationRuleResponse.Value.Rights.Count == createAutorizationRuleParameter.Rights.Count);
            Assert.True(isContains(createAutorizationRuleParameter.Rights, createNamespaceAuthorizationRuleResponse.Value.Rights));
            // Get created namespace AuthorizationRules
            var getNamespaceAuthorizationRulesResponse = await NamespacesOperations.GetAuthorizationRuleAsync(resourceGroup, namespaceName, authorizationRuleName);
            Assert.NotNull(getNamespaceAuthorizationRulesResponse);
            Assert.True(getNamespaceAuthorizationRulesResponse.Value.Rights.Count == createAutorizationRuleParameter.Rights.Count);
            Assert.True(isContains(createAutorizationRuleParameter.Rights, getNamespaceAuthorizationRulesResponse.Value.Rights));
            var getNamespaceAuthorizationRulesListKeysResponse = NamespacesOperations.ListKeysAsync(resourceGroup, namespaceName, authorizationRuleName);
            // Create a Disaster Recovery -
            var disasterRecoveryName = Recording.GenerateAssetName(Helper.DisasterRecoveryPrefix);
            //CheckNameavaliability for Alias
            var checknameAlias = await DisasterRecoveryConfigsOperations.CheckNameAvailabilityAsync(resourceGroup, namespaceName, new CheckNameAvailabilityParameter(disasterRecoveryName));
            Assert.True(checknameAlias.Value.NameAvailable, "The Alias Name: '" + disasterRecoveryName + "' is not avilable");
            //CheckNameAvaliability for Alias with same as namespace name (alternateName will be used in this case)
            var checknameAliasSame =await DisasterRecoveryConfigsOperations.CheckNameAvailabilityAsync(resourceGroup, namespaceName, new CheckNameAvailabilityParameter(namespaceName));
            // Assert.True(checknameAliasSame.NameAvailable, "The Alias Name: '" + namespaceName + "' is not avilable");
            var DisasterRecoveryResponse = await DisasterRecoveryConfigsOperations.CreateOrUpdateAsync(resourceGroup, namespaceName, disasterRecoveryName, new ArmDisasterRecovery()
            {
                PartnerNamespace = np2.Id
            });
            Assert.NotNull(DisasterRecoveryResponse);
            DelayInTest(30);

            //// Get the created DisasterRecovery config - Primary
            var disasterRecoveryGetResponse = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, disasterRecoveryName);
            Assert.NotNull(disasterRecoveryGetResponse);
            if (disasterRecoveryGetResponse.Value.PendingReplicationOperationsCount.HasValue)
                Assert.True(disasterRecoveryGetResponse.Value.PendingReplicationOperationsCount >= 0);
            else
                Assert.False(disasterRecoveryGetResponse.Value.PendingReplicationOperationsCount.HasValue);
            Assert.AreEqual(RoleDisasterRecovery.Primary, disasterRecoveryGetResponse.Value.Role);
            //// Get the created DisasterRecovery config - Secondary
            var disasterRecoveryGetResponse_Sec = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName2, disasterRecoveryName);
            Assert.AreEqual(RoleDisasterRecovery.Secondary, disasterRecoveryGetResponse_Sec.Value.Role);
            //Get authorization rule thorugh Alias
            var getAuthoRuleAliasResponse = await DisasterRecoveryConfigsOperations.GetAuthorizationRuleAsync(resourceGroup, namespaceName, disasterRecoveryName, authorizationRuleName);
            Assert.AreEqual(getAuthoRuleAliasResponse.Value.Name, getNamespaceAuthorizationRulesResponse.Value.Name);
            var getAuthoruleListKeysResponse = await DisasterRecoveryConfigsOperations.ListKeysAsync(resourceGroup, namespaceName, disasterRecoveryName, authorizationRuleName);
            Assert.True(string.IsNullOrEmpty(getAuthoruleListKeysResponse.Value.PrimaryConnectionString));
            Assert.True(string.IsNullOrEmpty(getAuthoruleListKeysResponse.Value.SecondaryConnectionString));
            while (DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, disasterRecoveryName).Result.Value.ProvisioningState != ProvisioningStateDR.Succeeded)
            {
                DelayInTest(10);
            }
            disasterRecoveryGetResponse = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, disasterRecoveryName);
            if (disasterRecoveryGetResponse.Value.PendingReplicationOperationsCount.HasValue)
                Assert.True(disasterRecoveryGetResponse.Value.PendingReplicationOperationsCount >= 0);
            else
                Assert.False(disasterRecoveryGetResponse.Value.PendingReplicationOperationsCount.HasValue);
            //// Break Pairing
            await DisasterRecoveryConfigsOperations.BreakPairingAsync(resourceGroup, namespaceName, disasterRecoveryName);
            DelayInTest(10);
            while (DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, disasterRecoveryName).Result.Value.ProvisioningState != ProvisioningStateDR.Succeeded)
            {
                DelayInTest(10);
            }
            var DisasterRecoveryResponse_update = await DisasterRecoveryConfigsOperations.CreateOrUpdateAsync(resourceGroup, namespaceName, disasterRecoveryName, new ArmDisasterRecovery()
            {
                PartnerNamespace = np2.Id
            });
            Assert.NotNull(DisasterRecoveryResponse_update);
            DelayInTest(10);
            var getGeoDRResponse = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, disasterRecoveryName);
            while (getGeoDRResponse.Value.ProvisioningState != ProvisioningStateDR.Succeeded)
            {
                getGeoDRResponse = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, disasterRecoveryName);
                DelayInTest(10);
            }
            getGeoDRResponse = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, disasterRecoveryName);
            if (getGeoDRResponse.Value.PendingReplicationOperationsCount.HasValue)
                Assert.True(getGeoDRResponse.Value.PendingReplicationOperationsCount >= 0);
            else
                Assert.False(getGeoDRResponse.Value.PendingReplicationOperationsCount.HasValue);
            // Fail over
            await DisasterRecoveryConfigsOperations.FailOverAsync(resourceGroup, namespaceName2, disasterRecoveryName);
            DelayInTest(10);
            while (DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName2, disasterRecoveryName).Result.Value.ProvisioningState != ProvisioningStateDR.Succeeded)
            {
                DelayInTest(10);
            }
            // Get all Disaster Recovery for a given NameSpace
            var getListisasterRecoveryResponse = DisasterRecoveryConfigsOperations.ListAsync(resourceGroup, namespaceName2);
            Assert.NotNull(getListisasterRecoveryResponse);
            //Assert.True(getListisasterRecoveryResponse.AsPages.Count<ArmDisasterRecovery>() >= 1);
            // Delete the DisasterRecovery
            await DisasterRecoveryConfigsOperations.DeleteAsync(resourceGroup, namespaceName2, disasterRecoveryName);
            // Delete Namespace using Async
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroup, namespaceName));
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroup, namespaceName2));
        }
    }
}
