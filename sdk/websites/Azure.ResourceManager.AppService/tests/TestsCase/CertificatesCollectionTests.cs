// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class CertificatesCollectionTests : AppServiceTestBase
    {
        public CertificatesCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<AppCertificateCollection> GetCertificatesCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAppCertificates();
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Service request failed.Status: 500 (Internal Server Error)")]
        public async Task CreateOrUpdate()
        {
            var container = await GetCertificatesCollectionAsync();
            var name = Recording.GenerateAssetName("testCertificate");
            var input = ResourceDataHelper.GetBasicCertificateData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var certificate = lro.Value;
            Assert.That(certificate.Data.Name, Is.EqualTo(name));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateWithNullKeyVaultId()
        {
            // Call CreateOrUpdate on an existing certificate which returns empty string for keyVaultId
            var name = "aeronline.net-myfirstapp0102-null";
            var data = new AppCertificateData(DefaultLocation)
            {
                ServerFarmId = new Core.ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testRG-666/providers/Microsoft.Web/serverfarms/ASP-testRG666-b64f"),
                CanonicalName = "aeronline.net",
                KeyVaultId = null // Test to see that if service works fine when we set KeyVaultId to null.
            };
            var collection = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", "testRG-666")).GetAppCertificates();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data);
            var certificate = lro.Value;
            Assert.Multiple(() =>
            {
                Assert.That(certificate.Data.Name, Is.EqualTo(name));
                Assert.That(certificate.Data.KeyVaultId, Is.Null);
            });
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Service request failed.Status: 500 (Internal Server Error)")]
        public async Task Get()
        {
            var container = await GetCertificatesCollectionAsync();
            var certificateName = Recording.GenerateAssetName("testCertificate-");
            var input = ResourceDataHelper.GetBasicCertificateData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, certificateName, input);
            AppCertificateResource certificate1 = lro.Value;
            AppCertificateResource certificate2 = await container.GetAsync(certificateName);
            ResourceDataHelper.AssertCertificate(certificate1.Data, certificate2.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Service request failed.Status: 500 (Internal Server Error)")]
        public async Task GetAll()
        {
            var container = await GetCertificatesCollectionAsync();
            var input = ResourceDataHelper.GetBasicCertificateData(DefaultLocation);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testCertificate-"), input);
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testCertificate-"), input);
            int count = 0;
            await foreach (var certificate in container.GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(2));
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Service request failed.Status: 500 (Internal Server Error)")]
        public async Task Exists()
        {
            var container = await GetCertificatesCollectionAsync();
            var certificateName = Recording.GenerateAssetName("testCertificate-");
            var input = ResourceDataHelper.GetBasicCertificateData(DefaultLocation);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, certificateName, input);
            AppCertificateResource certificate = lro.Value;
            Assert.Multiple(async () =>
            {
                Assert.That((bool)await container.ExistsAsync(certificateName), Is.True);
                Assert.That((bool)await container.ExistsAsync(certificateName + "1"), Is.False);
            });

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
