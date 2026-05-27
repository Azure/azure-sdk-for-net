// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class DelegationSettingTests : ApiManagementManagementTestBase
    {
        public DelegationSettingTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceResourceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync(AzureLocation.EastUS);
            ApiServiceCollection = ResourceGroup.GetApiManagementServiceResources();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceResourceData(AzureLocation.EastUS, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.Developer, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        public static string GenerateValidationKey()
        {
            const int ValidateKeyLength = 64;
            var bytes = new byte[ValidateKeyLength];
            Random rnd = new Random();
            rnd.NextBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        [Test]
        [PlaybackOnly("ValidationKey Sanitized")]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var delegationCollection = ApiServiceResource.GetPortalDelegationSettings();

            //var intialPortalDelegationSettings = await delegationCollection.GetAsync();

            string delegationServer = Recording.GenerateAssetName("delegationServer");
            string urlParameter = new UriBuilder("https", delegationServer, 443).Uri.ToString();

            var portalDelegationSettingsParams = new PortalDelegationSettingsData()
            {
                SubscriptionsEnabled = true,
                UserRegistrationEnabled = true,
                Uri = urlParameter,
                ValidationKey = "Sanitized"
            };
            var portalDelegationSettings = (await delegationCollection.CreateOrUpdateAsync(WaitUntil.Completed, portalDelegationSettingsParams)).Value;
            Assert.NotNull(portalDelegationSettings);
            Assert.AreEqual(urlParameter, portalDelegationSettings.Data.Uri);
            //validation key is generated brand new on playback mode and hence validation fails
            Assert.AreEqual(portalDelegationSettingsParams.ValidationKey, portalDelegationSettings.Data.ValidationKey);
            Assert.IsTrue(portalDelegationSettings.Data.UserRegistrationEnabled);
            Assert.IsTrue(portalDelegationSettings.Data.SubscriptionsEnabled);

            // update the delegation settings
            var data = portalDelegationSettings.Data;
            data.SubscriptionsEnabled = false;
            data.UserRegistrationEnabled = false;

            await portalDelegationSettings.UpdateAsync(ETag.All.ToString(), data);
            portalDelegationSettings = await portalDelegationSettings.GetAsync();
            Assert.NotNull(portalDelegationSettings);
            //Assert.IsNull(portalDelegationSettings.Data.Uri);
            Assert.IsNull(portalDelegationSettings.Data.ValidationKey);
            Assert.IsFalse(portalDelegationSettings.Data.UserRegistrationEnabled);
            Assert.IsFalse(portalDelegationSettings.Data.SubscriptionsEnabled);
        }
    }
}
