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
        public void WCFRelayCreateGetUpdateDeleteAuthorizationRules_length()
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
                Assert.Equal(2, createNamespaceResponse.Tags.Count);
                Assert.Equal("Microsoft.Relay/Namespaces", createNamespaceResponse.Type);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = RelayManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState.ToString(), "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = RelayManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState.ToString(), StringComparer.CurrentCultureIgnoreCase);                
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);
                
                // Get all namespaces created within a resourceGroup
                var getAllNamespacesResponse = RelayManagementClient.Namespaces.ListByResourceGroup(resourceGroup);
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);
                Assert.True(getAllNamespacesResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Get all namespaces created within the subscription irrespective of the resourceGroup
                getAllNamespacesResponse = RelayManagementClient.Namespaces.List();
                Assert.NotNull(getAllNamespacesResponse);
                Assert.True(getAllNamespacesResponse.Count() >= 1);
                Assert.Contains(getAllNamespacesResponse, ns => ns.Name == namespaceName);

                // Create WCF Relay  - 
                var wcfRelayName = RelayManagementHelper.WcfPrefix + "thisisthenamewithmorethan53charschecktoverifytheremovlaof50charsnamelengthlimit";
                var createdWCFRelayResponse = RelayManagementClient.WCFRelays.CreateOrUpdate(resourceGroup, namespaceName, wcfRelayName, new WcfRelay()
                {
                    RelayType = Relaytype.NetTcp,
                    RequiresClientAuthorization = true,
                    RequiresTransportSecurity = true
                });

                Assert.NotNull(createdWCFRelayResponse);
                Assert.Equal(createdWCFRelayResponse.Name, wcfRelayName);
                Assert.True(createdWCFRelayResponse.RequiresClientAuthorization);
                Assert.True(createdWCFRelayResponse.RequiresTransportSecurity);
                Assert.Equal(Relaytype.NetTcp, createdWCFRelayResponse.RelayType);

                var getWCFRelaysResponse = RelayManagementClient.WCFRelays.Get(resourceGroup, namespaceName, wcfRelayName);
                
                // Create a WCFRelay AuthorizationRule
                var authorizationRuleName = RelayManagementHelper.AuthorizationRulesPrefix + "thisisthenamewithmorethan53charschecktoverifytheremovlaof50charsnamelengthlimit";
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", RelayManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new AuthorizationRule()
                {
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = RelayManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var test = RelayManagementClient.WCFRelays.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName, wcfRelayName, authorizationRuleName, createAutorizationRuleParameter);

                var createNamespaceAuthorizationRuleResponse = RelayManagementClient.WCFRelays.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName, wcfRelayName,                
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(createNamespaceAuthorizationRuleResponse.Rights, r => r == right);
                }

                // Get created WCFRelay AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = RelayManagementClient.WCFRelays.GetAuthorizationRule(resourceGroup, namespaceName, wcfRelayName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == right);
                }

                // Get all WCFRelay AuthorizationRules
                var getAllNamespaceAuthorizationRulesResponse = RelayManagementClient.WCFRelays.ListAuthorizationRules(resourceGroup, namespaceName,wcfRelayName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() >= 1);
                Assert.Contains(getAllNamespaceAuthorizationRulesResponse, ns => ns.Name == authorizationRuleName);

                // Update WCFRelay authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", RelayManagementHelper.GenerateRandomKey());
                AuthorizationRule updateNamespaceAuthorizationRuleParameter = new AuthorizationRule();
                updateNamespaceAuthorizationRuleParameter.Rights = new List<AccessRights?>() { AccessRights.Listen };

                var updateNamespaceAuthorizationRuleResponse = RelayManagementClient.WCFRelays.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, wcfRelayName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(updateNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the WCFRelay namespace AuthorizationRule
                var getNamespaceAuthorizationRuleResponse = RelayManagementClient.WCFRelays.GetAuthorizationRule(resourceGroup, namespaceName, wcfRelayName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(getNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the connectionString to the WCFRelay for a Authorization rule created
                var listKeysResponse = RelayManagementClient.WCFRelays.ListKeys(resourceGroup, namespaceName, wcfRelayName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                // Regenerate AuthorizationRules
                var regenerateKeysParameters = new RegenerateAccessKeyParameters();
                regenerateKeysParameters.KeyType = KeyType.PrimaryKey;

                //Primary Key
                var regenerateKeysPrimaryResponse = RelayManagementClient.WCFRelays.RegenerateKeys(resourceGroup, namespaceName, wcfRelayName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotNull(regenerateKeysPrimaryResponse);
                Assert.NotEqual(regenerateKeysPrimaryResponse.PrimaryKey, listKeysResponse.PrimaryKey);
                Assert.Equal(regenerateKeysPrimaryResponse.SecondaryKey, listKeysResponse.SecondaryKey);

                regenerateKeysParameters.KeyType = KeyType.SecondaryKey;

                //Secondary Key
                var regenerateKeysSecondaryResponse = RelayManagementClient.WCFRelays.RegenerateKeys(resourceGroup, namespaceName, wcfRelayName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotNull(regenerateKeysSecondaryResponse);
                Assert.NotEqual(regenerateKeysSecondaryResponse.SecondaryKey, listKeysResponse.SecondaryKey);
                Assert.Equal(regenerateKeysSecondaryResponse.PrimaryKey, regenerateKeysPrimaryResponse.PrimaryKey);

                // Delete WCFRelay authorizationRule
                RelayManagementClient.WCFRelays.DeleteAuthorizationRule(resourceGroup, namespaceName, wcfRelayName, authorizationRuleName);

                try
                {
                    RelayManagementClient.WCFRelays.Delete(resourceGroup, namespaceName, wcfRelayName);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

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

