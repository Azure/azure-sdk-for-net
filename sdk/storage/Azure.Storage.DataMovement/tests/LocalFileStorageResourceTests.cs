// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Test;
using Mono.Unix.Native;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalFileStorageResourceTests : DataMovementTestBase
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
            "/user1/Documents/file/",
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
        public void Ctor_string()
        {
            // Arrange
            foreach (string path in fileNames)
            {
                LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

                // Assert
                Assert.AreEqual(path, storageResource.Uri.LocalPath);
                Assert.AreEqual(Uri.UriSchemeFile, storageResource.Uri.Scheme);
            }
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true)]
        [TestCase("C:\\test\\path=true@&#%", "C:/test/path%3Dtrue%40%26%23%25")]
        [TestCase("C:\\test\\path%3Dtest%26", "C:/test/path%253Dtest%2526")]
        [TestCase("C:\\test\\file with spaces", "C:/test/file%20with%20spaces")]
        public void Ctor_String_Encoding_Windows(string path, string absolutePath)
        {
            LocalFileStorageResource storageResource = new(path);
            Assert.That(storageResource.Uri.AbsolutePath, Is.EqualTo(absolutePath));
            // LocalPath should equal original path
            Assert.That(storageResource.Uri.LocalPath, Is.EqualTo(path));
        }

        [Test]
        [RunOnlyOnPlatforms(Linux = true, OSX = true)]
        [TestCase("/test/path=true@&#%", "/test/path%3Dtrue%40%26%23%25")]
        [TestCase("/test/path%3Dtest%26", "/test/path%253Dtest%2526")]
        [TestCase("/test/file with spaces", "/test/file%20with%20spaces")]
        public void Ctor_String_Encoding_Unix(string path, string absolutePath)
        {
            LocalFileStorageResource storageResource = new(path);
            Assert.That(storageResource.Uri.AbsolutePath, Is.EqualTo(absolutePath));
            // LocalPath should equal original path
            Assert.That(storageResource.Uri.LocalPath, Is.EqualTo(path));
        }

        public void Ctor_String_Encoding(string path, string absolutePath)
        {
            LocalFileStorageResource storageResource = new(path);
            Assert.That(storageResource.Uri.AbsolutePath, Is.EqualTo(absolutePath));
            // LocalPath should equal original path
            Assert.That(storageResource.Uri.LocalPath, Is.EqualTo(path));
        }

        [Test]
        public void Ctor_Error()
        {
            Assert.Catch<ArgumentException>(() =>
                new LocalFileStorageResource(""));

            Assert.Catch<ArgumentException>(() =>
                new LocalFileStorageResource("   "));

            Assert.Catch<ArgumentException>(() =>
                new LocalFileStorageResource(path: default));

            Assert.Catch<ArgumentException>(() =>
                new LocalFileStorageResource(uri: default));
        }

        [Test]
        public async Task ReadStreamAsync()
        {
            // Arrange
            var size = Constants.KB;
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string path = await CreateRandomFileAsync(test.DirectoryPath, size:0);
            var data = GetRandomBuffer(size);
            File.WriteAllBytes(path, data);

            // Act
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            StorageResourceReadStreamResult result = await storageResource.ReadStreamAsync();
            using Stream content = result.Content;

            // Assert
            Assert.NotNull(content);
            TestHelper.AssertSequenceEqual(data, content.AsBytes().ToArray());
        }

        [Test]
        public async Task ReadStreamAsync_Position()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string path = await CreateRandomFileAsync(test.DirectoryPath, size: 0);

            var length = Constants.KB;
            var data = GetRandomBuffer(length);
            File.WriteAllBytes(path, data);

            // Act
            var readPosition = 5;
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            StorageResourceReadStreamResult result = await storageResource.ReadStreamAsync(position: readPosition);
            using Stream content = result.Content;

            // Assert
            Assert.NotNull(content);
            byte[] copiedData = new byte[data.Length - readPosition];
            Array.Copy(data, readPosition, copiedData, 0, data.Length - readPosition);
            TestHelper.AssertSequenceEqual(copiedData, content.AsBytes().ToArray());
        }

        [Test]
        public async Task ReadStreamAsync_Error()
        {
            // Arrange
            string path = Path.Combine(Path.GetTempPath(), Recording.Random.NewGuid().ToString());
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
        public async Task WriteStreamAsync()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string path = Path.Combine(test.DirectoryPath, Recording.Random.NewGuid().ToString());

            var length = Constants.KB;
            var data = GetRandomBuffer(length);

            // Act
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.CopyFromStreamAsync(
                    stream,
                    streamLength: length,
                    false,
                    completeLength: length,
                    options: new StorageResourceWriteToOffsetOptions() { Initial = true });
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
            var writePosition = 5;
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string path = await CreateRandomFileAsync(test.DirectoryPath, size: writePosition);

            var length = Constants.KB;
            var data = GetRandomBuffer(length);

            // Act
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            using (var stream = new MemoryStream(data))
            {
                // Act
                await storageResource.CopyFromStreamAsync(
                    stream,
                    streamLength: length,
                    overwrite: false,
                    completeLength: length,
                    options: new StorageResourceWriteToOffsetOptions() { Position = writePosition, Initial = false });
            }

            // Assert
            using FileStream pathStream = new FileStream(path, FileMode.Open);
            Assert.NotNull(pathStream);
            pathStream.Seek(writePosition, SeekOrigin.Begin);
            TestHelper.AssertSequenceEqual(data, pathStream.AsBytes().ToArray());
        }

        [Test]
        public async Task WriteStreamAsync_Error()
        {
            // Arrange
            var length = Constants.KB;
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string path = await CreateRandomFileAsync(test.DirectoryPath, size: length);
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);
            var data = GetRandomBuffer(length);
            Assert.ThrowsAsync<IOException>(async () =>
            {
                using (var stream = new MemoryStream(data))
                {
                    await storageResource.CopyFromStreamAsync(
                        stream: stream,
                        streamLength: length,
                        overwrite: false,
                        completeLength: length,
                        options: new StorageResourceWriteToOffsetOptions() { Initial = true });
                }
            },
            $"File path `{path}` already exists. Cannot overwrite file.");
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            int size = Constants.KB;
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string path = await CreateRandomFileAsync(test.DirectoryPath, size: size);
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            StorageResourceItemProperties result = await storageResource.GetPropertiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ResourceLength, size);
            Assert.NotNull(result.RawProperties);
        }

        [Test]
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
        public async Task CompleteTransferAsync()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string path = await CreateRandomFileAsync(test.DirectoryPath, size: 0);
            LocalFileStorageResource storageResource = new LocalFileStorageResource(path);

            // Act
            await storageResource.CompleteTransferAsync(false);

            // Assert
            Assert.IsTrue(File.Exists(path));
        }
    }
}
