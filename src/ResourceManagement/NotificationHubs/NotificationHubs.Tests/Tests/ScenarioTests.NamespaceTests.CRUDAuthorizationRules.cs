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
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Management;
    using NotificationHubs.Tests.TestHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public partial class ScenarioTests : TestBase
    {
        [Fact]
        public void NamespaceCreateGetUpdateDeleteAuthorizationRules()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ScenarioTests", "NamespaceCreateGetUpdateDeleteAuthorizationRules");

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
                Assert.NotNull(createNamespaceResponse.Value);
                Assert.Equal(createNamespaceResponse.Value.Properties.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                //Get the created namespace
                var getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.Value.Properties.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = NotificationHubsManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.NotNull(getNamespaceResponse.Value);
                Assert.Equal("Succeeded", getNamespaceResponse.Value.Properties.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal("Active", getNamespaceResponse.Value.Properties.Status, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(NamespaceType.NotificationHub, getNamespaceResponse.Value.Properties.NamespaceType);
                Assert.Equal(location, getNamespaceResponse.Value.Properties.Region, StringComparer.CurrentCultureIgnoreCase);

                //Create a namespace AuthorizationRule
                var authorizationRuleName = TestUtilities.GenerateName(NotificationHubsManagementHelper.AuthorizationRulesPrefix);
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                    {
                        Name = authorizationRuleName,
                        Properties = new SharedAccessAuthorizationRuleProperties()
                        {
                            KeyName = authorizationRuleName,
                            Rights = new List<AccessRights>() { AccessRights.Listen, AccessRights.Send },
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
                Assert.NotNull(createNamespaceAuthorizationRuleResponse.Value);
                Assert.Equal(createNamespaceAuthorizationRuleResponse.Value.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(createNamespaceAuthorizationRuleResponse.Value.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(createNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(createNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r == right));
                }

                //Get default namespace AuthorizationRules
                var getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse.Value);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Name, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Properties.KeyName, NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule);
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == AccessRights.Listen));
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == AccessRights.Send));
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == AccessRights.Manage));

                //Get created namespace AuthorizationRules
                getNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.GetAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse);
                Assert.NotNull(getNamespaceAuthorizationRulesResponse.Value);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Name, createAutorizationRuleParameter.Properties.KeyName);
                Assert.Equal(getNamespaceAuthorizationRulesResponse.Value.Properties.PrimaryKey, createAutorizationRuleParameter.Properties.PrimaryKey);
                Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Count == createAutorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRulesResponse.Value.Properties.Rights.Any(r => r == right));
                }

                //Get all namespaces AuthorizationRules 
                var getAllNamespaceAuthorizationRulesResponse = NotificationHubsManagementClient.Namespaces.ListAuthorizationRules(resourceGroup, namespaceName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse.Value);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Value.Count > 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Value.Any(ns => ns.Name == authorizationRuleName));
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Value.Any(auth => auth.Name == NotificationHubsManagementHelper.DefaultNamespaceAuthorizationRule));

                //Update namespace authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", NotificationHubsManagementHelper.GenerateRandomKey());
                SharedAccessAuthorizationRuleCreateOrUpdateParameters updateNamespaceAuthorizationRuleParameter = new SharedAccessAuthorizationRuleCreateOrUpdateParameters(getNamespaceAuthorizationRulesResponse.Value.Properties);
                updateNamespaceAuthorizationRuleParameter.Properties.Rights = new List<AccessRights>() { AccessRights.Listen };
                updateNamespaceAuthorizationRuleParameter.Properties.PrimaryKey = updatePrimaryKey;

                var updateNamespaceAuthorizationRuleResponse = NotificationHubsManagementClient.Namespaces.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName, authorizationRuleName, updateNamespaceAuthorizationRuleParameter);

                Assert.NotNull(updateNamespaceAuthorizationRuleResponse);
                Assert.NotNull(updateNamespaceAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName, updateNamespaceAuthorizationRuleResponse.Value.Name);
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
                Assert.NotNull(getNamespaceAuthorizationRuleResponse);
                Assert.NotNull(getNamespaceAuthorizationRuleResponse.Value);
                Assert.Equal(authorizationRuleName, getNamespaceAuthorizationRuleResponse.Value.Name);
                //Assert.Equal(getNamespaceAuthorizationRuleResponse.Value.Properties.PrimaryKey, updateNamespaceAuthorizationRuleParameter.Properties.PrimaryKey);
                Assert.Equal(getNamespaceAuthorizationRuleResponse.Value.Properties.KeyName, updateNamespaceAuthorizationRuleParameter.Properties.KeyName);
                Assert.True(getNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Count == updateNamespaceAuthorizationRuleParameter.Properties.Rights.Count);
                foreach (var right in updateNamespaceAuthorizationRuleParameter.Properties.Rights)
                {
                    Assert.True(getNamespaceAuthorizationRuleResponse.Value.Properties.Rights.Any(r => r.Equals(right)));
                }

                //Get the connectionString to the namespace for a Authorization rule created
                var listKeysResponse = NotificationHubsManagementClient.Namespaces.ListKeys(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(listKeysResponse);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysResponse.PrimaryConnectionString.Contains(getNamespaceAuthorizationRuleResponse.Value.Properties.PrimaryKey));
                Assert.NotNull(listKeysResponse.SecondaryConnectionString);
                Assert.NotNull(listKeysResponse.SecondaryConnectionString.Contains(getNamespaceAuthorizationRuleResponse.Value.Properties.SecondaryKey));

                //Delete namespace authorizationRule
                var deleteResponse = NotificationHubsManagementClient.Namespaces.DeleteAuthorizationRule(resourceGroup, namespaceName, authorizationRuleName);
                Assert.NotNull(deleteResponse);
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

                //Delete namespace
                var deleteNSResponse = NotificationHubsManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                Assert.NotNull(deleteNSResponse);
                Assert.True(HttpStatusCode.NotFound == deleteNSResponse.StatusCode || HttpStatusCode.OK == deleteNSResponse.StatusCode);
            }
        }        
    }
}
