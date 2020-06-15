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
        public async Task DisasterRecoveryAlertnateNameCreateGetUpdateDelete()
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
            var np2 = (await WaitForCompletionAsync (createNamespaceResponse2)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np2.Name, namespaceName2);
            DelayInTest(5);
            // Create a namespace AuthorizationRule
            var authorizationRuleName = Recording.GenerateAssetName(Helper.AuthorizationRulesPrefix);
            var createAutorizationRuleParameter = new AuthorizationRule()
            {
                Rights = new List<AccessRights>() { AccessRights.Listen,AccessRights.Send}
            };
            var createNamespaceAuthorizationRuleResponse =await NamespacesOperations.CreateOrUpdateAuthorizationRuleAsync(resourceGroup, namespaceName,
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
            var alternateName = Recording.GenerateAssetName(Helper.DisasterRecoveryPrefix);
            //CheckNameavaliability for Alias
            var checknameAlias =await DisasterRecoveryConfigsOperations.CheckNameAvailabilityAsync(resourceGroup, namespaceName, new CheckNameAvailabilityParameter(namespaceName));
            Assert.True(checknameAlias.Value.NameAvailable, "The Alias Name: '" + namespaceName + "' is not avilable");
            var DisasterRecoveryResponse =await DisasterRecoveryConfigsOperations.CreateOrUpdateAsync(resourceGroup, namespaceName, namespaceName, new ArmDisasterRecovery()
            {
                PartnerNamespace = np2.Id,
                AlternateName = alternateName
            });
            Assert.NotNull(DisasterRecoveryResponse);
            DelayInTest(30);
            //// Get the created DisasterRecovery config - Primary
            var disasterRecoveryGetResponse = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, namespaceName);
            Assert.NotNull(disasterRecoveryGetResponse);
            Assert.AreEqual(RoleDisasterRecovery.Primary, disasterRecoveryGetResponse.Value.Role);
            //// Get the created DisasterRecovery config - Secondary
            var disasterRecoveryGetResponse_Sec =await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName2, namespaceName);
            Assert.NotNull(disasterRecoveryGetResponse_Sec);
            Assert.AreEqual(RoleDisasterRecovery.Secondary, disasterRecoveryGetResponse_Sec.Value.Role);
            //Get authorization rule thorugh Alias
            var getAuthoRuleAliasResponse = await DisasterRecoveryConfigsOperations.GetAuthorizationRuleAsync(resourceGroup, namespaceName, namespaceName, authorizationRuleName);
            Assert.AreEqual(getAuthoRuleAliasResponse.Value.Name, getNamespaceAuthorizationRulesResponse.Value.Name);
            var getAuthoruleListKeysResponse = await DisasterRecoveryConfigsOperations.ListKeysAsync(resourceGroup, namespaceName, namespaceName, authorizationRuleName);
            var disasterRecoveryGetResponse_Accepted =await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, namespaceName);
            while (DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, namespaceName).Result.Value.ProvisioningState!= ProvisioningStateDR.Succeeded)
            {
                DelayInTest(10);
            }
            //// Break Pairing
            await DisasterRecoveryConfigsOperations.BreakPairingAsync(resourceGroup, namespaceName, namespaceName);
            DelayInTest(10);
            disasterRecoveryGetResponse_Accepted = await DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, namespaceName);
            while (DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, namespaceName).Result.Value.ProvisioningState != ProvisioningStateDR.Succeeded)
            {
                DelayInTest(10);
            }
            var DisasterRecoveryResponse_update = DisasterRecoveryConfigsOperations.CreateOrUpdateAsync(resourceGroup, namespaceName, namespaceName, new ArmDisasterRecovery()
            {
                PartnerNamespace = np2.Id,
                AlternateName = alternateName
            });
            Assert.NotNull(DisasterRecoveryResponse_update);
            DelayInTest(10);
            while (DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName, namespaceName).Result.Value.ProvisioningState != ProvisioningStateDR.Succeeded)
            {
                DelayInTest(10);
            }
            // Fail over
            await DisasterRecoveryConfigsOperations.FailOverAsync(resourceGroup, namespaceName2, namespaceName);
            DelayInTest(10);
            while (DisasterRecoveryConfigsOperations.GetAsync(resourceGroup, namespaceName2, namespaceName).Result.Value.ProvisioningState != ProvisioningStateDR.Succeeded)
            {
                DelayInTest(10);
            }
            // Get all Disaster Recovery for a given NameSpace
            var getListisasterRecoveryResponse = DisasterRecoveryConfigsOperations.ListAsync(resourceGroup, namespaceName2);
            Assert.NotNull(getListisasterRecoveryResponse);
            //Assert.True(getListisasterRecoveryResponse.AsPages.Count<ArmDisasterRecovery>() >= 1);
            // Delete the DisasterRecovery
            await DisasterRecoveryConfigsOperations.DeleteAsync(resourceGroup, namespaceName2, namespaceName);
            // Delete Namespace using Async
            //await NamespacesClient.StartDeleteAsync(resourceGroup, namespaceName, new CancellationToken()).ConfigureAwait(false);
            ////NamespacesClient.DeleteWithHttpMessages(resourceGroup, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
            //await NamespacesClient.StartDeleteAsync(resourceGroup, namespaceName2, new CancellationToken()).ConfigureAwait(false);
        }
        public bool isContains(IList<AccessRights> accessRights, IList<AccessRights> accessRightsComp)
        {
            bool isAllContain = true;
            foreach (var rightDetail in accessRights)
            {
                bool isContain = false;
                foreach (var compareRight in accessRightsComp)
                {
                    if (compareRight == rightDetail)
                    {
                        isContain = true;
                        break;
                    }
                }
                if (isContain == false)
                {
                    isAllContain = false;
                }
            }
            return isAllContain;
        }
    }
}
