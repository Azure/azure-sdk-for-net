// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Models;
using Azure.ResourceManager.Nginx.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Scenario
{
    internal class NginxCertificateResourceTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxCertificateResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxCertificateResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await CreateResourceGroup(Subscription, ResourceGroupPrefix, Location);
            }
        }

        [TestCase]
        [RecordedTest]
        public void CreateResourceIdentifier()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            ResourceIdentifier nginxCertificateResourceIdentifier = NginxCertificateResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName, "default");
            NginxCertificateResource.ValidateResourceId(nginxCertificateResourceIdentifier);

            Assert.That(nginxCertificateResourceIdentifier.ResourceType, Is.EqualTo(NginxCertificateResource.ResourceType));
        }

        [TestCase]
        [RecordedTest]
        public async Task Data()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            const string certificateVirtualPath = "/etc/nginx/nginx.cert";
            const string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            ResourceIdentifier nginxCertificateResourceIdentifier = NginxCertificateResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName, nginxCertificateName);

            Assert.Multiple(() =>
            {
                Assert.That(nginxCertificate.HasData, Is.True);
                Assert.That(nginxCertificate.Data, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(nginxCertificate.Data.Name.Equals(nginxCertificateName, StringComparison.InvariantCultureIgnoreCase), Is.True);
                Assert.That(nginxCertificate.Data.Id, Is.EqualTo(nginxCertificateResourceIdentifier));
                Assert.That(nginxCertificate.Data.ResourceType, Is.EqualTo(NginxCertificateResource.ResourceType));
                Assert.That(nginxCertificate.Data.SystemData, Is.Null);
                Assert.That(nginxCertificate.Data.Location, Is.Null);
                Assert.That(nginxCertificate.Data.Properties.ProvisioningState, Is.Not.Null);
                Assert.That(nginxCertificate.Data.Properties.CertificateVirtualPath, Is.EqualTo(certificateVirtualPath));
                Assert.That(nginxCertificate.Data.Properties.KeyVirtualPath, Is.EqualTo(keyVirtualPath));
                Assert.That(nginxCertificate.Data.Properties.KeyVaultSecretId, Is.EqualTo(TestEnvironment.KeyVaultSecretId));
                Assert.That(nginxCertificate.Data.Properties.Sha1Thumbprint, Is.Not.Null);
                Assert.That(nginxCertificate.Data.Properties.KeyVaultSecretVersion, Is.Not.Null);
                Assert.That(nginxCertificate.Data.Properties.KeyVaultSecretCreated, Is.Not.Null);
                Assert.That(nginxCertificate.Data.Properties.CertificateError, Is.Not.Null);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            const string certificateVirtualPath = "/etc/nginx/nginx.cert";
            const string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            NginxCertificateResource response = await nginxCertificate.GetAsync();

            ResourceDataHelper.AssertResourceData(nginxCertificate.Data, response.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            const string certificateVirtualPath = "/etc/nginx/nginx.cert";
            const string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            Assert.That((bool)await collection.ExistsAsync(nginxCertificateName), Is.True);

            await nginxCertificate.DeleteAsync(WaitUntil.Completed);
            Assert.That((bool)await collection.ExistsAsync(nginxCertificateName), Is.False);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            const string certificateVirtualPath = "/etc/nginx/nginx.cert";
            const string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);

            NginxCertificateProperties certificateProperties = new NginxCertificateProperties
            {
                CertificateVirtualPath = "/etc/nginx/app.cert",
                KeyVirtualPath = "/etc/nginx/app.key",
                KeyVaultSecretId = TestEnvironment.KeyVaultSecretId
            };

            NginxCertificateData nginxCertificateData = new NginxCertificateData
            {
                Location = Location,
                Properties = certificateProperties
            };
            NginxCertificateResource nginxCertificate2 = (await nginxCertificate.UpdateAsync(WaitUntil.Completed, nginxCertificateData)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(nginxCertificate2.Data.Properties.CertificateVirtualPath, Is.Not.EqualTo(nginxCertificate.Data.Properties.CertificateVirtualPath));
                Assert.That(nginxCertificate2.Data.Properties.KeyVirtualPath, Is.Not.EqualTo(nginxCertificate.Data.Properties.KeyVirtualPath));
            });
        }
    }
}
