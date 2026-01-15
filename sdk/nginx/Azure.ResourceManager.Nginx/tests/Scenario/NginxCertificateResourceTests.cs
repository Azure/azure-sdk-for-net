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

            Assert.That(nginxCertificateResourceIdentifier.ResourceType.Equals(NginxCertificateResource.ResourceType), Is.True);
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

            Assert.That(nginxCertificate.HasData, Is.True);
            Assert.NotNull(nginxCertificate.Data);
            Assert.That(nginxCertificate.Data.Name.Equals(nginxCertificateName, StringComparison.InvariantCultureIgnoreCase), Is.True);
            Assert.That(nginxCertificate.Data.Id.Equals(nginxCertificateResourceIdentifier), Is.True);
            Assert.That(nginxCertificate.Data.ResourceType.Equals(NginxCertificateResource.ResourceType), Is.True);
            Assert.IsNull(nginxCertificate.Data.SystemData);
            Assert.IsNull(nginxCertificate.Data.Location);
            Assert.IsNotNull(nginxCertificate.Data.Properties.ProvisioningState);
            Assert.That(nginxCertificate.Data.Properties.CertificateVirtualPath.Equals(certificateVirtualPath), Is.True);
            Assert.That(nginxCertificate.Data.Properties.KeyVirtualPath.Equals(keyVirtualPath), Is.True);
            Assert.That(nginxCertificate.Data.Properties.KeyVaultSecretId.Equals(TestEnvironment.KeyVaultSecretId), Is.True);
            Assert.IsNotNull(nginxCertificate.Data.Properties.Sha1Thumbprint);
            Assert.IsNotNull(nginxCertificate.Data.Properties.KeyVaultSecretVersion);
            Assert.IsNotNull(nginxCertificate.Data.Properties.KeyVaultSecretCreated);
            Assert.IsNotNull(nginxCertificate.Data.Properties.CertificateError);
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

            Assert.That(nginxCertificate2.Data.Properties.CertificateVirtualPath, Is.Not.EqualTo(nginxCertificate.Data.Properties.CertificateVirtualPath));
            Assert.That(nginxCertificate2.Data.Properties.KeyVirtualPath, Is.Not.EqualTo(nginxCertificate.Data.Properties.KeyVirtualPath));
        }
    }
}
