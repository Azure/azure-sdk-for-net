// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.ServiceBus.Fluent;

using System;
using System.Linq;
using System.Text;

namespace ServiceBusWithClaimBasedAuthorization
{
    public class Program
    {
        /**
         * Azure Service Bus basic scenario sample.
         * - Create namespace with a queue and a topic
         * - Create 2 subscriptions for topic using different methods.
         * - Create send authorization rule for queue.
         * - Create send and listener authorization rule for Topic.
         * - Get the keys from authorization rule to connect to queue.
         * - Send a "Hello" message to queue using Data plan sdk for Service Bus.
         * - Send a "Hello" message to topic using Data plan sdk for Service Bus.
         * - Delete namespace
         */
        public static void RunSample(IAzure azure)
        {
            // New resources
            var rgName = SdkContext.RandomResourceName("rgSB03_", 24);
            var namespaceName = SdkContext.RandomResourceName("namespace", 20);
            var queueName = SdkContext.RandomResourceName("queue1_", 24);
            var topicName = SdkContext.RandomResourceName("topic_", 24);
            var subscription1Name = SdkContext.RandomResourceName("sub1_", 24);
            var subscription2Name = SdkContext.RandomResourceName("sub2_", 24);

            try
            {
                //============================================================
                // Create a namespace.

                Utilities.Log("Creating name space " + namespaceName + " along with a queue " + queueName + " and a topic " + topicName + " in resource group " + rgName + "...");

                var serviceBusNamespace = azure.ServiceBusNamespaces
                        .Define(namespaceName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithSku(NamespaceSku.PremiumCapacity1)
                        .WithNewQueue(queueName, 1024)
                        .WithNewTopic(topicName, 1024)
                        .Create();

                Utilities.Log("Created service bus " + serviceBusNamespace.Name + " (with queue and topic)");
                Utilities.Print(serviceBusNamespace);

                var queue = serviceBusNamespace.Queues.GetByName(queueName);
                Utilities.Print(queue);

                var topic = serviceBusNamespace.Topics.GetByName(topicName);
                Utilities.Print(topic);

                //============================================================
                // Create 2 subscriptions in topic using different methods.
                Utilities.Log("Creating a subscription in the topic using update on topic");
                topic = topic.Update().WithNewSubscription(subscription1Name).Apply();

                var subscription1 = topic.Subscriptions.GetByName(subscription1Name);

                Utilities.Log("Creating another subscription in the topic using direct create method for subscription");
                var subscription2 = topic.Subscriptions.Define(subscription2Name).Create();

                Utilities.Print(subscription1);
                Utilities.Print(subscription2);

                //=============================================================
                // Create new authorization rule for queue to send message.
                Utilities.Log("Create authorization rule for queue ...");
                var sendQueueAuthorizationRule = serviceBusNamespace.AuthorizationRules.Define("SendRule").WithSendingEnabled().Create();
                Utilities.Print(sendQueueAuthorizationRule);

                Utilities.Log("Getting keys for authorization rule ...");
                var keys = sendQueueAuthorizationRule.GetKeys();
                Utilities.Print(keys);

                //=============================================================
                // Send a message to queue.
                Utilities.SendMessageToQueue(keys.PrimaryConnectionString, queueName, "Hello");
                //=============================================================
                // Send a message to topic.
                Utilities.SendMessageToTopic(keys.PrimaryConnectionString, topicName, "Hello");
                //=============================================================
                // Delete a namespace
                Utilities.Log("Deleting namespace " + namespaceName + " [topic, queues and subscription will delete along with that]...");
                // This will delete the namespace and queue within it.
                try
                {
                    azure.ServiceBusNamespaces.DeleteById(serviceBusNamespace.Id);
                }
                catch (Exception)
                {
                }
                Utilities.Log("Deleted namespace " + namespaceName + "...");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
                }
            }
        }
        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e.ToString());
            }
        }
    }

}
