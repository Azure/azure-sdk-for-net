// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_ConfigurationStores_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.AppConfiguration;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Snippet:Manage_ConfigurationStores_Namespaces

namespace Azure.ResourceManager.AppConfiguration.Tests.Samples
{
    public class Sample1_ManagingConfigurationStores
    {
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_ConfigurationStores_CreateAConfigurationStore
            string configurationStoreName = ("myApp");
            AppConfigurationStoreData configurationStoreData = new AppConfigurationStoreData("westus", new AppConfigurationSku("Standard"))
            {
                PublicNetworkAccess = AppConfigurationPublicNetworkAccess.Disabled
            };
            AppConfigurationStoreResource configurationStore = (await resourceGroup.GetAppConfigurationStores().CreateOrUpdateAsync(WaitUntil.Completed, configurationStoreName, configurationStoreData)).Value;

            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_ConfigurationStores_ListAllConfigurationStores
            AsyncPageable<AppConfigurationStoreResource> configurationStores = resourceGroup.GetAppConfigurationStores().GetAllAsync();

            await foreach (AppConfigurationStoreResource item in configurationStores)
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
            AppConfigurationStoreResource configurationStore = await resourceGroup.GetAppConfigurationStores().GetAsync("myApp");
            Console.WriteLine(configurationStore.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Delete()
        {
            #region Snippet:Managing_ConfigurationStores_DeleteAConfigurationStore
            AppConfigurationStoreCollection configurationStoreCollection = resourceGroup.GetAppConfigurationStores();

            AppConfigurationStoreResource configStore = await configurationStoreCollection.GetAsync("myApp");
            await configStore.DeleteAsync(WaitUntil.Completed);
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = armClient.GetDefaultSubscriptionAsync().Result;
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the Collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupResource resourceGroup = (await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location))).Value;
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}
