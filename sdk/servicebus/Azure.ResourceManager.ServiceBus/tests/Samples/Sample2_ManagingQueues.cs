// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.ServiceBus;
using Azure.ResourceManager.ServiceBus.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.ServiceBus.Tests.Samples
{
    public class  Sample2_ManagingQueues
    {
        private ServiceBusQueueCollection serviceBusQueueCollection;
        [SetUp]
        public async Task createNamespace()
        {
            #region Snippet:Managing_ServiceBusQueues_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_ServiceBusQueues_CreateResourceGroup
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
            #endregion
            #region Snippet:Managing_ServiceBusQueues_CreateNamespace
            string namespaceName = "myNamespace";
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(location))).Value;
            ServiceBusQueueCollection serviceBusQueueCollection = serviceBusNamespace.GetServiceBusQueues();
            #endregion
            this.serviceBusQueueCollection = serviceBusQueueCollection;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Create()
        {
            #region Snippet:Managing_ServiceBusQueues_CreateQueue
            string queueName = "myQueue";
            ServiceBusQueueResource serviceBusQueue = (await serviceBusQueueCollection.CreateOrUpdateAsync(WaitUntil.Completed, queueName, new ServiceBusQueueData())).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ServiceBusQueues_ListQueues
            await foreach (ServiceBusQueueResource serviceBusQueue in serviceBusQueueCollection.GetAllAsync())
            {
                Console.WriteLine(serviceBusQueue.Id.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_ServiceBusQueues_GetQueue
            ServiceBusQueueResource serviceBusQueue = await serviceBusQueueCollection.GetAsync("myQueue");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_ServiceBusQueues_DeleteQueue
            ServiceBusQueueResource serviceBusQueue = await serviceBusQueueCollection.GetAsync("myQueue");
            await serviceBusQueue.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
