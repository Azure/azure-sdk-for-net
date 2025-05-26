// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.Core.TestFramework.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class GatewayConfigConnectionTests : ApiManagementManagementTestBase
    {
        public GatewayConfigConnectionTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiGatewayResource GatewayResource { get; set; }

        private ApiGatewayCollection GatewayResources { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            GatewayResources = ResourceGroup.GetApiGateways();
        }

        private async Task CreateGatewayResourceAsync()
        {
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiGatewayData(AzureLocation.WestUS2, new ApiManagementGatewaySkuProperties(ApiGatewaySkuType.WorkspaceGatewayPremium));
            GatewayResource = (await GatewayResources.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        /*
        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }


        [Test]
        public async Task CRUD()
        {
            await SetCollectionsAsync();

            var gatewConfigCollections = GatewayResource.GetGatewayConfigConnectionResources();

            string configName = Recording.GenerateAssetName("cfg");

            var collection = await GetApiManagementServiceCollectionAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var apiManagementService = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
            Assert.AreEqual(apiManagementService.Data.Name, apiName);

            // create new group with default parameters
            string loggerDescription = Recording.GenerateAssetName("newloggerDescription");
            var configCreateParameters = new ApiManagementGatewayConfigConnectionResourceData()
            {
                SourceId = ""
            };

            var configConnectionContract = (await gatewConfigCollections.CreateOrUpdateAsync(WaitUntil.Completed, configName, configCreateParameters)).Value;

            Assert.NotNull(configConnectionContract);
            Assert.AreEqual(newloggerId, loggerContract.Data.Name);
            Assert.IsTrue(loggerContract.Data.IsBuffered);
            Assert.AreEqual(LoggerType.AzureEventHub, loggerContract.Data.LoggerType);
            Assert.NotNull(loggerContract.Data.Credentials);
            Assert.AreEqual(2, loggerContract.Data.Credentials.Keys.Count);

            var listLoggers = await logCollection.GetAllAsync().ToEnumerableAsync();
            // there should be one user
            Assert.GreaterOrEqual(listLoggers.Count, 1);

            // patch logger
            string patchedDescription = Recording.GenerateAssetName("patchedDescription");
            await loggerContract.UpdateAsync(ETag.All, new ApiManagementLoggerPatch() { Description = patchedDescription });

            // get to check it was patched
            loggerContract = await logCollection.GetAsync(newloggerId);

            Assert.NotNull(loggerContract);
            Assert.AreEqual(newloggerId, loggerContract.Data.Name);
            Assert.AreEqual(patchedDescription, loggerContract.Data.Description);
            Assert.NotNull(loggerContract.Data.Credentials);

            // delete the logger
            await loggerContract.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = await logCollection.ExistsAsync(newloggerId);
            Assert.IsFalse(falseResult);
        }
        */
    }
}
