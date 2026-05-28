// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
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
        private const string SqlFilterOnlySubscriptionName = "RedSqlFilterSubscription";
        private const string SqlFilterWithActionSubscriptionName = "BlueSqlFilterWithActionSubscription";
        private const string CorrelationFilterSubscriptionName = "ImportantCorrelationFilterSubscription";

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
            // In this scenario, rather than deleting the default rule after creating the subscription,
            // we will create the subscription along with our desired rule in a single operation.
            // See https://learn.microsoft.com/azure/service-bus-messaging/topic-filters to learn more about topic filters.
            Console.WriteLine($"Creating subscription {SqlFilterOnlySubscriptionName}");
            await s_adminClient.CreateSubscriptionAsync(
                new CreateSubscriptionOptions(TopicName, SqlFilterOnlySubscriptionName),
                new CreateRuleOptions { Name = "RedSqlRule", Filter = new SqlRuleFilter("Color = 'Red'") });

            // 3rd Subscription: Add the SqlFilter Rule and Action
            // See https://learn.microsoft.com/azure/service-bus-messaging/topic-filters#actions to learn more about actions.
            Console.WriteLine($"Creating subscription {SqlFilterWithActionSubscriptionName}");
            await s_adminClient.CreateSubscriptionAsync(
                new CreateSubscriptionOptions(TopicName, SqlFilterWithActionSubscriptionName),
                new CreateRuleOptions
                {
                    Name = "BlueSqlRule",
                    Filter = new SqlRuleFilter("Color = 'Blue'"),
                    Action = new SqlRuleAction("SET Color = 'BlueProcessed'")
                });

            // 4th Subscription: Add Correlation Filter on Subscription 4
            Console.WriteLine($"Creating subscription {CorrelationFilterSubscriptionName}");
            await s_adminClient.CreateSubscriptionAsync(
                new CreateSubscriptionOptions(TopicName, CorrelationFilterSubscriptionName),
                new CreateRuleOptions
                {
                    Name = "ImportantCorrelationRule",
                    Filter = new CorrelationRuleFilter { Subject = "Red", CorrelationId = "important" }
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
            await ReceiveMessagesAsync(NoFilterSubscriptionName);

            // Receive messages from 'SqlFilterOnlySubscription'. Should receive all messages with Color = 'Red' i.e 3 messages
            await ReceiveMessagesAsync(SqlFilterOnlySubscriptionName);

            // Receive messages from 'SqlFilterWithActionSubscription'. Should receive all messages with Color = 'Blue'
            // i.e 3 messages AND all messages should have color set to 'BlueProcessed'
            await ReceiveMessagesAsync(SqlFilterWithActionSubscriptionName);

            // Receive messages from 'CorrelationFilterSubscription'. Should receive all messages  with Color = 'Red' and CorrelationId = "important"
            // i.e 1 message
            await ReceiveMessagesAsync(CorrelationFilterSubscriptionName);
            Console.ResetColor();
            
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Completed Receiving all messages. Disposing clients and deleting topic.");
            Console.WriteLine("=======================================================================");

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
            Console.WriteLine("Creating messages to send to Topic");
            List<ServiceBusMessage> messages = new ();
            messages.Add(CreateMessage(subject: "Red"));
            messages.Add(CreateMessage(subject: "Blue"));
            messages.Add(CreateMessage(subject: "Red", correlationId: "important"));
            messages.Add(CreateMessage(subject: "Blue", correlationId: "important"));
            messages.Add(CreateMessage(subject: "Red", correlationId: "notimportant"));
            messages.Add(CreateMessage(subject: "Blue", correlationId: "notimportant"));
            messages.Add(CreateMessage(subject: "Green"));
            messages.Add(CreateMessage(subject: "Green", correlationId: "important"));
            messages.Add(CreateMessage(subject: "Green", correlationId: "notimportant"));

            Console.WriteLine("Sending messages to send to Topic");
            await s_sender.SendMessagesAsync(messages);
            Console.WriteLine($"==========================================================================");
        }

        private static ServiceBusMessage CreateMessage(string subject, string correlationId = null)
        {
            ServiceBusMessage message = new() {Subject = subject};
            message.ApplicationProperties.Add("Color", subject);

            if (correlationId != null)
            {
                message.CorrelationId = correlationId;
            }

            PrintMessage(message);

            return message;
        }

        private static void PrintMessage(ServiceBusMessage message)
        {
            Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), message.Subject);
            Console.WriteLine($"Created message with color: {message.ApplicationProperties["Color"]}, CorrelationId: {message.CorrelationId}");
            Console.ResetColor();
        }
        
        private static void PrintReceivedMessage(ServiceBusReceivedMessage message)
        {
            Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), message.Subject);
            Console.WriteLine($"Received message with color: {message.ApplicationProperties["Color"]}, CorrelationId: {message.CorrelationId}");
            Console.ResetColor();
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
                    PrintReceivedMessage(receivedMessage);
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
