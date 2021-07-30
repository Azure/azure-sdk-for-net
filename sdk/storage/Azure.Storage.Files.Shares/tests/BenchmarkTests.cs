// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class BenchmarkTests : FileTestBase
    {
        public BenchmarkTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, RecordedTestMode.None /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [TestCase(Constants.MB)]
        [TestCase(512 * Constants.MB)]
        [TestCase(256 * Constants.MB)]
        [TestCase(1024 * Constants.MB)]
        public async Task TestMaxInitialDownload(long size)
        {
            var data = GetRandomBuffer(size);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            await file.CreateAsync(size);
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            Console.WriteLine("\n\n\nUpload successful.\n\n\n");
            using (var resultStream = new MemoryStream(data))
            {
                await file.DownloadToAsync(resultStream, transferOptions: new StorageTransferOptions()
                {
                    InitialTransferSize = size,
                    MaximumTransferSize = Constants.MB
                });
                Console.WriteLine("\n\n\nDownload successful.\n\n\n");
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }

        [Test]
        [TestCase(512 * Constants.MB)]
        [TestCase(256 * Constants.MB)]
        [TestCase(1024 * Constants.MB)]
        public async Task TestMaxSequentialDownload(long size)
        {
            var data = GetRandomBuffer(size + Constants.MB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            await file.CreateAsync(size + Constants.MB);
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            Console.WriteLine("\n\n\nUpload successful.\n\n\n");
            using (var resultStream = new MemoryStream(data))
            {
                await file.DownloadToAsync(resultStream, transferOptions: new StorageTransferOptions()
                {
                    InitialTransferSize = Constants.MB,
                    MaximumTransferSize = size
                });
                Console.WriteLine("\n\n\nDownload successful.\n\n\n");
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }

        [Test]
        [TestCase(512 * Constants.MB)]
        [TestCase(256 * Constants.MB)]
        public async Task TestDefaultInitialDownload(long size)
        {
            var data = GetRandomBuffer(size);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;
            await file.CreateAsync(size);
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            Console.WriteLine("\n\n\nUpload successful.\n\n\n");
            using (var resultStream = new MemoryStream(data))
            {
                await file.DownloadToAsync(resultStream, transferOptions: new StorageTransferOptions()
                {
                    MaximumTransferSize = Constants.MB
                });
                Console.WriteLine("\n\n\nDownload successful.\n\n\n");
                Assert.AreEqual(data.Length, resultStream.Length);
                TestHelper.AssertSequenceEqual(data, resultStream.ToArray());
            }
        }
    }
}
