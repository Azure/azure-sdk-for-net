// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
using System;
using System.Linq;
using System.Text;

namespace ServiceBusPublishSubscribeBasic
{
    public class Program
    {
        /**
         * Azure Service Bus basic scenario sample.
         * - Create namespace.
         * - Create a topic.
         * - Update topic with new size and a new ServiceBus subscription.
         * - Create another ServiceBus subscription in the topic.
         * - List topic
         * - List ServiceBus subscriptions
         * - Get default authorization rule.
         * - Regenerate the keys in the authorization rule.
         * - Send a message to topic using Data plan sdk for Service Bus.
         * - Delete one ServiceBus subscription as part of update of topic.
         * - Delete another ServiceBus subscription.
         * - Delete topic
         * - Delete namespace
         */
        public static void RunSample(IAzure azure)
        {
            var rgName = SdkContext.RandomResourceName("rgSB02_", 24);
            var namespaceName = SdkContext.RandomResourceName("namespace", 20);
            var topicName = SdkContext.RandomResourceName("topic_", 24);
            var subscription1Name = SdkContext.RandomResourceName("sub1_", 24);
            var subscription2Name = SdkContext.RandomResourceName("sub2_", 24);
            try
            {
                //============================================================
                // Create a namespace.

                Utilities.Log("Creating name space " + namespaceName + " in resource group " + rgName + "...");

                var serviceBusNamespace = azure.ServiceBusNamespaces
                        .Define(namespaceName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithSku(NamespaceSku.PremiumCapacity1)
                        .Create();

                Utilities.Log("Created service bus " + serviceBusNamespace.Name);
                Utilities.Print(serviceBusNamespace);

                //============================================================
                // Create a topic in namespace

                Utilities.Log("Creating topic " + topicName + " in namespace " + namespaceName + "...");

                var topic = serviceBusNamespace.Topics.Define(topicName)
                        .WithSizeInMB(2048)
                        .Create();

                Utilities.Log("Created second queue in namespace");

                Utilities.Print(topic);

                //============================================================
                // Get and update topic with new size and a subscription
                Utilities.Log("Updating topic " + topicName + " with new size and a subscription...");
                topic = serviceBusNamespace.Topics.GetByName(topicName);
                topic = topic.Update()
                        .WithNewSubscription(subscription1Name)
                        .WithSizeInMB(3072)
                        .Apply();

                Utilities.Log("Updated topic to change its size in MB along with a subscription");

                Utilities.Print(topic);

                var firstSubscription = topic.Subscriptions.GetByName(subscription1Name);
                Utilities.Print(firstSubscription);
                //============================================================
                // Create a subscription
                Utilities.Log("Adding second subscription" + subscription2Name + " to topic " + topicName + "...");
                var secondSubscription = topic.Subscriptions.Define(subscription2Name).WithDeleteOnIdleDurationInMinutes(10).Create();
                Utilities.Log("Added second subscription" + subscription2Name + " to topic " + topicName + "...");

                Utilities.Print(secondSubscription);

                //=============================================================
                // List topics in namespaces

                var topics = serviceBusNamespace.Topics.List();
                Utilities.Log("Number of topics in namespace :" + topics.Count());

                foreach (var topicInNamespace  in  topics)
                {
                    Utilities.Print(topicInNamespace);
                }

                //=============================================================
                // List all subscriptions for topic in namespaces

                var subscriptions = topic.Subscriptions.List();
                Utilities.Log("Number of subscriptions to topic: " + subscriptions.Count());

                foreach (var subscription  in  subscriptions)
                {
                    Utilities.Print(subscription);
                }

                //=============================================================
                // Get connection string for default authorization rule of namespace

                var namespaceAuthorizationRules = serviceBusNamespace.AuthorizationRules.List();
                Utilities.Log("Number of authorization rule for namespace :" + namespaceAuthorizationRules.Count());


                foreach (var namespaceAuthorizationRule in  namespaceAuthorizationRules)
                {
                    Utilities.Print(namespaceAuthorizationRule);
                }

                Utilities.Log("Getting keys for authorization rule ...");

                var keys = namespaceAuthorizationRules.FirstOrDefault().GetKeys();
                Utilities.Print(keys);
                Utilities.Log("Regenerating secondary key for authorization rule ...");
                keys = namespaceAuthorizationRules.FirstOrDefault().RegenerateKey(Policykey.SecondaryKey);
                Utilities.Print(keys);

                //=============================================================
                // Send a message to topic.
                Utilities.SendMessageToTopic(keys.PrimaryConnectionString, topicName, "Hello");
                //=============================================================
                // Delete a queue and namespace
                Utilities.Log("Deleting subscription " + subscription1Name + " in topic " + topicName + " via update flow...");
                topic = topic.Update().WithoutSubscription(subscription1Name).Apply();
                Utilities.Log("Deleted subscription " + subscription1Name + "...");

                Utilities.Log("Number of subscriptions in the topic after deleting first subscription: " + topic.SubscriptionCount);

                Utilities.Log("Deleting namespace " + namespaceName + "...");
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
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
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
