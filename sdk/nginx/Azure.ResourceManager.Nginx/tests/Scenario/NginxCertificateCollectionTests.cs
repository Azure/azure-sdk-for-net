// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Scenario
{
    internal class NginxCertificateCollectionTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxCertificateCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxCertificateCollectionTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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
        public async Task CreateOrUpdate()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/nginx/nginx.cert";
            string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);

            Assert.IsTrue(nginxCertificateName.Equals(nginxCertificate.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.GetNginxCertificates().CreateOrUpdateAsync(WaitUntil.Completed, nginxCertificateName, null)).Value);

            NginxCertificateData nginxCertificateData = new NginxCertificateData();
            nginxCertificateData.Location = Location;
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.GetNginxCertificates().CreateOrUpdateAsync(WaitUntil.Completed, null, nginxCertificateData)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();
            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/nginx/nginx.cert";
            string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate1 = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            NginxCertificateResource nginxCertificate2 = await collection.GetAsync(nginxCertificateName);

            ResourceDataHelper.AssertResourceData(nginxCertificate1.Data, nginxCertificate2.Data);
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await collection.GetAsync(nginxCertificateName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();
            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/nginx/nginx.cert";
            string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);

            Assert.IsTrue(await collection.ExistsAsync(nginxCertificateName));
            Assert.IsFalse(await collection.ExistsAsync(nginxCertificateName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetIfExists()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();
            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            NullableResponse<NginxCertificateResource> nginxCertificateResponse = await collection.GetIfExistsAsync(nginxCertificateName);
            Assert.False(nginxCertificateResponse.HasValue);

            string certificateVirtualPath = "/etc/nginx/nginx.cert";
            string keyVirtualPath = "/etc/nginx/nginx.key";
            NginxCertificateResource nginxCertificate1 = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            NullableResponse<NginxCertificateResource> nginxCertificateResponse2 = await collection.GetIfExistsAsync(nginxCertificateName);
            Assert.True(nginxCertificateResponse2.HasValue);
            NginxCertificateResource nginxCertificate2 = nginxCertificateResponse2.Value;

            ResourceDataHelper.AssertResourceData(nginxCertificate1.Data, nginxCertificate2.Data);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();

            int count = 0;
            await foreach (NginxCertificateResource nginxCertificate in collection.GetAllAsync())
            {
                count++;
            }

            Assert.AreEqual(count, 0);

            string nginxCertificateName1 = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath1 = "/etc/nginx/nginx.cert";
            string keyVirtualPath1 = "/etc/nginx/nginx.key";
            string nginxCertificateName2 = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath2 = "/etc/nginx/nginx2.cert";
            string keyVirtualPath2 = "/etc/nginx/nginx2.key";
            _ = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName1, certificateVirtualPath1, keyVirtualPath1);
            _ = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName2, certificateVirtualPath2, keyVirtualPath2);

            await foreach (NginxCertificateResource nginxCertificate in collection.GetAllAsync())
            {
                count++;
            }

            Assert.GreaterOrEqual(count, 2);
        }
    }
}
