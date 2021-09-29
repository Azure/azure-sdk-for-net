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
        private EventhubContainer eventhubContainer;

        [SetUp]
        public async Task CreateNamespace()
        {
            #region Snippet:Managing_EventHubs_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #endregion
            #region Snippet:Managing_EventHubs_CreateResourceGroup
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            #endregion
            #region Snippet:Managing_EventHubs_CreateNamespace
            string namespaceName = "myNamespace";
            EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(location))).Value;
            EventhubContainer eventhubContainer = eHNamespace.GetEventhubs();
            #endregion
            this.eventhubContainer = eventhubContainer;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Create()
        {
            #region Snippet:Managing_EventHubs_CreateEventHub
            string eventhubName = "myEventhub";
            Eventhub eventhub = (await eventhubContainer.CreateOrUpdateAsync(eventhubName, new EventhubData())).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_EventHubs_ListEventHubs
            await foreach (Eventhub eventhub in eventhubContainer.GetAllAsync())
            {
                Console.WriteLine(eventhub.Id.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_EventHubs_GetEventHub
            Eventhub eventhub = await eventhubContainer.GetAsync("myEventhub");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_EventHubs_GetEventHubIfExists
            Eventhub eventhub = await eventhubContainer.GetIfExistsAsync("foo");
            if (eventhub != null)
            {
                Console.WriteLine("eventhub 'foo' exists");
            }
            if (await eventhubContainer.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("eventhub 'bar' exists");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_EventHubs_DeleteEventHub
            Eventhub eventhub = await eventhubContainer.GetAsync("myEventhub");
            await eventhub.DeleteAsync();
            #endregion
        }
    }
}
