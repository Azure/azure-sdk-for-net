// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class StorageMoverCollectionTests : StorageMoverManagementTestBase
    {
       public StorageMoverCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
            {
            }

        private ResourceGroupResource _resourceGroup;

        [Test]
        [RecordedTest]
        public async Task CreateUpdateGetExistsTest()
        {
            _resourceGroup = await CreateResourceGroup(DefaultSubscription, ResourceGroupNamePrefix, TestLocation);
            StorageMoverCollection storageMovers = _resourceGroup.GetStorageMovers();

            StorageMoverData data = new StorageMoverData(TestLocation);
            data.Tags.Add("tag1", "value1");
            data.Description = "This is a new storage mover";
            string storageMoverName = Recording.GenerateAssetName(StorageMoverPrefix);
            string storageMoverName2 = Recording.GenerateAssetName(StorageMoverPrefix);

            StorageMoverResource storageMover1 = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName, data)).Value;
            Assert.That(storageMoverName, Is.EqualTo(storageMover1.Id.Name));
            Assert.That(storageMover1.Data.Tags["tag1"], Is.EqualTo("value1"));
            Assert.That(storageMover1.Data.Description, Is.EqualTo("This is a new storage mover"));

            StorageMoverResource storageMover2 = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName2, data)).Value;
            Assert.That(storageMoverName2, Is.EqualTo(storageMover2.Id.Name));
            Assert.That(storageMover1.Data.Tags["tag1"], Is.EqualTo("value1"));
            Assert.That(storageMover1.Data.Description, Is.EqualTo("This is a new storage mover"));

            storageMover1 = (await _resourceGroup.GetStorageMovers().GetAsync(storageMoverName)).Value;
            Assert.That(storageMoverName, Is.EqualTo(storageMover1.Id.Name));
            Assert.That(storageMover1.Data.Tags["tag1"], Is.EqualTo("value1"));
            Assert.That(storageMover1.Data.Description, Is.EqualTo("This is a new storage mover"));

            storageMovers = _resourceGroup.GetStorageMovers();
            int counter = 0;
            await foreach (StorageMoverResource _ in storageMovers.GetAllAsync())
            {
                counter++;
            }
            Assert.That(counter, Is.EqualTo(2));

            data.Description = "This is an updated storage mover";
            storageMover1 = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName, data)).Value;
            Assert.That(storageMoverName, Is.EqualTo(storageMover1.Id.Name));
            Assert.That(storageMover1.Data.Tags["tag1"], Is.EqualTo("value1"));
            Assert.That(storageMover1.Data.Description, Is.EqualTo("This is an updated storage mover"));

            Assert.That((await storageMovers.ExistsAsync(storageMoverName)).Value, Is.True);
            Assert.That((await storageMovers.ExistsAsync(storageMoverName + "111")).Value, Is.False);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await storageMovers.ExistsAsync(null));
        }
    }
}
