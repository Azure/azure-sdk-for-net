// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HealthDataAIServices.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HealthDataAIServices.Tests
{
    [TestFixture]
    public class DeidServicesCreateGetDelete : HealthDataAIServicesManagementTestBase
    {
        public DeidServicesCreateGetDelete() : base(true)
        {
        }

        //         [SetUp]
        //         public async Task ClearAndInitialize()
        //         {
        //             if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
        //             {
        //                 await InitializeClients();
        //             }
        //         }
        //
        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestAddressCRUDOperations()
        {
            ResourceGroupResource rg = await CreateResourceGroup("testRg");
            string deidServiceName = Recording.GenerateAssetName("deidService");

            // Create
            DeidServiceResource deidService = (await rg.GetDeidServices().CreateOrUpdateAsync(WaitUntil.Completed, deidServiceName, new DeidServiceData(Location))).Value;
            Assert.AreEqual(deidServiceName, deidService.Data.Name);

            // Get
            DeidServiceResource deidServiceResource = (await rg.GetDeidServices().GetAsync(deidServiceName)).Value;
            Assert.AreEqual(HealthDataAIServicesProvisioningState.Succeeded, deidServiceResource.Data.Properties.ProvisioningState);
            Assert.AreEqual(deidServiceName, deidServiceResource.Data.Name);
            Assert.AreEqual(Location, deidServiceResource.Data.Location);
            Assert.IsTrue(deidServiceResource.Data.Properties.ServiceUri.ToString().Contains("deid"), "ServiceUri should contain 'deid'");

            // Delete
            ArmOperation operation = await deidService.DeleteAsync(WaitUntil.Completed);
            await operation.WaitForCompletionResponseAsync();
            Assert.IsTrue(operation.HasCompleted);
        }
    }
}
