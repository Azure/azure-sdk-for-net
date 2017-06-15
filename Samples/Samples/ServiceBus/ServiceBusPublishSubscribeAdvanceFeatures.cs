// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using System;
using System.Linq;

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

                Utilities.Log("Creating name space " + namespaceName + " in resource group " + rgName + "...");

                var serviceBusNamespace = azure.ServiceBusNamespaces
                        .Define(namespaceName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithSku(NamespaceSku.PremiumCapacity1)
                        .WithNewTopic(topic1Name, 1024)
                        .Create();

                Utilities.Log("Created service bus " + serviceBusNamespace.Name);
                Utilities.Print(serviceBusNamespace);

                Utilities.Log("Created topic following topic along with namespace " + namespaceName);

                var firstTopic = serviceBusNamespace.Topics.GetByName(topic1Name);
                Utilities.Print(firstTopic);

                //============================================================
                // Create a service bus subscription in the topic with session and dead-letter enabled.

                Utilities.Log("Creating subscription " + subscription1Name + " in topic " + topic1Name + "...");
                var firstSubscription = firstTopic.Subscriptions.Define(subscription1Name)
                        .WithSession()
                        .WithDefaultMessageTTL(TimeSpan.FromMinutes(20))
                        .WithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount(20)
                        .WithExpiredMessageMovedToDeadLetterSubscription()
                        .WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException()
                        .Create();
                Utilities.Log("Created subscription " + subscription1Name + " in topic " + topic1Name + "...");

                Utilities.Print(firstSubscription);

                //============================================================
                // Create another subscription in the topic with auto deletion of idle entities.
                Utilities.Log("Creating another subscription " + subscription2Name + " in topic " + topic1Name + "...");

                var secondSubscription = firstTopic.Subscriptions.Define(subscription2Name)
                        .WithSession()
                        .WithDeleteOnIdleDurationInMinutes(20)
                        .Create();
                Utilities.Log("Created subscription " + subscription2Name + " in topic " + topic1Name + "...");

                Utilities.Print(secondSubscription);

                //============================================================
                // Create second topic with new Send Authorization rule, partitioning enabled and a new Service bus Subscription.

                Utilities.Log("Creating second topic " + topic2Name + ", with De-duplication and AutoDeleteOnIdle features...");

                var secondTopic = serviceBusNamespace.Topics.Define(topic2Name)
                        .WithNewSendRule(sendRuleName)
                        .WithPartitioning()
                        .WithNewSubscription(subscription3Name)
                        .Create();

                Utilities.Log("Created second topic in namespace");

                Utilities.Print(secondTopic);

                Utilities.Log("Creating following authorization rules in second topic ");

                var authorizationRules = secondTopic.AuthorizationRules.List();
                foreach (var authorizationRule in authorizationRules)
                {
                    Utilities.Print(authorizationRule);
                }

                //============================================================
                // Update second topic to change time for AutoDeleteOnIdle time, without Send rule and with a new manage authorization rule.
                Utilities.Log("Updating second topic " + topic2Name + "...");

                secondTopic = secondTopic.Update()
                        .WithDeleteOnIdleDurationInMinutes(5)
                        .WithoutAuthorizationRule(sendRuleName)
                        .WithNewManageRule(manageRuleName)
                        .Apply();

                Utilities.Log("Updated second topic to change its auto deletion time");

                Utilities.Print(secondTopic);
                Utilities.Log("Updated  following authorization rules in second topic, new list of authorization rules are ");

                authorizationRules = secondTopic.AuthorizationRules.List();
                foreach (var authorizationRule in  authorizationRules)
                {
                    Utilities.Print(authorizationRule);
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

                //=============================================================
                // Send a message to topic.
                Utilities.SendMessageToTopic(keys.PrimaryConnectionString, topic1Name, "Hello");
                //=============================================================
                // Delete a topic and namespace
                Utilities.Log("Deleting topic " + topic1Name + "in namespace " + namespaceName + "...");
                serviceBusNamespace.Topics.DeleteByName(topic1Name);
                Utilities.Log("Deleted topic " + topic1Name + "...");

                Utilities.Log("Deleting namespace " + namespaceName + "...");
                // This will delete the namespace and topic within it.
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
