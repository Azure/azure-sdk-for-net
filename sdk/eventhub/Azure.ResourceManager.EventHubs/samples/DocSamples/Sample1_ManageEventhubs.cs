// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests.Samples
{
    public class Sample1_ManageEventhubs
    {
        private EventHubCollection eventHubCollection;

        [SetUp]
        public async Task CreateNamespace()
        {
            #region Snippet:Managing_EventHubs_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_EventHubs_CreateResourceGroup
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
            #endregion
            #region Snippet:Managing_EventHubs_CreateNamespace
            string namespaceName = "myNamespace";
            EventHubsNamespaceCollection namespaceCollection = resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubsNamespaceData(location))).Value;
            EventHubCollection eventHubCollection = eHNamespace.GetEventHubs();
            #endregion
            this.eventHubCollection = eventHubCollection;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Create()
        {
            #region Snippet:Managing_EventHubs_CreateEventHub
            string eventhubName = "myEventhub";
            EventHubResource eventHub = (await eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_EventHubs_ListEventHubs
            await foreach (EventHubResource eventHub in eventHubCollection.GetAllAsync())
            {
                Console.WriteLine(eventHub.Id.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_EventHubs_GetEventHub
            EventHubResource eventHub = await eventHubCollection.GetAsync("myEventHub");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_EventHubs_DeleteEventHub
            EventHubResource eventHub = await eventHubCollection.GetAsync("myEventhub");
            await eventHub.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
