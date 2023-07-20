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
    internal class AppPlatformSupportedStackTests : AppPlatformManagementTestBase
    {
        private AppPlatformSupportedStackCollection _appPlatformSupportedStackCollection;
        private const string _stackName = "io.buildpacks.stacks.bionic-base";

        public AppPlatformSupportedStackTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateEnterpriseAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            var buildService = await service.GetAppPlatformBuildServices().GetAsync("default");
            _appPlatformSupportedStackCollection = buildService.Value.GetAppPlatformSupportedStacks();
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _appPlatformSupportedStackCollection.ExistsAsync(_stackName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var stack = await _appPlatformSupportedStackCollection.GetAsync(_stackName);
            ValidateAppPlatformSupportedStack(stack.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _appPlatformSupportedStackCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformSupportedStack(list.FirstOrDefault().Data);
        }

        private void ValidateAppPlatformSupportedStack(AppPlatformSupportedStackData stack)
        {
            Assert.IsNotNull(stack);
        }
    }
}
