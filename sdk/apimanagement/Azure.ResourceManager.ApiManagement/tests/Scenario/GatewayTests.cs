// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class GatewayTests : ApiManagementManagementTestBase
    {
        public GatewayTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
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
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementGateways();

            // list gateways: there should be none
            var gatewayListResponse = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(gatewayListResponse);
            Assert.IsEmpty(gatewayListResponse);

            // list all the APIs
            var apisResponse = await ApiServiceResource.GetApis().GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(apisResponse);
            Assert.AreEqual(apisResponse.Count, 1);
            var echoApi = apisResponse.First();

            string gatewayId = Recording.GenerateAssetName("gatewayid");
            string certificateId = Recording.GenerateAssetName("certificateId");
            string hostnameConfigId = Recording.GenerateAssetName("hostnameConfigId");

            var gatewayContract = new ApiManagementGatewayData()
            {
                LocationData = new ResourceLocationDataContract("Microsoft")
                {
                    City = "Seattle",
                    CountryOrRegion = "USA",
                    District = "King County",
                },
                Description = Recording.GenerateAssetName("desc")
            };
            var createResponse = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, gatewayId, gatewayContract)).Value;
            Assert.NotNull(createResponse);
            Assert.AreEqual(gatewayId, createResponse.Data.Name);
            Assert.AreEqual(gatewayContract.Description, createResponse.Data.Description);
            Assert.NotNull(createResponse.Data.LocationData);
            Assert.AreEqual(gatewayContract.LocationData.City, createResponse.Data.LocationData.City);
            Assert.AreEqual(gatewayContract.LocationData.CountryOrRegion, createResponse.Data.LocationData.CountryOrRegion);
            Assert.AreEqual(gatewayContract.LocationData.District, createResponse.Data.LocationData.District);
            Assert.AreEqual(gatewayContract.LocationData.Name, createResponse.Data.LocationData.Name);

            // get the gateway to check is was created
            var getResponse = (await collection.GetAsync(gatewayId)).Value;

            Assert.NotNull(getResponse);
            Assert.AreEqual(gatewayId, getResponse.Data.Name);

            // list gateways
            gatewayListResponse = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(gatewayListResponse);
            Assert.AreEqual(gatewayListResponse.Count, 1);

            var associationContract = new AssociationContract()
            {
                ProvisioningState = AssociationEntityProvisioningState.Created
            };

            // assign gateway to api
            var assignResponse = (await getResponse.CreateOrUpdateGatewayApiAsync(echoApi.Data.Name, associationContract)).Value;

            Assert.NotNull(assignResponse);
            Assert.AreEqual(echoApi.Data.Name, assignResponse.Name);

            // list gateway apis
            var apiGatewaysResponse = await getResponse.GetGatewayApisByServiceAsync().ToEnumerableAsync();

            Assert.NotNull(apiGatewaysResponse);
            Assert.AreEqual(apiGatewaysResponse.Count, 1);
            Assert.AreEqual(echoApi.Data.Name, apiGatewaysResponse.FirstOrDefault().Name);

            // remove the gateway
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await collection.ExistsAsync(gatewayId)).Value;
            Assert.IsFalse(resultFalse);
        }
    }
}
