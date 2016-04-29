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
                        Location = location,
                        Properties = new NamespaceProperties()
                        {
                            NamespaceType = NamespaceType.NotificationHub
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

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

                //Create a namespace AuthorizationRule
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

                var jsonStr = NotificationHubsManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);

                var createNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createNamespaceAuthorizationRuleResponse);
                Assert.Equal(createNamespaceAuthorizationRuleResponse.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(createNamespaceAuthorizationRuleResponse.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(createNamespaceAuthorizationRuleResponse.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(createNamespaceAuthorizationRuleResponse.Properties.Rights.Any(r => r == right));
                }

                //Get default namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Properties.KeyName, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.True(getNamespaceAuthorizationRulesResponse.Properties.Rights.Any(r => r == AccessRights.Listen));
                Assert.True(getNamespaceAuthorizationRulesResponse.Properties.Rights.Any(r => r == AccessRights.Send));
                Assert.True(getNamespaceAuthorizationRulesResponse.Properties.Rights.Any(r => r == AccessRights.Manage));

                //Get created namespace AuthorizationRules
                getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(getNamespaceAuthorizationRulesResponse.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRulesResponse.Properties.Rights.Any(r => r == right));
                }

                //Get all namespaces AuthorizationRules 
                var getAllNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Count() > 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(auth => auth.Name == NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule));

                //Update namespace authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                SharedAccessAuthorizationRuleCreateOrUpdateParameters updateNamespaceAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters(getNamespaceAuthorizationRulesResponse.Properties);
                updateNamespaceAuthorizationRuleParameter.Properties.Rights = new List<AccessRights?>() { AccessRights.Listen };
                updateNamespaceAuthorizationRuleParameter.Properties.PrimaryKey = updatePrimaryKey;

                var updateNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Name);
                Assert.Equal(updateNamespaceAuthorizationRuleResponse.Properties.PrimaryKey, updateNamespaceAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(updateNamespaceAuthorizationRuleResponse.Properties.KeyName, updateNamespaceAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(updateNamespaceAuthorizationRuleResponse.Properties.Rights.Count == updateNamespaceAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(updateNamespaceAuthorizationRuleResponse.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the updated namespace AuthorizationRule
                var getNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName,
                    authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Name);
                Assert.Equal(getNamespaceAuthorizationRuleResponse.Properties.KeyName, updateNamespaceAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(getNamespaceAuthorizationRuleResponse.Properties.Rights.Count == updateNamespaceAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRuleResponse.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the connectionString to the namespace for a Authorization rule created
                var listKeysResponse = NotificationHubsManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString.Contains(getNamespaceAuthorizationRuleResponse.Properties.PrimaryKey));
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString.Contains(getNamespaceAuthorizationRuleResponse.Properties.SecondaryKey));

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
