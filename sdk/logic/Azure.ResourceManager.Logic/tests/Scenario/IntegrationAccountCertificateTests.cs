// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountCertificateTests : LogicManagementTestBase
    {
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountCertificateCollection _certificateCollection => _integrationAccount.GetIntegrationAccountCertificates();

        public IntegrationAccountCertificateTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("intergrationAccount"));
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _integrationAccount = await Client.GetIntegrationAccountResource(_integrationAccountIdentifier).GetAsync();
        }

        private async Task<IntegrationAccountCertificateResource> CreateCertificate(string certificateName)
        {
#if NET9_0_OR_GREATER
            var certContent = X509CertificateLoader.LoadCertificateFromFile(@"TestData/IntegrationAccountCertificate.cer");
#else
            var certContent = new X509Certificate2(@"TestData/IntegrationAccountCertificate.cer");
#endif
            string certContentStr = Convert.ToBase64String(certContent.RawData);
            IntegrationAccountCertificateData data = new IntegrationAccountCertificateData(_integrationAccount.Data.Location)
            {
                PublicCertificate = BinaryData.FromString($"\"{certContentStr}\""),
            };
            var cert = await _certificateCollection.CreateOrUpdateAsync(WaitUntil.Completed, certificateName, data);
            return cert.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string certificateName = Recording.GenerateAssetName("cert");
            var cert = await CreateCertificate(certificateName);
            Assert.IsNotNull(cert);
            Assert.AreEqual(certificateName, cert.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string certificateName = Recording.GenerateAssetName("cert");
            await CreateCertificate(certificateName);
            bool flag = await _certificateCollection.ExistsAsync(certificateName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string certificateName = Recording.GenerateAssetName("cert");
            await CreateCertificate(certificateName);
            var cert = await _certificateCollection.GetAsync(certificateName);
            Assert.IsNotNull(cert);
            Assert.AreEqual(certificateName, cert.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string certificateName = Recording.GenerateAssetName("cert");
            await CreateCertificate(certificateName);
            var list = await _certificateCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string certificateName = Recording.GenerateAssetName("cert");
            var cert = await CreateCertificate(certificateName);
            bool flag = await _certificateCollection.ExistsAsync(certificateName);
            Assert.IsTrue(flag);

            await cert.DeleteAsync(WaitUntil.Completed);
            flag = await _certificateCollection.ExistsAsync(certificateName);
            Assert.IsFalse(flag);
        }
    }
}
