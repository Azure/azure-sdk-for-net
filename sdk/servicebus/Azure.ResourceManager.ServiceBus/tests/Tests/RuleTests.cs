// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.ResourceManager.ServiceBus.Tests
{
    public class RuleTests : ServiceBusManagementTestBase
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
            Assert.Multiple(() =>
            {
                Assert.That(topic, Is.Not.Null);
                Assert.That(topicName, Is.EqualTo(topic.Id.Name));
            });

            //create a subscription
            ServiceBusSubscriptionCollection serviceBusSubscriptionCollection = topic.GetServiceBusSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            ServiceBusSubscriptionData parameters = new ServiceBusSubscriptionData();
            ServiceBusSubscriptionResource serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionName, parameters)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(serviceBusSubscription, Is.Not.Null);
                Assert.That(subscriptionName, Is.EqualTo(serviceBusSubscription.Id.Name));
            });

            //create rule with no filters
            string ruleName1 = Recording.GenerateAssetName("rule");
            ServiceBusRuleCollection ruleCollection = serviceBusSubscription.GetServiceBusRules();
            ServiceBusRuleResource rule1 = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName1, new ServiceBusRuleData())).Value;
            Assert.Multiple(() =>
            {
                Assert.That(rule1, Is.Not.Null);
                Assert.That(ruleName1, Is.EqualTo(rule1.Id.Name));
            });

            //create rule with correlation filter
            string ruleName2 = Recording.GenerateAssetName("rule");
            ServiceBusRuleResource rule2 = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName2, new ServiceBusRuleData(){FilterType = ServiceBusFilterType.CorrelationFilter})).Value;
            Assert.That(rule2, Is.Not.Null);
            Assert.That(ruleName2, Is.EqualTo(rule2.Id.Name));

            //get created rules
            rule1 = await ruleCollection.GetAsync(ruleName1);
            Assert.That(rule1, Is.Not.Null);
            Assert.That(ruleName1, Is.EqualTo(rule1.Id.Name));

            //get all rules
            List<ServiceBusRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(rules, Has.Count.EqualTo(2));

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
            Assert.Multiple(() =>
            {
                Assert.That(topic, Is.Not.Null);
                Assert.That(topicName, Is.EqualTo(topic.Id.Name));
            });

            //create a subscription
            ServiceBusSubscriptionCollection serviceBusSubscriptionCollection = topic.GetServiceBusSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            ServiceBusSubscriptionData parameters = new ServiceBusSubscriptionData();
            ServiceBusSubscriptionResource serviceBusSubscription = (await serviceBusSubscriptionCollection.CreateOrUpdateAsync(WaitUntil.Completed, subscriptionName, parameters)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(serviceBusSubscription, Is.Not.Null);
                Assert.That(subscriptionName, Is.EqualTo(serviceBusSubscription.Id.Name));
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(rule, Is.Not.Null);
                Assert.That(ruleName, Is.EqualTo(rule.Id.Name));
            });
        }
    }
}
