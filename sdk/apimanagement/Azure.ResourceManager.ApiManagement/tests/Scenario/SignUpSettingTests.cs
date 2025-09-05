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
    public class SignUpSettingTests : ApiManagementManagementTestBase
    {
        public SignUpSettingTests(bool isAsync)
                       : base(isAsync) //, RecordedTestMode.Record)
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
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Standard, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();

            // get the existing settings on the service
            var defaultSignupSettings = ApiServiceResource.GetApiManagementPortalSignUpSetting();
            defaultSignupSettings = await defaultSignupSettings.GetAsync();
            Assert.NotNull(defaultSignupSettings);

            // disable portal signup
            defaultSignupSettings.Data.IsSignUpDeveloperPortalEnabled = false;
            defaultSignupSettings = (await defaultSignupSettings.CreateOrUpdateAsync(WaitUntil.Completed, defaultSignupSettings.Data)).Value;

            Assert.NotNull(defaultSignupSettings);
            Assert.IsFalse(defaultSignupSettings.Data.IsSignUpDeveloperPortalEnabled);

            defaultSignupSettings = await defaultSignupSettings.GetAsync();
            Assert.NotNull(defaultSignupSettings);
            Assert.IsFalse(defaultSignupSettings.Data.IsSignUpDeveloperPortalEnabled);
        }
    }
}
