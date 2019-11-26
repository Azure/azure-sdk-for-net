﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public void QueuesCreateGetUpdateDeleteAuthorizationRules()
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
                 
                //Get the created namespace
                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create Queue
                var queueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                
                var createQueueResponse = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName,
                new SBQueue() { EnablePartitioning = true });

                Assert.NotNull(createQueueResponse);
                Assert.Equal(createQueueResponse.Name, queueName);
                
                // Get the created Queue
                var getQueueResponse = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                Assert.NotNull(getQueueResponse);
                Assert.Equal(EntityStatus.Active, getQueueResponse.Status);
                Assert.Equal(getQueueResponse.Name, queueName);                

                // Create a queue AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(ServiceBusManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SBAuthorizationRule()
                {
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = ServiceBusManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createQueueAuthorizationRuleResponse = ServiceBusManagementClient.Queues.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,queueName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createQueueAuthorizationRuleResponse);
                Assert.True(createQueueAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(createQueueAuthorizationRuleResponse.Rights, r => r == right);
                }

                // Get created queues AuthorizationRules
                var getQueueAuthorizationRulesResponse = ServiceBusManagementClient.Queues.GetAuthorizationRule(resourceGroup, namespaceName,queueName, authorizationRuleName);
                Assert.NotNull(getQueueAuthorizationRulesResponse);
                Assert.True(getQueueAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.Contains(getQueueAuthorizationRulesResponse.Rights, r => r == right);
                }

                // Get all queues AuthorizationRules
                var getAllNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Queues.ListAuthorizationRules(resourceGroup, namespaceName, queueName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.Single(getAllNamespaceAuthorizationRulesResponse);
                Assert.Contains(getAllNamespaceAuthorizationRulesResponse, ns => ns.Name == authorizationRuleName);                

                // Update queues authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                SBAuthorizationRule updateQueuesAuthorizationRuleParameter = new SBAuthorizationRule();
                updateQueuesAuthorizationRuleParameter.Rights = new List<AccessRights?>() { AccessRights.Listen };

                var updateQueueAuthorizationRuleResponse = ServiceBusManagementClient.Queues.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName,queueName, authorizationRuleName, updateQueuesAuthorizationRuleParameter);

                Assert.NotNull(updateQueueAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateQueueAuthorizationRuleResponse.Name);
                Assert.True(updateQueueAuthorizationRuleResponse.Rights.Count == updateQueuesAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateQueuesAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(updateQueueAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the updated queues AuthorizationRule
                var getQueueAuthorizationRuleResponse = ServiceBusManagementClient.Queues.GetAuthorizationRule(resourceGroup, namespaceName,queueName,
                    authorizationRuleName);
                Assert.NotNull(getQueueAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getQueueAuthorizationRuleResponse.Name);
                Assert.True(getQueueAuthorizationRuleResponse.Rights.Count == updateQueuesAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateQueuesAuthorizationRuleParameter.Rights)
                {
                    Assert.Contains(getQueueAuthorizationRuleResponse.Rights, r => r.Equals(right));
                }

                // Get the connectionString to the queues for a Authorization rule created
                var listKeysResponse = ServiceBusManagementClient.Queues.ListKeys(resourceGroup, namespaceName, queueName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                
                // Regenerate Keys for the create Authorization rules
                var regenerateKeysParameters = new RegenerateAccessKeyParameters();
                regenerateKeysParameters.KeyType = KeyType.PrimaryKey;
                
                var regenerateKeysResposnse = ServiceBusManagementClient.Queues.RegenerateKeys(resourceGroup, namespaceName, queueName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotEqual(listKeysResponse.PrimaryKey, regenerateKeysResposnse.PrimaryKey);
                Assert.NotNull(regenerateKeysResposnse.SecondaryConnectionString);
                Assert.NotNull(regenerateKeysResposnse.SecondaryKey);

                regenerateKeysParameters.KeyType = KeyType.SecondaryKey;

                regenerateKeysResposnse = ServiceBusManagementClient.Queues.RegenerateKeys(resourceGroup, namespaceName, queueName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotEqual(listKeysResponse.SecondaryKey, regenerateKeysResposnse.SecondaryKey);
                Assert.NotNull(regenerateKeysResposnse.PrimaryConnectionString);
                Assert.NotNull(regenerateKeysResposnse.SecondaryConnectionString);
                Assert.NotNull(regenerateKeysResposnse.PrimaryKey);                

                // Delete Queue authorizationRule
                ServiceBusManagementClient.Queues.DeleteAuthorizationRule(resourceGroup, namespaceName, queueName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                
                // Delete queue  
                ServiceBusManagementClient.Queues.Delete(resourceGroup, namespaceName, queueName);
                
                // Delete namespace
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                
            }
        }
    }
}
