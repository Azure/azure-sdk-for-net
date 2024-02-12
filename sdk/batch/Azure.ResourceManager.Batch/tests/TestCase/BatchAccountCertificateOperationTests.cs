// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountCertificateOperationTests : BatchManagementTestBase
    {
        private BatchAccountResource _batchAccount;

        public BatchAccountCertificateOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            var batchAccountName = Recording.GenerateAssetName("testaccount");
            _batchAccount = await CreateBatchAccount(ResourceGroup, batchAccountName, StorageAccountIdentifier);
        }

        [TestCase]
        public async Task CertificateResourceApiTests()
        {
            //1.Get
            var certificateName = "sha1-cff2ab63c8c955aaf71989efa641b906558d9fb7";
            var certificateContainer = _batchAccount.GetBatchAccountCertificates();
            var certificateInput = ResourceDataHelper.GetBatchAccountCertificateData();
            var lro = await certificateContainer.CreateOrUpdateAsync(WaitUntil.Completed, certificateName, certificateInput);
            var certificate1 = lro.Value;
            BatchAccountCertificateResource certificate2 = await certificate1.GetAsync();

            ResourceDataHelper.AssertCertificate(certificate1.Data, certificate2.Data);
        }
    }
}
