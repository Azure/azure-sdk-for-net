// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using System;
using System.Linq;
using System.Text;

namespace ServiceBusQueueAdvanceFeatures
{
    public class Program
    {
        /**
         * Azure Service Bus basic scenario sample.
         * - Create namespace.
         * - Add a queue in namespace with features session and dead-lettering.
         * - Create another queue with auto-forwarding to first queue. [Remove]
         * - Create another queue with dead-letter auto-forwarding to first queue. [Remove]
         * - Create second queue with Deduplication and AutoDeleteOnIdle feature
         * - Update second queue to change time for AutoDeleteOnIdle.
         * - Update first queue to disable dead-letter forwarding and with new Send authorization rule
         * - Update queue to remove the Send Authorization rule.
         * - Get default authorization rule.
         * - Get the keys from authorization rule to connect to queue.
         * - Send a "Hello" message to queue using Data plan sdk for Service Bus.
         * - Delete queue
         * - Delete namespace
         */
        public static void RunSample(IAzure azure)
        {
            var rgName = SdkContext.RandomResourceName("rgSB04_", 24);
            var namespaceName = SdkContext.RandomResourceName("namespace", 20);
            var queue1Name = SdkContext.RandomResourceName("queue1_", 24);
            var queue2Name = SdkContext.RandomResourceName("queue2_", 24);
            var sendRuleName = "SendRule";

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
                // Add a queue in namespace with features session and dead-lettering.
                Utilities.Log("Creating first queue " + queue1Name + ", with session, time to live and move to dead-letter queue features...");

                var firstQueue = serviceBusNamespace.Queues.Define(queue1Name)
                        .WithSession()
                        .WithDefaultMessageTTL(TimeSpan.FromMinutes(10))
                        .WithExpiredMessageMovedToDeadLetterQueue()
                        .WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(40)
                        .Create();
                Utilities.Print(firstQueue);

                //============================================================
                // Create second queue with Deduplication and AutoDeleteOnIdle feature

                Utilities.Log("Creating second queue " + queue2Name + ", with De-duplication and AutoDeleteOnIdle features...");

                var secondQueue = serviceBusNamespace.Queues.Define(queue2Name)
                        .WithSizeInMB(2048)
                        .WithDuplicateMessageDetection(TimeSpan.FromMinutes(10))
                        .WithDeleteOnIdleDurationInMinutes(10)
                        .Create();

                Utilities.Log("Created second queue in namespace");

                Utilities.Print(secondQueue);

                //============================================================
                // Update second queue to change time for AutoDeleteOnIdle.

                secondQueue = secondQueue.Update()
                        .WithDeleteOnIdleDurationInMinutes(5)
                        .Apply();

                Utilities.Log("Updated second queue to change its auto deletion time");

                Utilities.Print(secondQueue);

                //=============================================================
                // Update first queue to disable dead-letter forwarding and with new Send authorization rule
                secondQueue = firstQueue.Update()
                        .WithoutExpiredMessageMovedToDeadLetterQueue()
                        .WithNewSendRule(sendRuleName)
                        .Apply();

                Utilities.Log("Updated first queue to change dead-letter forwarding");

                Utilities.Print(secondQueue);

                //=============================================================
                // Get connection string for default authorization rule of namespace

                var namespaceAuthorizationRules = serviceBusNamespace.AuthorizationRules.List();
                Utilities.Log("Number of authorization rule for namespace :" + namespaceAuthorizationRules.Count());


                foreach (var namespaceAuthorizationRule in namespaceAuthorizationRules)
                {
                    Utilities.Print(namespaceAuthorizationRule);
                }

                Utilities.Log("Getting keys for authorization rule ...");

                var keys = namespaceAuthorizationRules.FirstOrDefault().GetKeys();
                Utilities.Print(keys);

                //=============================================================
                // Update first queue to remove Send Authorization rule.
                firstQueue.Update().WithoutAuthorizationRule(sendRuleName).Apply();

                //=============================================================
                // Send a message to queue.
                Utilities.SendMessageToQueue(keys.PrimaryConnectionString, queue1Name, "Hello");

                //=============================================================
                // Delete a queue and namespace
                Utilities.Log("Deleting queue " + queue1Name + "in namespace " + namespaceName + "...");
                serviceBusNamespace.Queues.DeleteByName(queue1Name);
                Utilities.Log("Deleted queue " + queue1Name + "...");

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
