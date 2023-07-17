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
        public AppPlatformGatewayTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
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

        private async Task<AppPlatformGatewayResource> CreateAppPlatformGateway(AppPlatformServiceResource service)
        {
            AppPlatformGatewayData data = new AppPlatformGatewayData()
            {
                Properties = new AppPlatformGatewayProperties()
                {
                    IsPublic = false,
                    IsHttpsOnly = false,
                    ResourceRequests = new AppPlatformGatewayResourceRequirements()
                    {
                        Cpu = "1",
                        Memory = "2Gi"
                    }
                },
                Sku = new AppPlatformSku()
                {
                    Name = "E0",
                    Tier = "Enterprise",
                    Capacity = 2,
                },
            };
            var lro = await service.GetAppPlatformGateways().CreateOrUpdateAsync(WaitUntil.Completed, _gatewayName, data);
            return lro.Value;
        }

        [Test]
        public void CreateOrUpdate()
        {
            ValidateAppPlatformGateway(_gateway.Data, _gatewayName);
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
            ValidateAppPlatformGateway(gateway.Value.Data, _gatewayName);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _getAppPlatformGatewayCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformGateway(list.FirstOrDefault().Data, _gatewayName);
        }

        [Test]
        public async Task Delete()
        {
            await _gateway.DeleteAsync(WaitUntil.Completed);
            bool flag = await _getAppPlatformGatewayCollection.ExistsAsync(_gatewayName);
            Assert.IsFalse(flag);
        }

        private void ValidateAppPlatformGateway(AppPlatformGatewayData gateway, string _gatewayName)
        {
            Assert.IsNotNull(gateway);
        }
    }
}
