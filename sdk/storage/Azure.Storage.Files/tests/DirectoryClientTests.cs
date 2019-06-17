// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Azure.Storage.Files.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Test
{
    [TestFixture]
    public class DirectoryClientTests : FileTestBase
    {
        public DirectoryClientTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = this.GetNewShareName();
            var directoryPath = this.GetNewDirectoryName();

            var directory = this.InstrumentClient(new DirectoryClient(connectionString.ToString(true), shareName, directoryPath, this.GetOptions()));

            var builder = new FileUriBuilder(directory.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual(directoryPath, builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task CreateAsync()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));

                // Act
                var response = await directory.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));
                // Directory is intentionally created twice
                await directory.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.CreateAsync(),
                    e => Assert.AreEqual("ResourceAlreadyExists", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));
                var metadata = this.BuildMetadata();

                // Act
                await directory.CreateAsync(metadata: metadata);

                // Assert
                var response = await directory.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task DeleteAsync()
        {
            using (this.GetNewDirectory(out var directory))
            {
                // Act
                var response = await directory.DeleteAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.DeleteAsync(),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (this.GetNewDirectory(out var directory))
            {
                // Act
                var response = await directory.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.GetPropertiesAsync(),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (this.GetNewDirectory(out var directory))
            {
                // Arrange
                var metadata = this.BuildMetadata();

                // Act
                await directory.SetMetadataAsync(metadata);

                // Assert
                var response = await directory.GetPropertiesAsync();
                this.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));
                var metadata = this.BuildMetadata();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.SetMetadataAsync(metadata),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task ListFilesAndDirectoriesSegmentAsync()
        {
            // Arrange
            var numFiles = 10;
            var fileNames = Enumerable.Range(0, numFiles).Select(_ => this.GetNewFileName()).ToArray();

            var numDirectories = 5;
            var directoryNames = Enumerable.Range(0, numDirectories).Select(_ => this.GetNewFileName()).ToArray();

            using (this.GetNewShare(out var share))
            {
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));
                await directory.CreateAsync();

                foreach (var fileName in fileNames)
                {
                    var file = this.InstrumentClient(directory.GetFileClient(fileName));

                    await file.CreateAsync(maxSize: Constants.MB);
                }

                foreach (var subDirName in directoryNames)
                {
                    var subDir = this.InstrumentClient(directory.GetDirectoryClient(subDirName));

                    await subDir.CreateAsync();
                }

                var directories = new List<DirectoryItem>();
                var files = new List<FileItem>();
                var marker = default(string);

                // Act
                do
                {
                    var response = await directory.ListFilesAndDirectoriesSegmentAsync(marker: marker);
                    directories.AddRange(response.Value.DirectoryItems);
                    files.AddRange(response.Value.FileItems);
                    marker = response.Value.NextMarker;
                }
                while (!String.IsNullOrWhiteSpace(marker));

                // Assert
                Assert.AreEqual(directoryNames.Length, directories.Count);
                Assert.AreEqual(fileNames.Length, files.Count);

                var foundDirectoryNames = directories.Select(entry => entry.Name).ToArray();
                var foundFileNames = files.Select(entry => entry.Name).ToArray();

                Assert.IsTrue(directoryNames.All(fileName => foundDirectoryNames.Contains(fileName)));
                Assert.IsTrue(fileNames.All(fileName => foundFileNames.Contains(fileName)));
            }
        }

        [Test]
        public async Task ListFilesAndDirectoriesSegmentAsync_Error()
        {
            using (this.GetNewShare(out var share))
            {
                // Arrange
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.ListFilesAndDirectoriesSegmentAsync(),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task ListHandles()
        {
            // Arrange
            using (this.GetNewDirectory(out var directory))
            {
                // Act
                var response = await directory.ListHandlesAsync(
                    maxResults: 5,
                    recursive: true);

                // Assert
                Assert.AreEqual(0, response.Value.Handles.Count());
                Assert.AreEqual(String.Empty, response.Value.NextMarker);
            }
        }

        [Test]
        public async Task ListHandles_Min()
        {
            // Arrange
            using (this.GetNewDirectory(out var directory))
            {
                // Act
                var response = await directory.ListHandlesAsync();

                // Assert
                Assert.AreEqual(0, response.Value.Handles.Count());
                Assert.AreEqual(String.Empty, response.Value.NextMarker);
            }
        }

        [Test]
        public async Task ListHandles_Error()
        {
            // Arrange
            using (this.GetNewShare(out var share))
            {
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.ListHandlesAsync(),
                    actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));

            }
        }

        [Test]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            using (this.GetNewDirectory(out var directory))
            {
                // Act
                var response = await directory.ForceCloseHandlesAsync();

                // Assert
                Assert.AreEqual(0, response.Value.NumberOfHandlesClosed);

            }
        }

        [Test]
        public async Task ForceCloseHandles_Recursive()
        {
            // Arrange
            using (this.GetNewDirectory(out var directory))
            {
                // Act
                var response = await directory.ForceCloseHandlesAsync(recursive: true);

                // Assert
                Assert.AreEqual(0, response.Value.NumberOfHandlesClosed);

            }
        }

        [Test]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            using (this.GetNewShare(out var share))
            {
                var directory = this.InstrumentClient(share.GetDirectoryClient(this.GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.ForceCloseHandlesAsync(),
                    actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));

            }
        }
    }
}
