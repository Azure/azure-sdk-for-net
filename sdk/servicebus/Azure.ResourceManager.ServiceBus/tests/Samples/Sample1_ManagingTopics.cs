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
    public class Sample1_ManagingTopics
    {
        private ServiceBusTopicCollection serviceBusTopicCollection;

        [SetUp]
        public async Task CreateNamespace()
        {
            #region Snippet:Managing_ServiceBusTopics_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_ServiceBusTopics_CreateResourceGroup
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
            #endregion
            #region Snippet:Managing_ServiceBusTopics_CreateNamespace
            string namespaceName = "myNamespace";
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(location))).Value;
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
            ServiceBusTopicResource serviceBusTopic = (await serviceBusTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, topicName, new ServiceBusTopicData())).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ServiceBusTopics_ListTopics
            await foreach (ServiceBusTopicResource serviceBusTopic in serviceBusTopicCollection.GetAllAsync())
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
            ServiceBusTopicResource serviceBusTopic = await serviceBusTopicCollection.GetAsync("myTopic");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_ServiceBusTopics_DeleteTopic
            ServiceBusTopicResource serviceBusTopic = await serviceBusTopicCollection.GetAsync("myTopic");
            await serviceBusTopic.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
