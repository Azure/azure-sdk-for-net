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
            IgnoreTestInLiveMode();

            const string strSqlExp = "myproperty=test";

            //create namespace
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;

            //create a topic
            ServiceBusTopicCollection topicCollection = serviceBusNamespace.GetServiceBusTopics();
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //create a subscription
            ServiceBusSubscriptionCollection serviceBusSubscriptionCollection = topic.GetServiceBusSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            ServiceBusSubscriptionData parameters = new ServiceBusSubscriptionData();
            ServiceBusSubscriptionResource serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionName, parameters)).Value;
            Assert.NotNull(serviceBusSubscription);
            Assert.AreEqual(serviceBusSubscription.Id.Name, subscriptionName);

            //create rule with no filters
            string ruleName1 = Recording.GenerateAssetName("rule");
            ServiceBusRuleCollection ruleCollection = serviceBusSubscription.GetServiceBusRules();
            ServiceBusRuleResource rule1 = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName1, new ServiceBusRuleData())).Value;
            Assert.NotNull(rule1);
            Assert.AreEqual(rule1.Id.Name, ruleName1);

            //create rule with correlation filter
            string ruleName2 = Recording.GenerateAssetName("rule");
            ServiceBusRuleResource rule2 = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName2, new ServiceBusRuleData(){FilterType = ServiceBusFilterType.CorrelationFilter})).Value;
            Assert.NotNull(rule2);
            Assert.AreEqual(rule2.Id.Name, ruleName2);

            //get created rules
            rule1 = await ruleCollection.GetAsync(ruleName1);
            Assert.NotNull(rule1);
            Assert.AreEqual(rule1.Id.Name, ruleName1);

            //get all rules
            List<ServiceBusRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, rules.Count);

            //update rule with sql filter and action
            ServiceBusRuleData updateParameters = new ServiceBusRuleData()
            {
                Action = new ServiceBusFilterAction()
                {
                    RequiresPreprocessing = true,
                    SqlExpression = "SET " + strSqlExp,
                },
                SqlFilter = new ServiceBusSqlFilter() { SqlExpression = strSqlExp },
                FilterType = ServiceBusFilterType.SqlFilter,
                CorrelationFilter = new ServiceBusCorrelationFilter()
            };
            rule1 = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName1, updateParameters)).Value;

            await rule1.DeleteAsync(WaitUntil.Completed);
            await rule2.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task CreateRuleWithCorrelationFilter()
        {
            IgnoreTestInLiveMode();

            //create namespace
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(DefaultLocation))).Value;

            //create a topic
            ServiceBusTopicCollection topicCollection = serviceBusNamespace.GetServiceBusTopics();
            string topicName = Recording.GenerateAssetName("topic");
            ServiceBusTopicResource topic = (await topicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //create a subscription
            ServiceBusSubscriptionCollection serviceBusSubscriptionCollection = topic.GetServiceBusSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            ServiceBusSubscriptionData parameters = new ServiceBusSubscriptionData();
            ServiceBusSubscriptionResource serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionName, parameters)).Value;
            Assert.NotNull(serviceBusSubscription);
            Assert.AreEqual(serviceBusSubscription.Id.Name, subscriptionName);

            //create rule with no filters
            string ruleName = Recording.GenerateAssetName("rule");
            ServiceBusRuleCollection ruleCollection = serviceBusSubscription.GetServiceBusRules();
            ServiceBusRuleData input = new ServiceBusRuleData()
            {
                FilterType = ServiceBusFilterType.CorrelationFilter,
                CorrelationFilter = new ServiceBusCorrelationFilter()
            };
            input.CorrelationFilter.ApplicationProperties.Add("stringKey", "stringVal");
            input.CorrelationFilter.ApplicationProperties.Add("intKey", 5);
            input.CorrelationFilter.ApplicationProperties.Add("dateTimeKey", Recording.Now.UtcDateTime);
            ServiceBusRuleResource rule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, input)).Value;
            Assert.NotNull(rule);
            Assert.AreEqual(rule.Id.Name, ruleName);
        }
    }
}
