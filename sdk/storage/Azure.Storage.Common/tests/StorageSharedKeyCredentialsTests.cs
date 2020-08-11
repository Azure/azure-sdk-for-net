// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    public class StorageSharedKeyCredentialsTests : CommonTestBase
    {
        public StorageSharedKeyCredentialsTests(bool async)
            : base(async, null /* RecordedTestMode.Record to re-record */)
        {
        }

        /// <summary>
        /// Ensure updating the account key is reflected in the client
        /// </summary>
        [Test]
        public async Task RollCredentials()
        {
            // Create a service client
            var credential = new StorageSharedKeyCredential(
                TestConfigDefault.AccountName,
                TestConfigDefault.AccountKey);
            BlobServiceClient service =
                InstrumentClient(
                    new BlobServiceClient(
                        new Uri(TestConfigDefault.BlobServiceEndpoint),
                        credential,
                        GetBlobOptions()));

            // Verify the credential works (i.e., doesn't throw)
            await service.GetAccountInfoAsync();

            // Roll the credential to an Invalid value and make sure it fails
            credential.SetAccountKey(Convert.ToBase64String(Encoding.UTF8.GetBytes("Invalid")));
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await service.GetAccountInfoAsync());

            // Re-roll the credential and make sure it succeeds again
            credential.SetAccountKey(TestConfigDefault.AccountKey);
            await service.GetAccountInfoAsync();
        }

        /// <summary>
        /// Ensure updating the account key is reflected in the client and any
        /// children it created.
        /// </summary>
        [Test]
        public async Task RollCredentialsToChildren()
        {
            // Create a service client
            var credential = new StorageSharedKeyCredential(
                TestConfigDefault.AccountName,
                TestConfigDefault.AccountKey);
            BlobServiceClient service =
                InstrumentClient(
                    new BlobServiceClient(
                        new Uri(TestConfigDefault.BlobServiceEndpoint),
                        credential,
                        GetBlobOptions()));

            // Create a child container
            BlobContainerClient container = await service.CreateBlobContainerAsync(GetNewContainerName());
            try
            {
                // Verify the credential works (i.e., doesn't throw)
                await service.GetAccountInfoAsync();
                await container.GetPropertiesAsync();

                // Roll the credential to an Invalid value and make sure it fails
                credential.SetAccountKey(Convert.ToBase64String(Encoding.UTF8.GetBytes("Invalid")));
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await service.GetAccountInfoAsync());
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await container.GetPropertiesAsync());

                // Re-roll the credential and make sure it succeeds again
                credential.SetAccountKey(TestConfigDefault.AccountKey);
                await service.GetAccountInfoAsync();
                await container.GetPropertiesAsync();
            }
            finally
            {
                // Clean up the child container
                await container.DeleteAsync();
            }
        }
    }
}
