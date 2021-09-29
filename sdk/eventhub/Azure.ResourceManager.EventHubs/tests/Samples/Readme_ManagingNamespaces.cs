﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            Subscription subscription = armClient.DefaultSubscription;
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
            EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
            Location location = Location.EastUS2;
            EHNamespace eHNamespace = (await namespaceContainer.CreateOrUpdateAsync(namespaceName, new EHNamespaceData(location))).Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_Namespaces_ListNamespaces
            EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
            await foreach (EHNamespace eHNamespace in namespaceContainer.GetAllAsync())
            {
                Console.WriteLine(eHNamespace.Id.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_Namespaces_GetNamespace
            EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = await namespaceContainer.GetAsync("myNamespace");
            Console.WriteLine(eHNamespace.Id.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExist()
        {
            #region Snippet:Managing_Namespaces_GetNamespaceIfExists
            EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = await namespaceContainer.GetIfExistsAsync("foo");
            if (eHNamespace != null)
            {
                Console.WriteLine("namespace 'foo' exists");
            }
            if (await namespaceContainer.CheckIfExistsAsync("bar"))
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
            EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = await namespaceContainer.GetAsync("myNamespace");
            await eHNamespace.DeleteAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AddTag()
        {
            #region Snippet:Managing_Namespaces_AddTag
            EHNamespaceContainer namespaceContainer = resourceGroup.GetEHNamespaces();
            EHNamespace eHNamespace = await namespaceContainer.GetAsync("myNamespace");
            await eHNamespace.AddTagAsync("key","value");
            #endregion
        }
    }
}
