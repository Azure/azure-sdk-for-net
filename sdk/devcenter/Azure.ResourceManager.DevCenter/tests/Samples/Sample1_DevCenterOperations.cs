// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.DevCenter.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests.Samples
{
    public class Sample1_DevCenterOperations
    {
        private ResourceGroupResource _resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDevCenter()
        {
            #region Snippet:DevCenter_CreateDevCenter
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            // Get (or create) a resource group to place the DevCenter in
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            ArmOperation<ResourceGroupResource> rgLro = await rgCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "sample-rg",
                new ResourceGroupData(AzureLocation.EastUS));
            ResourceGroupResource resourceGroup = rgLro.Value;

            // Create the DevCenter resource
            DevCenterCollection devCenterCollection = resourceGroup.GetDevCenters();
            DevCenterData devCenterData = new DevCenterData(AzureLocation.EastUS)
            {
                Tags = { ["Environment"] = "Dev" }
            };
            ArmOperation<DevCenterResource> devCenterLro = await devCenterCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "Contoso",
                devCenterData);
            DevCenterResource devCenter = devCenterLro.Value;
            Console.WriteLine($"Created DevCenter with id: {devCenter.Data.Id}");
            #endregion Snippet:DevCenter_CreateDevCenter
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetDevCenter()
        {
            #region Snippet:DevCenter_GetDevCenter
            DevCenterCollection devCenterCollection = _resourceGroup.GetDevCenters();

            Response<DevCenterResource> response = await devCenterCollection.GetAsync("Contoso");
            DevCenterResource devCenter = response.Value;
            Console.WriteLine($"DevCenter: {devCenter.Data.Name}, Location: {devCenter.Data.Location}");
            #endregion Snippet:DevCenter_GetDevCenter
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListDevCenters()
        {
            #region Snippet:DevCenter_ListDevCenters
            DevCenterCollection devCenterCollection = _resourceGroup.GetDevCenters();

            await foreach (DevCenterResource devCenter in devCenterCollection.GetAllAsync())
            {
                Console.WriteLine($"DevCenter: {devCenter.Data.Name}");
            }
            #endregion Snippet:DevCenter_ListDevCenters
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDevCenter()
        {
            #region Snippet:DevCenter_DeleteDevCenter
            DevCenterCollection devCenterCollection = _resourceGroup.GetDevCenters();

            Response<DevCenterResource> response = await devCenterCollection.GetAsync("Contoso");
            DevCenterResource devCenter = response.Value;

            await devCenter.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine("DevCenter deleted successfully.");
            #endregion Snippet:DevCenter_DeleteDevCenter
        }
    }
}
