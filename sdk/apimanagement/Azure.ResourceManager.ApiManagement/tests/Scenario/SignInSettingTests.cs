// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class SignInSettingTests : ApiManagementManagementTestBase
    {
        public SignInSettingTests(bool isAsync)
                       : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceResourceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServiceResources();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.Standard, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();

            // get the existing settings on the service
            var portalSignInSettings = ApiServiceResource.GetPortalSigninSettings();
            portalSignInSettings = await portalSignInSettings.GetAsync();
            Assert.NotNull(portalSignInSettings);

            // disable portal signIn
            portalSignInSettings.Data.Enabled = false;
            portalSignInSettings = (await portalSignInSettings.CreateOrUpdateAsync(WaitUntil.Completed, portalSignInSettings.Data)).Value;

            Assert.NotNull(portalSignInSettings);
            Assert.IsFalse(portalSignInSettings.Data.Enabled);

            portalSignInSettings = await portalSignInSettings.GetAsync();
            Assert.NotNull(portalSignInSettings);
            Assert.IsFalse(portalSignInSettings.Data.Enabled);
        }
    }
}
