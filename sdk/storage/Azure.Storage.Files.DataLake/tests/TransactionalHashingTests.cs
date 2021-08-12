// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class TransactionalHashingTests : DataLakeTestBase
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

        public TransactionalHashingTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test, Combinatorial]
        public async Task ReadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(DefaultDataSize);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act / Assert
            Assert.DoesNotThrowAsync(async () => await (await file.ReadAsync(new DataLakeFileReadOptions
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
        public async Task ExpectedReadStreamTypeReturned(TransactionalHashAlgorithm algorithm, bool isBuffered)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            // don't make options instance at all for no hash request
            DownloadTransactionalHashingOptions hashingOptions = algorithm == TransactionalHashAlgorithm.None
                ? default
                : new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var response = await file.ReadAsync(new DataLakeFileReadOptions { TransactionalHashingOptions = hashingOptions });

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
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(storageStreamDefinitions.DataSize);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var readStream = await file.OpenReadAsync(new DataLakeOpenReadOptions(false)
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = storageStreamDefinitions.BufferSize
            });

            // Assert
            Assert.DoesNotThrowAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }
    }
}
