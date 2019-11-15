// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
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

            ShareDirectoryClient directory = InstrumentClient(new ShareDirectoryClient(connectionString.ToString(true), shareName, directoryPath, GetOptions()));

            var builder = new ShareUriBuilder(directory.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual(directoryPath, builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public void DirectoryPathsParsing()
        {
            // nested directories
            Uri uri1 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/dir2");
            var builder1 = new ShareUriBuilder(uri1);
            var directoryClient1 = new ShareDirectoryClient(uri1);
            TestHelper.AssertCacheableProperty("dir2", () => directoryClient1.Name);
            TestHelper.AssertCacheableProperty("dir1/dir2", () => directoryClient1.Path);
            Assert.AreEqual("dir2", builder1.LastDirectoryOrFileName);

            // one directory
            Uri uri2 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1");
            var builder2 = new ShareUriBuilder(uri2);
            var directoryClient2 = new ShareDirectoryClient(uri2);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient2.Name);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient2.Path);
            Assert.AreEqual("dir1", builder2.LastDirectoryOrFileName);

            // directory with trailing slash
            Uri uri3 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/");
            var builder3 = new ShareUriBuilder(uri3);
            var directoryClient3 = new ShareDirectoryClient(uri3);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient3.Name);
            TestHelper.AssertCacheableProperty("dir1", () => directoryClient3.Path);
            Assert.AreEqual("dir1", builder3.LastDirectoryOrFileName);

            // no directory
            Uri uri4 = new Uri("http://dummyaccount.file.core.windows.net/share");
            var builder4 = new ShareUriBuilder(uri4);
            var directoryClient4 = new ShareDirectoryClient(uri4);
            TestHelper.AssertCacheableProperty(string.Empty, () => directoryClient4.Name);
            TestHelper.AssertCacheableProperty(string.Empty, () => directoryClient4.Path);
            Assert.AreEqual(string.Empty, builder4.LastDirectoryOrFileName);

        }

        [Test]
        public async Task CreateAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var name = GetNewDirectoryName();
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(name));

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            var accountName = new ShareUriBuilder(directory.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => directory.AccountName);
            var shareName = new ShareUriBuilder(directory.Uri).ShareName;
            TestHelper.AssertCacheableProperty(shareName, () => directory.ShareName);
            TestHelper.AssertCacheableProperty(name, () => directory.Name);
        }

        [Test]
        public async Task CreateAsync_FilePermission()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(filePermission: filePermission);

            // Assert
            AssertValidStorageDirectoryInfo(response);
        }

        [Test]
        public async Task CreateAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
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

        [Test]
        public async Task CreateAsync_FilePermissionTooLarge()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = new string('*', 9 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                directory.CreateAsync(filePermission: filePermission),
                e => Assert.AreEqual(
                    "Value must be less than or equal to 8192" + Environment.NewLine
                    + "Parameter name: filePermission", e.Message));
        }

        [Test]
        public async Task CreateAsync_SmbProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(permission);

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Directory|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };

            // Act
            Response<ShareDirectoryInfo> response = await directory.CreateAsync(smbProperties: smbProperties);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            //Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.Value.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            // Directory is intentionally created twice
            await directory.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.CreateAsync(),
                e => Assert.AreEqual("ResourceAlreadyExists", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await directory.CreateAsync(metadata: metadata);

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            Response response = await directory.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.DeleteAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            Response<ShareDirectoryInfo> createResponse = await directory.CreateAsync();
            Response<ShareDirectoryProperties> getPropertiesResponse = await directory.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
            Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetPropertiesAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermission()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            await directory.CreateAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync(filePermission: filePermission);

            // Assert
            AssertValidStorageDirectoryInfo(response);
        }

        [Test]
        public async Task SetPropertiesAsync_SmbProperties()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var permission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            Response<PermissionInfo> createPermissionResponse = await share.CreatePermissionAsync(permission);

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Directory|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };


            await directory.CreateAsync();

            // Act
            Response<ShareDirectoryInfo> response = await directory.SetHttpHeadersAsync(smbProperties: smbProperties);

            // Assert
            AssertValidStorageDirectoryInfo(response);
            Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionTooLong()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
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

        [Test]
        public async Task SetPropertiesAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
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

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await directory.SetMetadataAsync(metadata);

            // Assert
            Response<ShareDirectoryProperties> response = await directory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ListFilesAndDirectoriesSegmentAsync()
        {
            // Arrange
            var numFiles = 10;
            var fileNames = Enumerable.Range(0, numFiles).Select(_ => GetNewFileName()).ToArray();

            var numDirectories = 5;
            var directoryNames = Enumerable.Range(0, numDirectories).Select(_ => GetNewFileName()).ToArray();

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            await directory.CreateAsync();

            foreach (var fileName in fileNames)
            {
                ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));

                await file.CreateAsync(maxSize: Constants.MB);
            }

            foreach (var subDirName in directoryNames)
            {
                ShareDirectoryClient subDir = InstrumentClient(directory.GetSubdirectoryClient(subDirName));

                await subDir.CreateAsync();
            }

            var directories = new List<ShareFileItem>();
            var files = new List<ShareFileItem>();

            // Act
            await foreach (Page<ShareFileItem> page in directory.GetFilesAndDirectoriesAsync().AsPages())
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

        [Test]
        public async Task ListFilesAndDirectoriesSegmentAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetFilesAndDirectoriesAsync().ToListAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        [AsyncOnly]
        public async Task ListHandles()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            var handles = (await directory.GetHandlesAsync(recursive: true)
                .AsPages(pageSizeHint: 5)
                .ToListAsync())
                .SelectMany(p => p.Values)
                .ToList();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Min()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            IList<ShareFileHandle> handles = await directory.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.GetHandlesAsync().ToListAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            int handlesClosed = await directory.ForceCloseAllHandlesAsync();

            // Assert
            Assert.AreEqual(0, handlesClosed);
        }

        [Test]
        public async Task ForceCloseHandles_Recursive()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Act
            int handlesClosed = await directory.ForceCloseAllHandlesAsync(recursive: true);

            // Assert
            Assert.AreEqual(0, handlesClosed);
        }

        [Test]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.ForceCloseAllHandlesAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandle_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            AsyncPageable<ShareFileHandle> handles = directory.GetHandlesAsync();
            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                directory.ForceCloseHandleAsync("nonExistantHandleId"),
                actualException => Assert.AreEqual("InvalidHeaderValue", actualException.ErrorCode));
        }

        [Test]
        public async Task CreateSubdirectoryAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            ShareDirectoryClient subdir = (await dir.CreateSubdirectoryAsync(GetNewDirectoryName())).Value;

            Response<ShareDirectoryProperties> properties = await subdir.GetPropertiesAsync();
            Assert.IsNotNull(properties.Value);
        }

        [Test]
        public async Task DeleteSubdirectoryAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            var name = GetNewDirectoryName();
            ShareDirectoryClient subdir = (await dir.CreateSubdirectoryAsync(name)).Value;

            await dir.DeleteSubdirectoryAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await subdir.GetPropertiesAsync());
        }

        [Test]
        public async Task CreateFileAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            ShareFileClient file = (await dir.CreateFileAsync(GetNewFileName(), 1024)).Value;

            Response<ShareFileProperties> properties = await file.GetPropertiesAsync();
            Assert.IsNotNull(properties.Value);
        }

        [Test]
        public async Task DeleteFileAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient dir = test.Directory;

            var name = GetNewFileName();
            ShareFileClient file = (await dir.CreateFileAsync(name, 1024)).Value;

            await dir.DeleteFileAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await file.GetPropertiesAsync());
        }
    }
}
