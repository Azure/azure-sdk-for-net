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

            Assert.IsTrue(nginxCertificateResourceIdentifier.ResourceType.Equals(NginxCertificateResource.ResourceType));
            Assert.Throws<ArgumentException>(() => NginxCertificateResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public async Task Data()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/cert/nginx.cert";
            string keyVirtualPath = "/etc/cert/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);

            Assert.IsTrue(nginxCertificate.HasData);
            Assert.NotNull(nginxCertificate.Data);
            Assert.IsTrue(nginxCertificate.Data.Name.Equals(nginxCertificateName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/cert/nginx.cert";
            string keyVirtualPath = "/etc/cert/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            NginxCertificateResource response = await nginxCertificate.GetAsync();

            ResourceDataHelper.AssertTrackedResource(nginxCertificate.Data, response.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/cert/nginx.cert";
            string keyVirtualPath = "/etc/cert/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            Assert.IsTrue(await collection.ExistsAsync(nginxCertificateName));

            await nginxCertificate.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await collection.ExistsAsync(nginxCertificateName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/cert/nginx.cert";
            string keyVirtualPath = "/etc/cert/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);

            NginxCertificateProperties certificateProperties = new NginxCertificateProperties();
            certificateProperties.CertificateVirtualPath = "/etc/cert/app.cert";
            certificateProperties.KeyVirtualPath = "/etc/cert/app.key";
            certificateProperties.KeyVaultSecretId = TestEnvironment.KeyVaultSecretId;

            NginxCertificateData nginxCertificateData = new NginxCertificateData(Location);
            nginxCertificateData.Properties = certificateProperties;
            NginxCertificateResource nginxCertificate2 = (await nginxCertificate.UpdateAsync(WaitUntil.Completed, nginxCertificateData)).Value;

            Assert.AreNotEqual(nginxCertificate.Data.Properties.CertificateVirtualPath, nginxCertificate2.Data.Properties.CertificateVirtualPath);
            Assert.AreNotEqual(nginxCertificate.Data.Properties.KeyVirtualPath, nginxCertificate2.Data.Properties.KeyVirtualPath);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxCertificate.UpdateAsync(WaitUntil.Completed, null)).Value);
        }
    }
}
