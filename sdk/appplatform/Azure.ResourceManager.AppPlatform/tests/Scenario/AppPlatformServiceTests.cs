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
    internal class AppPlatformServiceTests : AppPlatformManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private AppPlatformServiceCollection _serviceCollection;
        private AppPlatformServiceResource _appPlatformService;
        private string _serviceName;

        public AppPlatformServiceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _resourceGroup = await CreateResourceGroup();
            _serviceCollection = _resourceGroup.GetAppPlatformServices();
            _serviceName = Recording.GenerateAssetName("aztestservice");
            _appPlatformService = await CreateAppPlatformService(_resourceGroup, _serviceName);
        }

        [Test]
        public void CreateOrUpdate()
        {
            ValidateAppPlatformService(_appPlatformService.Data, _serviceName);
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _serviceCollection.ExistsAsync(_serviceName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var AppPlatformService = await _serviceCollection.GetAsync(_serviceName);
            ValidateAppPlatformService(AppPlatformService.Value.Data, _serviceName);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _serviceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformService(list.FirstOrDefault().Data, _serviceName);
        }

        [Test]
        public async Task Delete()
        {
            await _appPlatformService.DeleteAsync(WaitUntil.Completed);
            bool flag = await _serviceCollection.ExistsAsync(_serviceName);
            Assert.IsFalse(flag);
        }

        private void ValidateAppPlatformService(AppPlatformServiceData service, string _serviceName)
        {
            Assert.IsNotNull(service);
        }
    }
}
