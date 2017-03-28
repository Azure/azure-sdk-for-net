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
    using Microsoft.Azure.Management.Relay;
    using Microsoft.Azure.Management.Relay.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Relay.Tests.TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void HybridConnectionsCreateGetUpdateDeleteAuthorizationRules()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location =  this.ResourceManagementClient.GetLocationFromProvider();
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(RelayManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create Namespace
                var namespaceName = TestUtilities.GenerateName(RelayManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.RelayManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new RelayNamespace()
                    {
                        Location = location,
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }

                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);
                Assert.Equal(createNamespaceResponse.Tags.Count, 2);
                Assert.Equal(createNamespaceResponse.Type, "Microsoft.Relay/namespaces");
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = RelayManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = RelayManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);                
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                
                // Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = RelayManagementClient.Namespaces.ListByResourceGroup(resourceGroup);
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.True(getAllNamespacesResponse.Any(ns => ns.Name == namespaceName));
                Assert.True(getAllNamespacesResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = RelayManagementClient.Namespaces.List();
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.True(getAllNamespacesResponse.Any(ns => ns.Name == namespaceName));

                // Create Relay HybridConnections  - 
                var hybridConnectionsName = TestUtilities.GenerateName(RelayManagementHelper.HybridPrefix);
                var createdWCFRelayResponse = RelayManagementClient.HybridConnections.CreateOrUpdate(resourceGroup, namespaceName, hybridConnectionsName, new HybridConnection()
                {                    
                    RequiresClientAuthorization = true,
                });

                Assert.NotNull(createdWCFRelayResponse);
                Assert.Equal(createdWCFRelayResponse.Name, hybridConnectionsName);
                Assert.True(createdWCFRelayResponse.RequiresClientAuthorization);

                var getWCFRelaysResponse = RelayManagementClient.HybridConnections.Get(resourceGroup, namespaceName, hybridConnectionsName);

                // Create a HybridConnections AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(RelayManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", RelayManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRule()
                {
                    Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = RelayManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var test = RelayManagementClient.HybridConnections.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName, hybridConnectionsName, authorizationRuleName, createAutorizationRuleParameter);

                var createNamespaceAuthorizationRuleResponse = RelayManagementClient.HybridConnections.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName, hybridConnectionsName,                
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Any(r => r == right));
                }                

                // Get created HybridConnections AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = RelayManagementClient.HybridConnections.GetAuthorizationRule(resourceGroup, namespaceName, hybridConnectionsName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                // Get all HybridConnections AuthorizationRules
                var getAllNamespaceAuthorizationRulesResponse = RelayManagementClient.HybridConnections.ListAuthorizationRules(resourceGroup, namespaceName, hybridConnectionsName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() >= 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));

                // Update HybridConnections authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", RelayManagementHelper.GenerateRandomKey());
                SharedAccessAuthorizationRule updateNamespaceAuthorizationRuleParameter = new SharedAccessAuthorizationRule();
                updateNamespaceAuthorizationRuleParameter.Rights = new List<string>() { AccessRights.Listen };

                var updateNamespaceAuthorizationRuleResponse = RelayManagementClient.HybridConnections.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, hybridConnectionsName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the HybridConnections namespace AuthorizationRule
                var getNamespaceAuthorizationRuleResponse = RelayManagementClient.HybridConnections.GetAuthorizationRule(resourceGroup, namespaceName, hybridConnectionsName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the connectionString to the HybridConnections for a Authorization rule created
                var listKeysResponse = RelayManagementClient.HybridConnections.ListKeys(resourceGroup, namespaceName, hybridConnectionsName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                // Regenerate AuthorizationRules
                var regenerateKeysParameters = new RegenerateKeysParameters();
                regenerateKeysParameters.PolicyKey = PolicyKey.PrimaryKey;

                //Primary Key
                var regenerateKeysPrimaryResponse = RelayManagementClient.HybridConnections.RegenerateKeys(resourceGroup, namespaceName, hybridConnectionsName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotNull(regenerateKeysPrimaryResponse);
                Assert.NotEqual(regenerateKeysPrimaryResponse.PrimaryKey, listKeysResponse.PrimaryKey);
                Assert.Equal(regenerateKeysPrimaryResponse.SecondaryKey, listKeysResponse.SecondaryKey);


                regenerateKeysParameters.PolicyKey = PolicyKey.SecondaryKey;

                //Secondary Key
                var regenerateKeysSecondaryResponse = RelayManagementClient.HybridConnections.RegenerateKeys(resourceGroup, namespaceName, hybridConnectionsName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotNull(regenerateKeysSecondaryResponse);
                Assert.NotEqual(regenerateKeysSecondaryResponse.SecondaryKey, listKeysResponse.SecondaryKey);
                Assert.Equal(regenerateKeysSecondaryResponse.PrimaryKey, regenerateKeysPrimaryResponse.PrimaryKey);


                // Delete HybridConnections authorizationRule
                RelayManagementClient.HybridConnections.DeleteAuthorizationRule(resourceGroup, namespaceName, hybridConnectionsName, authorizationRuleName);

                try
                {
                    RelayManagementClient.HybridConnections.Delete(resourceGroup, namespaceName, hybridConnectionsName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }

                try
                {
                    // Delete namespace
                    RelayManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
            }
        }
    }
}
