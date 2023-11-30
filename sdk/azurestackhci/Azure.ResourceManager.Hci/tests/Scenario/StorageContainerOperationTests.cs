// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class StorageContainerOperationTests: HciManagementTestBase
    {
        public StorageContainerOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task StorageContainerGetDelete()
        {
            var storageContainer = await CreateStorageContainerAsync();
            var testPath = "C:\\ClusterStorage\\Volume1\\sc-dotnet-test";

            StorageContainerResource storageContainerFromGet = await storageContainer.GetAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(storageContainerFromGet), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(storageContainerFromGet.Data.Name, storageContainer.Data.Name);
                Assert.AreEqual(storageContainerFromGet.Data.Path, testPath);
            }
            Assert.AreEqual(storageContainerFromGet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await storageContainerFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        [RecordedTest]
        public async Task StorageContainerSetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var storageContainer = await CreateStorageContainerAsync();

            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            StorageContainerResource updatedStorageContainer = await storageContainer.SetTagsAsync(tags);
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(updatedStorageContainer), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(tags, updatedStorageContainer.Data.Tags);
            }
            Assert.AreEqual(updatedStorageContainer.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);
        }
    }
}
