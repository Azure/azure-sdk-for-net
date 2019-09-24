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
    public class DirectoryClientTests : FileTestBase
    {
        public DirectoryClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = GetNewShareName();
            var directoryPath = GetNewDirectoryName();

            DirectoryClient directory = InstrumentClient(new DirectoryClient(connectionString.ToString(true), shareName, directoryPath, GetOptions()));

            var builder = new FileUriBuilder(directory.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual(directoryPath, builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task CreateAsync()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                Response<StorageDirectoryInfo> response = await directory.CreateAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task CreateAsync_FilePermission()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

                // Act
                Response<StorageDirectoryInfo> response = await directory.CreateAsync(filePermission: filePermission);

                // Assert
                AssertValidStorageDirectoryInfo(response);
            }
        }

        [Test]
        public async Task CreateAsync_FilePermissionAndFilePermissionKeySet()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
                var fileSmbProperties = new FileSmbProperties()
                {
                    FilePermissionKey = "filePermissionKey"
                };

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.CreateAsync(
                        smbProperties: fileSmbProperties,
                        filePermission: filePermission),
                    e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
            }
        }

        [Test]
        public async Task CreateAsync_FilePermissionTooLarge()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var filePermission = new string('*', 9 * Constants.KB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                    directory.CreateAsync(filePermission: filePermission),
                    e => Assert.AreEqual(
                        "Value must be less than or equal to 8192" + Environment.NewLine
                        + "Parameter name: filePermission", e.Message));
            }
        }

        [Test]
        public async Task CreateAsync_SmbProperties()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                var permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
                Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(permission);

                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var smbProperties = new FileSmbProperties
                {
                    FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                    FileAttributes = NtfsFileAttributes.Parse("Directory|ReadOnly"),
                    FileCreationTime = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                    FileLastWriteTime = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                };

                // Act
                Response<StorageDirectoryInfo> response = await directory.CreateAsync(smbProperties: smbProperties);

                // Assert
                AssertValidStorageDirectoryInfo(response);
                //Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.Value.FileAttributes);
                Assert.AreEqual(smbProperties.FileCreationTime, response.Value.SmbProperties.Value.FileCreationTime);
                Assert.AreEqual(smbProperties.FileLastWriteTime, response.Value.SmbProperties.Value.FileLastWriteTime);
            }
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
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
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await directory.CreateAsync(metadata: metadata);

                // Assert
                Response<StorageDirectoryProperties> response = await directory.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task DeleteAsync()
        {
            using (GetNewDirectory(out DirectoryClient directory))
            {
                // Act
                Response response = await directory.DeleteAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.DeleteAsync(),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                Response<StorageDirectoryInfo> createResponse = await directory.CreateAsync();
                Response<StorageDirectoryProperties> getPropertiesResponse = await directory.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
                Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
                Assert.AreEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.GetPropertiesAsync(),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermission()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
                await directory.CreateAsync();

                // Act
                Response<StorageDirectoryInfo> response = await directory.SetHttpHeadersAsync(filePermission: filePermission);

                // Assert
                AssertValidStorageDirectoryInfo(response);
            }
        }

        [Test]
        public async Task SetPropertiesAsync_SmbProperties()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                var permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
                Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(permission);

                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var smbProperties = new FileSmbProperties
                {
                    FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                    FileAttributes = NtfsFileAttributes.Parse("Directory|ReadOnly"),
                    FileCreationTime = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                    FileLastWriteTime = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
                };


                await directory.CreateAsync();

                // Act
                Response<StorageDirectoryInfo> response = await directory.SetHttpHeadersAsync(smbProperties: smbProperties);

                // Assert
                AssertValidStorageDirectoryInfo(response);
                Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.Value.FileAttributes);
                Assert.AreEqual(smbProperties.FileCreationTime, response.Value.SmbProperties.Value.FileCreationTime);
                Assert.AreEqual(smbProperties.FileLastWriteTime, response.Value.SmbProperties.Value.FileLastWriteTime);
            }
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionTooLong()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var filePermission = new string('*', 9 * Constants.KB);
                await directory.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                    directory.SetHttpHeadersAsync(
                        filePermission: filePermission),
                    e => Assert.AreEqual(
                        "Value must be less than or equal to 8192" + Environment.NewLine
                        + "Parameter name: filePermission", e.Message));
            }
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionAndFilePermissionKeySet()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
                var fileSmbProperties = new FileSmbProperties()
                {
                    FilePermissionKey = "filePermissionKey"
                };
                await directory.CreateAsync();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                    directory.SetHttpHeadersAsync(
                        smbProperties: fileSmbProperties,
                        filePermission: filePermission),
                    e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
            }
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            using (GetNewDirectory(out DirectoryClient directory))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();

                // Act
                await directory.SetMetadataAsync(metadata);

                // Assert
                Response<StorageDirectoryProperties> response = await directory.GetPropertiesAsync();
                AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                IDictionary<string, string> metadata = BuildMetadata();

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
            var fileNames = Enumerable.Range(0, numFiles).Select(_ => GetNewFileName()).ToArray();

            var numDirectories = 5;
            var directoryNames = Enumerable.Range(0, numDirectories).Select(_ => GetNewFileName()).ToArray();

            using (GetNewShare(out ShareClient share))
            {
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
                await directory.CreateAsync();

                foreach (var fileName in fileNames)
                {
                    FileClient file = InstrumentClient(directory.GetFileClient(fileName));

                    await file.CreateAsync(maxSize: Constants.MB);
                }

                foreach (var subDirName in directoryNames)
                {
                    DirectoryClient subDir = InstrumentClient(directory.GetSubdirectoryClient(subDirName));

                    await subDir.CreateAsync();
                }

                var directories = new List<StorageFileItem>();
                var files = new List<StorageFileItem>();

                // Act
                await foreach (Page<StorageFileItem> page in directory.GetFilesAndDirectoriesAsync().ByPage())
                {
                    directories.AddRange(page.Values.Where(item => item.IsDirectory));
                    files.AddRange(page.Values.Where(item => !item.IsDirectory));
                }

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
            using (GetNewShare(out ShareClient share))
            {
                // Arrange
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.GetFilesAndDirectoriesAsync().ToListAsync(),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ListHandles()
        {
            // Arrange
            using (GetNewDirectory(out DirectoryClient directory))
            {
                // Act
                var handles = (await directory.GetHandlesAsync(recursive: true)
                    .ByPage(pageSizeHint: 5)
                    .ToListAsync())
                    .SelectMany(p => p.Values)
                    .ToList();

                // Assert
                Assert.AreEqual(0, handles.Count);
            }
        }

        [Test]
        public async Task ListHandles_Min()
        {
            // Arrange
            using (GetNewDirectory(out DirectoryClient directory))
            {
                // Act
                IList<StorageHandle> handles = await directory.GetHandlesAsync().ToListAsync();

                // Assert
                Assert.AreEqual(0, handles.Count);
            }
        }

        [Test]
        public async Task ListHandles_Error()
        {
            // Arrange
            using (GetNewShare(out ShareClient share))
            {
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.GetHandlesAsync().ToListAsync(),
                    actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));

            }
        }

        [Test]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            using (GetNewDirectory(out DirectoryClient directory))
            {
                // Act
                Response<StorageClosedHandlesSegment> response = await directory.ForceCloseHandlesAsync();

                // Assert
                Assert.AreEqual(0, response.Value.NumberOfHandlesClosed);

            }
        }

        [Test]
        public async Task ForceCloseHandles_Recursive()
        {
            // Arrange
            using (GetNewDirectory(out DirectoryClient directory))
            {
                // Act
                Response<StorageClosedHandlesSegment> response = await directory.ForceCloseHandlesAsync(recursive: true);

                // Assert
                Assert.AreEqual(0, response.Value.NumberOfHandlesClosed);

            }
        }

        [Test]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            using (GetNewShare(out ShareClient share))
            {
                DirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    directory.ForceCloseHandlesAsync(),
                    actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));

            }
        }

        [Test]
        public async Task CreateSubdirectoryAsync()
        {
            using (GetNewDirectory(out DirectoryClient dir))
            {
                DirectoryClient subdir = (await dir.CreateSubdirectoryAsync(GetNewDirectoryName())).Value;

                Response<StorageDirectoryProperties> properties = await subdir.GetPropertiesAsync();
                Assert.IsNotNull(properties.Value);
            }
        }

        [Test]
        public async Task DeleteSubdirectoryAsync()
        {
            using (GetNewDirectory(out DirectoryClient dir))
            {
                var name = GetNewDirectoryName();
                DirectoryClient subdir = (await dir.CreateSubdirectoryAsync(name)).Value;

                await dir.DeleteSubdirectoryAsync(name);
                Assert.ThrowsAsync<StorageRequestFailedException>(
                    async () => await subdir.GetPropertiesAsync());
            }
        }

        [Test]
        public async Task CreateFileAsync()
        {
            using (GetNewDirectory(out DirectoryClient dir))
            {
                FileClient file = (await dir.CreateFileAsync(GetNewFileName(), 1024)).Value;

                Response<StorageFileProperties> properties = await file.GetPropertiesAsync();
                Assert.IsNotNull(properties.Value);
            }
        }

        [Test]
        public async Task DeleteFileAsync()
        {
            using (GetNewDirectory(out DirectoryClient dir))
            {
                var name = GetNewFileName();
                FileClient file = (await dir.CreateFileAsync(name, 1024)).Value;

                await dir.DeleteFileAsync(name);
                Assert.ThrowsAsync<StorageRequestFailedException>(
                    async () => await file.GetPropertiesAsync());
            }
        }
    }
}
