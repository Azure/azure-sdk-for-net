// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:Managing_ServiceBusNamespaces_Namespaces
using System;
using Azure.Core;
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
        private ResourceGroupResource resourceGroup;

        [SetUp]
        public async Task createResourceGroup()
        {
            #region Snippet:Managing_ServiceBusNamespaces_GetSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion
            #region Snippet:Managing_ServiceBusNamespaces_CreateResourceGroup
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> operation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = operation.Value;
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
            AzureLocation location = AzureLocation.EastUS2;
            ServiceBusNamespaceResource serviceBusNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new ServiceBusNamespaceData(location))).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ServiceBusNamespaces_ListNamespaces
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            await foreach (ServiceBusNamespaceResource serviceBusNamespace in namespaceCollection.GetAllAsync())
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
            ServiceBusNamespaceResource serviceBusNamespace = await namespaceCollection.GetAsync("myNamespace");
            Console.WriteLine(serviceBusNamespace.Id.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_ServiceBusNamespaces_DeleteNamespace
            ServiceBusNamespaceCollection namespaceCollection = resourceGroup.GetServiceBusNamespaces();
            ServiceBusNamespaceResource serviceBusNamespace = await namespaceCollection.GetAsync("myNamespace");
            await serviceBusNamespace.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
