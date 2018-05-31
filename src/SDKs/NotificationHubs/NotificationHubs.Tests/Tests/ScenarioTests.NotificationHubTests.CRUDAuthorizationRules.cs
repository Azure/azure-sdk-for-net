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
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;
    using System.Net;
    using System.Linq;

    public partial class ScenarioTests 
    {
        [Fact]
        public void NotificationHubCreateGetUpdateDeleteAuthorizationRules()
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
                        Location = location,
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

                //Create a notificationHub
                var notificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix);

                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                    notificationHubName,
                    new NotificationHubCreateOrUpdateParameters()
                    {
                        Location = location
                    });

                Assert.NotNull(createNotificationHubResponse);

                //Create a notificationHub AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(NotificationHubsManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send },
                    }
                };

                var createNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, notificationHubName, authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNotificationHubAuthorizationRuleResponse);
                Assert.Equal(createNotificationHubAuthorizationRuleResponse.Name, authorizationRuleName);
                Assert.True(createNotificationHubAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(createNotificationHubAuthorizationRuleResponse.Rights.Any(r => r == right));
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                //Get created notificationHub AuthorizationRules
                var getNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.NotNull(getNotificationHubAuthorizationRulesResponse);
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Name, authorizationRuleName);
                Assert.True(getNotificationHubAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                //Get all notificationHub AuthorizationRules 
                var getAllNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.ListAuthorizationRules(resourceGroup, namespaceName,
                    notificationHubName);
                Assert.NotNull(getAllNotificationHubAuthorizationRulesResponse);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Count() > 1);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));

                //Update notificationHub authorizationRule 
                var updateNotificationHubAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        Rights = new List<AccessRights?>() { AccessRights.Listen },
                    }
                };

                var updateNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, notificationHubName, authorizationRuleName, updateNotificationHubAuthorizationRuleParameter);

                Assert.NotNull(updateNotificationHubAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNotificationHubAuthorizationRuleResponse.Name);
                Assert.True(updateNotificationHubAuthorizationRuleResponse.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(updateNotificationHubAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the updated notificationHub AuthorizationRule
                var getNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.NotNull(getNotificationHubAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNotificationHubAuthorizationRuleResponse.Name);
                Assert.True(getNotificationHubAuthorizationRuleResponse.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                //Get the connectionString to the namespace for a Authorization rule created at notificationHub level
                var listKeysResponse = NotificationHubsManagementClient.NotificationHubs.ListKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                Assert.True(listKeysResponse.PrimaryConnectionString.Contains(listKeysResponse.PrimaryKey));
                Assert.True(listKeysResponse.SecondaryConnectionString.Contains(listKeysResponse.SecondaryKey));

                var policyKey = new PolicykeyResource()
                {
                    PolicyKey = "primary KEY"
                };

                var regenerateKeys = NotificationHubsManagementClient.NotificationHubs.RegenerateKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName, policyKey);
                Assert.NotNull(regenerateKeys);
                Assert.Equal(regenerateKeys.KeyName, authorizationRuleName);
                Assert.NotNull(regenerateKeys.PrimaryConnectionString);
                Assert.NotNull(regenerateKeys.SecondaryConnectionString);
                Assert.True(regenerateKeys.PrimaryConnectionString.Contains(regenerateKeys.PrimaryKey));
                Assert.True(regenerateKeys.SecondaryConnectionString.Contains(regenerateKeys.SecondaryKey));
                //Bug : uncomment after the fix
                //Assert.Equal(regenerateKeys.SecondaryConnectionString, listKeysResponse.SecondaryConnectionString);
                Assert.NotEqual(regenerateKeys.PrimaryConnectionString, listKeysResponse.PrimaryConnectionString);
                Assert.Equal(regenerateKeys.SecondaryKey, listKeysResponse.SecondaryKey);
                Assert.NotEqual(regenerateKeys.PrimaryKey, listKeysResponse.PrimaryKey);

                //Get the connectionString to the notificationHub for a Authorization rule after regenerating the primary key 
                var listKeysAfterRegenerateResponse = NotificationHubsManagementClient.NotificationHubs.ListKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.NotNull(listKeysAfterRegenerateResponse);
                Assert.Equal(listKeysAfterRegenerateResponse.KeyName, authorizationRuleName);
                Assert.NotNull(listKeysAfterRegenerateResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysAfterRegenerateResponse.SecondaryConnectionString);
                Assert.True(listKeysAfterRegenerateResponse.PrimaryConnectionString.Contains(listKeysAfterRegenerateResponse.PrimaryKey));
                Assert.True(listKeysAfterRegenerateResponse.SecondaryConnectionString.Contains(listKeysAfterRegenerateResponse.SecondaryKey));
                Assert.Equal(listKeysAfterRegenerateResponse.SecondaryConnectionString, listKeysResponse.SecondaryConnectionString);
                Assert.NotEqual(listKeysAfterRegenerateResponse.PrimaryConnectionString, listKeysResponse.PrimaryConnectionString);
                Assert.Equal(listKeysAfterRegenerateResponse.SecondaryKey, listKeysResponse.SecondaryKey);
                Assert.NotEqual(listKeysAfterRegenerateResponse.PrimaryKey, listKeysResponse.PrimaryKey);
                Assert.Equal(listKeysAfterRegenerateResponse.PrimaryKey, regenerateKeys.PrimaryKey);
                //Bug : uncomment after the fix
                //Assert.Equal(listKeysAfterRegenerateResponse.PrimaryConnectionString, regenerateKeys.PrimaryConnectionString);

                //Delete notificationHub authorizationRule
                NotificationHubsManagementClient.NotificationHubs.DeleteAuthorizationRule(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                try
                {
                    NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
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
