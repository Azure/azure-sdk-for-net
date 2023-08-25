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
            Assert.AreEqual(storageMoverName, storageMover1.Id.Name);
            Assert.AreEqual("value1", storageMover1.Data.Tags["tag1"]);
            Assert.AreEqual("This is a new storage mover", storageMover1.Data.Description);

            StorageMoverResource storageMover2 = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName2, data)).Value;
            Assert.AreEqual(storageMoverName2, storageMover2.Id.Name);
            Assert.AreEqual("value1", storageMover1.Data.Tags["tag1"]);
            Assert.AreEqual("This is a new storage mover", storageMover1.Data.Description);

            storageMover1 = (await _resourceGroup.GetStorageMovers().GetAsync(storageMoverName)).Value;
            Assert.AreEqual(storageMoverName, storageMover1.Id.Name);
            Assert.AreEqual("value1", storageMover1.Data.Tags["tag1"]);
            Assert.AreEqual("This is a new storage mover", storageMover1.Data.Description);

            storageMovers = _resourceGroup.GetStorageMovers();
            int counter = 0;
            await foreach (StorageMoverResource _ in storageMovers.GetAllAsync())
            {
                counter++;
            }
            Assert.AreEqual(2, counter);

            data.Description = "This is an updated storage mover";
            storageMover1 = (await storageMovers.CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName, data)).Value;
            Assert.AreEqual(storageMoverName, storageMover1.Id.Name);
            Assert.AreEqual("value1", storageMover1.Data.Tags["tag1"]);
            Assert.AreEqual("This is an updated storage mover", storageMover1.Data.Description);

            Assert.IsTrue(await storageMovers.ExistsAsync(storageMoverName));
            Assert.IsFalse(await storageMovers.ExistsAsync(storageMoverName + "111"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await storageMovers.ExistsAsync(null));
        }
    }
}
