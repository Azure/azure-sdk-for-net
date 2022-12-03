﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Mono.Unix.Native;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalFileStorageResourceTests : StorageTestBase<StorageTestEnvironment>
    {
        private readonly FileSystemAccessRule _winAcl;
        public LocalFileStorageResourceTests(bool async)
           : base(async, null /* TestMode.Record /* to re-record */)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string currentUser = WindowsIdentity.GetCurrent().Name;
                _winAcl = new FileSystemAccessRule(currentUser, FileSystemRights.ReadData, AccessControlType.Deny);
            }
        }

        private string[] fileNames => new[]
        {
            "C:\\Users\\user1\\Documents\file.txt",
            "C:\\Users\\user1\\Documents\file",
            "C:\\Users\\user1\\Documents\file\\",
            "user1\\Documents\file\\",
        };

        private void AllowReadData(string path, bool isDirectory, bool allowRead)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Dynamically will be set to correct type supplied by user
                dynamic fsInfo = isDirectory ? new DirectoryInfo(path) : new FileInfo(path);
                dynamic fsSec = FileSystemAclExtensions.GetAccessControl(fsInfo);

                fsSec.ModifyAccessRule(allowRead ? AccessControlModification.Remove : AccessControlModification.Add, _winAcl, out bool result);

                FileSystemAclExtensions.SetAccessControl(fsInfo, fsSec);
            }
#if !NETFRAMEWORK
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                FilePermissions permissions = (allowRead ?
                    (FilePermissions.S_IRWXU | FilePermissions.S_IRWXG | FilePermissions.S_IRWXO) :
                    (FilePermissions.S_IWUSR | FilePermissions.S_IWGRP | FilePermissions.S_IWOTH));

                Syscall.chmod(path, permissions);
            }
#endif
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public void Ctor_string()
        {
            // Arrange
            foreach (string path in fileNames)
            {
                LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

                // Assert
                Assert.AreEqual(path, storageResource.Path);
                Assert.AreEqual(ProduceUriType.NoUri, storageResource.CanProduceUri);
                Assert.AreEqual(TransferCopyMethod.None, storageResource.ServiceCopyMethod);
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task ReadStreamAsync()
        {
            // Arrange
            var size = Constants.KB;
            string path = await CreateRandomFileAsync(Path.GetTempPath(), size:0);
            var data = GetRandomBuffer(size);
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task ReadStreamAsync_Position()
        {
            // Arrange
            string path = await CreateRandomFileAsync(Path.GetTempPath(), size: 0);
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task ReadStreamAsync_Error()
        {
            // Arrange
            string path = "C:\\FakeFileName";
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act without creating the blob
            try
            {
                await storageResource.ReadStreamAsync();
            }
            catch (FileNotFoundException ex)
            {
                Assert.AreEqual(ex.Message, $"Could not find file '{path}'.");
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task WriteStreamAsync()
        {
            // Arrange
            string tempPath = Path.GetTempPath();
            string tempFile = string.Concat(tempPath, Path.GetRandomFileName());
            try
            {
                var length = Constants.KB;
                var data = GetRandomBuffer(length);

                // Act
                LocalFileStorageResource storageResource = new LocalFileStorageResource(tempFile);
                using (var stream = new MemoryStream(data))
                {
                    // Act
                    await storageResource.WriteFromStreamAsync(
                        stream,
                        false,
                        streamLength: length,
                        completeLength: length);
                }

                // Assert
                using FileStream pathStream = new FileStream(tempFile, FileMode.Open);
                Assert.NotNull(pathStream);
                TestHelper.AssertSequenceEqual(data, pathStream.AsBytes().ToArray());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task WriteStreamAsync_Position()
        {
            // Arrange
            var writePosition = 5;
            string path = await CreateRandomFileAsync(Path.GetTempPath(), size: writePosition);
            try
            {
                var length = Constants.KB;
                var data = GetRandomBuffer(length);

                // Act
                LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
                using (var stream = new MemoryStream(data))
                {
                    // Act
                    await storageResource.WriteFromStreamAsync(
                        stream,
                        false,
                        position: writePosition,
                        streamLength: length,
                        completeLength: length);
                }

                // Assert
                using FileStream pathStream = new FileStream(path, FileMode.Open);
                Assert.NotNull(pathStream);
                pathStream.Seek(writePosition, SeekOrigin.Begin);
                TestHelper.AssertSequenceEqual(data, pathStream.AsBytes().ToArray());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task WriteStreamAsync_Error()
        {
            // Arrange
            string path = Path.GetTempFileName();
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            try
            {
                using (var stream = new MemoryStream(data))
                {
                    await storageResource.WriteFromStreamAsync(stream, false);
                }
            }
            catch (IOException ex)
            {
                Assert.AreEqual(ex.Message, $"File path {path} already exists. Cannot overwite file");
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            int size = Constants.KB;
            string path = await CreateRandomFileAsync(Path.GetTempPath(), size: size);
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            StorageResourceProperties result = await storageResource.GetPropertiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ContentLength, size);
            Assert.NotNull(result.ETag);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            string path = "C:/FakeFileName";
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            try
            {
                await storageResource.GetPropertiesAsync();
            }
            catch (FileNotFoundException ex)
            {
                Assert.AreEqual(ex.Message, "Unable to find the specified file.");
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task CompleteTransferAsync()
        {
            // Arrange
            string path = await CreateRandomFileAsync(Path.GetTempPath(), size: 0);
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            await storageResource.CompleteTransferAsync();

            // Assert
            Assert.IsTrue(File.Exists(path));
        }
    }
}
