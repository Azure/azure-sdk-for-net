//  
//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


namespace Relay.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.Relay;
    using Microsoft.Azure.Management.Relay.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Relay.Tests.TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void NamespaceCreateGetUpdateDeleteAuthorizationRules()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location =  this.ResourceManagementClient.GetLocationFromProvider();
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(RelayManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create a namespace
                var namespaceName = TestUtilities.GenerateName(RelayManagementHelper.NamespacePrefix);
                var createNamespaceResponse = RelayManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new RelayNamespace()
                    {
                        Location = location,
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = RelayManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState.ToString(), "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = RelayManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState.ToString(), StringComparer.CurrentCultureIgnoreCase);                
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create a namespace AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(RelayManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", RelayManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new AuthorizationRule()
                {
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = RelayManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createNamespaceAuthorizationRuleResponse = RelayManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(createNamespaceAuthorizationRuleResponse.Rights, r => r == right);
                }

                // Get default namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = RelayManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, RelayManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, RelayManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Listen);
                Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Send);
                Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Manage);

                // Get created namespace AuthorizationRules
                getNamespaceAuthorizationRulesResponse = RelayManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == right);
                }

                // Get all namespaces AuthorizationRules 
                var getAllNamespaceAuthorizationRulesResponse = RelayManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() > 1);
                Assert.Contains(getAllNamespaceAuthorizationRulesResponse, ns => ns.Name == authorizationRuleName);
                Assert.Contains(getAllNamespaceAuthorizationRulesResponse, auth => auth.Name == RelayManagementHelper.DefaultNamespaceAuthorizationRule);

                // Update namespace authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", RelayManagementHelper.GenerateRandomKey());
                AuthorizationRule updateNamespaceAuthorizationRuleParameter = new AuthorizationRule();
                updateNamespaceAuthorizationRuleParameter.Rights = new List<AccessRights?>() { AccessRights.Listen };
                var updateNamespaceAuthorizationRuleResponse = RelayManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(updateNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the updated namespace AuthorizationRule
                var getNamespaceAuthorizationRuleResponse = RelayManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName,authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(getNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the connectionString to the namespace for a Authorization rule created
                var listKeysResponse = RelayManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                // Regenerate AuthorizationRules
                var regenerateKeysParameters = new RegenerateAccessKeyParameters();
                regenerateKeysParameters.KeyType = KeyType.PrimaryKey;

                //Primary Key
                var regenerateKeysPrimaryResponse = RelayManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotNull(regenerateKeysPrimaryResponse);
                Assert.NotEqual(regenerateKeysPrimaryResponse.PrimaryKey, listKeysResponse.PrimaryKey);
                Assert.Equal(regenerateKeysPrimaryResponse.SecondaryKey, listKeysResponse.SecondaryKey);


                regenerateKeysParameters.KeyType = KeyType.SecondaryKey;
                //Secondary Key
                var regenerateKeysSecondaryResponse = RelayManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotNull(regenerateKeysSecondaryResponse);
                Assert.NotEqual(regenerateKeysSecondaryResponse.SecondaryKey, listKeysResponse.SecondaryKey);
                Assert.Equal(regenerateKeysSecondaryResponse.PrimaryKey, regenerateKeysPrimaryResponse.PrimaryKey);
                // Delete namespace authorizationRule
                RelayManagementClient.Namespaces.DeleteAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                try
                {
                    // Delete namespace
                    RelayManagementClient.Namespaces.Delete(resourceGroup, namespaceName); 
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
            }
        }
    }
}

