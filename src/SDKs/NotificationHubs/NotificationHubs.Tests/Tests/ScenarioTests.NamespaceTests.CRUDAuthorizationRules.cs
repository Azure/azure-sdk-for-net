// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace NotificationHubs.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Test.HttpRecorder;
    using TestHelper;
    using System;
    using Xunit;
    using Microsoft.Rest.Azure;
    using System.Net;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ScenarioTests 
    {
        [Fact]
        public void NamespaceCreateGetUpdateDeleteAuthorizationRules()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = NotificationHubsManagementHelper.DefaultLocation;
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(NotificationHubsManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                //Create a namespace
                var namespaceName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NamespacePrefix);
                var createNamespaceResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new NamespaceCreateOrUpdateParameters()
                    {
                        Location = location
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                ActivateNamespace(resourceGroup, namespaceName);

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);


                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                //Create a namespace AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(NotificationHubsManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send },
                    }
                };

                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.Equal(createNamespaceAuthorizationRuleResponse.Name, authorizationRuleName);
                Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(createNamespaceAuthorizationRuleResponse.Rights.Any(r => r == right));
                }

                //Get default namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == AccessRights.Listen));
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == AccessRights.Send));
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == AccessRights.Manage));

                //Get created namespace AuthorizationRules
                getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, authorizationRuleName);
                Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                //Get all namespaces AuthorizationRules 
                var getAllNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() > 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(auth => auth.Name == NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule));

                //Update namespace authorizationRule
                var updateNamespaceAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        Rights = new List<AccessRights?>() { AccessRights.Listen},
                    }
                };

                //uncomment after the bug fix
                //var updateNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup,
                //    namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                //Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                //Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                //Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Properties.Rights.Count);
                //foreach (var right in updateNamespaceAuthorizationRuleParameter.Properties.Rights)
                //{
                //    Assert.True(updateNamespaceAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                //}

                //Get the updated namespace AuthorizationRule
                //var getNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName,
                //    authorizationRuleName);
                //Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                //Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                //Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Count == updateNamespaceAuthorizationRuleParameter.Properties.Rights.Count);
                //foreach (var right in updateNamespaceAuthorizationRuleParameter.Properties.Rights)
                //{
                //    Assert.True(getNamespaceAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                //}

                //Get the connectionString to the namespace for a Authorization rule created
                var listKeysResponse = NotificationHubsManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                var policyKey = new PolicykeyResource()
                {
                    PolicyKey = "primary KEY"
                };

                var regenerateKeys = NotificationHubsManagementClient.Namespaces.RegenerateKeys(resourceGroup, namespaceName, authorizationRuleName, policyKey);
                Assert.NotNull(regenerateKeys);
                Assert.Equal(regenerateKeys.KeyName, authorizationRuleName);
                Assert.NotNull(regenerateKeys.PrimaryConnectionString);
                Assert.NotNull(regenerateKeys.SecondaryConnectionString);

                //Get the connectionString to the namespace for a Authorization rule after regenerating the primary key 
                var listKeysAfterRegenerateResponse = NotificationHubsManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(listKeysAfterRegenerateResponse);

                //Delete namespace authorizationRule
                NotificationHubsManagementClient.Namespaces.DeleteAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                try
                {
                    NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                    Assert.True(false, "this step should have failed");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                try
                {
                    //Delete namespace
                    NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName); 
                }
                catch (Exception ex)
                {
                    Assert.True(ex.Message.Contains("NotFound"));
                }
            }
        }
    }
}
