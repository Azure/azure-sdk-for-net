// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs.Tests;

using NUnit.Framework;

namespace Azure.Management.EventHub.Tests
{
    public partial class ScenarioTests : EventHubsManagementClientBase
    {
        [Test]
        public async Task NamespaceCreateGetUpdateDeleteAuthorizationRules()
        {
            var location = await GetLocation();
            var resourceGroupName = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            Subscription sub = await ArmClient.GetDefaultSubscriptionAsync();
            await sub.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName, new ResourceGroupData(location));;
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroupName, namespaceName,
                new EHNamespace()
                {
                    Location = location,
                    //Sku = new Sku("as")
                    Tags =
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                }
                );
            var np = (await WaitForCompletionAsync(createNamespaceResponse)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np.Name, namespaceName);
            DelayInTest(5);
            //get the created namespace
            var getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroupName, namespaceName);
            if (string.Compare(getNamespaceResponse.Value.ProvisioningState, "Succeeded", true) != 0)
                DelayInTest(5);
            getNamespaceResponse = await NamespacesOperations.GetAsync(resourceGroupName, namespaceName);
            Assert.NotNull(getNamespaceResponse);
            Assert.AreEqual("Succeeded", getNamespaceResponse.Value.ProvisioningState,StringComparer.CurrentCultureIgnoreCase.ToString());
            Assert.AreEqual(location, getNamespaceResponse.Value.Location);
            // Create a namespace AuthorizationRule
            var authorizationRuleName = Recording.GenerateAssetName(Helper.AuthorizationRulesPrefix);
            string createPrimaryKey = Recording.GetVariable("authorizaRuNa", Helper.GenerateRandomKey());
            var createAutorizationRuleParameter = new AuthorizationRule()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            var createNamespaceAuthorizationRuleResponse = await NamespacesOperations.CreateOrUpdateAuthorizationRuleAsync(resourceGroupName, namespaceName,
                authorizationRuleName, createAutorizationRuleParameter);
            Assert.NotNull(createNamespaceAuthorizationRuleResponse);
            Assert.True(createNamespaceAuthorizationRuleResponse.Value.Rights.Count == createAutorizationRuleParameter.Rights.Count);
            Assert.True( isContains(createAutorizationRuleParameter.Rights, createNamespaceAuthorizationRuleResponse.Value.Rights));
            // Get default namespace AuthorizationRules
            var getNamespaceAuthorizationRulesResponse = await NamespacesOperations.GetAuthorizationRuleAsync(resourceGroupName, namespaceName, Helper.DefaultNamespaceAuthorizationRule);
            Assert.NotNull(getNamespaceAuthorizationRulesResponse);
            Assert.AreEqual(getNamespaceAuthorizationRulesResponse.Value.Name, Helper.DefaultNamespaceAuthorizationRule);
            var accessRights = new List<AccessRights>() { AccessRights.Listen, AccessRights.Send, AccessRights.Manage};
            Assert.True(isContains(getNamespaceAuthorizationRulesResponse.Value.Rights, accessRights));
            // Get created namespace AuthorizationRules
            getNamespaceAuthorizationRulesResponse =await NamespacesOperations.GetAuthorizationRuleAsync(resourceGroupName, namespaceName, authorizationRuleName);
            Assert.NotNull(getNamespaceAuthorizationRulesResponse);
            Assert.True(getNamespaceAuthorizationRulesResponse.Value.Rights.Count == createAutorizationRuleParameter.Rights.Count);
            Assert.True(isContains(createAutorizationRuleParameter.Rights, getNamespaceAuthorizationRulesResponse.Value.Rights));
            // Get all namespaces AuthorizationRules
            var getAllNamespaceAuthorizationRulesResponse = NamespacesOperations.ListAuthorizationRulesAsync(resourceGroupName, namespaceName);
            Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
            var getAllNpsAuthResp = await getAllNamespaceAuthorizationRulesResponse.ToEnumerableAsync();
            Assert.True(getAllNpsAuthResp.Count() > 1);
            bool isContainAuthorizationRuleName=false;
            bool isContainEventHubManagementHelper=false;
            foreach (var Authrule in getAllNpsAuthResp)
            {
                if (Authrule.Name == authorizationRuleName)
                {
                    isContainAuthorizationRuleName = true;
                    break;
                }
            }
            foreach (var Authrule in getAllNpsAuthResp)
            {
                if (Authrule.Name == Helper.DefaultNamespaceAuthorizationRule)
                {
                    isContainEventHubManagementHelper = true;
                    break;
                }
            }
            Assert.True(isContainAuthorizationRuleName);
            Assert.True(isContainEventHubManagementHelper);
            // Update namespace authorizationRule
            string updatePrimaryKey = Recording.GetVariable("UpdatePrimaryKey", Helper.GenerateRandomKey());
            AuthorizationRule updateNamespaceAuthorizationRuleParameter = new AuthorizationRule();
            updateNamespaceAuthorizationRuleParameter.Rights.Add(AccessRights.Listen);
            var updateNamespaceAuthorizationRuleResponse =await NamespacesOperations.CreateOrUpdateAuthorizationRuleAsync(resourceGroupName,
                namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);
            Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
            Assert.AreEqual(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Value.Name);
            Assert.True(updateNamespaceAuthorizationRuleResponse.Value.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
            Assert.True(isContains(updateNamespaceAuthorizationRuleParameter.Rights, updateNamespaceAuthorizationRuleResponse.Value.Rights));
            // Get the updated namespace AuthorizationRule
            var getNamespaceAuthorizationRuleResponse = await NamespacesOperations.GetAuthorizationRuleAsync(resourceGroupName, namespaceName,
                authorizationRuleName);
            Assert.NotNull(getNamespaceAuthorizationRuleResponse);
            Assert.AreEqual(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Value.Name);
            Assert.True(getNamespaceAuthorizationRuleResponse.Value.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
            Assert.True(isContains(updateNamespaceAuthorizationRuleParameter.Rights, getNamespaceAuthorizationRuleResponse.Value.Rights));
            // Get the connection string to the namespace for a Authorization rule created
            var listKeysResponse =await NamespacesOperations.ListKeysAsync(resourceGroupName, namespaceName, authorizationRuleName);
            Assert.NotNull(listKeysResponse);
            Assert.NotNull(listKeysResponse.Value.PrimaryConnectionString);
            Assert.NotNull(listKeysResponse.Value.SecondaryConnectionString);
            // Regenerate connection string to the namespace for a Authorization rule created
            var NewKeysResponse_primary = await NamespacesOperations.RegenerateKeysAsync(resourceGroupName, namespaceName, authorizationRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey));
            Assert.NotNull(NewKeysResponse_primary);
            // Assert.AreNotEqual(NewKeysResponse_primary.Value.PrimaryConnectionString, listKeysResponse.Value.PrimaryConnectionString);
            Assert.AreEqual(NewKeysResponse_primary.Value.SecondaryConnectionString, listKeysResponse.Value.SecondaryConnectionString);
            // Regenerate connection string to the namespace for a Authorization rule created
            var NewKeysResponse_secondary =await NamespacesOperations.RegenerateKeysAsync(resourceGroupName, namespaceName, authorizationRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey));
            Assert.NotNull(NewKeysResponse_secondary);
            // Assert.AreNotEqual(NewKeysResponse_secondary.Value.PrimaryConnectionString, listKeysResponse.Value.PrimaryConnectionString);
            // Assert.AreNotEqual(NewKeysResponse_secondary.Value.SecondaryConnectionString, listKeysResponse.Value.SecondaryConnectionString);
            // Delete namespace authorizationRule
            await NamespacesOperations.DeleteAuthorizationRuleAsync(resourceGroupName, namespaceName, authorizationRuleName);
            DelayInTest(5);
            // Delete namespace
            await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroupName, namespaceName));
        }
    }
}
