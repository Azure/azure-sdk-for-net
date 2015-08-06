﻿//  
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
    using global::NotificationHubs.Tests;
    using Hyak.Common;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management;
    using NotificationHubs.Tests.TestHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public partial class ScenarioTests : TestBase
    {
        [Fact]
        public void NotificationHubCreateGetUpdateDeleteAuthorizationRules()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "NotificationHubCreateGetUpdateDeleteAuthorizationRules");

                var location = this.ManagmentClient.TryGetLocation(NotificationHubsManagementHelper.DefaultLocation);
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

                Assert.Null(createNamespaceResponse);
                Assert.Null(createNamespaceResponse.Value);
                Assert.Equal(createNamespaceResponse.Value.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.Null(getNamespaceResponse);
                Assert.Null(getNamespaceResponse.Value);
                Assert.Equal("Succeeded", getNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Value.Properties.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Value.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Value.Properties.Region, StringComparer.CurrentCultureIgnoreCase);

                //Create a notificationHub
                var notificationHubName = TestUtilities.GenerateName(NotificationHubsManagementHelper.NotificationHubPrefix);

                var createNotificationHubResponse = NotificationHubsManagementClient.NotificationHubs.CreateOrUpdate(resourceGroup, namespaceName,
                    notificationHubName,
                    new NotificationHubCreateOrUpdateParameters()
                    {
                        Location = location,
                        Properties = new NotificationHubProperties()
                    });

                Assert.Null(createNotificationHubResponse);
                Assert.Null(createNotificationHubResponse.Value);
                Assert.Equal(createNotificationHubResponse.Value.Name, notificationHubName);

                //Create a notificationHub AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(NotificationHubsManagementHelper.AuthorizationRulesPrefix);
                var createAutorizationRuleParameter = new AuthorizationRulesCreateOrUpdateParameters()
                {
                    Properties = new AuthorizationRulesProperties()
                    {
                        KeyName = authorizationRuleName,
                        Rights = new List<AccessRight>() { AccessRight.Listen, AccessRight.Send },
                        PrimaryKey = NotificationHubsManagementHelper.GenerateRandomKey()
                    }
                };

                var createNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateAuthorizationRule(resourceGroup, 
                    namespaceName, notificationHubName, authorizationRuleName, createAutorizationRuleParameter);
                Assert.Null(createNotificationHubAuthorizationRuleResponse);
                Assert.Null(createNotificationHubAuthorizationRuleResponse.Value);

                //Get created notificationHub AuthorizationRules
                var getNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.Null(getNotificationHubAuthorizationRulesResponse);
                Assert.Null(getNotificationHubAuthorizationRulesResponse.Value);
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Value.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(getNotificationHubAuthorizationRulesResponse.Value.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(getNotificationHubAuthorizationRulesResponse.Value.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == right));
                }

                //Get all notificationHub AuthorizationRules 
                var getAllNotificationHubAuthorizationRulesResponse = NotificationHubsManagementClient.NotificationHubs.ListAuthorizationRules(resourceGroup, namespaceName,
                    notificationHubName);
                Assert.Null(getAllNotificationHubAuthorizationRulesResponse);
                Assert.Null(getAllNotificationHubAuthorizationRulesResponse.Value);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Value.Count > 1);
                Assert.True(getAllNotificationHubAuthorizationRulesResponse.Value.Any(ns => ns.Name == authorizationRuleName));

                //Update notificationHub authorizationRule 
                var updateNotificationHubAuthorizationRuleParameter = new AuthorizationRulesCreateOrUpdateParameters()
                {
                    Properties = new AuthorizationRulesProperties()
                    {
                        KeyName = authorizationRuleName,
                        Rights = new List<AccessRight>() { AccessRight.Listen },
                        PrimaryKey = NotificationHubsManagementHelper.GenerateRandomKey()
                    }
                };

                var updateNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.CreateAuthorizationRule(resourceGroup,
                    namespaceName, notificationHubName, authorizationRuleName, updateNotificationHubAuthorizationRuleParameter);

                Assert.NotNull(updateNotificationHubAuthorizationRuleResponse);
                Assert.NotNull(updateNotificationHubAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName, updateNotificationHubAuthorizationRuleResponse.Value.Name);
                Assert.Equal(updateNotificationHubAuthorizationRuleResponse.Value.Properties.PrimaryKey, updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(updateNotificationHubAuthorizationRuleResponse.Value.Properties.KeyName, updateNotificationHubAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(updateNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(updateNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the updated notificationHub AuthorizationRule
                var getNotificationHubAuthorizationRuleResponse = NotificationHubsManagementClient.NotificationHubs.GetAuthorizationRule(resourceGroup, namespaceName,
                    notificationHubName, authorizationRuleName);
                Assert.Null(getNotificationHubAuthorizationRuleResponse);
                Assert.Null(getNotificationHubAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName, getNotificationHubAuthorizationRuleResponse.Value.Name);
                Assert.Equal(getNotificationHubAuthorizationRuleResponse.Value.Properties.PrimaryKey, updateNotificationHubAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(getNotificationHubAuthorizationRuleResponse.Value.Properties.KeyName, updateNotificationHubAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(getNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Count == updateNotificationHubAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNotificationHubAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNotificationHubAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the connectionString to the namespace for a Authorization rule created at notificationHub level
                var listKeysResponse = NotificationHubsManagementClient.NotificationHubs.ListKeys(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.Null(listKeysResponse);
                Assert.Null(listKeysResponse.PrimaryConnectionString);
                Assert.Null(listKeysResponse.PrimaryConnectionString.Contains(getNotificationHubAuthorizationRuleResponse.Value.Properties.PrimaryKey));
                Assert.Null(listKeysResponse.SecondaryConnectionString);
                Assert.Null(listKeysResponse.SecondaryConnectionString.Contains(getNotificationHubAuthorizationRuleResponse.Value.Properties.SecondaryKey));

                //Delete notificationHub authorizationRule
                var deleteResponse = NotificationHubsManagementClient.NotificationHubs.DeleteAuthorizationRule(resourceGroup, namespaceName, notificationHubName, authorizationRuleName);
                Assert.Null(deleteResponse);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);

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
            }
        }
    }
}
