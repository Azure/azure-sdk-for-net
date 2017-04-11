// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Fluent.ServiceBus.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Servicebus.Fluent;
using Microsoft.Azure.ServiceBus;
using System;
using System.Linq;
using System.Text;

namespace ServiceBusPublishSubscribeAdvanceFeatures
{
    public class Program
    {
        /**
         * Azure Service Bus basic scenario sample.
         * - Create namespace.
         * - Create a service bus subscription in the topic with session and dead-letter enabled.
         * - Create another subscription in the topic with auto deletion of idle entities.
         * - Create second topic with new Send Authorization rule, partitioning enabled and a new Service bus Subscription.
         * - Update second topic to change time for AutoDeleteOnIdle time, without Send rule and with a new manage authorization rule.
         * - Get the keys from default authorization rule to connect to topic.
         * - Send a "Hello" message to topic using Data plan sdk for Service Bus.
         * - Delete a topic
         * - Delete namespace
         */
        public static void RunSample(IAzure azure)
        {
            var rgName = SdkContext.RandomResourceName("rgSB04_", 24);
            var namespaceName = SdkContext.RandomResourceName("namespace", 20);
            var topic1Name = SdkContext.RandomResourceName("topic1_", 24);
            var topic2Name = SdkContext.RandomResourceName("topic2_", 24);
            var subscription1Name = SdkContext.RandomResourceName("subs_", 24);
            var subscription2Name = SdkContext.RandomResourceName("subs_", 24);
            var subscription3Name = SdkContext.RandomResourceName("subs_", 24);
            var sendRuleName = "SendRule";
            var manageRuleName = "ManageRule";

            try
            {
                //============================================================
                // Create a namespace.

                Console.WriteLine("Creating name space " + namespaceName + " in resource group " + rgName + "...");

                var serviceBusNamespace = azure.ServiceBusNamespaces
                        .Define(namespaceName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithSku(NamespaceSku.PremiumCapacity1)
                        .WithNewTopic(topic1Name, 1024)
                        .Create();

                Console.WriteLine("Created service bus " + serviceBusNamespace.Name);
                Utilities.Print(serviceBusNamespace);

                Console.WriteLine("Created topic following topic along with namespace " + namespaceName);

                var firstTopic = serviceBusNamespace.Topics.GetByName(topic1Name);
                Utilities.Print(firstTopic);

                //============================================================
                // Create a service bus subscription in the topic with session and dead-letter enabled.

                Console.WriteLine("Creating subscription " + subscription1Name + " in topic " + topic1Name + "...");
                var firstSubscription = firstTopic.Subscriptions.Define(subscription1Name)
                        .WithSession()
                        .WithDefaultMessageTTL(TimeSpan.FromMinutes(20))
                        .WithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount(20)
                        .WithExpiredMessageMovedToDeadLetterSubscription()
                        .WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException()
                        .Create();
                Console.WriteLine("Created subscription " + subscription1Name + " in topic " + topic1Name + "...");

                Utilities.Print(firstSubscription);

                //============================================================
                // Create another subscription in the topic with auto deletion of idle entities.
                Console.WriteLine("Creating another subscription " + subscription2Name + " in topic " + topic1Name + "...");

                var secondSubscription = firstTopic.Subscriptions.Define(subscription2Name)
                        .WithSession()
                        .WithDeleteOnIdleDurationInMinutes(20)
                        .Create();
                Console.WriteLine("Created subscription " + subscription2Name + " in topic " + topic1Name + "...");

                Utilities.Print(secondSubscription);

                //============================================================
                // Create second topic with new Send Authorization rule, partitioning enabled and a new Service bus Subscription.

                Console.WriteLine("Creating second topic " + topic2Name + ", with De-duplication and AutoDeleteOnIdle features...");

                var secondTopic = serviceBusNamespace.Topics.Define(topic2Name)
                        .WithNewSendRule(sendRuleName)
                        .WithPartitioning()
                        .WithNewSubscription(subscription3Name)
                        .Create();

                Console.WriteLine("Created second topic in namespace");

                Utilities.Print(secondTopic);

                Console.WriteLine("Creating following authorization rules in second topic ");

                var authorizationRules = secondTopic.AuthorizationRules.List();
                foreach (var authorizationRule in authorizationRules)
                {
                    Utilities.Print(authorizationRule);
                }

                //============================================================
                // Update second topic to change time for AutoDeleteOnIdle time, without Send rule and with a new manage authorization rule.
                Console.WriteLine("Updating second topic " + topic2Name + "...");

                secondTopic = secondTopic.Update()
                        .WithDeleteOnIdleDurationInMinutes(5)
                        .WithoutAuthorizationRule(sendRuleName)
                        .WithNewManageRule(manageRuleName)
                        .Apply();

                Console.WriteLine("Updated second topic to change its auto deletion time");

                Utilities.Print(secondTopic);
                Console.WriteLine("Updated  following authorization rules in second topic, new list of authorization rules are ");

                authorizationRules = secondTopic.AuthorizationRules.List();
                foreach (var authorizationRule in  authorizationRules)
                {
                    Utilities.Print(authorizationRule);
                }

                //=============================================================
                // Get connection string for default authorization rule of namespace

                var namespaceAuthorizationRules = serviceBusNamespace.AuthorizationRules.List();
                Console.WriteLine("Number of authorization rule for namespace :" + namespaceAuthorizationRules.Count());


                foreach (var namespaceAuthorizationRule in  namespaceAuthorizationRules)
                {
                    Utilities.Print(namespaceAuthorizationRule);
                }

                Console.WriteLine("Getting keys for authorization rule ...");

                var keys = namespaceAuthorizationRules.FirstOrDefault().GetKeys();
                Utilities.Print(keys);

                //=============================================================
                // Send a message to topic.
                try
                {
                    var topicClient = new TopicClient(keys.PrimaryConnectionString, topic1Name);
                    topicClient.SendAsync(new Message(Encoding.UTF8.GetBytes("Hello"))).Wait();
                    topicClient.Close();
                }
                catch (Exception)
                {
                }
                //=============================================================
                // Delete a topic and namespace
                Console.WriteLine("Deleting topic " + topic1Name + "in namespace " + namespaceName + "...");
                serviceBusNamespace.Topics.DeleteByName(topic1Name);
                Console.WriteLine("Deleted topic " + topic1Name + "...");

                Console.WriteLine("Deleting namespace " + namespaceName + "...");
                // This will delete the namespace and topic within it.
                try
                {
                    azure.ServiceBusNamespaces.DeleteById(serviceBusNamespace.Id);
                }
                catch (Exception ex)
                {
                }
                Console.WriteLine("Deleted namespace " + namespaceName + "...");

            }
            finally
            {
                try
                {
                    Console.WriteLine("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    Console.WriteLine("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
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
