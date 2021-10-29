// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:Managing_Namespaces_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion

namespace Azure.ResourceManager.EventHubs.Tests.Samples
{
    public class Readme_ManagingNamespaces
    {
        private ResourceGroup resourceGroup;
        [SetUp]
        public async Task createResourceGroup()
        {
            #region Snippet:Managing_Namespaces_CreateResourceGroup
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = operation.Value;
            #endregion
            this.resourceGroup = resourceGroup;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_Namespaces_CreateNamespace
            string namespaceName = "myNamespace";
            EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
            Location location = Location.EastUS2;
            EventHubNamespace eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new EventHubNamespaceData(location))).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_Namespaces_ListNamespaces
            EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
            await foreach (EventHubNamespace eventHubNamespace in namespaceCollection.GetAllAsync())
            {
                Console.WriteLine(eventHubNamespace.Id.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_Namespaces_GetNamespace
            EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
            Console.WriteLine(eventHubNamespace.Id.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_Namespaces_GetNamespaceIfExists
            EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eventHubNamespace = await namespaceCollection.GetIfExistsAsync("foo");
            if (eventHubNamespace != null)
            {
                Console.WriteLine("namespace 'foo' exists");
            }
            if (await namespaceCollection.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("namespace 'bar' exists");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_Namespaces_DeleteNamespace
            EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
            await eventHubNamespace.DeleteAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AddTag()
        {
            #region Snippet:Managing_Namespaces_AddTag
            EventHubNamespaceCollection namespaceCollection = resourceGroup.GetEventHubNamespaces();
            EventHubNamespace eventHubNamespace = await namespaceCollection.GetAsync("myNamespace");
            await eventHubNamespace.AddTagAsync("key","value");
            #endregion
        }
    }
}
