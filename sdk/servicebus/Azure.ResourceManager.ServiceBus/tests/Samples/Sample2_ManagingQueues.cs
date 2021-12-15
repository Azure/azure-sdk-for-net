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
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_ServiceBusQueues_CreateResourceGroup
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            #endregion
            #region Snippet:Managing_ServiceBusQueues_CreateNamespace
            string namespaceName = "myNamespace";
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespace serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new ServiceBusNamespaceData(location))).Value;
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
            ServiceBusQueue serviceBusQueue = (await serviceBusQueueCollection.CreateOrUpdateAsync(queueName, new ServiceBusQueueData())).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ServiceBusQueues_ListQueues
            await foreach (ServiceBusQueue serviceBusQueue in serviceBusQueueCollection.GetAllAsync())
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
            ServiceBusQueue serviceBusQueue = await serviceBusQueueCollection.GetAsync("myQueue");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_ServiceBusQueues_GetQueueIfExists
            ServiceBusQueue serviceBusQueue = await serviceBusQueueCollection.GetIfExistsAsync("foo");
            if (serviceBusQueue != null)
            {
                Console.WriteLine("queue 'foo' exists");
            }
            if (await serviceBusQueueCollection.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("queue 'bar' exists");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_ServiceBusQueues_DeleteQueue
            ServiceBusQueue serviceBusQueue = await serviceBusQueueCollection.GetAsync("myQueue");
            await serviceBusQueue.DeleteAsync();
            #endregion
        }
    }
}
