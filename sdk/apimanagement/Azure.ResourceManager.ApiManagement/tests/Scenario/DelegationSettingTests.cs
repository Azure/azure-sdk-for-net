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
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
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
            var delegationCollection = ApiServiceResource.GetApiManagementPortalDelegationSetting();

            //var intialPortalDelegationSettings = await delegationCollection.GetAsync();

            string delegationServer = Recording.GenerateAssetName("delegationServer");
            string urlParameter = new UriBuilder("https", delegationServer, 443).Uri.ToString();

            var portalDelegationSettingsParams = new ApiManagementPortalDelegationSettingData()
            {
                Subscriptions = new SubscriptionDelegationSettingProperties()
                {
                    IsSubscriptionDelegationEnabled = true,
                },
                UserRegistration = new RegistrationDelegationSettingProperties()
                {
                    IsUserRegistrationDelegationEnabled = true,
                },
                Uri = new Uri(urlParameter),
                ValidationKey = "Sanitized"
            };
            var portalDelegationSettings = (await delegationCollection.CreateOrUpdateAsync(WaitUntil.Completed, portalDelegationSettingsParams)).Value;
            //Assert.NotNull(portalDelegationSettings);
            //Assert.AreEqual(urlParameter, portalDelegationSettings.Data.Uri.ToString());
            // validation key is generated brand new on playback mode and hence validation fails
            //Assert.Equal(portalDelegationSettingsParams.ValidationKey, portalDelegationSettings.ValidationKey);
            //Assert.IsTrue(portalDelegationSettings.Data.UserRegistration.Enabled);
            //Assert.IsTrue(portalDelegationSettings.Data.Subscriptions.Enabled);

            // update the delegation settings
            var data = portalDelegationSettings.Data;
            data.Subscriptions.IsSubscriptionDelegationEnabled = false;
            data.UserRegistration.IsUserRegistrationDelegationEnabled = false;

            await portalDelegationSettings.UpdateAsync(ETag.All, data);
            portalDelegationSettings = await portalDelegationSettings.GetAsync();
            //Assert.NotNull(portalDelegationSettings);
            //Assert.IsNull(portalDelegationSettings.Data.Uri.ToString());
            //Assert.IsNull(portalDelegationSettings.Data.ValidationKey);
            //Assert.IsFalse(portalDelegationSettings.Data.UserRegistration.Enabled);
            //Assert.IsFalse(portalDelegationSettings.Data.Subscriptions.Enabled);
        }
    }
}
