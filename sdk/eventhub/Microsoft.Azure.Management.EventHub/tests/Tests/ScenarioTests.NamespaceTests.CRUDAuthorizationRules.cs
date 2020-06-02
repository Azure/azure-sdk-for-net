﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        [Fact]
        public void NamespaceCreateGetUpdateDeleteAuthorizationRules()
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
                    var nameAvailable = EventHubManagementClient.Namespaces.CheckNameAvailability(new CheckNameAvailabilityParameter(namespaceName));

                    var createNamespaceResponse = EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
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

                    // Create a namespace AuthorizationRule
                    var authorizationRuleName = TestUtilities.GenerateName(EventHubManagementHelper.AuthorizationRulesPrefix);
                    string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", EventHubManagementHelper.GenerateRandomKey());
                    var createAutorizationRuleParameter = new AuthorizationRule()
                    {
                        Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
                    };

                    var jsonStr = EventHubManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                    var createNamespaceAuthorizationRuleResponse = EventHubManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                        authorizationRuleName, createAutorizationRuleParameter);
                    Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                    Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                    foreach (var right in createAutorizationRuleParameter.Rights)
                    {
                        Assert.Contains(createNamespaceAuthorizationRuleResponse.Rights, r => r == right);
                    }

                    // Get default namespace AuthorizationRules
                    var getNamespaceAuthorizationRulesResponse = EventHubManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, EventHubManagementHelper.DefaultNamespaceAuthorizationRule);
                    Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                    Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, EventHubManagementHelper.DefaultNamespaceAuthorizationRule);
                    Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Listen);
                    Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Send);
                    Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == AccessRights.Manage);

                    // Get created namespace AuthorizationRules
                    getNamespaceAuthorizationRulesResponse = EventHubManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                    Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                    Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                    foreach (var right in createAutorizationRuleParameter.Rights)
                    {
                        Assert.Contains(getNamespaceAuthorizationRulesResponse.Rights, r => r == right);
                    }

                    // Get all namespaces AuthorizationRules
                    var getAllNamespaceAuthorizationRulesResponse = EventHubManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                    Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                    Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() > 1);
                    Assert.Contains(getAllNamespaceAuthorizationRulesResponse, ns => ns.Name == authorizationRuleName);
                    Assert.Contains(getAllNamespaceAuthorizationRulesResponse, auth => auth.Name == EventHubManagementHelper.DefaultNamespaceAuthorizationRule);

                    // Update namespace authorizationRule
                    string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", EventHubManagementHelper.GenerateRandomKey());
                    AuthorizationRule updateNamespaceAuthorizationRuleParameter = new AuthorizationRule();
                    updateNamespaceAuthorizationRuleParameter.Rights = new List<string>() { AccessRights.Listen };

                    var updateNamespaceAuthorizationRuleResponse = EventHubManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup,
                        namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                    Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                    Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                    Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                    foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                    {
                        Assert.Contains(updateNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                    }

                    // Get the updated namespace AuthorizationRule
                    var getNamespaceAuthorizationRuleResponse = EventHubManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName,
                        authorizationRuleName);
                    Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                    Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                    Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                    foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                    {
                        Assert.Contains(getNamespaceAuthorizationRuleResponse.Rights, r => r.Equals(right));
                    }

                    // Get the connection string to the namespace for a Authorization rule created
                    var listKeysResponse = EventHubManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                    Assert.NotNull(listKeysResponse);
                    Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                    Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                    // Regenerate connection string to the namespace for a Authorization rule created
                    var NewKeysResponse_primary = EventHubManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, new RegenerateAccessKeyParameters(KeyType.PrimaryKey));
                    Assert.NotNull(NewKeysResponse_primary);
                    Assert.NotEqual(NewKeysResponse_primary.PrimaryConnectionString, listKeysResponse.PrimaryConnectionString);
                    Assert.Equal(NewKeysResponse_primary.SecondaryConnectionString, listKeysResponse.SecondaryConnectionString);

                    // Regenerate connection string to the namespace for a Authorization rule created
                    var NewKeysResponse_secondary = EventHubManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, new RegenerateAccessKeyParameters(KeyType.SecondaryKey));
                    Assert.NotNull(NewKeysResponse_secondary);
                    Assert.NotEqual(NewKeysResponse_secondary.PrimaryConnectionString, listKeysResponse.PrimaryConnectionString);
                    Assert.NotEqual(NewKeysResponse_secondary.SecondaryConnectionString, listKeysResponse.SecondaryConnectionString);

                    // Delete namespace authorizationRule
                    EventHubManagementClient.Namespaces.DeleteAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Delete namespace
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
