// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample12_ManagingRules : ServiceBusLiveTestBase
    {
        [Test]
        public async Task ManageRules()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusManageRules
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string topicName = "<topic_name>";
                string subscriptionName = "<subscription_name>";
                DefaultAzureCredential credential = new();
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string topicName = scope.TopicName;
                string subscriptionName = scope.SubscriptionNames.First();
                var credential = TestEnvironment.Credential;
#endif

                await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

                await using ServiceBusRuleManager ruleManager = client.CreateRuleManager(topicName, subscriptionName);

                // By default, subscriptions are created with a default rule that always evaluates to True. In order to filter, we need
                // to delete the default rule. You can skip this step if you create the subscription with the ServiceBusAdministrationClient,
                // and specify a the FalseRuleFilter in the create rule options.
                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);
                await ruleManager.CreateRuleAsync("brand-filter", new CorrelationRuleFilter { Subject = "Toyota" });

                // create the sender
                ServiceBusSender sender = client.CreateSender(topicName);

                ServiceBusMessage[] messages =
                {
                    new ServiceBusMessage() { Subject = "Ford", ApplicationProperties = { { "Price", 25000 } } },
                    new ServiceBusMessage() { Subject = "Toyota", ApplicationProperties = { { "Price", 28000 } } },
                    new ServiceBusMessage() { Subject = "Honda", ApplicationProperties = { { "Price", 35000 } } }
                };

                // send the messages
                await sender.SendMessagesAsync(messages);

                // create a receiver for our subscription that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);

                // receive the message - we only get back the Toyota message
                while (true)
                {
                    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                    if (receivedMessage == null)
                    {
                        break;
                    }
                    Console.WriteLine($"Brand: {receivedMessage.Subject}, Price: {receivedMessage.ApplicationProperties["Price"]}");
                    await receiver.CompleteMessageAsync(receivedMessage);
                }

                await ruleManager.CreateRuleAsync("price-filter", new SqlRuleFilter("Price < 30000"));
                await ruleManager.DeleteRuleAsync("brand-filter");

                // we can also use the rule manager to iterate over the rules on the subscription.
                await foreach (RuleProperties rule in ruleManager.GetRulesAsync())
                {
                    // we should only have 1 rule at this point - "price-filter"
                    Console.WriteLine(rule.Name);
                }

                // send the messages again - because the subscription rules are evaluated when the messages are first enqueued, adding rules
                // for messages that are already in a subscription would have no effect.
                await sender.SendMessagesAsync(messages);

                // receive the messages - we get back both the Ford and the Toyota
                while (true)
                {
                    ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                    if (receivedMessage == null)
                    {
                        break;
                    }
                    Console.WriteLine($"Brand: {receivedMessage.Subject}, Price: {receivedMessage.ApplicationProperties["Price"]}");
                }
                #endregion
            }
        }
    }
}
