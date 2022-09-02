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
    public class BatchAccountCertificateCollectionTests : BatchManagementTestBase
    {
        public BatchAccountCertificateCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<BatchAccountCertificateCollection> GetAccountCollectionAsync()
        {
            var container = (await CreateResourceGroupAsync()).GetBatchAccounts();
            var input = ResourceDataHelper.GetBatchAccountData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testaccount"), input);
            var account = lro.Value;
            return account.GetBatchAccountCertificates();
        }

        [TestCase]
        public async Task CertificateCollectionApiTests()
        {
            //1.CreateOrUpdate
            var container = await GetAccountCollectionAsync();
            var name = Recording.GenerateAssetName("testCertificate-");
            var input = ResourceDataHelper.GetBatchAccountCertificateData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountCertificateResource certificate1 = lro.Value;
            Assert.AreEqual(name, certificate1.Data.Name);
            //2.Get
            BatchAccountCertificateResource ertificate2 = await container.GetAsync(name);
            ResourceDataHelper.AssertCertificate(certificate1.Data, ertificate2.Data);
            //3.GetAll
            _ = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var account in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await container.ExistsAsync(name));
            Assert.IsFalse(await container.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.ExistsAsync(null));
        }
    }
}
