// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact()]
        public void EventhubCreateGetUpdateDeleteAuthorizationRules_Length()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = string.Empty;
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create a namespace
                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                try
                {
                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new EHNamespace()
                    {
                        Location = location,
                        Sku = new Sku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        },
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
                    var getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                    if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                        TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                    Assert.NotNull(getNamespaceResponse);
                    Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                    Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                    // Create Eventhub
                    var eventhubName = EventHubManagementHelper.EventHubPrefix;
                    var createEventhubResponse = this.EventHubManagementClient.EventHubs.CreateOrUpdate(resourceGroup, namespaceName, eventhubName,
                    new Eventhub() { MessageRetentionInDays = 5 });

                    Assert.NotNull(createEventhubResponse);
                    Assert.Equal(createEventhubResponse.Name, eventhubName);

                    // Get the created EventHub
                    var geteventhubResponse = EventHubManagementClient.EventHubs.Get(resourceGroup, namespaceName, eventhubName);
                    Assert.NotNull(geteventhubResponse);
                    Assert.Equal(EntityStatus.Active, geteventhubResponse.Status);
                    Assert.Equal(geteventhubResponse.Name, eventhubName);

                    // Create a EventHub AuthorizationRule
                    var authorizationRuleName = EventHubManagementHelper.AuthorizationRulesPrefix;
                    string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", EventHubManagementHelper.GenerateRandomKey());
                    var createAutorizationRuleParameter = new AuthorizationRule()
                    {
                        Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
                    };

                    var jsonStr = EventHubManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                    var createEventhubAuthorizationRuleResponse = EventHubManagementClient.EventHubs.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName, eventhubName,
                        authorizationRuleName, createAutorizationRuleParameter);
                    Assert.NotNull(createEventhubAuthorizationRuleResponse);
                    Assert.True(createEventhubAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                    foreach (var right in createAutorizationRuleParameter.Rights)
                    {
                        Assert.Contains(createEventhubAuthorizationRuleResponse.Rights, r => r == right);
                    }

                    // Get created Eventhub AuthorizationRules
                    var getEventhubAuthorizationRulesResponse = EventHubManagementClient.EventHubs.GetAuthorizationRule(resourceGroup, namespaceName, eventhubName, authorizationRuleName);
                    Assert.NotNull(getEventhubAuthorizationRulesResponse);
                    Assert.True(getEventhubAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                    foreach (var right in createAutorizationRuleParameter.Rights)
                    {
                        Assert.Contains(getEventhubAuthorizationRulesResponse.Rights, r => r == right);
                    }

                    // Get all Eventhub AuthorizationRules
                    var getAllNamespaceAuthorizationRulesResponse = EventHubManagementClient.EventHubs.ListAuthorizationRules(resourceGroup, namespaceName, eventhubName);
                    Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                    Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() == 1);
                    Assert.Contains(getAllNamespaceAuthorizationRulesResponse, ns => ns.Name == authorizationRuleName);

                    // Update Eventhub authorizationRule
                    string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", EventHubManagementHelper.GenerateRandomKey());
                    AuthorizationRule updateEventhubAuthorizationRuleParameter = new AuthorizationRule();
                    updateEventhubAuthorizationRuleParameter.Rights = new List<string>() { AccessRights.Listen };

                    var updateEventhubAuthorizationRuleResponse = EventHubManagementClient.EventHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                        namespaceName, eventhubName, authorizationRuleName, updateEventhubAuthorizationRuleParameter);

                    Assert.NotNull(updateEventhubAuthorizationRuleResponse);
                    Assert.Equal(authorizationRuleName, updateEventhubAuthorizationRuleResponse.Name);
                    Assert.True(updateEventhubAuthorizationRuleResponse.Rights.Count == updateEventhubAuthorizationRuleParameter.Rights.Count);
                    foreach (var right in updateEventhubAuthorizationRuleParameter.Rights)
                    {
                        Assert.Contains(updateEventhubAuthorizationRuleResponse.Rights, r => r.Equals(right));
                    }

                    // Get the updated Eventhub AuthorizationRule
                    var getEventhubAuthorizationRuleResponse = EventHubManagementClient.EventHubs.GetAuthorizationRule(resourceGroup, namespaceName, eventhubName,
                        authorizationRuleName);
                    Assert.NotNull(getEventhubAuthorizationRuleResponse);
                    Assert.Equal(authorizationRuleName, getEventhubAuthorizationRuleResponse.Name);
                    Assert.True(getEventhubAuthorizationRuleResponse.Rights.Count == updateEventhubAuthorizationRuleParameter.Rights.Count);
                    foreach (var right in updateEventhubAuthorizationRuleParameter.Rights)
                    {
                        Assert.Contains(getEventhubAuthorizationRuleResponse.Rights, r => r.Equals(right));
                    }

                    // Get the connectionString to the Eventhub for a Authorization rule created
                    var listKeysResponse = EventHubManagementClient.EventHubs.ListKeys(resourceGroup, namespaceName, eventhubName, authorizationRuleName);
                    Assert.NotNull(listKeysResponse);
                    Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                    Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                    //New connection string 
                    var regenerateConnection_primary = EventHubManagementClient.EventHubs.RegenerateKeys(resourceGroup, namespaceName, eventhubName, authorizationRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey));
                    Assert.NotNull(regenerateConnection_primary);
                    Assert.NotEqual(listKeysResponse.PrimaryConnectionString, regenerateConnection_primary.PrimaryConnectionString);
                    Assert.Equal(listKeysResponse.SecondaryConnectionString, regenerateConnection_primary.SecondaryConnectionString);

                    var regenerateConnection_Secondary = EventHubManagementClient.EventHubs.RegenerateKeys(resourceGroup, namespaceName, eventhubName, authorizationRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey));
                    Assert.NotNull(regenerateConnection_Secondary);
                    Assert.NotEqual(listKeysResponse.SecondaryConnectionString, regenerateConnection_Secondary.SecondaryConnectionString);
                    Assert.Equal(regenerateConnection_primary.PrimaryConnectionString, regenerateConnection_Secondary.PrimaryConnectionString);

                    // Delete Eventhub authorizationRule
                    EventHubManagementClient.EventHubs.DeleteAuthorizationRule(resourceGroup, namespaceName, eventhubName, authorizationRuleName);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Delete Eventhub and check for the NotFound exception 
                    EventHubManagementClient.EventHubs.Delete(resourceGroup, namespaceName, eventhubName);

                    // Delete namespace and check for the NotFound exception 
                    EventHubManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                }
                finally
                {
                    //Delete Resource Group
                    this.ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroup, null, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD IPFilter Rules test");
                }
            }
        }
    }
}
