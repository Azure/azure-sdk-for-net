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
    internal class AppPlatformGatewayRouteConfigTests : AppPlatformManagementTestBase
    {
        private AppPlatformGatewayRouteConfigCollection _appPlatformGatewayRouteConfigCollection;
        private string _routeConfigName;
        private AppPlatformGatewayRouteConfigResource _routeConfig;

        public AppPlatformGatewayRouteConfigTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var rg = await CreateResourceGroup();
            var service = await CreateEnterpriseAppPlatformService(rg, Recording.GenerateAssetName("aztestservice"));
            var gateway = await CreateAppPlatformGateway(service);
            _appPlatformGatewayRouteConfigCollection = gateway.GetAppPlatformGatewayRouteConfigs();
            _routeConfigName = Recording.GenerateAssetName("config");
            _routeConfig = await CreateAppPlatformGatewayRouteConfig(service);
        }

        private async Task<AppPlatformGatewayRouteConfigResource> CreateAppPlatformGatewayRouteConfig(AppPlatformServiceResource service)
        {
            // create an app
            var app = await CreateAppPlatformApp(service, Recording.GenerateAssetName("app"));

            AppPlatformGatewayRouteConfigData data = new AppPlatformGatewayRouteConfigData()
            {
                Properties = new AppPlatformGatewayRouteConfigProperties()
                {
                    AppResourceId = new ResourceIdentifier(app.Id),
                    OpenApiUri = new Uri("https://raw.githubusercontent.com/OAI/OpenAPI-Specification/main/examples/v3.0/petstore.json"),
                    Protocol = AppPlatformGatewayRouteConfigProtocol.Https,
                    Routes =
                    {
                        new AppPlatformGatewayApiRoute()
                        {
                            Title = "myApp route config",
                            IsSsoEnabled = true,
                            Predicates ={"Path=/api5/customer/**"},
                            Filters = {"StripPrefix=2","RateLimit=1,1s" },
                        }
                    },
                },
            };
            var lro = await _appPlatformGatewayRouteConfigCollection.CreateOrUpdateAsync(WaitUntil.Completed, _routeConfigName, data);
            return lro.Value;
        }

        [Test]
        public void CreateOrUpdate()
        {
            ValidateAppPlatformGatewayRouteConfig(_routeConfig.Data);
        }

        [Test]
        public async Task Exist()
        {
            var flag = await _appPlatformGatewayRouteConfigCollection.ExistsAsync(_routeConfigName);
            Assert.IsTrue(flag);
        }

        [Test]
        public async Task Get()
        {
            var routeConfig = await _appPlatformGatewayRouteConfigCollection.GetAsync(_routeConfigName);
            ValidateAppPlatformGatewayRouteConfig(routeConfig.Value.Data);
        }

        [Test]
        public async Task GetAll()
        {
            var list = await _appPlatformGatewayRouteConfigCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAppPlatformGatewayRouteConfig(list.FirstOrDefault().Data);
        }

        [Test]
        public async Task Delete()
        {
            await _routeConfig.DeleteAsync(WaitUntil.Completed);
            bool flag = await _appPlatformGatewayRouteConfigCollection.ExistsAsync(_routeConfigName);
            Assert.IsFalse(flag);
        }

        private void ValidateAppPlatformGatewayRouteConfig(AppPlatformGatewayRouteConfigData routeConfig)
        {
            Assert.IsNotNull(routeConfig);
            //Assert.AreEqual(_routeConfigName, routeConfig.Name);
        }
    }
}
