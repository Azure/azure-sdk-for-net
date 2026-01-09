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
            ResourceGroup = await CreateResourceGroupAsync(AzureLocation.EastUS);
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
            Assert.That(portalDelegationSettings, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(portalDelegationSettings.Data.Uri.ToString(), Is.EqualTo(urlParameter));
                //validation key is generated brand new on playback mode and hence validation fails
                Assert.That(portalDelegationSettings.Data.ValidationKey, Is.EqualTo(portalDelegationSettingsParams.ValidationKey));
                Assert.That(portalDelegationSettings.Data.UserRegistration.IsUserRegistrationDelegationEnabled, Is.True);
                Assert.That(portalDelegationSettings.Data.Subscriptions.IsSubscriptionDelegationEnabled, Is.True);
            });

            // update the delegation settings
            var data = portalDelegationSettings.Data;
            data.Subscriptions.IsSubscriptionDelegationEnabled = false;
            data.UserRegistration.IsUserRegistrationDelegationEnabled = false;

            await portalDelegationSettings.UpdateAsync(ETag.All, data);
            portalDelegationSettings = await portalDelegationSettings.GetAsync();
            Assert.That(portalDelegationSettings, Is.Not.Null);
            //Assert.IsNull(portalDelegationSettings.Data.Uri.ToString());
            Assert.That(portalDelegationSettings.Data.ValidationKey, Is.Null);
            Assert.That(portalDelegationSettings.Data.UserRegistration.IsUserRegistrationDelegationEnabled, Is.False);
            Assert.That(portalDelegationSettings.Data.Subscriptions.IsSubscriptionDelegationEnabled, Is.False);
        }
    }
}
