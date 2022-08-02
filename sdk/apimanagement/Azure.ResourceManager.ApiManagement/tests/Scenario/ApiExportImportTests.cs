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
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class ApiExportImportTests : ApiManagementManagementTestBase
    {
        public ApiExportImportTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private VirtualNetworkCollection VNetCollection { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiCollection Collection { get; set; }

        private ApiResource Resources { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            VNetCollection = ResourceGroup.GetVirtualNetworks();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;

            Collection = ApiServiceResource.GetApis();
            var name = Recording.GenerateAssetName("testapi-");
            var content = new ApiCreateOrUpdateContent()
            {
                Description = "apidescription5200",
                SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract()
                {
                    Header = "header4520",
                    Query = "query3037"
                },
                DisplayName = "apiname1463",
                ServiceUri = new Uri("http://newechoapi.cloudapp.net/api"),
                Path = "newapiPath",
                Protocols = { ApiOperationInvokableProtocol.Https, ApiOperationInvokableProtocol.Http }
            };
            Resources = (await Collection.CreateOrUpdateAsync(WaitUntil.Completed, name, content)).Value;
        }

        //[Test]
        //public async Task CreateOrUpdate_GetAll_Get_Exists_Delete()
        //{
        //    await CreateApiAsync();
        //    var swaggerPath = "./Resources/SwaggerPetStoreV2.json";
        //    var path = "swaggerApi";
        //    var swaggerApi = TestUtilities.GenerateName("aid");
        //}
    }
}
