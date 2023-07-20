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
        private const string _portalName = "default";
        private AppPlatformApiPortalResource _portal;

        public AppPlatformPortalTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateEnterpriseAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            _appPlatformApiPortalCollection = service.GetAppPlatformApiPortals();
            _portal = await CreateAppPlatformApp();
        }

        private async Task<AppPlatformApiPortalResource> CreateAppPlatformApp()
        {
            var data = new AppPlatformApiPortalData();
            var portal = await _appPlatformApiPortalCollection.CreateOrUpdateAsync(WaitUntil.Completed, _portalName, data);
            return portal.Value;
        }

        [Test]
        public void CreateOrUpdate()
        {
            ValidateAppPlatformApiPortal(_portal.Data);
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _appPlatformApiPortalCollection.ExistsAsync(_portalName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var portal = await _appPlatformApiPortalCollection.GetAsync(_portalName);
            ValidateAppPlatformApiPortal(portal.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _appPlatformApiPortalCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformApiPortal(list.FirstOrDefault().Data);
        }

        [Test]
        public async Task Delete()
        {
            await _portal.DeleteAsync(WaitUntil.Completed);
            bool flag = await _appPlatformApiPortalCollection.ExistsAsync(_portalName);
            Assert.IsFalse(flag);
        }

        private void ValidateAppPlatformApiPortal(AppPlatformApiPortalData portal)
        {
            Assert.IsNotNull(portal);
            Assert.AreEqual(_portalName, portal.Name);
            Assert.AreEqual(1, portal.Properties.Instances.Count);
            Assert.AreEqual(AppPlatformApiPortalProvisioningState.Succeeded, portal.Properties.ProvisioningState);
            Assert.AreEqual(1, portal.Sku.Capacity);
            Assert.AreEqual("Enterprise", portal.Sku.Tier);
        }
    }
}
