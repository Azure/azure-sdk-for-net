// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Media.Tests
{
    public class AccountFilterTests : MediaManagementTestBase
    {
        private MediaServicesAccountResource _mediaService;

        private MediaServicesAccountFilterCollection accountFilterCollection => _mediaService.GetMediaServicesAccountFilters();

        public AccountFilterTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var mediaServiceName = Recording.GenerateAssetName("dotnetsdkmediatests");
            _mediaService = await CreateMediaService(ResourceGroup, mediaServiceName);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string accountFilterName = Recording.GenerateAssetName("accountFilter");
            var mediaAsset = await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new MediaServicesAccountFilterData());
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(accountFilterName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string accountFilterName = Recording.GenerateAssetName("accountFilter");
            await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new MediaServicesAccountFilterData());
            bool flag = await accountFilterCollection.ExistsAsync(accountFilterName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string accountFilterName = Recording.GenerateAssetName("accountFilter");
            await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new MediaServicesAccountFilterData());
            var mediaAsset = await accountFilterCollection.GetAsync(accountFilterName);
            Assert.IsNotNull(mediaAsset);
            Assert.AreEqual(accountFilterName, mediaAsset.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string accountFilterName = Recording.GenerateAssetName("accountFilter");
            await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new MediaServicesAccountFilterData());
            var list = await accountFilterCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string accountFilterName = Recording.GenerateAssetName("accountFilter");
            var accountFilter = await accountFilterCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountFilterName, new MediaServicesAccountFilterData());
            bool flag = await accountFilterCollection.ExistsAsync(accountFilterName);
            Assert.IsTrue(flag);

            await accountFilter.Value.DeleteAsync(WaitUntil.Completed);
            flag = await accountFilterCollection.ExistsAsync(accountFilterName);
            Assert.IsFalse(flag);
        }
    }
}
