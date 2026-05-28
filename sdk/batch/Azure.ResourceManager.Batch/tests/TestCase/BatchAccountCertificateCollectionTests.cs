// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.TestCase
{
    public class BatchAccountCertificateCollectionTests : BatchManagementTestBase
    {
        private BatchAccountResource _batchAccount;

        public BatchAccountCertificateCollectionTests(bool isAsync)
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
        public async Task CertificateCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = _batchAccount.GetBatchAccountCertificates();
            var name = "sha1-cff2ab63c8c955aaf71989efa641b906558d9fb7";
            var input = ResourceDataHelper.GetBatchAccountCertificateData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BatchAccountCertificateResource certificate1 = lro.Value;
            Assert.AreEqual(name, certificate1.Data.Name);
            //2.Get
            BatchAccountCertificateResource certificate2 = await collection.GetAsync(name);
            ResourceDataHelper.AssertCertificate(certificate1.Data, certificate2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var account in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync("sha1-cff2ab63c8c955aaf71989efa641b906558d9fb8"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
