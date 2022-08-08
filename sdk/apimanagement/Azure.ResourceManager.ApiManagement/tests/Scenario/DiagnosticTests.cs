// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class DiagnosticTests : ApiManagementManagementTestBase
    {
        public DiagnosticTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementDiagnostics();

            // list diagnostics: there should be none
            var diagnostics = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(diagnostics);
            Assert.IsEmpty(diagnostics);

            // create new diagnostic, supported Ids are applicationinsights, azuremonitor
            //string diagnosticId = "applicationinsights";
            string loggerId = Recording.GenerateAssetName("appInsights");
        }
    }
}
