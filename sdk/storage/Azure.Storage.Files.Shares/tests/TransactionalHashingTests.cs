// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class TransactionalHashingTests : FileTestBase
    {
        #region Test Arg Definitions
        private const long DefaultDataSize = Constants.KB;
        private static IEnumerable<HttpRange> DefaultDataHttpRanges
        {
            get
            {
                yield return new HttpRange(0, 512);
                yield return new HttpRange(256, 512);
                yield return new HttpRange(512, 512);
            }
        }

        private static IEnumerable<(int DataSize, int BufferSize)> StorageStreamDefinitions
        {
            get
            {
                yield return (Constants.KB, Constants.KB);
            }
        }
        #endregion

        public TransactionalHashingTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test, Combinatorial]
        public async Task DownloadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(DefaultDataSize);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act / Assert
            Assert.DoesNotThrowAsync(async () => await (await file.DownloadAsync(new ShareFileDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            })).Value.Content.CopyToAsync(Stream.Null));
        }

        // hashing, so we buffered the stream to hash then rewind before returning to user
        [TestCase(TransactionalHashAlgorithm.MD5, true)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64, true)]
        // no hashing, so we save users a buffer
        [TestCase(TransactionalHashAlgorithm.None, false)]
        public async Task ExpectedDownloadStreamTypeReturned(TransactionalHashAlgorithm algorithm, bool isBuffered)
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            // don't make options instance at all for no hash request
            DownloadTransactionalHashingOptions hashingOptions = algorithm == TransactionalHashAlgorithm.None
                ? default
                : new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var response = await file.DownloadAsync(new ShareFileDownloadOptions { TransactionalHashingOptions = hashingOptions });

            // Assert
            if (isBuffered)
            {
                Assert.AreEqual(typeof(MemoryStream), response.Value.Content.GetType());
            }
            // actual unbuffered stream type is private; just check we didn't get back a buffered stream
            else
            {
                Assert.AreNotEqual(typeof(MemoryStream), response.Value.Content.GetType());
            }
        }

        [Test, Combinatorial]
        public async Task OpenReadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("StorageStreamDefinitions")] (int DataSize, int BufferSize) storageStreamDefinitions)
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();

            // Arrange
            var data = GetRandomBuffer(storageStreamDefinitions.DataSize);
            ShareFileClient file = InstrumentClient(test.Directory.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var readStream = await file.OpenReadAsync(new ShareFileOpenReadOptions(false)
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = storageStreamDefinitions.BufferSize
            });

            // Assert
            Assert.DoesNotThrowAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }
    }
}
