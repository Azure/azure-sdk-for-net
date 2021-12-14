// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:Managing_ServiceBusNamespaces_Namespaces
using System;
using Azure.Identity;
using Azure.ResourceManager.ServiceBus;
using Azure.ResourceManager.ServiceBus.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion
using NUnit.Framework;
using System.Threading.Tasks;
namespace Azure.ResourceManager.ServiceBus.Tests.Samples
{
    public class Readme_ManagingNamespaces
    {
        private ResourceGroup resourceGroup;

        [SetUp]
        public async Task createResourceGroup()
        {
            #region Snippet:Managing_ServiceBusNamespaces_GetSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_ServiceBusNamespaces_CreateResourceGroup
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
            #region Snippet:Managing_ServiceBusNamespaces_CreateNamespace
            string namespaceName = "myNamespace";
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            Location location = Location.EastUS2;
            ServiceBusNamespace serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(namespaceName, new ServiceBusNamespaceData(location))).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ServiceBusNamespaces_ListNamespaces
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            await foreach (ServiceBusNamespace serviceBusNamespace in namespaceCollection.GetAllAsync())
            {
                Console.WriteLine(serviceBusNamespace.Id.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_ServiceBusNamespaces_GetNamespace
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespace serviceBusNamespace = await namespaceCollection.GetAsync("myNamespace");
            Console.WriteLine(serviceBusNamespace.Id.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_ServiceBusNamespaces_GetNamespaceIfExists
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespace serviceBusNamespace = await namespaceCollection.GetIfExistsAsync("foo");
            if (serviceBusNamespace != null)
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
            #region Snippet:Managing_ServiceBusNamespaces_DeleteNamespace
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespace serviceBusNamespace = await namespaceCollection.GetAsync("myNamespace");
            await serviceBusNamespace.DeleteAsync();
            #endregion
        }
    }
}
