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
    internal class AppPlatformPortalTests : AppPlatformManagementTestBase
    {
        private AppPlatformApiPortalCollection _appPlatformApiPortalCollection;
        //private string _appName;
        //private AppPlatformAppResource _app;

        public AppPlatformPortalTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg1 = await DefaultSubscription.GetResourceGroups().GetAsync("AppPlatformRG214");
            var service1 = await  rg1.Value.GetAppPlatformServices().GetAsync("appservice-enterprise");
            var list  =  await service1.Value.GetAppPlatformApiPortals().GetAllAsync().ToEnumerableAsync();
            var rg = await CreateResourceGroup();
            var service = await CreateAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            _appPlatformApiPortalCollection = service.GetAppPlatformApiPortals();
        }

        //private async Task<AppPlatformAppResource> CreateAppPlatformApp(AppPlatformServiceResource service, string appName)
        //{
        //    AppPlatformAppData data = new AppPlatformAppData()
        //    {
        //    };
        //    var app = await _appPlatformApiPortalCollection.CreateOrUpdateAsync(WaitUntil.Completed, appName, data);
        //    return app.Value;
        //}

        [Test]
        public async Task CreateOrUpdate()
        {
            var list = await _appPlatformApiPortalCollection.GetAllAsync().ToEnumerableAsync();
            var foo = await _appPlatformApiPortalCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                "portal",
                new AppPlatformApiPortalData());

            //ValidateAppPlatformAppData(_app.Data, _appName);
        }

        //[Test]
        //public async Task Exist()
        //{
        //    var flag = await _appPlatformApiPortalCollection.ExistsAsync(_appName);
        //    Assert.IsTrue(flag);
        //}

        //[Test]
        //public async Task Get()
        //{
        //    var app = await _appPlatformApiPortalCollection.GetAsync(_appName);
        //    ValidateAppPlatformAppData(app.Value.Data, _appName);
        //}

        //[Test]
        //public async Task GetAll()
        //{
        //    var list = await _appPlatformApiPortalCollection.GetAllAsync().ToEnumerableAsync();
        //    Assert.IsNotEmpty(list);
        //    ValidateAppPlatformAppData(list.FirstOrDefault().Data, _appName);
        //}

        //[Test]
        //public async Task Delete()
        //{
        //    await _app.DeleteAsync(WaitUntil.Completed);
        //    bool flag = await _appPlatformApiPortalCollection.ExistsAsync(_appName);
        //    Assert.IsFalse(flag);
        //}

        //private void ValidateAppPlatformAppData(AppPlatformAppData app, string _appName)
        //{
        //    Assert.IsNotNull(app);
        //}
    }
}
