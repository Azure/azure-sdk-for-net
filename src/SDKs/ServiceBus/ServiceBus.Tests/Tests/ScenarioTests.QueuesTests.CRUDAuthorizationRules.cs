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
        public void QueuesCreateGetUpdateDeleteAuthorizationRules()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = "Standard",
                            Tier = "Standard"
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
                Assert.Equal(NamespaceState.Active , getNamespaceResponse.Status);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create Queue
                var queueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                
                var createQueueResponse = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName,
                new QueueCreateOrUpdateParameters()
                {
                    Location = location
                });

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
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Name = authorizationRuleName,
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = ServiceBusManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createQueueAuthorizationRuleResponse = ServiceBusManagementClient.Queues.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,queueName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createQueueAuthorizationRuleResponse);
                Assert.True(createQueueAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(createQueueAuthorizationRuleResponse.Rights.Any(r => r == right));
                }

                // Get created queues AuthorizationRules
                var getQueueAuthorizationRulesResponse = ServiceBusManagementClient.Queues.GetAuthorizationRule(resourceGroup, namespaceName,queueName, authorizationRuleName);
                Assert.NotNull(getQueueAuthorizationRulesResponse);
                Assert.True(getQueueAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(getQueueAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                // Get all queues AuthorizationRules
                var getAllNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Queues.ListAuthorizationRules(resourceGroup, namespaceName, queueName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.Equal(getAllNamespaceAuthorizationRulesResponse.Count(), 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));                

                // Update queues authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                SharedAccessAuthorizationRuleCreateOrUpdateParameters updateQueuesAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters();
                updateQueuesAuthorizationRuleParameter.Rights = new List<AccessRights?>() { AccessRights.Listen };

                var updateQueueAuthorizationRuleResponse = ServiceBusManagementClient.Queues.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName,queueName, authorizationRuleName, updateQueuesAuthorizationRuleParameter);

                Assert.NotNull(updateQueueAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateQueueAuthorizationRuleResponse.Name);
                Assert.True(updateQueueAuthorizationRuleResponse.Rights.Count == updateQueuesAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateQueuesAuthorizationRuleParameter.Rights)
                {
                    Assert.True(updateQueueAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the updated queues AuthorizationRule
                var getQueueAuthorizationRuleResponse = ServiceBusManagementClient.Queues.GetAuthorizationRule(resourceGroup, namespaceName,queueName,
                    authorizationRuleName);
                Assert.NotNull(getQueueAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getQueueAuthorizationRuleResponse.Name);
                Assert.True(getQueueAuthorizationRuleResponse.Rights.Count == updateQueuesAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateQueuesAuthorizationRuleParameter.Rights)
                {
                    Assert.True(getQueueAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the connectionString to the queues for a Authorization rule created
                var listKeysResponse = ServiceBusManagementClient.Queues.ListKeys(resourceGroup, namespaceName, queueName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                
                // Regenerate Keys for the create Authorization rules
                var regenerateKeysParameters = new RegenerateKeysParameters();
                regenerateKeysParameters.Policykey = Policykey.PrimaryKey;
                
                var regenerateKeysResposnse = ServiceBusManagementClient.Queues.RegenerateKeys(resourceGroup, namespaceName, queueName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotEqual(listKeysResponse.PrimaryKey, regenerateKeysResposnse.PrimaryKey);
                Assert.NotNull(regenerateKeysResposnse.SecondaryConnectionString);
                Assert.NotNull(regenerateKeysResposnse.SecondaryKey);

                regenerateKeysParameters.Policykey = Policykey.SecondaryKey;

                regenerateKeysResposnse = ServiceBusManagementClient.Queues.RegenerateKeys(resourceGroup, namespaceName, queueName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotEqual(listKeysResponse.SecondaryKey, regenerateKeysResposnse.SecondaryKey);
                Assert.NotNull(regenerateKeysResposnse.PrimaryConnectionString);
                Assert.NotNull(regenerateKeysResposnse.SecondaryConnectionString);
                Assert.NotNull(regenerateKeysResposnse.PrimaryKey);                

                // Delete Queue authorizationRule
                ServiceBusManagementClient.Queues.DeleteAuthorizationRule(resourceGroup, namespaceName, queueName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                try
                {
                    ServiceBusManagementClient.Queues.GetAuthorizationRule(resourceGroup, namespaceName, queueName, authorizationRuleName);
                    Assert.True(false, "this step should have failed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // Delete queue and check for the NotFound exception 
                ServiceBusManagementClient.Queues.Delete(resourceGroup, namespaceName, queueName);
                try
                {
                    var getQueueResponse_chkDelete = ServiceBusManagementClient.Queues.Get(resourceGroup, namespaceName, queueName);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound,ex.Response.StatusCode);
                }

                // Delete namespace and check for the NotFound exception 
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                try
                {
                    var getNamespaceResponse_chkDelete = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }
    }
}
