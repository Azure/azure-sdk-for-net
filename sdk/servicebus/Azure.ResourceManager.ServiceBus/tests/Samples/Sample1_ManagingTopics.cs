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
    public class Sample1_ManagingTopics
    {
        private ServiceBusTopicCollection serviceBusTopicCollection;

        [SetUp]
        public async Task CreateNamespace()
        {
            #region Snippet:Managing_ServiceBusTopics_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_ServiceBusTopics_CreateResourceGroup
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            #endregion
            #region Snippet:Managing_ServiceBusTopics_CreateNamespace
            string namespaceName = "myNamespace";
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespace serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new ServiceBusNamespaceData(location))).Value;
            ServiceBusTopicCollection serviceBusTopicCollection = serviceBusNamespace.GetServiceBusTopics();
            #endregion
            this.serviceBusTopicCollection = serviceBusTopicCollection;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Create()
        {
            #region Snippet:Managing_ServiceBusTopics_CreateTopic
            string topicName = "myTopic";
            ServiceBusTopic serviceBusTopic = (await serviceBusTopicCollection.CreateOrUpdateAsync(topicName, new ServiceBusTopicData())).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ServiceBusTopics_ListTopics
            await foreach (ServiceBusTopic serviceBusTopic in serviceBusTopicCollection.GetAllAsync())
            {
                Console.WriteLine(serviceBusTopic.Id.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_ServiceBusTopics_GetTopic
            ServiceBusTopic serviceBusTopic = await serviceBusTopicCollection.GetAsync("myTopic");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_ServiceBusTopics_GetTopicIfExists
            ServiceBusTopic serviceBusTopic = await serviceBusTopicCollection.GetIfExistsAsync("foo");
            if (serviceBusTopic != null)
            {
                Console.WriteLine("topic 'foo' exists");
            }
            if (await serviceBusTopicCollection.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("topic 'bar' exists");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_ServiceBusTopics_DeleteTopic
            ServiceBusTopic serviceBusTopic = await serviceBusTopicCollection.GetAsync("myTopic");
            await serviceBusTopic.DeleteAsync();
            #endregion
        }
    }
}
