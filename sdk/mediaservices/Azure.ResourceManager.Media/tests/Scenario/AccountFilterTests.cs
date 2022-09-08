// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class AccountFilterTests : MediaManagementTestBase
    {
        private ResourceIdentifier _mediaServiceIdentifier;
        private MediaServicesAccountResource _mediaService;

        private AccountFilterCollection accountFilterCollection => _mediaService.GetAccountFilters();

        public AccountFilterTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var storage = await CreateStorageAccount(rgLro.Value, SessionRecording.GenerateAssetName(StorageAccountNamePrefix));
            var mediaService = await CreateMediaService(rgLro.Value, SessionRecording.GenerateAssetName("mediaservice"), storage.Id);
            _mediaServiceIdentifier = mediaService.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _mediaService = await Client.GetMediaServicesAccountResource(_mediaServiceIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string accountFilterName = SessionRecording.GenerateAssetName("accountFilter");
            var mediaAsset = await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new AccountFilterData());
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(accountFilterName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string accountFilterName = SessionRecording.GenerateAssetName("accountFilter");
            await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new AccountFilterData());
            bool flag = await accountFilterCollection.ExistsAsync(accountFilterName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string accountFilterName = SessionRecording.GenerateAssetName("accountFilter");
            await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new AccountFilterData());
            var mediaAsset = await accountFilterCollection.GetAsync(accountFilterName);
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(accountFilterName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string accountFilterName = SessionRecording.GenerateAssetName("accountFilter");
            await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new AccountFilterData());
            var list = await accountFilterCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string accountFilterName = SessionRecording.GenerateAssetName("accountFilter");
            var accountFilter = await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new AccountFilterData());
            bool flag = await accountFilterCollection.ExistsAsync(accountFilterName);
            Assert.IsTrue(flag);

            await accountFilter.Value.DeleteAsync(WaitUntil.Completed);
            flag = await accountFilterCollection.ExistsAsync(accountFilterName);
            Assert.IsFalse(flag);
        }
    }
}
