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
    internal class AppPlatformBuildServiceTests : AppPlatformManagementTestBase
    {
        private AppPlatformBuildServiceCollection _appPlatformBuildServiceCollection;
        private const string _buildServicesName = "default";

        public AppPlatformBuildServiceTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateEnterpriseAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            _appPlatformBuildServiceCollection = service.GetAppPlatformBuildServices();
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _appPlatformBuildServiceCollection.ExistsAsync(_buildServicesName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var buildService = await _appPlatformBuildServiceCollection.GetAsync(_buildServicesName);
            ValidateAppPlatformBuildService(buildService.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _appPlatformBuildServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformBuildService(list.FirstOrDefault().Data);
        }

        private void ValidateAppPlatformBuildService(AppPlatformBuildServiceData buildService, string buildServicesName = _buildServicesName)
        {
            Assert.IsNotNull(buildService);
        }
    }
}
