// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountCertificateOperationTests : BatchManagementTestBase
    {
        public BatchAccountCertificateOperationTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<BatchAccountCertificateResource> CreateAccountResourceAsync(string accountName)
        {
            var container = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testaccount"), input);
            var account = lro.Value;
            var certificateContainer  = account.GetBatchAccountCertificates();
            var certificateInput = ResourceDataHelper.GetBatchAccountCertificateData();
            var lroc = await certificateContainer.CreateOrUpdateAsync(WaitUntil.Completed, accountName, certificateInput);
            return lroc.Value;
        }

        [TestCase]
        [Ignore("Thumbprint Value invalid")]
        public async Task CertificateResourceApiTests()
        {
            //1.Get
            var certificateName = Recording.GenerateAssetName("testCertificate-");
            var certificate1 = await CreateAccountResourceAsync(certificateName);
            BatchAccountCertificateResource certificate2 = await certificate1.GetAsync();

            ResourceDataHelper.AssertCertificate(certificate1.Data, certificate2.Data);
            //2.Delete
            await certificate1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
