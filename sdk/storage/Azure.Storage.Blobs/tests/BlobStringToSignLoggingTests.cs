// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using EventLevel = System.Diagnostics.Tracing.EventLevel;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobStringToSignLoggingTests : BlobTestBase
    {
        public BlobStringToSignLoggingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task SharedKeyStringToSignLogging()
        {
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_SharedKey();

            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    if (e.EventName == "GenerateSharedKeyStringToSign")
                    {
                        Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                    }
                },
                EventLevel.Verbose);

            await serviceClient.GetBlobContainersAsync().ToListAsync();
        }

        [RecordedTest]
        public void AccountSasStringToSignLogging()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_SharedKey();
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual("GenerateAccountSasStringToSign", e.EventName);
                    Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                },
                EventLevel.Verbose);

            // Act
            serviceClient.GenerateAccountSasUri(
                permissions: AccountSasPermissions.Write,
                expiresOn: expiresOn,
                AccountSasResourceTypes.All);
        }

        [RecordedTest]
        public void BlobSasStringToSignLogging()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_SharedKey();
            string containerName = GetNewContainerName();
            BlobContainerClient containerClient = InstrumentClient(serviceClient.GetBlobContainerClient(containerName));
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);

            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual("GenerateServiceSasStringToSign", e.EventName);
                    Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                },
                EventLevel.Verbose);

            // Act
            containerClient.GenerateSasUri(
                permissions: BlobContainerSasPermissions.Read,
                expiresOn: expiresOn);
        }

        [RecordedTest]
        public async Task BlobUserDelegationSasStringToSignLogging()
        {
            // Arrange
            BlobServiceClient serviceClient = BlobsClientBuilder.GetServiceClient_OAuth();
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(1);
            Response<UserDelegationKey> userDelegationKeyResponse = await serviceClient.GetUserDelegationKeyAsync(
                startsOn: startsOn,
                expiresOn: expiresOn);

            string containerName = GetNewContainerName();

            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (e, message) =>
                {
                    Assert.AreEqual("GenerateUserDelegationSasStringToSign", e.EventName);
                    Assert.IsTrue(message.Contains("Generated string to sign:\n"));
                },
                EventLevel.Verbose);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobContainerSasPermissions.Read,
                expiresOn: expiresOn);
            blobSasBuilder.BlobContainerName = containerName;

            // Act
            blobSasBuilder.ToSasQueryParameters(userDelegationKeyResponse.Value, serviceClient.AccountName);
        }
    }
}
