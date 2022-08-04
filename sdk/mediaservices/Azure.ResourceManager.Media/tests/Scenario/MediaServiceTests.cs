// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Media.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class MediaServiceTests : MediaManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceIdentifier _storageAccountIdentifier;
        private ResourceGroupResource _resourceGroup;

        private MediaServiceCollection mediaServiceCollection => _resourceGroup.GetMediaServices();

        public MediaServiceTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName($"MediaService-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
            string storageAccountName = SessionRecording.GenerateAssetName("azstorageformedia");
            var storage = await CreateStorageAccount(rgLro.Value, storageAccountName);
            _storageAccountIdentifier = storage.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup  = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string mediaServiceName = SessionRecording.GenerateAssetName("mediaservice");
            var mediaService = await CreateMediaService(_resourceGroup, mediaServiceName, _storageAccountIdentifier);
            Assert.IsNotNull(mediaService);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var mediaService = await mediaServiceCollection.GetAllAsync().ToEnumerableAsync();
            System.Console.WriteLine(mediaService);
        }
    }
}
