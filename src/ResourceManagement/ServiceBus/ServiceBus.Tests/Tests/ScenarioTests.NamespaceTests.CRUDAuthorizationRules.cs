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
                var createNamespaceResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location,
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
                Assert.Equal(NamespaceState.Active , getNamespaceResponse.Status);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create a namespace AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(ServiceBusManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Name = authorizationRuleName,
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = ServiceBusManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createNamespaceAuthorizationRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Any(r => r == right));
                }

                // Get default namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, ServiceBusManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, ServiceBusManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == AccessRights.Listen));
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == AccessRights.Send));
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == AccessRights.Manage));

                // Get created namespace AuthorizationRules
                getNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                // Get all namespaces AuthorizationRules 
                var getAllNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() > 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(auth => auth.Name == ServiceBusManagementHelper.DefaultNamespaceAuthorizationRule));

                // Update namespace authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                SharedAccessAuthorizationRuleCreateOrUpdateParameters updateNamespaceAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters();
                updateNamespaceAuthorizationRuleParameter.Rights = new List<AccessRights?>() { AccessRights.Listen };

                var updateNamespaceAuthorizationRuleResponse = ServiceBusManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the updated namespace AuthorizationRule
                var getNamespaceAuthorizationRuleResponse = ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName,                     authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the connectionString to the namespace for a Authorization rule created
                var listKeysResponse = ServiceBusManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);

                // Regenerate AuthorizationRules
                var regenerateKeysParameters = new RegenerateKeysParameters();
                regenerateKeysParameters.Policykey = Policykey.PrimaryKey;

                var regenerateKeysResponse = ServiceBusManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, regenerateKeysParameters);
                Assert.NotNull(regenerateKeysResponse);
                Assert.NotEqual(regenerateKeysResponse.PrimaryKey, listKeysResponse.PrimaryKey);
                Assert.Equal(regenerateKeysResponse.SecondaryKey, listKeysResponse.SecondaryKey);

                // Delete namespace authorizationRule
                ServiceBusManagementClient.Namespaces.DeleteAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                try
                {
                    ServiceBusManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                    Assert.True(false, "this step should have failed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                try
                {
                    // Delete namespace
                    ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName); 
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
            }
        }
    }
}
