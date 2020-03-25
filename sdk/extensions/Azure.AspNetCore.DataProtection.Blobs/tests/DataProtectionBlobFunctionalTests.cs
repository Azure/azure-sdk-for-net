// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AspNetCore.DataProtection.Blobs.Tests
{
    public class DataProtectionBlobFunctionalTests
    {
        private static readonly string StorageAccountName = Environment.GetEnvironmentVariable("BLOB_STORAGE_ACCOUNT_NAME");
        private static readonly string StorageAccountKey = Environment.GetEnvironmentVariable("BLOB_STORAGE_ACCOUNT_KEY");

        [Test]
        [Category("Live")]
        public async Task PersistsKeysToAzureBlob()
        {
            var client = new BlobServiceClient(new Uri($"https://{StorageAccountName}.blob.core.windows.net/"), new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey));
            var blobContainerClient = client.GetBlobContainerClient("testcontainer");
            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient("testblob");

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDataProtection().PersistKeysToAzureBlobStorage(blobClient);
            var services = serviceCollection.BuildServiceProvider();

            var dataProtector = services.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var protectedText = dataProtector.Protect("Hello world!");

            var anotherServices = serviceCollection.BuildServiceProvider();
            var anotherDataProtector = anotherServices.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var unprotectedText = anotherDataProtector.Unprotect(protectedText);

            Assert.AreEqual("Hello world!", unprotectedText);
        }
    }
}