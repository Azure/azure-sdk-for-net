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
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class StorageContainerCollectionTests: HciManagementTestBase
    {
        public StorageContainerCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task StorageContainerCreateGetList()
        {
            var testPath = "C:\\ClusterStorage\\Volume1\\sc-dotnet-test";
            var storageContainerCollection = ResourceGroup.GetStorageContainers();
            var storageContainer = await CreateStorageContainerAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(storageContainer), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(storageContainer.Data.Name, storageContainer.Data.Name);
                Assert.AreEqual(storageContainer.Data.Path, testPath);
            }
            Assert.AreEqual(storageContainer.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await foreach (StorageContainerResource storageContainerFromList in storageContainerCollection)
            {
                Assert.AreEqual(storageContainerFromList.Data.Path, testPath);
            }
        }
    }
}
