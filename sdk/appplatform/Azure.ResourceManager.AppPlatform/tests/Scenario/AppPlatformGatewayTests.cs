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
    internal class AppPlatformGatewayTests : AppPlatformManagementTestBase
    {
        private AppPlatformGatewayCollection _getAppPlatformGatewayCollection;
        private const string _gatewayName = "default";
        private AppPlatformGatewayResource _gateway;
        public AppPlatformGatewayTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateEnterpriseAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            _getAppPlatformGatewayCollection = service.GetAppPlatformGateways();
            _gateway = await CreateAppPlatformGateway(service);
        }

        [Test]
        public void CreateOrUpdate()
        {
            ValidateAppPlatformGateway(_gateway.Data);
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _getAppPlatformGatewayCollection.ExistsAsync(_gatewayName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var gateway = await _getAppPlatformGatewayCollection.GetAsync(_gatewayName);
            ValidateAppPlatformGateway(gateway.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _getAppPlatformGatewayCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformGateway(list.FirstOrDefault().Data);
        }

        [Test]
        public async Task Delete()
        {
            await _gateway.DeleteAsync(WaitUntil.Completed);
            bool flag = await _getAppPlatformGatewayCollection.ExistsAsync(_gatewayName);
            Assert.IsFalse(flag);
        }

        private void ValidateAppPlatformGateway(AppPlatformGatewayData gateway)
        {
            Assert.IsNotNull(gateway);
            Assert.AreEqual(_gatewayName, gateway.Name);
            Assert.AreEqual("E0", gateway.Sku.Name);
            Assert.AreEqual("Enterprise", gateway.Sku.Tier);
            Assert.AreEqual(2, gateway.Sku.Capacity);
            Assert.AreEqual(AppPlatformGatewayProvisioningState.Succeeded, gateway.Properties.ProvisioningState);
        }
    }
}
