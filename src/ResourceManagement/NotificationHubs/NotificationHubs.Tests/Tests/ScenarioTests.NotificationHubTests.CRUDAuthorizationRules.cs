//  
//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


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
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(30));

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.Properties.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Properties.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                //Create a notificationHub
                var notificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix);

                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                    notificationHubName,
                    new NotificationHubCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NotificationHubProperties()
                    });

                Assert.NotNull(createNotificationHubResponse);

                //Create a notificationHub AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(NotificationHubsManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Name = authorizationRuleName,
                    Properties = new SharedAccessAuthorizationRuleProperties()
                    {
                        KeyName = authorizationRuleName,
                        Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send },
                        PrimaryKey = createPrimaryKey,
                        SecondaryKey = NotificationHubsManagementHelper.GenerateRandomKey(),
                        ClaimType = "SharedAccessKey",
                        ClaimValue = "None"
                    }
                };

                var createNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, notificationHubName, authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNotificationHubAuthorizationRuleResponse);
                Assert.Equal(createNotificationHubAuthorizationRuleResponse.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(createNotificationHubAuthorizationRuleResponse.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(createNotificationHubAuthorizationRuleResponse.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(createNotificationHubAuthorizationRuleResponse.Properties.Rights.Any(r => r == right));
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                //Get created notificationHub AuthorizationRules
                var getNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.NotNull(getNotificationHubAuthorizationRulesResponse);
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(getNotificationHubAuthorizationRulesResponse.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRulesResponse.Properties.Rights.Any(r => r == right));
                }

                //Get all notificationHub AuthorizationRules 
                var getAllNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.ListAuthorizationRules(resourceGroup, namespaceName,
                    notificationHubName);
                Assert.NotNull(getAllNotificationHubAuthorizationRulesResponse);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Count() > 1);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));

                //Update notificationHub authorizationRule 
                var updateNotificationHubAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters(getNotificationHubAuthorizationRulesResponse.Properties);
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                updateNotificationHubAuthorizationRuleParameter.Properties.Rights = new List<AccessRights?>() { AccessRights.Listen };
                updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey = updatePrimaryKey;

                var updateNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, notificationHubName, authorizationRuleName, updateNotificationHubAuthorizationRuleParameter);

                Assert.NotNull(updateNotificationHubAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNotificationHubAuthorizationRuleResponse.Name);
                Assert.Equal(updateNotificationHubAuthorizationRuleResponse.Properties.PrimaryKey, updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(updateNotificationHubAuthorizationRuleResponse.Properties.KeyName, updateNotificationHubAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(updateNotificationHubAuthorizationRuleResponse.Properties.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(updateNotificationHubAuthorizationRuleResponse.Properties.Rights.Any(r => r.Equals(right)));
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the updated notificationHub AuthorizationRule
                var getNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.NotNull(getNotificationHubAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNotificationHubAuthorizationRuleResponse.Name);
                Assert.Equal(getNotificationHubAuthorizationRuleResponse.Properties.PrimaryKey, updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(getNotificationHubAuthorizationRuleResponse.Properties.KeyName, updateNotificationHubAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(getNotificationHubAuthorizationRuleResponse.Properties.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRuleResponse.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the connectionString to the namespace for a Authorization rule created at notificationHub level
                var listKeysResponse = NotificationHubsManagementClient.NotificationHubs.ListKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString.Contains(getNotificationHubAuthorizationRuleResponse.Properties.PrimaryKey));
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString.Contains(getNotificationHubAuthorizationRuleResponse.Properties.SecondaryKey));

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
