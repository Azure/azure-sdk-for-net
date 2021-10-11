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
namespace Azure.ResourceManager.ServiceBus.Tests.Tests
{
    public class RuleTests : ServiceBusTestBase
    {
        public RuleTests(bool isAsync) : base(isAsync)
        {
        }
        [Test]
        [RecordedTest]
        [Ignore("cannot parse SBSubscription id")]
        public async Task CreateGetUpdateDeleteRule()
        {
            const string strSqlExp = "myproperty=test";

            //create namespace
            ResourceGroup resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            SBNamespaceContainer namespaceContainer = resourceGroup.GetSBNamespaces();
            SBNamespace sBNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new SBNamespaceData(DefaultLocation))).Value;

            //create a topic
            SBTopicContainer topicContainer = sBNamespace.GetSBTopics();
            string topicName = Recording.GenerateAssetName("topic");
            SBTopic topic = (await topicContainer.CreateOrUpdateAsync(topicName, new SBTopicData())).Value;
            Assert.NotNull(topic);
            Assert.AreEqual(topic.Id.Name, topicName);

            //create a subscription
            SBSubscriptionContainer sBSubscriptionContainer = topic.GetSBSubscriptions();
            string subscriptionName = Recording.GenerateAssetName("subscription");
            SBSubscriptionData parameters = new SBSubscriptionData();
            SBSubscription sBSubscription = (await sBSubscriptionContainer.CreateOrUpdateAsync(subscriptionName, parameters)).Value;
            Assert.NotNull(sBSubscription);
            Assert.AreEqual(sBSubscription.Id.Name, subscriptionName);

            //create rule with no filters
            string ruleName1 = Recording.GenerateAssetName("rule");
            RuleContainer ruleContainer = sBSubscription.GetRules();
            Rule rule1 = (await ruleContainer.CreateOrUpdateAsync(ruleName1, new RuleData())).Value;
            Assert.NotNull(rule1);
            Assert.AreEqual(rule1.Id.Name, ruleName1);

            //create rule with correlation filter
            string ruleName2 = Recording.GenerateAssetName("rule");
            Rule rule2 = (await ruleContainer.CreateOrUpdateAsync(ruleName2, new RuleData(){FilterType = FilterType.CorrelationFilter})).Value;
            Assert.NotNull(rule2);
            Assert.AreEqual(rule2.Id.Name, ruleName2);

            //get created rules
            rule1 = await ruleContainer.GetAsync(ruleName1);
            Assert.NotNull(rule1);
            Assert.AreEqual(rule1.Id.Name, ruleName1);

            //get all rules
            List<Rule> rules = await ruleContainer.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(2, rules.Count);

            //update rule with sql filter and action
            RuleData updateParameters = new RuleData()
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
            rule1 = (await ruleContainer.CreateOrUpdateAsync(ruleName1, updateParameters)).Value;

            await rule1.DeleteAsync();
            await rule2.DeleteAsync();
            await sBSubscription.DeleteAsync();
            await sBNamespace.DeleteAsync();
        }
    }
}
