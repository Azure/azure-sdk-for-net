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
        public void CreateGetUpdateDeleteAuthorizationRules()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "CreateGetUpdateDeleteAuthorizationRules");

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

                //Create a namespace AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(NotificationHubsManagementHelper.AuthorizationRulesPrefix);
                var createAutorizationRuleParameter = new AuthorizationRulesCreateOrUpdateParameters() 
                    {
                        Properties = new AuthorizationRulesProperties()
                        {
                            KeyName = authorizationRuleName,
                            Rights = new List<AccessRight>() {AccessRight.Listen, AccessRight.Send},
                            PrimaryKey = NotificationHubsManagementHelper.GenerateRandomKey()
                        }
                    };

                var createNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.CreateAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.Null(createNamespaceAuthorizationRuleResponse);
                Assert.Null(createNamespaceAuthorizationRuleResponse.Value);

                //Get default namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.Null(getNamespaceAuthorizationRulesResponse);
                Assert.Null(getNamespaceAuthorizationRulesResponse.Value);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Name, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Properties.KeyName, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == AccessRight.Listen));
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == AccessRight.Send));
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == AccessRight.Manage));

                //Get created namespace AuthorizationRules
                getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.Null(getNamespaceAuthorizationRulesResponse);
                Assert.Null(getNamespaceAuthorizationRulesResponse.Value);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == right));
                }

                //Get all namespaces AuthorizationRules 
                var getAllNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                Assert.Null(getAllNamespaceAuthorizationRulesResponse);
                Assert.Null(getAllNamespaceAuthorizationRulesResponse.Value);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Value.Count > 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Value.Any(ns => ns.Name == authorizationRuleName));
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Value.Any(auth => auth.Name == NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule));
                
                //Update namespace authorizationRule 
                var updateNamespaceAuthorizationRuleParameter = new AuthorizationRulesCreateOrUpdateParameters()
                {
                    Properties = new AuthorizationRulesProperties()
                    {
                        KeyName = authorizationRuleName,
                        Rights = new List<AccessRight>() { AccessRight.Listen},
                        PrimaryKey = NotificationHubsManagementHelper.GenerateRandomKey()
                    }
                };

                var updateNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.CreateAuthorizationRule(resourceGroup,
                    namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.NotNull(updateNamespaceAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName , updateNamespaceAuthorizationRuleResponse.Value.Name);
                Assert.Equal(updateNamespaceAuthorizationRuleResponse.Value.Properties.PrimaryKey, updateNamespaceAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(updateNamespaceAuthorizationRuleResponse.Value.Properties.KeyName, updateNamespaceAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(updateNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Count == updateNamespaceAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(updateNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the updated namespace AuthorizationRule
                var getNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, 
                    authorizationRuleName);
                Assert.Null(getNamespaceAuthorizationRuleResponse);
                Assert.Null(getNamespaceAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Value.Name);
                Assert.Equal(getNamespaceAuthorizationRuleResponse.Value.Properties.PrimaryKey, updateNamespaceAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(getNamespaceAuthorizationRuleResponse.Value.Properties.KeyName, updateNamespaceAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(getNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Count == updateNamespaceAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the connectionString to the namespace for a Authorization rule created
                var listKeysResponse = NotificationHubsManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.Null(listKeysResponse);
                Assert.Null(listKeysResponse.PrimaryConnectionString);
                Assert.Null(listKeysResponse.PrimaryConnectionString.Contains(getNamespaceAuthorizationRuleResponse.Value.Properties.PrimaryKey));
                Assert.Null(listKeysResponse.SecondaryConnectionString);
                Assert.Null(listKeysResponse.SecondaryConnectionString.Contains(getNamespaceAuthorizationRuleResponse.Value.Properties.SecondaryKey));

                //Delete namespace authorizationRule
                var deleteResponse = NotificationHubsManagementClient.Namespaces.DeleteAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.Null(deleteResponse);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);

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
            }
        }        
    }
}
