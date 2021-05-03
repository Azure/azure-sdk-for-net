// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace TopicSubscriptionWithRuleOperationsSample
{
    public class Program
    {
        private const string TopicName = "TopicSubscriptionWithRuleOperationsSample";

        private const string NoFilterSubscriptionName = "NoFilterSubscription";
        private const string SqlFilterOnlySubscriptionName = "SqlFilterOnlySubscription";
        private const string SqlFilterWithActionSubscriptionName = "SqlFilterWithActionSubscription";
        private const string CorrelationFilterSubscriptionName = "CorrelationFilterSubscription";

        private static ServiceBusClient s_client;
        private static ServiceBusAdministrationClient s_adminClient;
        private static ServiceBusSender s_sender;

        public static async Task Main(string[] args)
        {
            var command = new RootCommand("Demonstrates the Topic Filters feature of Azure Service Bus.")
            {
                new Option<string>(
                    alias: "--namespace",
                    description: "Fully qualified Service Bus Queue namespace to use") {Name = "FullyQualifiedNamespace"},
                new Option<string>(
                    alias: "--connection-variable",
                    description: "The name of an environment variable containing the connection string to use.") {Name = "Connection"},
            };
            command.Handler = CommandHandler.Create<string, string>(RunAsync);
            await command.InvokeAsync(args);
        }

        private static async Task RunAsync(string fullyQualifiedNamespace, string connection)
        {
            if (!string.IsNullOrEmpty(connection))
            {
                s_client = new ServiceBusClient(Environment.GetEnvironmentVariable(connection));
                s_adminClient = new ServiceBusAdministrationClient(Environment.GetEnvironmentVariable(connection));
            }
            else if (!string.IsNullOrEmpty(fullyQualifiedNamespace))
            {
                var defaultAzureCredential = new DefaultAzureCredential();
                s_client = new ServiceBusClient(fullyQualifiedNamespace, defaultAzureCredential);
                s_adminClient = new ServiceBusAdministrationClient(fullyQualifiedNamespace, defaultAzureCredential);
            }
            else
            {
                throw new ArgumentException(
                    "Either a fully qualified namespace or a connection string environment variable must be specified.");
            }

            Console.WriteLine($"Creating topic {TopicName}");
            await s_adminClient.CreateTopicAsync(TopicName);

            s_sender = s_client.CreateSender(TopicName);

            // First Subscription is already created with default rule. Leave as is.
            Console.WriteLine($"Creating subscription {NoFilterSubscriptionName}");
            await s_adminClient.CreateSubscriptionAsync(TopicName, NoFilterSubscriptionName);

            Console.WriteLine($"SubscriptionName: {NoFilterSubscriptionName}, Removing and re-adding Default Rule");
            await s_adminClient.DeleteRuleAsync(TopicName, NoFilterSubscriptionName, RuleProperties.DefaultRuleName);
            await s_adminClient.CreateRuleAsync(TopicName, NoFilterSubscriptionName,
                new CreateRuleOptions(RuleProperties.DefaultRuleName, new TrueRuleFilter()));

            // 2nd Subscription: Add SqlFilter on Subscription 2
            // Delete Default Rule.
            // Add the required SqlFilter Rule
            // Note: Does not apply to this sample but if there are multiple rules configured for a 
            // single subscription, then one message is delivered to the subscription when any of the 
            // rule matches. If more than one rules match and if there is no `SqlRuleAction` set for the
            // rule, then only one message will be delivered to the subscription. If more than one rules
            // match and there is a `SqlRuleAction` specified for the rule, then one message per `SqlRuleAction`
            // is delivered to the subscription.
            Console.WriteLine($"Creating subscription {SqlFilterOnlySubscriptionName}");
            await s_adminClient.CreateSubscriptionAsync(TopicName, SqlFilterOnlySubscriptionName);

            Console.WriteLine($"SubscriptionName: {SqlFilterOnlySubscriptionName}, Removing Default Rule and Adding SqlFilter");
            await s_adminClient.DeleteRuleAsync(TopicName, SqlFilterOnlySubscriptionName, RuleProperties.DefaultRuleName);
            await s_adminClient.CreateRuleAsync(
                TopicName,
                SqlFilterOnlySubscriptionName,
                new CreateRuleOptions {Name = "RedSqlRule", Filter = new SqlRuleFilter("Color = 'Red'")});


            // 3rd Subscription: Add SqlFilter and SqlRuleAction on Subscription 3
            // Delete Default Rule
            // Add the required SqlFilter Rule and Action
            Console.WriteLine($"Creating subscription {SqlFilterWithActionSubscriptionName}");
            await s_adminClient.CreateSubscriptionAsync(TopicName, SqlFilterWithActionSubscriptionName);

            Console.WriteLine(
                $"SubscriptionName: {SqlFilterWithActionSubscriptionName}, Removing Default Rule and Adding SqlFilter and SqlRuleAction");
            await s_adminClient.DeleteRuleAsync(TopicName, SqlFilterWithActionSubscriptionName, RuleProperties.DefaultRuleName);
            await s_adminClient.CreateRuleAsync(
                TopicName,
                SqlFilterWithActionSubscriptionName,
                new CreateRuleOptions
                {
                    Name = "BlueSqlRule",
                    Filter = new SqlRuleFilter("Color = 'Blue'"),
                    Action = new SqlRuleAction("SET Color = 'BlueProcessed'")
                });

            // 4th Subscription: Add Correlation Filter on Subscription 4
            Console.WriteLine($"Creating subscription {CorrelationFilterSubscriptionName}");
            await s_adminClient.CreateSubscriptionAsync(TopicName, CorrelationFilterSubscriptionName);

            Console.WriteLine($"SubscriptionName: {CorrelationFilterSubscriptionName}, Removing Default Rule and Adding CorrelationFilter");
            await s_adminClient.DeleteRuleAsync(TopicName, CorrelationFilterSubscriptionName, RuleProperties.DefaultRuleName);
            await s_adminClient.CreateRuleAsync(
                TopicName,
                CorrelationFilterSubscriptionName,
                new CreateRuleOptions
                {
                    Name = "ImportantCorrelationRule", Filter = new CorrelationRuleFilter {Subject = "Red", CorrelationId = "important"}
                });

            // Get Rules on Subscription, called here only for one subscription as example
            var rules = s_adminClient.GetRulesAsync(TopicName, CorrelationFilterSubscriptionName);
            await foreach (var rule in rules)
            {
                Console.WriteLine(
                    $"GetRules:: SubscriptionName: {CorrelationFilterSubscriptionName}, CorrelationFilter Name: {rule.Name}, Rule: {rule.Filter}");
            }

            // Send messages to Topic
            await SendMessagesAsync();

            // Receive messages from 'NoFilterSubscription'. Should receive all 9 messages 
            Console.ForegroundColor = ConsoleColor.Yellow;
            await ReceiveMessagesAsync(NoFilterSubscriptionName);

            Console.ForegroundColor = ConsoleColor.Red;
            // Receive messages from 'sqlFilterOnlySubscription'. Should receive all messages with Color = 'Red' i.e 3 messages
            await ReceiveMessagesAsync(SqlFilterOnlySubscriptionName);

            Console.ForegroundColor = ConsoleColor.Blue;
            // Receive messages from 'SqlFilterWithActionSubscription'. Should receive all messages with Color = 'Blue'
            // i.e 3 messages AND all messages should have color set to 'BlueProcessed'
            await ReceiveMessagesAsync(SqlFilterWithActionSubscriptionName);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            // Receive messages from 'CorrelationFilterSubscription'. Should receive all messages  with Color = 'Red' and CorrelationId = "important"
            // i.e 1 message
            await ReceiveMessagesAsync(CorrelationFilterSubscriptionName);
            Console.ResetColor();
            
            Console.WriteLine("======================================================================");
            Console.WriteLine("Completed Receiving all messages... Press any key to clean up and exit");
            Console.WriteLine("======================================================================");

            Console.ReadKey();

            Console.WriteLine("Disposing sender");
            await s_sender.CloseAsync();
            Console.WriteLine("Disposing client");
            await s_client.DisposeAsync();

            Console.WriteLine("Deleting topic");
            // Deleting the topic will handle deleting all the subscriptions as well.
            await s_adminClient.DeleteTopicAsync(TopicName);
        }

        private static async Task SendMessagesAsync()
        {
            Console.WriteLine($"==========================================================================");
            Console.WriteLine("Sending Messages to Topic");
            try
            {
                await Task.WhenAll(
                    SendMessageAsync(subject: "Red"),
                    SendMessageAsync(subject: "Blue"),
                    SendMessageAsync(subject: "Red", correlationId: "important"),
                    SendMessageAsync(subject: "Blue", correlationId: "important"),
                    SendMessageAsync(subject: "Red", correlationId: "notimportant"),
                    SendMessageAsync(subject: "Blue", correlationId: "notimportant"),
                    SendMessageAsync(subject: "Green"),
                    SendMessageAsync(subject: "Green", correlationId: "important"),
                    SendMessageAsync(subject: "Green", correlationId: "notimportant")
                );
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }

        private static async Task SendMessageAsync(string subject, string correlationId = null)
        {
            ServiceBusMessage message = new() {Subject = subject};
            message.ApplicationProperties.Add("Color", subject);

            if (correlationId != null)
            {
                message.CorrelationId = correlationId;
            }

            await s_sender.SendMessageAsync(message);
            Console.WriteLine($"Sent Message:: Label: {message.Subject}, CorrelationId: {message.CorrelationId}");
        }

        private static async Task ReceiveMessagesAsync(string subscriptionName)
        {
            await using ServiceBusReceiver subscriptionReceiver = s_client.CreateReceiver(
                TopicName,
                subscriptionName,
                new ServiceBusReceiverOptions {ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete});

            Console.WriteLine($"==========================================================================");
            Console.WriteLine($"{DateTime.Now} :: Receiving Messages From Subscription: {subscriptionName}");
            int receivedMessageCount = 0;
            while (true)
            {
                var receivedMessage = await subscriptionReceiver.ReceiveMessageAsync(TimeSpan.FromSeconds(1));
                if (receivedMessage != null)
                {
                    receivedMessage.ApplicationProperties.TryGetValue("Color", out object colorProperty);
                    Console.WriteLine($"Color Property = {colorProperty}, CorrelationId = {receivedMessage.CorrelationId}");
                    receivedMessageCount++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"{DateTime.Now} :: Received '{receivedMessageCount}' Messages From Subscription: {subscriptionName}");
            Console.WriteLine($"==========================================================================");
            await subscriptionReceiver.CloseAsync();
        }
    }
}
