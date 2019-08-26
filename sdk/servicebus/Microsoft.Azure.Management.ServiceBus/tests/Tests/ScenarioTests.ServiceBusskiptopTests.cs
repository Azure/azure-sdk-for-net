// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
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
        public void ServiceBusskiptop()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
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
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create Queues  - 50
                var queueName = TestUtilities.GenerateName(ServiceBusManagementHelper.QueuesPrefix);
                int count = 0;
                while (count < 50)
                {
                    var createQueueResponse = this.ServiceBusManagementClient.Queues.CreateOrUpdate(resourceGroup, namespaceName, queueName+"_"+count.ToString(),
                    new SBQueue() { EnableExpress = true, EnableBatchedOperations = true });
                    count++;
                }

                var getFirst25 = this.ServiceBusManagementClient.Queues.ListByNamespace(resourceGroup, namespaceName, skip: 0, top: 25);
                Assert.Equal(25, getFirst25.Count<SBQueue>());

                var getlast10 = this.ServiceBusManagementClient.Queues.ListByNamespace(resourceGroup, namespaceName, skip: 40, top: 100);
                Assert.Equal(10, getlast10.Count<SBQueue>());



                // Create Topics - 50 
                var topicName = TestUtilities.GenerateName(ServiceBusManagementHelper.TopicPrefix);
                count = 0;
                while (count < 50)
                {
                    var createTopicResponse = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName + "_" + count.ToString(),
                        new SBTopic());
                    count++;
                }

                var getFirst25Topics = this.ServiceBusManagementClient.Topics.ListByNamespace(resourceGroup, namespaceName, skip: 0, top: 25);
                Assert.Equal(25, getFirst25Topics.Count<SBTopic>());

                var getlast10Topics = this.ServiceBusManagementClient.Topics.ListByNamespace(resourceGroup, namespaceName, skip: 40, top: 100);
                Assert.Equal(10, getlast10Topics.Count<SBTopic>());

                // Create Subscriptions
                var subscriptionName = TestUtilities.GenerateName(ServiceBusManagementHelper.SubscritpitonPrefix);
                count = 0;
                while (count < 50)
                {
                    var createSubscriptionResponse = this.ServiceBusManagementClient.Subscriptions.CreateOrUpdate(resourceGroup, namespaceName, topicName + "_0", subscriptionName + "_" + count.ToString(),
                        new SBSubscription());
                    count++;
                }

                var getFirst25Subscription = this.ServiceBusManagementClient.Subscriptions.ListByTopic(resourceGroup, namespaceName, topicName+"_0",  skip: 0, top: 25);
                Assert.Equal(25, getFirst25Subscription.Count<SBSubscription>());

                var getlast10subscriptions = this.ServiceBusManagementClient.Subscriptions.ListByTopic(resourceGroup, namespaceName, topicName + "_0", skip: 40, top: 100);
                Assert.Equal(10, getlast10subscriptions.Count<SBSubscription>());

                // Create Rules 
                var ruleName = TestUtilities.GenerateName(ServiceBusManagementHelper.RulesPrefix);
                count = 0;
                while (count < 50)
                {
                    var createRuleResponse = this.ServiceBusManagementClient.Rules.CreateOrUpdate(resourceGroup, namespaceName, topicName + "_0", subscriptionName + "_0", ruleName + "_" + count.ToString(),
                        new Rule());
                    count++;
                }

                var getFirst25Rule = this.ServiceBusManagementClient.Rules.ListBySubscriptions(resourceGroup, namespaceName, topicName + "_0", subscriptionName + "_0", skip: 0, top: 25);
                Assert.Equal(25, getFirst25Rule.Count<Rule>());

                var getlast10rule = this.ServiceBusManagementClient.Rules.ListBySubscriptions(resourceGroup, namespaceName, topicName + "_0", subscriptionName + "_0", skip: 40, top: 100);
                Assert.Equal(10, getlast10rule.Count<Rule>());

                // Delete Namespace

                this.ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
            }
        }
    }
}
