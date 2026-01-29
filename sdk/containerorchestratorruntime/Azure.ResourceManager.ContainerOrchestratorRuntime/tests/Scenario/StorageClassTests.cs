// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerOrchestratorRuntime.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Tests.Tests
{
    [TestFixture]
    public class StorageClassTests : ContainerOrchestratorRuntimeManagementTestBase
    {
        public StorageClassTests() : base(true)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/52801")]
        public async Task CreateStorageClassAsync()
        {
            var nfsStorageClassTypeProperties = new NfsStorageClassTypeProperties("172.23.1.4", "/");
            var storageClassData = new ConnectedClusterStorageClassData
            {
                Properties = new ConnectedClusterStorageClassProperties(nfsStorageClassTypeProperties)
            };
            var storageClassCollection = new ConnectedClusterStorageClassCollection(Client, TestEnvironment.ConnectedCluster);
            var storageClassResource = await storageClassCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testsc", storageClassData);
            await storageClassResource.Value.DeleteAsync(WaitUntil.Started);
        }
    }
}
