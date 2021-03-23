﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core.TestFramework;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests
{
    public class DataProtectionBlobFunctionalTests: LiveTestBase<DataProtectionTestEnvironment>
    {
        [Test]
        public async Task PersistsKeysToAzureBlob()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDataProtection().PersistKeysToAzureBlobStorage(await GetBlobClient("testblob"));
            var services = serviceCollection.BuildServiceProvider();

            var dataProtector = services.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var protectedText = dataProtector.Protect("Hello world!");

            var anotherServices = serviceCollection.BuildServiceProvider();
            var anotherDataProtector = anotherServices.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var unprotectedText = anotherDataProtector.Unprotect(protectedText);

            Assert.AreEqual("Hello world!", unprotectedText);
        }

        [Test]
        public async Task PersistsKeysToAzureBlobWhenBlobAlreadyExists()
        {
            var serviceCollection = new ServiceCollection();
            var client = await GetBlobClient("testblob3");
            await client.UploadAsync(Stream.Null, overwrite: true);

            serviceCollection.AddDataProtection().PersistKeysToAzureBlobStorage(client);
            var services = serviceCollection.BuildServiceProvider();

            var dataProtector = services.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var protectedText = dataProtector.Protect("Hello world!");

            var anotherServices = serviceCollection.BuildServiceProvider();
            var anotherDataProtector = anotherServices.GetService<IDataProtectionProvider>().CreateProtector("Fancy purpose");
            var unprotectedText = anotherDataProtector.Unprotect(protectedText);

            Assert.AreEqual("Hello world!", unprotectedText);
        }

        [Test]
        public async Task CanAddKeysIndependently()
        {
            var blobClient = await GetBlobClient("testblob2");
            await blobClient.DeleteIfExistsAsync();

            var repository = new AzureBlobXmlRepository(blobClient);
            repository.StoreElement(new XElement("XmlElement"), null);
            Assert.AreEqual(1, repository.GetAllElements().Count);

            var repository2 = new AzureBlobXmlRepository(blobClient);
            // Store another element
            repository2.StoreElement(new XElement("XmlElement"), null);

            Assert.AreEqual(2, repository2.GetAllElements().Count);
            Assert.AreEqual(2, repository.GetAllElements().Count);
        }

        private async Task<BlobClient> GetBlobClient(string name)
        {
            var client = new BlobServiceClient(
                new Uri($"https://{TestEnvironment.StorageAccountName}.blob.{TestEnvironment.StorageEndpointSuffix}/"),
                new StorageSharedKeyCredential(
                    TestEnvironment.StorageAccountName,
                    TestEnvironment.StorageAccountKey));

            var blobContainerClient = client.GetBlobContainerClient("testcontainer");
            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient(name);
            return blobClient;
        }
    }
}
