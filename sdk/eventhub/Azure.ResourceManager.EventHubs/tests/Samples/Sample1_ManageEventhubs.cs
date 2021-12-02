// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
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
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_EventHubs_CreateResourceGroup
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            #endregion
            #region Snippet:Managing_EventHubs_CreateNamespace
            string namespaceName = "myNamespace";
            EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(location))).Value;
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
            EventHub eventHub = (await eventHubCollection.CreateOrUpdateAsync(eventhubName, new EventHubData())).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_EventHubs_ListEventHubs
            await foreach (EventHub eventHub in eventHubCollection.GetAllAsync())
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
            EventHub eventHub = await eventHubCollection.GetAsync("myEventHub");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_EventHubs_GetEventHubIfExists
            EventHub eventHub = await eventHubCollection.GetIfExistsAsync("foo");
            if (eventHub != null)
            {
                Console.WriteLine("eventHub 'foo' exists");
            }
            if (await eventHubCollection.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("eventHub 'bar' exists");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_EventHubs_DeleteEventHub
            EventHub eventHub = await eventHubCollection.GetAsync("myEventhub");
            await eventHub.DeleteAsync();
            #endregion
        }
    }
}
