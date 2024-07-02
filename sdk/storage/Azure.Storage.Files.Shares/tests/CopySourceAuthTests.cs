// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class CopySourceAuthTests : FileTestBase
    {
        public CopySourceAuthTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_10_02)]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task UploadRangeFromUriAsync_SourceBearerToken()
        {
            // Arrange
            BlobServiceClient blobServiceClient = InstrumentClient(new BlobServiceClient(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                GetBlobOptions()));
            BlobContainerClient containerClient = InstrumentClient(blobServiceClient.GetBlobContainerClient(GetNewShareName()));

            try
            {
                await containerClient.CreateIfNotExistsAsync();
                AppendBlobClient appendBlobClient = InstrumentClient(containerClient.GetAppendBlobClient(GetNewFileName()));
                await appendBlobClient.CreateAsync();
                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);
                await appendBlobClient.AppendBlockAsync(stream);

                ShareServiceClient serviceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
                await using DisposingShare test = await GetTestShareAsync(
                    service: serviceClient,
                    shareName: GetNewShareName());
                ShareDirectoryClient directoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
                await directoryClient.CreateAsync();
                ShareFileClient fileClient = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));
                await fileClient.CreateAsync(Constants.KB);

                string sourceBearerToken = await GetAuthToken();

                HttpAuthorization sourceAuthHeader = new HttpAuthorization(
                    "Bearer",
                    sourceBearerToken);

                ShareFileUploadRangeFromUriOptions options = new ShareFileUploadRangeFromUriOptions
                {
                    SourceAuthentication = sourceAuthHeader
                };

                HttpRange range = new HttpRange(0, Constants.KB);

                // Act
                await fileClient.UploadRangeFromUriAsync(
                    sourceUri: appendBlobClient.Uri,
                    range: range,
                    sourceRange: range,
                    options: options);
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_10_02)]
        public async Task UploadRangeFromUriAsync_SourceBearerTokenFail()
        {
            // Arrange
            BlobServiceClient blobServiceClient = InstrumentClient(new BlobServiceClient(
                new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                TestEnvironment.Credential,
                GetBlobOptions()));
            BlobContainerClient containerClient = InstrumentClient(blobServiceClient.GetBlobContainerClient(GetNewShareName()));

            try
            {
                await containerClient.CreateIfNotExistsAsync();
                AppendBlobClient appendBlobClient = InstrumentClient(containerClient.GetAppendBlobClient(GetNewFileName()));
                await appendBlobClient.CreateAsync();
                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);
                await appendBlobClient.AppendBlockAsync(stream);

                ShareServiceClient serviceClient = SharesClientBuilder.GetServiceClient_OAuthAccount_SharedKey();
                await using DisposingShare test = await GetTestShareAsync(
                    service: serviceClient,
                    shareName: GetNewShareName());
                ShareDirectoryClient directoryClient = InstrumentClient(test.Share.GetDirectoryClient(GetNewDirectoryName()));
                await directoryClient.CreateAsync();
                ShareFileClient fileClient = InstrumentClient(directoryClient.GetFileClient(GetNewFileName()));
                await fileClient.CreateAsync(Constants.KB);

                HttpAuthorization sourceAuthHeader = new HttpAuthorization(
                    "Bearer",
                    "auth token");

                ShareFileUploadRangeFromUriOptions options = new ShareFileUploadRangeFromUriOptions
                {
                    SourceAuthentication = sourceAuthHeader
                };

                HttpRange range = new HttpRange(0, Constants.KB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    fileClient.UploadRangeFromUriAsync(
                        sourceUri: appendBlobClient.Uri,
                        range: range,
                        sourceRange: range,
                        options: options),
                    e => Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode));
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        private BlobClientOptions GetBlobOptions(
            bool parallelRange = false)
        {
            var options = new BlobClientOptions(ToBlobServiceVersion(_serviceVersion))
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Storage.Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60),
                    NetworkTimeout = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 100 : 400),
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording, parallelRange), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        private BlobClientOptions.ServiceVersion ToBlobServiceVersion(ShareClientOptions.ServiceVersion shareServiceVersion)
            => (BlobClientOptions.ServiceVersion)Enum.Parse(typeof(BlobClientOptions.ServiceVersion), shareServiceVersion.ToString());
    }
}
