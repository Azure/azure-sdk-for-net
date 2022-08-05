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
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void NamespaceCreateGetUpdateDeleteAuthorizationRules()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create a namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);
                var createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
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

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Get the created namespace
                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create a namespace AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(ServiceBusManagementHelper.AuthorizationRulesPrefix);                

                var createAutorizationRuleParameter = new SBAuthorizationRule()
                {
                    Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = ServiceBusManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createNamespaceAuthorizationRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(createNamespaceAuthorizationRuleResponse.Rights, r => r == right);
                }

                // Get default namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, ServiceBusManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, ServiceBusManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Listen);
                Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Send);
                Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Manage);

                // Get created namespace AuthorizationRules
                getNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == right);
                }

                // Get all namespaces AuthorizationRules 
                var getAllNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() > 1);
                Assert.Contains(getAllNamespaceAuthorizationRulesResponse, ns => ns.Name == authorizationRuleName);
                Assert.Contains(getAllNamespaceAuthorizationRulesResponse, auth => auth.Name == ServiceBusManagementHelper.DefaultNamespaceAuthorizationRule);

                SBAuthorizationRule updateNamespaceAuthorizationRuleParameter = new SBAuthorizationRule();
                updateNamespaceAuthorizationRuleParameter.Rights = new List<string>() { AccessRights.Listen };

                var updateNamespaceAuthorizationRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(updateNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the updated namespace AuthorizationRule
                var getNamespaceAuthorizationRuleResponse = ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(getNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the connectionString to the namespace for a Authorization rule created
                var listKeysResponse = ServiceBusManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                // Regenerate Keys for the create Authorization rules
                var regenerateKeysParameters = new RegenerateAccessKeyParameters();
                regenerateKeysParameters.KeyType = KeyType.PrimaryKey;

                var regeneratePrimaryKeysResponse = ServiceBusManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, regenerateKeysParameters);

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    var beforeKey = listKeysResponse.PrimaryKey;
                    var afterKey = regeneratePrimaryKeysResponse.PrimaryKey;
                    Assert.NotEqual(afterKey, beforeKey);
                }

                Assert.Equal(listKeysResponse.SecondaryKey, regeneratePrimaryKeysResponse.SecondaryKey);
                

                listKeysResponse = regeneratePrimaryKeysResponse;

                var regenerateSecondaryKeysResponse = ServiceBusManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, new RegenerateAccessKeyParameters() { KeyType = KeyType.SecondaryKey });

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    var beforeKey = regeneratePrimaryKeysResponse.SecondaryKey;
                    var afterKey = regenerateSecondaryKeysResponse.SecondaryKey;
                    Assert.NotEqual(afterKey, beforeKey);
                }

                Assert.Equal(listKeysResponse.PrimaryKey, regenerateSecondaryKeysResponse.PrimaryKey);
                listKeysResponse = regenerateSecondaryKeysResponse;

                RegenerateAccessKeyParameters keyObject = new RegenerateAccessKeyParameters()
                {
                    Key = ServiceBusManagementHelper.GenerateRandomKey(),
                    KeyType = KeyType.PrimaryKey
                };
                var regeneratePrimaryKeyResponse = ServiceBusManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, keyObject);
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Assert.Equal(keyObject.Key, regeneratePrimaryKeyResponse.PrimaryKey);
                    Assert.Equal(listKeysResponse.SecondaryKey, regeneratePrimaryKeyResponse.SecondaryKey);
                }
                else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    Assert.Equal("Sanitized", regeneratePrimaryKeyResponse.PrimaryKey);
                    Assert.Equal("Sanitized", regeneratePrimaryKeyResponse.SecondaryKey);
                }
                
                listKeysResponse = regeneratePrimaryKeyResponse;
                 keyObject = new RegenerateAccessKeyParameters()
                {
                    Key = ServiceBusManagementHelper.GenerateRandomKey(),
                    KeyType = KeyType.SecondaryKey
                };

                var regenerateSecondaryKeyResponse = ServiceBusManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, keyObject);

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Assert.Equal(keyObject.Key, regenerateSecondaryKeyResponse.SecondaryKey);
                    Assert.Equal(listKeysResponse.PrimaryKey, regenerateSecondaryKeyResponse.PrimaryKey);
                }
                else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    Assert.Equal("Sanitized", regenerateSecondaryKeyResponse.SecondaryKey);
                    Assert.Equal("Sanitized", regenerateSecondaryKeyResponse.PrimaryKey);
                }                              
                

                // Delete namespace authorizationRule
                ServiceBusManagementClient.Namespaces.DeleteAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                
                // Delete namespace
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName); 
                
            }
        }
    }
}
