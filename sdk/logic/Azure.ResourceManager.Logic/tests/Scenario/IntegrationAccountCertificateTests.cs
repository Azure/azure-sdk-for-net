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
        private ResourceIdentifier _keyVaultIdentifier;
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
            var keyVault = await CreateDefaultKeyVault(rgLro.Value, SessionRecording.GenerateAssetName("vaultforlogicapp"));
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            _keyVaultIdentifier = keyVault.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _integrationAccount = await Client.GetIntegrationAccountResource(_integrationAccountIdentifier).GetAsync();
        }

        [RecordedTest]
        [Ignore("Please authorize logic apps to perform operations on key vault by granting access for the logic apps service principal..")]
        public async Task CreateOrUpdate()
        {
            string certificateName = Recording.GenerateAssetName("cert");
            var certContent = new X509Certificate2(@"..\..\..\..\..\sdk\logic\Azure.ResourceManager.Logic\tests\TestData\IntegrationAccountCertificate.cer");
            string certContentStr = Convert.ToBase64String(certContent.RawData);
            IntegrationAccountCertificateData data = new IntegrationAccountCertificateData(_integrationAccount.Data.Location)
            {
                Key = new IntegrationAccountKeyVaultKeyReference("privatekey")
                {
                    ResourceId = _keyVaultIdentifier
                },
                PublicCertificate = BinaryData.FromString($"\"{certContentStr}\""),
            };
            var cert = await _certificateCollection.CreateOrUpdateAsync(WaitUntil.Completed, certificateName, data);
        }
    }
}
