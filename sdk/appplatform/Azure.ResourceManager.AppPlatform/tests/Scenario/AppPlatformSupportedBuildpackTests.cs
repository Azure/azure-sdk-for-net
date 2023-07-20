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
    internal class AppPlatformSupportedBuildpackTests : AppPlatformManagementTestBase
    {
        private AppPlatformSupportedBuildpackCollection _appPlatformSupportedBuildpackCollection;
        private const string _packName = "tanzu-buildpacks-dotnet-core";

        public AppPlatformSupportedBuildpackTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateEnterpriseAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            var buildService = await service.GetAppPlatformBuildServices().GetAsync("default");
            _appPlatformSupportedBuildpackCollection = buildService.Value.GetAppPlatformSupportedBuildpacks();
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _appPlatformSupportedBuildpackCollection.ExistsAsync(_packName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var pack = await _appPlatformSupportedBuildpackCollection.GetAsync(_packName);
            ValidateAppPlatformSupportedBuildpack(pack.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _appPlatformSupportedBuildpackCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformSupportedBuildpack(list.FirstOrDefault().Data);
        }

        private void ValidateAppPlatformSupportedBuildpack(AppPlatformSupportedBuildpackData pack)
        {
            Assert.IsNotNull(pack);
        }
    }
}
