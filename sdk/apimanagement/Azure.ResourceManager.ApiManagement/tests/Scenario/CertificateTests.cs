// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class CertificateTests : ApiManagementManagementTestBase
    {
        public CertificateTests(bool isAsync)
                    : base(isAsync)// RecordedTestMode.Record)
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

        [Test]
        [PlaybackOnly("linux cert issue")]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var certCollection = ApiServiceResource.GetApiManagementCertificates();

            // list certificates: there should be none
            var listResponse = await certCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listResponse, Is.Not.Null);
            Assert.That(listResponse, Is.Empty);

            // create new certificate
            string certificateId = Recording.GenerateAssetName("certificateId");

            X509Certificate2 cert = null;
            if (Mode != RecordedTestMode.Playback)
            {
#if NET9_0_OR_GREATER
                cert = X509CertificateLoader.LoadCertificateFromFile("./Resources/sdktest.cer");
#else
                cert = new X509Certificate2("./Resources/sdktest.cer");
#endif
            }
            var content = new ApiManagementCertificateCreateOrUpdateContent()
            {
                Data = "sanitized"
            };

            var createResponse = (await certCollection.CreateOrUpdateAsync(WaitUntil.Completed, certificateId, content)).Value;
            Assert.That(createResponse, Is.Not.Null);
            Assert.That(createResponse.Data.Name, Is.EqualTo(certificateId));

            // get the certificate to check is was created
            var getResponse = (await certCollection.GetAsync(certificateId)).Value;
            Assert.That(getResponse, Is.Not.Null);
            Assert.That(getResponse.Data.Name, Is.EqualTo(certificateId));
            if (Mode == RecordedTestMode.Playback)
            {
                Assert.That(getResponse.Data.Subject.ToLower(), Is.EqualTo("cn=contoso.com"));
                Assert.That(getResponse.Data.Thumbprint.ToLower(), Is.EqualTo("10ad178a8c73d33cde4e7ad638dc56de2671043d"));
            }
            else
            {
                Assert.That(getResponse.Data.Subject.ToLower(), Is.EqualTo(cert.Subject.ToLower()));
                Assert.That(getResponse.Data.Thumbprint.ToLower(), Is.EqualTo(cert.Thumbprint.ToLower()));
            }
            //create key vault certificate
            //string kvcertificateId = Recording.GenerateAssetName("kvcertificateId");
            //content = new ApiManagementCertificateCreateOrUpdateContent()
            //{
            //    KeyVaultDetails = new KeyVaultContractCreateProperties()
            //    {
            //        SecretIdentifier = "https://sdktestvault.vault.azure.net/secrets/aspnetuser/230e6c29e36244978368aa6c94130acc"
            //    }
            //};
            //var kvCertificateIdResponse = (await certCollection.CreateOrUpdateAsync(WaitUntil.Completed, kvcertificateId, content)).Value;
            //Assert.NotNull(kvCertificateIdResponse);
            //Assert.AreEqual(kvcertificateId, kvCertificateIdResponse.Data.Name);

            // get the certificate to check is was created
            //kvCertificateIdResponse = (await kvCertificateIdResponse.GetAsync()).Value;
            //Assert.NotNull(kvCertificateIdResponse);
            //Assert.AreEqual(kvcertificateId, kvCertificateIdResponse.Data.Name);

            //refresh secret of key vault client
            //var refreshKvCertificateResponse = (await getResponse.RefreshSecretAsync()).Value;
            //Assert.NotNull(refreshKvCertificateResponse);

            // list certificates
            listResponse = await certCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listResponse, Is.Not.Null);
            Assert.That(listResponse.Count, Is.EqualTo(1));

            // remove the certificate
            await getResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await certCollection.ExistsAsync(certificateId));
            Assert.That((bool)resultFalse, Is.False);
        }
    }
}
