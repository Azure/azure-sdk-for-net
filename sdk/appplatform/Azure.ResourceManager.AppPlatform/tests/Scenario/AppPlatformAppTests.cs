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
    internal class AppPlatformAppTests : AppPlatformManagementTestBase
    {
        private AppPlatformAppCollection _appPlatformAppCollection;
        private string _appName;
        private AppPlatformAppResource _app;

        public AppPlatformAppTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            _appPlatformAppCollection = service.GetAppPlatformApps();
            _appName = Recording.GenerateAssetName("app");
            _app = await CreateAppPlatformApp(service, _appName);
        }

        [Test]
        public void CreateOrUpdate()
        {
            ValidateAppPlatformAppData(_app.Data);
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _appPlatformAppCollection.ExistsAsync(_appName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var app = await _appPlatformAppCollection.GetAsync(_appName);
            ValidateAppPlatformAppData(app.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _appPlatformAppCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformAppData(list.FirstOrDefault().Data);
        }

        [Test]
        public async Task Delete()
        {
            await _app.DeleteAsync(WaitUntil.Completed);
            bool flag = await _appPlatformAppCollection.ExistsAsync(_appName);
            Assert.IsFalse(flag);
        }

        private void ValidateAppPlatformAppData(AppPlatformAppData app)
        {
            Assert.IsNotNull(app);
        }
    }
}
