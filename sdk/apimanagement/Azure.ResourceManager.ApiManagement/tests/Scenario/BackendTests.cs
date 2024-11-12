// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class BackendTests : ApiManagementManagementTestBase
    {
        public BackendTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
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
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var backendCollection = ApiServiceResource.GetApiManagementBackends();

            // create new group with default parameters
            string backendId = Recording.GenerateAssetName("backendid");
            string backendName = Recording.GenerateAssetName("backendName");
            string urlParameter = new UriBuilder("https", backendName, 443).Uri.ToString();

            var backendCreateParameters = new ApiManagementBackendData();
            backendCreateParameters.Uri = new Uri(urlParameter);
            backendCreateParameters.Protocol = BackendProtocol.Http;
            backendCreateParameters.Description = Recording.GenerateAssetName("description");
            backendCreateParameters.Tls = new BackendTlsProperties()
            {
                ShouldValidateCertificateChain = true,
                ShouldValidateCertificateName = true,
            };
            backendCreateParameters.Credentials = new BackendCredentialsContract();
            backendCreateParameters.Credentials.Authorization = new BackendAuthorizationHeaderCredentials("basic", "opensemame");
            backendCreateParameters.Credentials.Query.Add("sv", new List<string> { "xx", "bb", "cc" });
            backendCreateParameters.Credentials.Header.Add("x-my-1", new List<string> { "val1", "val2" });

            var backendResponse = (await backendCollection.CreateOrUpdateAsync(WaitUntil.Completed, backendId, backendCreateParameters)).Value;
            Assert.NotNull(backendResponse);

            // get to check it was created
            var backendContract = (await backendResponse.GetAsync()).Value;

            Assert.NotNull(backendContract);
            Assert.AreEqual(backendId, backendContract.Data.Name);
            Assert.NotNull(backendContract.Data.Description);
            Assert.NotNull(backendContract.Data.Credentials.Authorization);
            Assert.NotNull(backendContract.Data.Credentials.Query);
            Assert.NotNull(backendContract.Data.Credentials.Header);
            Assert.AreEqual(BackendProtocol.Http, backendContract.Data.Protocol);
            Assert.AreEqual(1, backendContract.Data.Credentials.Query.Keys.Count);
            Assert.AreEqual(1, backendContract.Data.Credentials.Header.Keys.Count);
            Assert.NotNull(backendContract.Data.Credentials.Authorization);
            Assert.AreEqual("basic", backendContract.Data.Credentials.Authorization.Scheme);

            var listBackends = await backendCollection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(listBackends);

            // there should be one user
            Assert.GreaterOrEqual(listBackends.Count, 1);

            // patch backend
            string patchedDescription = Recording.GenerateAssetName("patchedDescription");
            var patch = new ApiManagementBackendPatch()
            {
                Description = patchedDescription,
            };
            await backendContract.UpdateAsync(ETag.All, patch);

            // get to check it was patched
            backendContract = await backendCollection.GetAsync(backendId);
            Assert.NotNull(backendContract);
            Assert.AreEqual(backendId, backendContract.Data.Name);
            Assert.AreEqual(patchedDescription, backendContract.Data.Description);

            // delete the backend
            await backendContract.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await backendCollection.ExistsAsync(backendId)).Value;
            Assert.IsFalse(resultFalse);
        }
    }
}
