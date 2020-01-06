// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobServiceVersionPolicyTests : BlobTestBase
    {
        public BlobServiceVersionPolicyTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task EncryptionScope_CreateContainerTest()
        {
            // Arrange
            BlobClientOptions blobClientOptions = GetOptions(serviceVersion: BlobClientOptions.ServiceVersion.V2019_02_02);
            string containerName = GetNewContainerName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(TestConfigDefault.BlobServiceEndpoint));
            blobUriBuilder.BlobContainerName = containerName;
            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(blobUriBuilder.ToUri(), blobClientOptions));
            ContainerEncryptionScopeOptions encryptionScopeOptions = new ContainerEncryptionScopeOptions
            {
                DefaultEncryptionScope = "DefaultEncryptionScope"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.CreateAsync(encryptionScopeOptions: encryptionScopeOptions),
                e => Assert.AreEqual("x-ms-default-encryption-scope is not supported for create container in service version 2019-02-02", e.Message));

            // Arrange
            encryptionScopeOptions.DefaultEncryptionScope = null;
            encryptionScopeOptions.DenyEncryptionScopeOverride = true;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                containerClient.CreateAsync(encryptionScopeOptions: encryptionScopeOptions),
                e => Assert.AreEqual("x-ms-deny-encryption-scope-override is not supported for create container in service version 2019-02-02", e.Message));
        }

        [Test]
        public async Task EncryptionScope_BlobOperationsTest()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            EncryptionScope encryptionScope = new EncryptionScope
            {
                EncryptionScopeKey = "EncryptionScopeKey"
            };
            BlobClientOptions blobClientOptions = GetOptions(serviceVersion: BlobClientOptions.ServiceVersion.V2019_02_02);
            blobClientOptions.EncryptionScope = encryptionScope;

            string pageBlobName = GetNewBlobName();
            string appendBlobName = GetNewBlobName();
            string blockBlobName = GetNewBlobName();
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(TestConfigDefault.BlobServiceEndpoint));
            blobUriBuilder.BlobContainerName = test.Container.Name;

            blobUriBuilder.BlobName = pageBlobName;
            PageBlobClient pageBlob = InstrumentClient(new PageBlobClient(blobUriBuilder.ToUri(), blobClientOptions));

            blobUriBuilder.BlobName = appendBlobName;
            AppendBlobClient appendBlob = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), blobClientOptions));

            blobUriBuilder.BlobName = blockBlobName;
            BlockBlobClient blockBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), blobClientOptions));

            // Test blob create operations
            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlob.CreateAsync(1024),
                e => Assert.AreEqual("x-ms-encryption-scope is not supported for any API in service version 2019-02-02", e.Message));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                appendBlob.CreateAsync(),
                e => Assert.AreEqual("x-ms-encryption-scope is not supported for any API in service version 2019-02-02", e.Message));

            var data = GetRandomBuffer(1024);
            using (var stream = new MemoryStream(data))
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blockBlob.UploadAsync(stream),
                e => Assert.AreEqual("x-ms-encryption-scope is not supported for any API in service version 2019-02-02", e.Message));
        }

        [Test]
        public async Task GetPageRangeDiffFromUrlTest()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobClientOptions blobClientOptions = GetOptions(serviceVersion: BlobClientOptions.ServiceVersion.V2019_02_02);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(TestConfigDefault.BlobServiceEndpoint));
            blobUriBuilder.BlobContainerName = test.Container.Name;
            string blobName = GetNewBlobName();
            blobUriBuilder.BlobName = blobName;
            PageBlobClient pageBlob = InstrumentClient(new PageBlobClient(blobUriBuilder.ToUri(), blobClientOptions));

            // Arange
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                pageBlob.GetManagedDiskPageRangesDiffAsync(previousSnapshotUrl: pageBlob.Uri),
                e => Assert.AreEqual("x-ms-previous-snapshot-url is not supported for get page range diff in service version 2019-02-02", e.Message));
        }
    }
}
