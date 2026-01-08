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
    public class ApiVersionSetTests : ApiManagementManagementTestBase
    {
        public ApiVersionSetTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

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
            await CreateApiServiceAsync();
            var versionCollection = ApiServiceResource.GetApiVersionSets();

            // there is no api-version-set initially
            var versionSetlistResponse = await versionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(versionSetlistResponse, Is.Not.Null);
            Assert.That(versionSetlistResponse, Is.Empty);

            string newversionsetid = Recording.GenerateAssetName("apiversionsetid");
            const string paramName = "x-ms-sdk-version";
            var createVersionSetContract = new ApiVersionSetData()
            {
                DisplayName = Recording.GenerateAssetName("versionset"),
                Description = Recording.GenerateAssetName("versionsetdescript"),
                VersioningScheme = VersioningScheme.Header,
                VersionHeaderName = paramName
            };
            await versionCollection.CreateOrUpdateAsync(WaitUntil.Completed, newversionsetid, createVersionSetContract);
            var versionSetContract = (await versionCollection.GetAsync(newversionsetid)).Value;
            Assert.That(versionSetContract, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(versionSetContract.Data.DisplayName, Is.EqualTo(createVersionSetContract.DisplayName));
                Assert.That(versionSetContract.Data.Description, Is.EqualTo(createVersionSetContract.Description));
                Assert.That(VersioningScheme.Header, Is.EqualTo(versionSetContract.Data.VersioningScheme));
                Assert.That(versionSetContract.Data.VersionHeaderName, Is.EqualTo(createVersionSetContract.VersionHeaderName));
                Assert.That(versionSetContract.Data.VersionQueryName, Is.Null);
            });

            // update the version set contract to change versioning scheme
            var versionSetUpdateParams = new ApiVersionSetPatch()
            {
                VersioningScheme = VersioningScheme.Query,
                VersionQueryName = paramName,
                VersionHeaderName = null
            };
            await versionSetContract.UpdateAsync(ETag.All, versionSetUpdateParams);
            versionSetContract = await versionSetContract.GetAsync();
            Assert.That(versionSetContract, Is.Not.Null);
            Assert.That(versionSetContract.Data.VersioningScheme, Is.EqualTo(VersioningScheme.Query));
            Assert.That(versionSetContract.Data.VersionQueryName, Is.EqualTo(paramName));

            // now delete it
            await versionSetContract.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await versionCollection.ExistsAsync(newversionsetid)).Value;
            Assert.That(resultFalse, Is.False);
        }
    }
}
