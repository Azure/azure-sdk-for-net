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
            Assert.That(backendResponse, Is.Not.Null);

            // get to check it was created
            var backendContract = (await backendResponse.GetAsync()).Value;

            Assert.That(backendContract, Is.Not.Null);
            Assert.That(backendContract.Data.Name, Is.EqualTo(backendId));
            Assert.That(backendContract.Data.Description, Is.Not.Null);
            Assert.That(backendContract.Data.Credentials.Authorization, Is.Not.Null);
            Assert.That(backendContract.Data.Credentials.Query, Is.Not.Null);
            Assert.That(backendContract.Data.Credentials.Header, Is.Not.Null);
            Assert.That(backendContract.Data.Protocol, Is.EqualTo(BackendProtocol.Http));
            Assert.That(backendContract.Data.Credentials.Query.Keys.Count, Is.EqualTo(1));
            Assert.That(backendContract.Data.Credentials.Header.Keys.Count, Is.EqualTo(1));
            Assert.That(backendContract.Data.Credentials.Authorization, Is.Not.Null);
            Assert.That(backendContract.Data.Credentials.Authorization.Scheme, Is.EqualTo("basic"));

            var listBackends = await backendCollection.GetAllAsync().ToEnumerableAsync();

            Assert.That(listBackends, Is.Not.Null);

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
            Assert.That(backendContract, Is.Not.Null);
            Assert.That(backendContract.Data.Name, Is.EqualTo(backendId));
            Assert.That(backendContract.Data.Description, Is.EqualTo(patchedDescription));

            // delete the backend
            await backendContract.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await backendCollection.ExistsAsync(backendId)).Value;
            Assert.That(resultFalse, Is.False);
        }
    }
}
