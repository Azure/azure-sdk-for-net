// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Common;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareFileClientOpenReadTests
        : OpenReadTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        ShareFileRequestConditions,
        StorageTestEnvironment>
    {
        private const string _blobResourcePrefix = "test-blob-";
        /// <inheritdoc/>
        public override AccessConditionConfigs Conditions { get; }

        protected override string OpenReadAsync_Error_Code => "ResourceNotFound";

        public ShareFileClientOpenReadTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            Conditions = new AccessConditionConfigs(this);
        }

        #region Client-Specific Impl
        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override ShareFileClient GetResourceClient(ShareClient container, string resourceName = null, ShareClientOptions options = null)
        {
            Argument.AssertNotNull(container, nameof(container));

            string fileName = resourceName ?? GetNewResourceName();

            if (options == null)
            {
                return container.GetRootDirectoryClient().GetFileClient(fileName);
            }

            container = InstrumentClient(new ShareClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return InstrumentClient(container.GetRootDirectoryClient().GetFileClient(fileName));
        }

        protected override ShareFileRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true)
            => new ShareFileRequestConditions
            {
                LeaseId = lease ? parameters.LeaseId : default
            };

        protected override async Task<string> GetMatchConditionAsync(ShareFileClient client, string match)
        {
            if (match == Conditions.ReceivedETag)
            {
                Response<ShareFileProperties> headers = await client.GetPropertiesAsync();
                return headers.GetRawResponse().Headers.ETag.ToString();
            }
            else
            {
                return match;
            }
        }

        protected override async Task<string> SetupLeaseAsync(ShareFileClient client, string leaseId, string garbageLeaseId)
        {
            ShareFileLease lease = null;
            if (leaseId == Conditions.ReceivedLeaseId || leaseId == garbageLeaseId)
            {
                lease = await InstrumentClient(client.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync(ShareLeaseClient.InfiniteLeaseDuration);
            }
            return leaseId == Conditions.ReceivedLeaseId ? lease.LeaseId : leaseId;
        }

        protected override async Task<Stream> OpenReadAsync(ShareFileClient client, int? bufferSize = null, long position = 0, ShareFileRequestConditions conditions = null, bool allowModifications = false)
            => await client.OpenReadAsync(new ShareFileOpenReadOptions(allowModifications)
            {
                BufferSize = bufferSize,
                Position = position,
                Conditions = conditions
            });

        protected override async Task<Stream> OpenReadAsyncOverload(ShareFileClient client, int? bufferSize = null, long position = 0, bool allowModifications = false)
            => await client.OpenReadAsync(allowModifications, position, bufferSize);

        protected override async Task StageDataAsync(ShareFileClient client, Stream data)
        {
            await client.CreateAsync(data.Length);
            await client.UploadAsync(data);
        }

        protected override async Task ModifyDataAsync(ShareFileClient client, Stream data, ModifyDataMode mode)
        {
            switch (mode)
            {
                case ModifyDataMode.Replace:
                    await client.SetHttpHeadersAsync(new ShareFileSetHttpHeadersOptions() { NewSize = data.Length});
                    await client.UploadAsync(data);
                    break;
                case ModifyDataMode.Append:
                    long currentBlobLength = (await client.GetPropertiesAsync()).Value.ContentLength;
                    await client.SetHttpHeadersAsync(new ShareFileSetHttpHeadersOptions() { NewSize = currentBlobLength + data.Length });
                    await client.UploadRangeAsync(new HttpRange(currentBlobLength, data.Length),  data);
                    break;
                default:
                    throw Errors.InvalidArgument(nameof(mode));
            };
        }
        #endregion

        #region Test Overrides
        /// <summary>
        /// Shares do not support match or last-modified access conditions.
        /// Base test is forced to do a for-loop in the test to generate it's various conditions,
        /// rather than using <see cref="TestCaseSourceAttribute"/>, because they require Recording
        /// access to generate and so cannot be static as required by the attribute. Instead, we just
        /// rewrite the test using only leases.
        /// </summary>
        [RecordedTest]
        public override async Task OpenReadAsync_AccessConditions()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await ClientBuilder.GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewResourceName(), size);
            using Stream stream = new MemoryStream(data);
            await file.UploadAsync(stream);
            ShareFileLease fileLease = await InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString())).AcquireAsync();
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = fileLease.LeaseId
            };

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                Conditions = conditions
            };

            // Act
            Stream outputStream = await file.OpenReadAsync(options).ConfigureAwait(false);
            byte[] outputBytes = new byte[size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytes, 0, size);
#pragma warning restore CA2022

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        /// <summary>
        /// Shares do not support match or last-modified access conditions.
        /// Base test is forced to do a for-loop in the test to generate it's various conditions,
        /// rather than using <see cref="TestCaseSourceAttribute"/>, because they require Recording
        /// access to generate and so cannot be static as required by the attribute. Instead, we just
        /// rewrite the test using only leases.
        /// </summary>
        [RecordedTest]
        public override async Task OpenReadAsync_AccessConditionsFail()
        {
            int size = Constants.KB;
            await using DisposingDirectory test = await ClientBuilder.GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            ShareFileClient file = await test.Directory.CreateFileAsync(GetNewResourceName(), size);
            ShareFileRequestConditions conditions = new ShareFileRequestConditions
            {
                LeaseId = Recording.Random.NewGuid().ToString()
            };

            ShareFileOpenReadOptions options = new ShareFileOpenReadOptions(allowModifications: false)
            {
                Conditions = conditions
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.OpenReadAsync(options),
                e => Assert.AreEqual("LeaseNotPresentWithFileOperation", e.ErrorCode));
        }

        public override async Task AssertExpectedExceptionOpenReadModifiedAsync(Task readTask)
            => await TestHelper.AssertExpectedExceptionAsync<ShareFileModifiedException>(
                readTask,
                e => Assert.AreEqual("File has been modified concurrently", e.Message));
        #endregion
    }
}
