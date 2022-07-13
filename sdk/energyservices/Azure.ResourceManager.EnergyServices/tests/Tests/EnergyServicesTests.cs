// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EnergyServices.Models;
using Azure.ResourceManager.EnergyServices.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EnergyServices.Tests.Tests
{
    [TestFixture]
    public class EnergyServicesTests : EnergyServicesManagementTestBase
    {
        public EnergyServicesTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task TestEnergyServicesOperations()
        {
            //var resourceGroupName = "subscriptions/c99e2bf3-1777-412b-baba-d823676589c2/resourceGroups/komakkartest/";// Recording.GenerateAssetName("komakkartestiing");
            /*await EnergyServicesTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                EnergyServicesTestUtilities.DefaultResourceLocation, resourceGroupName);
            var energyServicesResourceName = Recording.GenerateAssetName("komakkarsdk");
            Console.WriteLine("Komakkar##################################################################");
            Console.WriteLine(energyServicesResourceName);
            EnergyServiceCollection energyServicesCollection = await GetEnergyServicesCollectionAsync(resourceGroupName);
            //EnergyServiceData energyServiceData = new EnergyServiceData();
            var createAddressOperation = await energyServicesCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName: energyServicesResourceName );*/
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            Console.WriteLine("################################"+  subscription);
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "komakkartest", AzureLocation.CentralUS);
            string resourceName = Recording.GenerateAssetName("resource");

            EnergyServiceCollection energyServiceCollection = rg.GetEnergyServices();
            //var resource = await energyServiceCollection; //.CreateOrUpdateAsync(WaitUntil.Completed, "komakkarsdk");
            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + energyServiceCollection.GetAll());
            var list = new List<DataPartitionNames>();
            list.Add(new DataPartitionNames("dp"));
            EnergyServiceData energyServiceData = new EnergyServiceData(AzureLocation.CentralUS);
            energyServiceData.Properties = new EnergyServiceProperties("2f59abbc-7b40-4d0e-91b2-22ca3084bc84", list);

            //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + energyServiceData.ToString());

            await energyServiceCollection.CreateOrUpdateAsync(data: energyServiceData, resourceName: "komakkarsdk2",waitUntil: WaitUntil.Completed);
            //EnergyServiceProperties energyServiceProperties = new EnergyServiceProperties(authAppId: "2f59abbc-7b40-4d0e-91b2-22ca3084bc84", dataPartitionNames:list , dnsName: "", ProvisioningState.Creating);
            //string dnsName, ProvisioningState? provisioningState, string authAppId, IList<DataPartitionNames> dataPartitionNames
            //energyServiceCollection.CreateOrUpdate()

            //ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.WestUS);
        }
    }
}
