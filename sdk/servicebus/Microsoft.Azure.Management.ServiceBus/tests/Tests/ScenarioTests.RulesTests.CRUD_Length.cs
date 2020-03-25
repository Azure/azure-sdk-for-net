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


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void RulesCreateGetUpdateDelete_Length()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                const string strSqlExp = "myproperty=test";               

                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }
                
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);


                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create a Topic
                var topicName = ServiceBusManagementHelper.TopicPrefix + "thisisthenamewithmorethan53charschecktoverifytheremovlaof50charsnamelenghtlimit";

                var createTopicResponse = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName,
                new SBTopic());
                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);

                // Get the created topic
                var getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, getTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);

                // Create Subscription.
                var subscriptionName = ServiceBusManagementHelper.SubscritpitonPrefix + "morethan50charschecktoverifqwer";
                var createSubscriptionResponse = ServiceBusManagementClient.Subscriptions.CreateOrUpdate(resourceGroup, namespaceName, topicName, subscriptionName, new SBSubscription());
                Assert.NotNull(createSubscriptionResponse);
                Assert.Equal(createSubscriptionResponse.Name, subscriptionName);

               // Create Rule with no filters.
               var ruleName = ServiceBusManagementHelper.RulesPrefix + "thisisthenamewithmorethan50charscheckto";
                var createRulesResponse = ServiceBusManagementClient.Rules.CreateOrUpdate(resourceGroup, namespaceName, topicName, subscriptionName, ruleName, new Rule());
                Assert.NotNull(createRulesResponse);
                Assert.Equal(createRulesResponse.Name, ruleName);

                // Get Created Rules
                var ruleGetResponse = ServiceBusManagementClient.Rules.Get(resourceGroup, namespaceName, topicName, subscriptionName, ruleName);
                Assert.NotNull(ruleGetResponse);
                Assert.Equal(ruleGetResponse.Name, ruleName);

                // Get all Rules  
                var getRulesListAllResponse = ServiceBusManagementClient.Rules.ListBySubscriptions(resourceGroup, namespaceName, topicName, subscriptionName);
                Assert.NotNull(getRulesListAllResponse);
                Assert.True(getRulesListAllResponse.Count() >= 1);
                Assert.True(getRulesListAllResponse.All(ns => ns.Id.Contains(resourceGroup)));

                // Update Rule with Filter and Action

                var updateRulesParameter = new Rule()
                {
                    Action = new SqlRuleAction()
                    {
                        RequiresPreprocessing = true,
                        SqlExpression = "SET " + strSqlExp,
                    },
                    SqlFilter = new SqlFilter() { SqlExpression = strSqlExp },
                    FilterType = FilterType.SqlFilter,
                    CorrelationFilter =  new CorrelationFilter()                                      
                };

                var updateRulesResponse = ServiceBusManagementClient.Rules.CreateOrUpdate(resourceGroup, namespaceName, topicName, subscriptionName, ruleName, updateRulesParameter);
                Assert.NotNull(updateRulesResponse);

                // Get the updated rule to check the Updated values. 
                var getRulesResponse = ServiceBusManagementClient.Rules.Get(resourceGroup, namespaceName, topicName, subscriptionName, ruleName);
                Assert.NotNull(getRulesResponse);
                //        Assert.Equal(true, getRulesResponse.Filter.RequiresPreprocessing);
                Assert.Equal(getRulesResponse.Name, ruleName);

                // Delete Created rule and check for the NotFound exception 
                ServiceBusManagementClient.Rules.Delete(resourceGroup, namespaceName, topicName, subscriptionName, ruleName);
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                
            }
        }
    }
}