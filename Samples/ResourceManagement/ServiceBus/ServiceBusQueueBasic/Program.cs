// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Fluent.ServiceBus.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Servicebus.Fluent;
using System;
using System.Linq;
using System.Text;

namespace ServiceBusQueueBasic
{
    public class Program
    {
        /**
         * Azure Service Bus basic scenario sample.
         * - Create namespace with a queue.
         * - Add another queue in same namespace.
         * - Update Queue.
         * - Update namespace
         * - List namespaces
         * - List queues
         * - Get default authorization rule.
         * - Regenerate the keys in the authorization rule.
         * - Get the keys from authorization rule to connect to queue.
         * - Send a "Hello" message to queue using Data plan sdk for Service Bus.
         * - Delete queue
         * - Delete namespace
         */
        public static void RunSample(IAzure azure)
        {
            var rgName = SdkContext.RandomResourceName("rgSB01_", 24);
            var namespaceName = SdkContext.RandomResourceName("namespace", 20);
            var queue1Name = SdkContext.RandomResourceName("queue1_", 24);
            var queue2Name = SdkContext.RandomResourceName("queue2_", 24);
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
                        .WithNewQueue(queue1Name, 1024)
                        .Create();

                Console.WriteLine("Created service bus " + serviceBusNamespace.Name);
                Utilities.Print(serviceBusNamespace);

                var firstQueue = serviceBusNamespace.Queues.GetByName(queue1Name);
                Utilities.Print(firstQueue);

                //============================================================
                // Create a second queue in same namespace

                Console.WriteLine("Creating second queue " + queue2Name + " in namespace " + namespaceName + "...");

                var secondQueue = serviceBusNamespace.Queues.Define(queue2Name)
                        .WithExpiredMessageMovedToDeadLetterQueue()
                        .WithSizeInMB(2048)
                        .WithMessageLockDurationInSeconds(20)
                        .Create();

                Console.WriteLine("Created second queue in namespace");

                Utilities.Print(secondQueue);

                //============================================================
                // Get and update second queue.

                secondQueue = serviceBusNamespace.Queues.GetByName(queue2Name);
                secondQueue = secondQueue.Update().WithSizeInMB(3072).Apply();

                Console.WriteLine("Updated second queue to change its size in MB");

                Utilities.Print(secondQueue);

                //=============================================================
                // Update namespace
                Console.WriteLine("Updating sku of namespace " + serviceBusNamespace.Name + "...");

                serviceBusNamespace = serviceBusNamespace
                        .Update()
                        .WithSku(NamespaceSku.PremiumCapacity1)
                        .Apply();
                Console.WriteLine("Updated sku of namespace " + serviceBusNamespace.Name);

                //=============================================================
                // List namespaces

                Console.WriteLine("List of namespaces in resource group " + rgName + "...");

                foreach (var serviceBusNamespace1  in  azure.ServiceBusNamespaces.ListByResourceGroup(rgName))
                {
                    Utilities.Print(serviceBusNamespace1);
                }

                //=============================================================
                // List queues in namespaces

                var queues = serviceBusNamespace.Queues.List();
                Console.WriteLine("Number of queues in namespace :" + queues.Count());

                foreach (var queue in queues)
                {
                    Utilities.Print(queue);
                }

                //=============================================================
                // Get connection string for default authorization rule of namespace

                var namespaceAuthorizationRules = serviceBusNamespace.AuthorizationRules.List();
                Console.WriteLine("Number of authorization rule for namespace :" + namespaceAuthorizationRules.Count());

                foreach (var namespaceAuthorizationRule in namespaceAuthorizationRules)
                {
                    Utilities.Print(namespaceAuthorizationRule);
                }

                Console.WriteLine("Getting keys for authorization rule ...");

                var keys = namespaceAuthorizationRules.FirstOrDefault().GetKeys();
                Utilities.Print(keys);
                Console.WriteLine("Regenerating secondary key for authorization rule ...");
                keys = namespaceAuthorizationRules.FirstOrDefault().RegenerateKey(Policykey.SecondaryKey);
                Utilities.Print(keys);

                //=============================================================
                // Send a message to queue.
                Utilities.SendMessageToQueue(keys.PrimaryConnectionString, queue1Name, "Hello");
                //=============================================================
                // Delete a queue and namespace
                Console.WriteLine("Deleting queue " + queue1Name + "in namespace " + namespaceName + "...");
                serviceBusNamespace.Queues.DeleteByName(queue1Name);
                Console.WriteLine("Deleted queue " + queue1Name + "...");

                Console.WriteLine("Deleting namespace " + namespaceName + "...");
                // This will delete the namespace and queue within it.
                try
                {
                    azure.ServiceBusNamespaces.DeleteById(serviceBusNamespace.Id);
                }
                catch (Exception)
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
                    Console.WriteLine(g);
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
