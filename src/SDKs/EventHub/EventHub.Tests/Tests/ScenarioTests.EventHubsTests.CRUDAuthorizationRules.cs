// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void EventhubCreateGetUpdateDeleteAuthorizationRules()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create a namespace
                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
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
                 
                // Get the created namespace
                var getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceState.Active , getNamespaceResponse.Status);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create Eventhub
                var eventhubName = TestUtilities.GenerateName(EventHubManagementHelper.EventHubPrefix);                
                var createEventhubResponse = this.EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName,
                new EventHubCreateOrUpdateParameters()
                {
                    Location = location
                });

                Assert.NotNull(createEventhubResponse);
                Assert.Equal(createEventhubResponse.Name, eventhubName);
                
                // Get the created EventHub
                var geteventhubResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                Assert.NotNull(geteventhubResponse);
                Assert.Equal(EntityStatus.Active, geteventhubResponse.Status);
                Assert.Equal(geteventhubResponse.Name, eventhubName);

                // Create a EventHub AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(EventHubManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", EventHubManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Name = authorizationRuleName,
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = EventHubManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createEventhubAuthorizationRuleResponse = EventHubManagementClient.EventHubs.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,eventhubName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createEventhubAuthorizationRuleResponse);
                Assert.True(createEventhubAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(createEventhubAuthorizationRuleResponse.Rights.Any(r => r == right));
                }

                // Get created Eventhub AuthorizationRules
                var getEventhubAuthorizationRulesResponse = EventHubManagementClient.EventHubs.GetAuthorizationRule(resourceGroup, namespaceName,eventhubName, authorizationRuleName);
                Assert.NotNull(getEventhubAuthorizationRulesResponse);
                Assert.True(getEventhubAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(getEventhubAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                // Get all Eventhub AuthorizationRules
                var getAllNamespaceAuthorizationRulesResponse = EventHubManagementClient.EventHubs.ListAuthorizationRules(resourceGroup, namespaceName, eventhubName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.Equal(getAllNamespaceAuthorizationRulesResponse.Count(), 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));

                // Update Eventhub authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", EventHubManagementHelper.GenerateRandomKey());
                SharedAccessAuthorizationRuleCreateOrUpdateParameters updateEventhubAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters();
                updateEventhubAuthorizationRuleParameter.Rights = new List<AccessRights?>() { AccessRights.Listen };

                var updateEventhubAuthorizationRuleResponse = EventHubManagementClient.EventHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName,eventhubName, authorizationRuleName, updateEventhubAuthorizationRuleParameter);

                Assert.NotNull(updateEventhubAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateEventhubAuthorizationRuleResponse.Name);
                Assert.True(updateEventhubAuthorizationRuleResponse.Rights.Count == updateEventhubAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateEventhubAuthorizationRuleParameter.Rights)
                {
                    Assert.True(updateEventhubAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the updated Eventhub AuthorizationRule
                var getEventhubAuthorizationRuleResponse = EventHubManagementClient.EventHubs.GetAuthorizationRule(resourceGroup, namespaceName,eventhubName,
                    authorizationRuleName);
                Assert.NotNull(getEventhubAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getEventhubAuthorizationRuleResponse.Name);
                Assert.True(getEventhubAuthorizationRuleResponse.Rights.Count == updateEventhubAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateEventhubAuthorizationRuleParameter.Rights)
                {
                    Assert.True(getEventhubAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the connectionString to the Eventhub for a Authorization rule created
                var listKeysResponse = EventHubManagementClient.EventHubs.ListKeys(resourceGroup, namespaceName, eventhubName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                // Delete Eventhub authorizationRule
                EventHubManagementClient.EventHubs.DeleteAuthorizationRule(resourceGroup, namespaceName, eventhubName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                try
                {
                    EventHubManagementClient.EventHubs.GetAuthorizationRule(resourceGroup, namespaceName, eventhubName, authorizationRuleName);
                    Assert.True(false, "this step should have failed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // Delete Eventhub and check for the NotFound exception 
                EventHubManagementClient.EventHubs.Delete(resourceGroup, namespaceName, eventhubName);
                try
                {
                    var getEventhubResponse_chkDelete = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound,ex.Response.StatusCode);
                }

                // Delete namespace and check for the NotFound exception 
                EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                try
                {
                    var getNamespaceResponse_chkDelete = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }
    }
}
