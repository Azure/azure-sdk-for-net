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

            Assert.That(gatewayListResponse, Is.Not.Null);
            Assert.IsEmpty(gatewayListResponse);

            // list all the APIs
            var apisResponse = await ApiServiceResource.GetApis().GetAllAsync().ToEnumerableAsync();

            Assert.That(apisResponse, Is.Not.Null);
            Assert.That(apisResponse.Count, Is.EqualTo(1));
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
            Assert.That(createResponse, Is.Not.Null);
            Assert.That(createResponse.Data.Name, Is.EqualTo(gatewayId));
            Assert.That(createResponse.Data.Description, Is.EqualTo(gatewayContract.Description));
            Assert.That(createResponse.Data.LocationData, Is.Not.Null);
            Assert.That(createResponse.Data.LocationData.City, Is.EqualTo(gatewayContract.LocationData.City));
            Assert.That(createResponse.Data.LocationData.CountryOrRegion, Is.EqualTo(gatewayContract.LocationData.CountryOrRegion));
            Assert.That(createResponse.Data.LocationData.District, Is.EqualTo(gatewayContract.LocationData.District));
            Assert.That(createResponse.Data.LocationData.Name, Is.EqualTo(gatewayContract.LocationData.Name));

            // get the gateway to check is was created
            var getResponse = (await collection.GetAsync(gatewayId)).Value;

            Assert.That(getResponse, Is.Not.Null);
            Assert.That(getResponse.Data.Name, Is.EqualTo(gatewayId));

            // list gateways
            gatewayListResponse = await collection.GetAllAsync().ToEnumerableAsync();

            Assert.That(gatewayListResponse, Is.Not.Null);
            Assert.That(gatewayListResponse.Count, Is.EqualTo(1));

            var associationContract = new AssociationContract()
            {
                ProvisioningState = AssociationEntityProvisioningState.Created
            };

            // assign gateway to api
            var assignResponse = (await getResponse.CreateOrUpdateGatewayApiAsync(echoApi.Data.Name, associationContract)).Value;

            Assert.That(assignResponse, Is.Not.Null);
            Assert.That(assignResponse.Name, Is.EqualTo(echoApi.Data.Name));

            // list gateway apis
            var apiGatewaysResponse = await getResponse.GetGatewayApisByServiceAsync().ToEnumerableAsync();

            Assert.That(apiGatewaysResponse, Is.Not.Null);
            Assert.That(apiGatewaysResponse.Count, Is.EqualTo(1));
            Assert.That(apiGatewaysResponse.FirstOrDefault().Name, Is.EqualTo(echoApi.Data.Name));

            // remove the gateway
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await collection.ExistsAsync(gatewayId)).Value;
            Assert.That(resultFalse, Is.False);
        }
    }
}
