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
            Assert.That(deidService.Data.Name, Is.EqualTo(deidServiceName));

            // Get
            DeidServiceResource deidServiceResource = (await rg.GetDeidServices().GetAsync(deidServiceName)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(deidServiceResource.Data.Properties.ProvisioningState, Is.EqualTo(HealthDataAIServicesProvisioningState.Succeeded));
                Assert.That(deidServiceResource.Data.Name, Is.EqualTo(deidServiceName));
                Assert.That(deidServiceResource.Data.Location, Is.EqualTo(Location));
                Assert.That(deidServiceResource.Data.Properties.ServiceUri.ToString(), Does.Contain("deid"), "ServiceUri should contain 'deid'");
            });

            // Delete
            ArmOperation operation = await deidService.DeleteAsync(WaitUntil.Completed);
            await operation.WaitForCompletionResponseAsync();
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
