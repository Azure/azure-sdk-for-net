// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalFileStorageResourceTests : StorageTestBase<StorageTestEnvironment>
    {
        public LocalFileStorageResourceTests(bool async)
           : base(async, null /* TestMode.Record /* to re-record */)
        { }

        private static string CreateRandomFile(string parentPath)
        {
            using (FileStream fs = File.Create(Path.Combine(parentPath, Path.GetRandomFileName())))
            {
                return fs.Name;
            }
        }

        [Test]
        [TestCase("C:\\Users\\user1\\Documents\file.txt")]
        [TestCase("C:\\Users\\user1\\Documents\file")]
        [TestCase("C:\\Users\\user1\\Documents\file\\")]
        [TestCase("user1\\Documents\file\\")]
        public void Ctor_string(string path)
        {
            // Arrange
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Assert
            Assert.AreEqual(path, storageResource.Path);
            Assert.AreEqual(ProduceUriType.NoUri, storageResource.CanProduceUri);
            Assert.AreEqual(TransferCopyMethod.None, storageResource.ServiceCopyMethod);
        }

        [Test]
        public async Task ReadStreamAsync()
        {
            // Arrange
            string path = CreateRandomFile(Path.GetTempPath());
            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
                await stream.CopyToAsync(fileStream);
            }

            // Act
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            ReadStreamStorageResourceResult result = await storageResource.ReadStreamAsync();

            // Assert
            Assert.NotNull(result);
            TestHelper.AssertSequenceEqual(data, result.Content.AsBytes().ToArray());
        }

        [Test]
        public async Task ReadStreamAsync_Position()
        {
            // Arrange
            string path = CreateRandomFile(Path.GetTempPath());
            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            using (var stream = new MemoryStream(data))
            {
                using FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
                await stream.CopyToAsync(fileStream);
            }

            // Act
            var readPosition = 5;
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            ReadStreamStorageResourceResult result = await storageResource.ReadStreamAsync(position: readPosition);

            // Assert
            Assert.NotNull(result);
            byte[] copiedData = new byte[data.Length - readPosition];
            Array.Copy(data, readPosition, copiedData, 0, data.Length - readPosition);
            TestHelper.AssertSequenceEqual(copiedData, result.Content.AsBytes().ToArray());
        }

        [Test]
        public async Task ReadStreamAsync_Error()
        {
            // Arrange
            string path = "C:/FakeFileName";
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act without creating the blob
            await TestHelper.AssertExpectedExceptionAsync<Exception>(
                storageResource.ReadStreamAsync(),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("Could not find file"));
                });
        }

        [Test]
        public async Task WriteStreamAsync()
        {
            // Arrange
            string path = CreateRandomFile(Path.GetTempPath());
            var length = Constants.KB;
            var data = GetRandomBuffer(length);

            // Act
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.WriteFromStreamAsync(stream);
            }

            // Assert
            using FileStream pathStream = new FileStream(path, FileMode.Open);
            Assert.NotNull(pathStream);
            TestHelper.AssertSequenceEqual(data, pathStream.AsBytes().ToArray());
        }

        [Test]
        public async Task WriteStreamAsync_Position()
        {
            // Arrange
            string path = CreateRandomFile(Path.GetTempPath());
            var length = Constants.KB;
            var data = GetRandomBuffer(length);

            // Act
            var readPosition = 5;
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.WriteFromStreamAsync(stream, position: readPosition);
            }

            // Assert
            using FileStream pathStream = new FileStream(path, FileMode.Open);
            Assert.NotNull(pathStream);
            byte[] copiedData = new byte[data.Length - readPosition];
            Array.Copy(data, readPosition, copiedData, 0, data.Length - readPosition);
            TestHelper.AssertSequenceEqual(copiedData, pathStream.AsBytes().ToArray());
        }

        [Test]
        public async Task WriteStreamAsync_Error()
        {
            // Arrange
            string path = "C:/FakeFileName";
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act without creating the blob
            await TestHelper.AssertExpectedExceptionAsync<Exception>(
                storageResource.ReadStreamAsync(),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("Could not find file"));
                });
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            string path = CreateRandomFile(Path.GetTempPath());
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            StorageResourceProperties result = await storageResource.GetPropertiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ContentLength, Constants.KB);
            Assert.NotNull(result.ETag);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            string path = "C:/FakeFileName";
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.GetPropertiesAsync(),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("The specified blob does not exist."));
                });
        }

        [Test]
        public async Task CompleteTransferAsync()
        {
            // Arrange
            string path = CreateRandomFile(Path.GetTempPath());
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            await storageResource.CompleteTransferAsync();

            // Assert
            Assert.IsTrue(File.Exists(path));
        }

        [Test]
        public async Task CompleteTransferAsync_Error()
        {
            // Arrange
            string path = "C:/FakeFileName";
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                storageResource.GetPropertiesAsync(),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains("The specified blob does not exist."));
                });
        }
    }
}
