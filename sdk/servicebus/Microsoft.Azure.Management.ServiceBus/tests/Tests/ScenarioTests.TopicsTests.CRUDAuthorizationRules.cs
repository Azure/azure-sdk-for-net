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
        public void TopicsCreateGetUpdateDeleteAuthorizationRules()
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

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
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

                // Create Topic
                var topicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);
                
                var createTopicResponse = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName,
                new SBTopic() {  EnablePartitioning = true });
                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);
                
                // Get the created Topic
                var getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, createTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);                

                // Create a topic AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(ServiceBusManagementHelper.AuthorizationRulesPrefix);                
                var createAutorizationRuleParameter = new SBAuthorizationRule()
                {
                    Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = ServiceBusManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);
                var createTopicAuthorizationRuleResponse = ServiceBusManagementClient.Topics.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,topicName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createTopicAuthorizationRuleResponse);
                Assert.True(createTopicAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(createTopicAuthorizationRuleResponse.Rights, r => r == right);
                }

                // Get created Topics AuthorizationRules
                var getTopicsAuthorizationRulesResponse = ServiceBusManagementClient.Topics.GetAuthorizationRule(resourceGroup, namespaceName, topicName, authorizationRuleName);
                Assert.NotNull(getTopicsAuthorizationRulesResponse);
                Assert.True(getTopicsAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(getTopicsAuthorizationRulesResponse.Rights, r => r == right);
                }

                // Get all Topics AuthorizationRules
                var getAllNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Topics.ListAuthorizationRules(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.Single(getAllNamespaceAuthorizationRulesResponse);
                Assert.Contains(getAllNamespaceAuthorizationRulesResponse, ns => ns.Name == authorizationRuleName);                

                // Update topics authorizationRule
          
                SBAuthorizationRule updateTopicsAuthorizationRuleParameter = new SBAuthorizationRule();
                updateTopicsAuthorizationRuleParameter.Rights = new List<string>() { AccessRights.Listen };

                var updateTopicAuthorizationRuleResponse = ServiceBusManagementClient.Topics.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName,topicName, authorizationRuleName, updateTopicsAuthorizationRuleParameter);

                Assert.NotNull(updateTopicAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateTopicAuthorizationRuleResponse.Name);
                Assert.True(updateTopicAuthorizationRuleResponse.Rights.Count == updateTopicsAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateTopicsAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(updateTopicAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the updated Topics AuthorizationRule
                var getTopicAuthorizationRuleResponse = ServiceBusManagementClient.Topics.GetAuthorizationRule(resourceGroup, namespaceName,topicName,
                    authorizationRuleName);
                Assert.NotNull(getTopicAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getTopicAuthorizationRuleResponse.Name);
                Assert.True(getTopicAuthorizationRuleResponse.Rights.Count == updateTopicsAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateTopicsAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(getTopicAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the connectionString to the Topics for a Authorization rule created
                var listKeysTopicsResponse = ServiceBusManagementClient.Topics.ListKeys(resourceGroup, namespaceName, topicName, authorizationRuleName);
                Assert.NotNull(listKeysTopicsResponse);
                Assert.NotNull(listKeysTopicsResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysTopicsResponse.SecondaryConnectionString);
                
                // Regenerate Keys for the create Authorization rules
                var regenerateKeysTopicsParameters = new RegenerateAccessKeyParameters();
                regenerateKeysTopicsParameters.KeyType = KeyType.PrimaryKey;
                
                var regeneratePrimaryKeysTopicsResposnse = ServiceBusManagementClient.Topics.RegenerateKeys(resourceGroup, namespaceName, topicName, authorizationRuleName, regenerateKeysTopicsParameters);

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    var beforeKey = listKeysTopicsResponse.PrimaryKey;
                    var afterKey = regeneratePrimaryKeysTopicsResposnse.PrimaryKey;
                    Assert.NotEqual(afterKey, beforeKey);
                }

                Assert.Equal(listKeysTopicsResponse.SecondaryKey, regeneratePrimaryKeysTopicsResposnse.SecondaryKey);

                listKeysTopicsResponse = regeneratePrimaryKeysTopicsResposnse;
                
                var regenerateSecondaryKeysTopicsResposnse = ServiceBusManagementClient.Topics.RegenerateKeys(resourceGroup, namespaceName, topicName, authorizationRuleName, new RegenerateAccessKeyParameters() { KeyType = KeyType.SecondaryKey });

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    var beforeKey = listKeysTopicsResponse.SecondaryKey;
                    var afterKey = regenerateSecondaryKeysTopicsResposnse.SecondaryKey;
                    Assert.NotEqual(afterKey, beforeKey);
                }

                Assert.Equal(listKeysTopicsResponse.PrimaryKey, regenerateSecondaryKeysTopicsResposnse.PrimaryKey);

                listKeysTopicsResponse = regenerateSecondaryKeysTopicsResposnse;
                              

                RegenerateAccessKeyParameters keyObject = new RegenerateAccessKeyParameters()
                {
                    Key = ServiceBusManagementHelper.GenerateRandomKey(),
                    KeyType = KeyType.PrimaryKey
                };

                regeneratePrimaryKeysTopicsResposnse = ServiceBusManagementClient.Topics.RegenerateKeys(resourceGroup, namespaceName, topicName, authorizationRuleName, keyObject);
                              

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Assert.Equal(keyObject.Key, regeneratePrimaryKeysTopicsResposnse.PrimaryKey);
                    Assert.Equal(listKeysTopicsResponse.SecondaryKey, regeneratePrimaryKeysTopicsResposnse.SecondaryKey);
                }
                else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    Assert.Equal("Sanitized", regeneratePrimaryKeysTopicsResposnse.PrimaryKey);
                    Assert.Equal("Sanitized", regeneratePrimaryKeysTopicsResposnse.SecondaryKey);
                }

                listKeysTopicsResponse = regeneratePrimaryKeysTopicsResposnse;
                                
                keyObject = new RegenerateAccessKeyParameters()
                {
                    Key = ServiceBusManagementHelper.GenerateRandomKey(),
                    KeyType = KeyType.SecondaryKey
                };

                regenerateSecondaryKeysTopicsResposnse = ServiceBusManagementClient.Topics.RegenerateKeys(resourceGroup, namespaceName, topicName, authorizationRuleName, keyObject);
                
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Assert.Equal(keyObject.Key, regenerateSecondaryKeysTopicsResposnse.SecondaryKey);
                    Assert.Equal(listKeysTopicsResponse.PrimaryKey, regenerateSecondaryKeysTopicsResposnse.PrimaryKey);
                }
                else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    Assert.Equal("Sanitized", regenerateSecondaryKeysTopicsResposnse.SecondaryKey);
                    Assert.Equal("Sanitized", regenerateSecondaryKeysTopicsResposnse.PrimaryKey);
                }


                // Delete Topic authorizationRule
                ServiceBusManagementClient.Topics.DeleteAuthorizationRule(resourceGroup, namespaceName, topicName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                
                // Delete Topic
                ServiceBusManagementClient.Topics.Delete(resourceGroup, namespaceName, topicName);
                
                // Delete namespace
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                
            }
        }
    }
}
