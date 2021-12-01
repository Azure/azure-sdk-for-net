// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_ConfigurationStores_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.AppConfiguration;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Snippet:Manage_ConfigurationStores_Namespaces

namespace Azure.ResourceManager.KeyVault.Tests.Samples
{
    public class Sample1_ManagingConfigurationStores
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_ConfigurationStores_CreateAConfigurationStore
            string configurationStoreName = ("myApp");
            ConfigurationStoreData configurationStoreData = new ConfigurationStoreData("westus", new Sku("Standard"))
            {
                PublicNetworkAccess = PublicNetworkAccess.Disabled
            };
            ConfigurationStore configurationStore = await (await resourceGroup.GetConfigurationStores().CreateOrUpdateAsync(configurationStoreName, configurationStoreData)).WaitForCompletionAsync();

            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ConfigurationStores_ListAllConfigurationStores
            AsyncPageable<ConfigurationStore> configurationStores = resourceGroup.GetConfigurationStores().GetAllAsync();

            await foreach (ConfigurationStore item in configurationStores)
            {
                Console.WriteLine(item.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_ConfigurationStores_GetAConfigurationStore
            ConfigurationStore configurationStore = await resourceGroup.GetConfigurationStores().GetAsync("myApp");
            Console.WriteLine(configurationStore.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExists()
        {
            #region Snippet:Managing_ConfigurationStores_GetAConfigurationStoreIfExists
            ConfigurationStoreCollection configurationStoreCollection = resourceGroup.GetConfigurationStores();

            ConfigurationStore configurationStore = await configurationStoreCollection.GetIfExistsAsync("foo");
            if (configurationStore != null)
            {
                Console.WriteLine(configurationStore.Data.Name);
            }

            if (await configurationStoreCollection.CheckIfExistsAsync("myApp"))
            {
                Console.WriteLine("ConfigurationStore 'myApp' exists.");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_ConfigurationStores_DeleteAConfigurationStore
            ConfigurationStoreCollection configurationStoreCollection = resourceGroup.GetConfigurationStores();

            ConfigurationStore configStore = await configurationStoreCollection.GetAsync("myApp");
            await (await configStore.DeleteAsync()).WaitForCompletionResponseAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.GetDefaultSubscriptionAsync().Result;
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the Collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroup resourceGroup = await rgCollection.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}
