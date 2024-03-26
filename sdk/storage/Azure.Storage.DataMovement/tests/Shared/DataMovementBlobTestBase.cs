// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using System.Net;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using System.IO;
using NUnit.Framework;
using Azure.Core;
using System.Threading;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Base class for Common tests
    /// </summary>
    [BlobsClientTestFixture]
    public abstract class DataMovementBlobTestBase : DataMovementTestBase
    {
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;
        /// <summary>
        /// Source of clients.
        /// </summary>
        protected ClientBuilder<BlobServiceClient, BlobClientOptions> BlobsClientBuilder { get; }

        public string GetNewContainerName() => BlobsClientBuilder.GetNewContainerName();
        public string GetNewBlobName() => BlobsClientBuilder.GetNewBlobName();
        public string GetNewBlobDirectoryName() => BlobsClientBuilder.GetNewBlobDirectoryName();
        public string GetNewBlockName() => BlobsClientBuilder.GetNewBlockName();

        public List<string> FailureMessages { get; } = new List<string>();

        public DataMovementBlobTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            BlobsClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, _serviceVersion);
        }

        public async Task<DisposingContainer> GetTestContainerAsync(
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = PublicAccessType.None,
            bool premium = default)
            => await BlobsClientBuilder.GetTestContainerAsync(service, containerName, metadata, publicAccessType, premium);

        public async Task<BlobContainerClient> GetContainerAsync(
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = PublicAccessType.None,
            bool premium = default)
            => await BlobsClientBuilder.GetContainerAsync(service, containerName, metadata, publicAccessType, premium);

        public BlobClientOptions GetBlobClientOptions(bool parallelRange = false)
            => BlobsClientBuilder.GetOptions(parallelRange);

        internal async Task<BlobBaseClient> GetNewBlobDirectoryClient(BlobContainerClient container, string blobName = default)
        {
            blobName ??= BlobsClientBuilder.GetNewBlobName();
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(blobName));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            return blob;
        }

        private BlobClientOptions GetSecondaryStorageOptions(
            TenantConfiguration config,
            out TestExceptionPolicy testExceptionPolicy,
            int numberOfReadFailuresToSimulate = 1,
            bool simulate404 = false,
            List<RequestMethod> trackedRequestMethods = null)
        {
            BlobClientOptions options = BlobsClientBuilder.GetOptions();
            options.GeoRedundantSecondaryUri = new Uri(config.BlobServiceSecondaryEndpoint);
            options.Retry.MaxRetries = 4;
            testExceptionPolicy = new TestExceptionPolicy(numberOfReadFailuresToSimulate, options.GeoRedundantSecondaryUri, simulate404, trackedRequestMethods);
            options.AddPolicy(testExceptionPolicy, HttpPipelinePosition.PerRetry);
            return options;
        }

        private BlobServiceClient GetSecondaryReadServiceClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            BlobClientOptions options = GetSecondaryStorageOptions(config, out testExceptionPolicy, numberOfReadFailuresToSimulate, simulate404, enabledRequestMethods);
            return InstrumentClient(
                 new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }

        private static TokenCredential GetKeyClientTokenCredential(KeyVaultConfiguration config)
            => new Identity.ClientSecretCredential(
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

        public BlobServiceClient GetServiceClient_BlobServiceSas_Container(
            string containerName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsContainer(containerName: containerName, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Blob(
            string containerName,
            string blobName,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsBlob(containerName: containerName, blobName: blobName, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceIdentitySas_Blob(
            string containerName,
            string blobName,
            UserDelegationKey userDelegationKey,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigOAuth.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceIdentitySasCredentialsBlob(containerName: containerName, blobName: blobName, userDelegationKey: userDelegationKey, accountName: Tenants.TestConfigOAuth.AccountName)}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsContainer(string containerName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = GetBlobSasBuilder(containerName);
            builder.SetPermissions(BlobContainerSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetNewBlobServiceIdentitySasCredentialsContainer(string containerName, UserDelegationKey userDelegationKey, string accountName)
        {
            var builder = GetBlobSasBuilder(containerName);
            builder.SetPermissions(BlobContainerSasPermissions.All);
            return builder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsBlob(string containerName, string blobName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            BlobSasBuilder builder = GetBlobSasBuilder(containerName, blobName);
            builder.SetPermissions(
                BlobSasPermissions.Read |
                BlobSasPermissions.Add |
                BlobSasPermissions.Create |
                BlobSasPermissions.Delete |
                BlobSasPermissions.Write);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetBlobSas(
            string containerName,
            string blobName,
            BlobSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetBlobIdentitySas(
            string containerName,
            string blobName,
            BlobSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetContainerSas(
            string containerName,
            BlobContainerSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetContainerIdentitySas(
            string containerName,
            BlobContainerSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetSnapshotSas(
            string containerName,
            string blobName,
            string snapshot,
            SnapshotSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, snapshot: snapshot, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetSnapshotIdentitySas(
            string containerName,
            string blobName,
            string snapshot,
            SnapshotSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, snapshot: snapshot, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public BlobSasQueryParameters GetBlobVersionSas(
            string containerName,
            string blobName,
            string blobVersion,
            BlobVersionSasPermissions permissions,
            StorageSharedKeyCredential sharedKeyCredential = default,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, blobVersion: blobVersion, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(sharedKeyCredential ?? Tenants.GetNewSharedKeyCredentials());
        }

        public BlobSasQueryParameters GetBlobVersionIdentitySas(
            string containerName,
            string blobName,
            string blobVersion,
            BlobVersionSasPermissions permissions,
            UserDelegationKey userDelegationKey,
            string accountName,
            string sasVersion = default)
        {
            BlobSasBuilder sasBuilder = GetBlobSasBuilder(containerName, blobName, blobVersion: blobVersion, sasVersion: sasVersion);
            sasBuilder.SetPermissions(permissions);
            return sasBuilder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        private BlobSasBuilder GetBlobSasBuilder(
            string containerName,
            string blobName = default,
            string snapshot = default,
            string blobVersion = default,
            string sasVersion = default)
            => new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                BlobVersionId = blobVersion,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
            };

        public BlobSasQueryParameters GetNewBlobServiceIdentitySasCredentialsBlob(string containerName, string blobName, UserDelegationKey userDelegationKey, string accountName)
        {
            var builder = GetBlobSasBuilder(containerName, blobName);
            builder.SetPermissions(
                BlobSasPermissions.Read |
                BlobSasPermissions.Add |
                BlobSasPermissions.Create |
                BlobSasPermissions.Delete |
                BlobSasPermissions.Write);
            return builder.ToSasQueryParameters(userDelegationKey, accountName);
        }

        public StorageSharedKeyCredential GetSharedKeyCredential() => Tenants.GetNewSharedKeyCredentials();

        public BlobServiceClient GetServiceClient_AccountSas(
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? BlobsClientBuilder.GetNewAccountSas(sharedKeyCredentials: sharedKeyCredentials)}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobServiceClient GetServiceClient_BlobServiceSas_Snapshot(
            string containerName,
            string blobName,
            string snapshot,
            StorageSharedKeyCredential sharedKeyCredentials = default,
            BlobSasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri($"{Tenants.TestConfigDefault.BlobServiceEndpoint}?{sasCredentials ?? GetNewBlobServiceSasCredentialsSnapshot(containerName: containerName, blobName: blobName, snapshot: snapshot, sharedKeyCredentials: sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials())}"),
                    BlobsClientBuilder.GetOptions()));

        public BlobSasQueryParameters GetNewBlobServiceSasCredentialsSnapshot(string containerName, string blobName, string snapshot, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Snapshot = snapshot,
                Protocol = SasProtocol.None,
                StartsOn = Tenants.Recording.UtcNow.AddHours(-1),
                ExpiresOn = Tenants.Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None),
            };
            builder.SetPermissions(SnapshotSasPermissions.All);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? Tenants.GetNewSharedKeyCredentials());
        }

        public async Task<PageBlobClient> CreatePageBlobClientAsync(BlobContainerClient container, long size)
        {
            PageBlobClient blob = InstrumentClient(container.GetPageBlobClient(BlobsClientBuilder.GetNewBlobName()));
            await blob.CreateIfNotExistsAsync(size, 0).ConfigureAwait(false);
            return blob;
        }

        public string ToBase64(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }

        public CustomerProvidedKey GetCustomerProvidedKey()
        {
            var bytes = new byte[32];
            Recording.Random.NextBytes(bytes);
            return new CustomerProvidedKey(bytes);
        }

        public Uri GetHttpsUri(Uri uri)
        {
            var uriBuilder = new UriBuilder(uri)
            {
                Scheme = TestConstants.Https,
                Port = TestConstants.HttpPort
            };
            return uriBuilder.Uri;
        }

        public BlobSignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new BlobSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new BlobAccessPolicy()
                    {
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                        Permissions = "rw"
                    }
                }
            };

        internal StorageConnectionString GetConnectionString(
            SharedAccessSignatureCredentials credentials = default,
            bool includeEndpoint = true,
            bool includeTable = false)
        {
            credentials ??= GetAccountSasCredentials();
            if (!includeEndpoint)
            {
                return new StorageConnectionString(credentials,
                    (new Uri(Tenants.TestConfigDefault.BlobServiceEndpoint), new Uri(Tenants.TestConfigDefault.BlobServiceSecondaryEndpoint)),
                    (new Uri(Tenants.TestConfigDefault.QueueServiceEndpoint), new Uri(Tenants.TestConfigDefault.QueueServiceSecondaryEndpoint)),
                    (new Uri(Tenants.TestConfigDefault.TableServiceEndpoint), new Uri(Tenants.TestConfigDefault.TableServiceSecondaryEndpoint)),
                    (new Uri(Tenants.TestConfigDefault.FileServiceEndpoint), new Uri(Tenants.TestConfigDefault.FileServiceSecondaryEndpoint)));
            }

            (Uri, Uri) blobUri = (new Uri(Tenants.TestConfigDefault.BlobServiceEndpoint), new Uri(Tenants.TestConfigDefault.BlobServiceSecondaryEndpoint));

            (Uri, Uri) tableUri = default;
            if (includeTable)
            {
                tableUri = (new Uri(Tenants.TestConfigDefault.TableServiceEndpoint), new Uri(Tenants.TestConfigDefault.TableServiceSecondaryEndpoint));
            }

            return new StorageConnectionString(
                    credentials,
                    blobStorageUri: blobUri,
                    tableStorageUri: tableUri);
        }

        public async Task EnableSoftDelete()
        {
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            Response<BlobServiceProperties> properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new BlobRetentionPolicy()
            {
                Enabled = true,
                Days = 2
            };
            await service.SetPropertiesAsync(properties);

            do
            {
                await Delay(250);
                properties = await service.GetPropertiesAsync();
            } while (!properties.Value.DeleteRetentionPolicy.Enabled);
        }

        public async Task DisableSoftDelete()
        {
            BlobServiceClient service = BlobsClientBuilder.GetServiceClient_SharedKey();
            Response<BlobServiceProperties> properties = await service.GetPropertiesAsync();
            properties.Value.DeleteRetentionPolicy = new BlobRetentionPolicy() { Enabled = false };
            await service.SetPropertiesAsync(properties);

            do
            {
                await Delay(250);
                properties = await service.GetPropertiesAsync();
            } while (properties.Value.DeleteRetentionPolicy.Enabled);
        }

        public class BlobQueryErrorHandler
        {
            private readonly BlobQueryError _expectedBlobQueryError;

            public BlobQueryErrorHandler(BlobQueryError expected)
            {
                _expectedBlobQueryError = expected;
            }

            public void Handle(BlobQueryError blobQueryError)
            {
                Assert.AreEqual(_expectedBlobQueryError.IsFatal, blobQueryError.IsFatal);
                Assert.AreEqual(_expectedBlobQueryError.Name, blobQueryError.Name);
                Assert.AreEqual(_expectedBlobQueryError.Description, blobQueryError.Description);
                Assert.AreEqual(_expectedBlobQueryError.Position, blobQueryError.Position);
            }
        }

        internal DateTimeOffset RoundToNearestSecond(DateTimeOffset initalDateTimeOffset)
            => new DateTimeOffset(
                year: initalDateTimeOffset.Year,
                month: initalDateTimeOffset.Month,
                day: initalDateTimeOffset.Day,
                hour: initalDateTimeOffset.Hour,
                minute: initalDateTimeOffset.Minute,
                second: initalDateTimeOffset.Second,
                offset: TimeSpan.Zero);

        internal void AssertContentFile(string sourceFile, string destinationFile)
        {
            FileInfo sourceFileInfo = new FileInfo(sourceFile);
            FileInfo destFileInfo = new FileInfo(destinationFile);
            Assert.AreEqual(sourceFileInfo.Length, destFileInfo.Length);
            using (FileStream sourceStream = File.OpenRead(sourceFile))
            {
                using (FileStream resultStream = File.OpenRead(destinationFile))
                {
                    TestHelper.AssertSequenceEqual(sourceStream.AsBytes(), resultStream.AsBytes());
                }
            }
        }

        public BlobClientOptions GetOptions(bool parallelRange = false)
            => BlobsClientBuilder.GetOptions(parallelRange);

        internal static void CompareSourceAndDestinationFiles(string sourceFile, string destinationFile)
        {
            FileStream sourceStream;
            FileStream destinationStream;

            // Open the two files.
            using (sourceStream = new FileStream(sourceFile, FileMode.Open))
            {
                using (destinationStream = new FileStream(destinationFile, FileMode.Open))
                {
                    // Read and compare a byte from each file until either a
                    // non-matching set of bytes is found or until the end of
                    // sourceFile is reached.
                    TestHelper.AssertSequenceEqual(sourceStream.AsBytes(), destinationStream.AsBytes());
                }
            }
        }

        internal class CheckBlobCompletionProgress : IProgress<long>
        {
            private long _expectedSize { get; }
            private AutoResetEvent _completeEvent { get; }
            public CheckBlobCompletionProgress(long expectedSize, AutoResetEvent completeEvent)
            {
                _expectedSize = expectedSize;
                _completeEvent = completeEvent;
            }
            public void Report(long value)
            {
                if (value == _expectedSize)
                {
                    //Console.WriteLine("Completed!");
                    _completeEvent.Set();
                }
                else if (value >= _expectedSize)
                {
                    // Error!!
                    Assert.Fail();
                    _completeEvent.Set();
                }
            }
        };

        /// <summary>
        /// Verifies Download blob contents
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="blob"></param>
        internal static void CheckDownloadFile(string uploadedFile, string downloadedFile)
        {
            using (FileStream downloadedStream = File.OpenRead(downloadedFile))
            {
                using (FileStream uploadedStream = File.OpenRead(uploadedFile))
                {
                    TestHelper.AssertSequenceEqual(uploadedStream.AsBytes(), downloadedStream.AsBytes());
                }
            }
        }

        /// <summary>
        /// Verifies Upload blob contents
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="blob"></param>
        /// <returns></returns>
        internal static async Task DownloadAndAssertAsync(Stream stream, BlobBaseClient blob)
        {
            var actual = new byte[Constants.DefaultBufferSize];
            using var actualStream = new MemoryStream(actual);

            // reset the stream before validating
            stream.Seek(0, SeekOrigin.Begin);
            long size = stream.Length;
            // we are testing Upload, not download: so we download in partitions to avoid the default timeout
            for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
            {
                var startIndex = i;
                var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                Response<BlobDownloadInfo> download = await blob.DownloadAsync(new HttpRange(startIndex, count));
                actualStream.Seek(0, SeekOrigin.Begin);
                await download.Value.Content.CopyToAsync(actualStream);

                var buffer = new byte[count];
                stream.Seek(i, SeekOrigin.Begin);
                await stream.ReadAsync(buffer, 0, count);

                TestHelper.AssertSequenceEqual(
                    buffer,
                    actual.AsSpan(0, count).ToArray());
            }
        }

        /// <summary>
        /// Verifies Upload blob contents
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="blob"></param>
        /// <returns></returns>
        internal static async Task DownloadCopyBlobAndAssert(BlobBaseClient sourceBlob, BlobBaseClient destinationBlob)
        {
            var source = new byte[Constants.DefaultBufferSize];
            using var sourceStream = new MemoryStream(source);
            var destination = new byte[Constants.DefaultBufferSize];
            using var destinationStream = new MemoryStream(destination);

            BlobProperties properties = await destinationBlob.GetPropertiesAsync();
            long size = properties.ContentLength;
            // we are testing Upload, not download: so we download in partitions to avoid the default timeout
            for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
            {
                var startIndex = i;
                var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                Response<BlobDownloadInfo> sourceDownload = await sourceBlob.DownloadAsync(new HttpRange(startIndex, count));
                Response<BlobDownloadInfo> destinationDownload = await destinationBlob.DownloadAsync(new HttpRange(startIndex, count));

                sourceStream.Seek(0, SeekOrigin.Begin);
                await sourceDownload.Value.Content.CopyToAsync(sourceStream);

                destinationStream.Seek(0, SeekOrigin.Begin);
                await destinationDownload.Value.Content.CopyToAsync(destinationStream);

                TestHelper.AssertSequenceEqual(
                    source.AsSpan(0, count).ToArray(),
                    destination.AsSpan(0, count).ToArray());
            }
        }

        internal async Task<AppendBlobClient> CreateAppendBlob(
            BlobContainerClient containerClient,
            string localSourceFile,
            string blobName,
            long size,
            AppendBlobCreateOptions createOptions = default)
        {
            AppendBlobClient blobClient = containerClient.GetAppendBlobClient(blobName);
            await blobClient.CreateIfNotExistsAsync(createOptions).ConfigureAwait(false);
            if (size > 0)
            {
                long offset = 0;
                long blockSize = Math.Min(Constants.DefaultBufferSize, size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                using (FileStream fileStream = File.Create(localSourceFile))
                {
                    // Copy source to a file, so we can verify the source against downloaded blob later
                    await originalStream.CopyToAsync(fileStream);
                    originalStream.Position = 0;
                    // Upload blob to storage account
                    while (offset < size)
                    {
                        Stream partStream = WindowStream.GetWindow(originalStream, blockSize);
                        await blobClient.AppendBlockAsync(partStream);
                        offset += blockSize;
                    }
                }
            }
            else
            {
                File.Create(localSourceFile).Close();
            }
            return blobClient;
        }

        internal async Task<BlockBlobClient> CreateBlockBlob(
            BlobContainerClient containerClient,
            string localSourceFile,
            string blobName,
            long size,
            BlobUploadOptions options = default)
        {
            BlockBlobClient blobClient = containerClient.GetBlockBlobClient(blobName);

            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                // Copy source to a file, so we can verify the source against downloaded blob later
                await originalStream.CopyToAsync(fileStream);
                // Upload blob to storage account
                originalStream.Position = 0;
                await blobClient.UploadAsync(originalStream, options);
            }
            return blobClient;
        }

        internal async Task<PageBlobClient> CreatePageBlob(
            BlobContainerClient containerClient,
            string localSourceFile,
            string blobName,
            long size,
            PageBlobCreateOptions options = default)
        {
            Assert.IsTrue(size % (Constants.KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");

            PageBlobClient blobClient = containerClient.GetPageBlobClient(blobName);
            await blobClient.CreateIfNotExistsAsync(size, options).ConfigureAwait(false);
            if (size > 0)
            {
                long offset = 0;
                long blockSize = Math.Min(Constants.DefaultBufferSize, size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                using (FileStream fileStream = File.Create(localSourceFile))
                {
                    // Copy source to a file, so we can verify the source against downloaded blob later
                    await originalStream.CopyToAsync(fileStream);
                    originalStream.Position = 0;
                }
                // Upload blob to storage account
                while (offset < size)
                {
                    Stream partStream = WindowStream.GetWindow(originalStream, blockSize);
                    await blobClient.UploadPagesAsync(partStream, offset);
                    offset += blockSize;
                }
            }
            else
            {
                File.Create(localSourceFile).Close();
            }
            return blobClient;
        }

        /// <summary>
        /// Creates a block blob.
        /// </summary>
        /// <param name="containerClient">The parent container which the blob will be uploaded to</param>
        /// <param name="sourceBlobDirectoryPath">Source Directory name. The source path will be appended to this to create the full path name</param>
        /// <param name="sourceFilePath">The blob name (full path to the blob) and the source file path</param>
        /// <param name="size">Size of the blob</param>
        /// <returns>The local source file path which contains the contents of the source blob.</returns>
        internal async Task CreateBlockBlobAndSourceFile(
            BlobContainerClient containerClient,
            string sourceBlobDirectoryPath,
            string fullBlobPathName,
            long size)
        {
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            BlobClient originalBlob = InstrumentClient(containerClient.GetBlobClient(fullBlobPathName));
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (FileStream fileStream = File.Create(Path.Combine(sourceBlobDirectoryPath, fullBlobPathName)))
            {
                // Copy source to a file, so we can verify the source against downloaded blob later
                await originalStream.CopyToAsync(fileStream);
                // Upload blob to storage account
                originalStream.Position = 0;
                await originalBlob.UploadAsync(originalStream);
            }
        }
    }
}
