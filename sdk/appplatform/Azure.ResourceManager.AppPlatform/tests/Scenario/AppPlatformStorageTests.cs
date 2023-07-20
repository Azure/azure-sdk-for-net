// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppPlatform.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppPlatform.Tests
{
    internal class AppPlatformStorageTests : AppPlatformManagementTestBase
    {
        private AppPlatformStorageCollection _appPlatformStorageCollection;
        private string _storageName;
        private AppPlatformStorageResource _appPlatformStorage;

        public AppPlatformStorageTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            _appPlatformStorageCollection = service.GetAppPlatformStorages();
            _storageName = Recording.GenerateAssetName("storage");
            _appPlatformStorage = await CreateAppPlatformStorage();
        }

        private async Task<AppPlatformStorageResource> CreateAppPlatformStorage()
        {
            string dummyStorageAccountName = Recording.GenerateAssetName("sa");
            string dummyStorageAccountkey = Recording.GenerateAssetName("key");
            AppPlatformStorageData data = new AppPlatformStorageData()
            {
                Properties = new AppPlatformStorageAccount(dummyStorageAccountName, dummyStorageAccountkey),
            };
            var lro = await _appPlatformStorageCollection.CreateOrUpdateAsync(WaitUntil.Completed, _storageName, data);
            return lro.Value;
        }

        [Test]
        public void CreateOrUpdate()
        {
            ValidateAppPlatformStorage(_appPlatformStorage.Data);
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _appPlatformStorageCollection.ExistsAsync(_storageName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var appPlatformStorage = await _appPlatformStorageCollection.GetAsync(_storageName);
            ValidateAppPlatformStorage(appPlatformStorage.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _appPlatformStorageCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformStorage(list.FirstOrDefault().Data);
        }

        [Test]
        public async Task Delete()
        {
            await _appPlatformStorage.DeleteAsync(WaitUntil.Completed);
            bool flag = await _appPlatformStorageCollection.ExistsAsync(_storageName);
            Assert.IsFalse(flag);
        }

        private void ValidateAppPlatformStorage(AppPlatformStorageData appPlatformStorage)
        {
            Assert.IsNotNull(appPlatformStorage);
        }
    }
}
