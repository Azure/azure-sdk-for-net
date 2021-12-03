// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceBus.Models;
using Azure.ResourceManager.ServiceBus.Tests.Helpers;
namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class RuleTests : ServiceBusTestBase
    {
        public RuleTests(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        [RecordedTest]
        public async Task CreateGetUpdateDeleteRule()
        {
            const string strSqlExp = "myproperty=test";

            //create namespace
            ResourceGroup resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespace serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;

            //create a topic
            ServiceBusTopicCollection topicCollection = serviceBusNamespace.GetServiceBusTopics();
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopic topic = (await topicCollection.CreateOrUpdateAsync(topicName, new ServiceBusTopicData())).Value;
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //create a subscription
            ServiceBusSubscriptionCollection serviceBusSubscriptionCollection = topic.GetServiceBusSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            ServiceBusSubscriptionData parameters = new ServiceBusSubscriptionData();
            ServiceBusSubscription serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(subscriptionName, parameters)).Value;
            Assert.NotNull(serviceBusSubscription);
            Assert.AreEqual(serviceBusSubscription.Id.Name, subscriptionName);

            //create rule with no filters
            string ruleName1 = Recording.GenerateAssetName("rule");
            ServiceBusRuleCollection ruleCollection = serviceBusSubscription.GetServiceBusRules();
            ServiceBusRule rule1 = (await ruleCollection.CreateOrUpdateAsync(ruleName1, new ServiceBusRuleData())).Value;
            Assert.NotNull(rule1);
            Assert.AreEqual(rule1.Id.Name, ruleName1);

            //create rule with correlation filter
            string ruleName2 = Recording.GenerateAssetName("rule");
            ServiceBusRule rule2 = (await ruleCollection.CreateOrUpdateAsync(ruleName2, new ServiceBusRuleData(){FilterType = FilterType.CorrelationFilter})).Value;
            Assert.NotNull(rule2);
            Assert.AreEqual(rule2.Id.Name, ruleName2);

            //get created rules
            rule1 = await ruleCollection.GetAsync(ruleName1);
            Assert.NotNull(rule1);
            Assert.AreEqual(rule1.Id.Name, ruleName1);

            //get all rules
            List<ServiceBusRule> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, rules.Count);

            //update rule with sql filter and action
            ServiceBusRuleData updateParameters = new ServiceBusRuleData()
            {
                Action = new SqlRuleAction()
                {
                    RequiresPreprocessing = true,
                    SqlExpression = "SET " + strSqlExp,
                },
                SqlFilter = new SqlFilter() { SqlExpression = strSqlExp },
                FilterType = FilterType.SqlFilter,
                CorrelationFilter = new CorrelationFilter()
            };
            rule1 = (await ruleCollection.CreateOrUpdateAsync(ruleName1, updateParameters)).Value;

            await rule1.DeleteAsync();
            await rule2.DeleteAsync();
            await serviceBusSubscription.DeleteAsync();
            await serviceBusNamespace.DeleteAsync();
        }
    }
}
