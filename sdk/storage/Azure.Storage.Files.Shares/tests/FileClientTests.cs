// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Files.Shares.Test
{
    public class FileClientTests : FileTestBase
    {
        public FileClientTests(bool async)
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
            var filePath = GetNewFileName();

            ShareFileClient file = InstrumentClient(new ShareFileClient(connectionString.ToString(true), shareName, filePath, GetOptions()));

            var builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual(filePath, builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public void FilePathsParsing()
        {
            // nested directories
            Uri uri1 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/dir2/file.txt");
            var builder1 = new ShareUriBuilder(uri1);
            var fileClient1 = new ShareFileClient(uri1);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient1.Name);
            TestHelper.AssertCacheableProperty("dir1/dir2/file.txt", () => fileClient1.Path);
            Assert.AreEqual("file.txt", builder1.LastDirectoryOrFileName);

            // one directory
            Uri uri2 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/file.txt");
            var builder2 = new ShareUriBuilder(uri2);
            var fileClient2 = new ShareFileClient(uri2);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient2.Name);
            TestHelper.AssertCacheableProperty("dir1/file.txt", () => fileClient2.Path);
            Assert.AreEqual("file.txt", builder2.LastDirectoryOrFileName);

            // trailing slash
            Uri uri3 = new Uri("http://dummyaccount.file.core.windows.net/share/dir1/file.txt/");
            var builder3 = new ShareUriBuilder(uri3);
            var fileClient3 = new ShareFileClient(uri3);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient3.Name);
            TestHelper.AssertCacheableProperty("dir1/file.txt", () => fileClient3.Path);
            Assert.AreEqual("file.txt", builder3.LastDirectoryOrFileName);

            // no directories
            Uri uri4 = new Uri("http://dummyaccount.file.core.windows.net/share/file.txt");
            var builder4 = new ShareUriBuilder(uri4);
            var fileClient4 = new ShareFileClient(uri4);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient4.Name);
            TestHelper.AssertCacheableProperty("file.txt", () => fileClient4.Path);
            Assert.AreEqual("file.txt", builder4.LastDirectoryOrFileName);

            // no directories or files
            Uri uri5 = new Uri("http://dummyaccount.file.core.windows.net/share");
            var builder5 = new ShareUriBuilder(uri5);
            var fileClient5 = new ShareFileClient(uri5);
            TestHelper.AssertCacheableProperty(string.Empty, () => fileClient5.Name);
            TestHelper.AssertCacheableProperty(string.Empty, () => fileClient5.Path);
            Assert.AreEqual(string.Empty, builder5.LastDirectoryOrFileName);
        }

        [Test]
        public async Task CreateAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            var name = GetNewFileName();
            ShareFileClient file = InstrumentClient(directory.GetFileClient(name));

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(maxSize: Constants.MB);

            // Assert
            AssertValidStorageFileInfo(response);
            var accountName = new ShareUriBuilder(file.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => file.AccountName);
            var shareName = new ShareUriBuilder(file.Uri).ShareName;
            TestHelper.AssertCacheableProperty(shareName, () => file.ShareName);
            TestHelper.AssertCacheableProperty(name, () => file.Name);
        }

        [Test]
        public async Task CreateAsync_FilePermission()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.MB,
                filePermission: filePermission);

            // Assert
            AssertValidStorageFileInfo(response);
        }

        [Test]
        public async Task CreateAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            var fileSmbProperties = new FileSmbProperties()
            {
                FilePermissionKey = "filePermissionKey"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.CreateAsync(
                    maxSize: Constants.MB,
                    smbProperties: fileSmbProperties,
                    filePermission: filePermission),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [Test]
        public async Task CreateAsync_FilePermissionTooLarge()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = new string('*', 9 * Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                file.CreateAsync(
                    maxSize: Constants.MB,
                    filePermission: filePermission),
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
            await directory.CreateAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };

            // Act
            Response<ShareFileInfo> response = await file.CreateAsync(
                maxSize: Constants.KB,
                smbProperties: smbProperties);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task CreateAsync_Metadata()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.CreateAsync(
                maxSize: Constants.MB,
                metadata: metadata);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task CreateAsync_Headers()
        {
            var constants = new TestConstants(this);

            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await file.CreateAsync(
                maxSize: Constants.MB,
                httpHeaders: new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                });

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5.ToList(), response.Value.ContentHash.ToList());
            Assert.AreEqual(1, response.Value.ContentEncoding.Count());
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding.First());
            Assert.AreEqual(1, response.Value.ContentLanguage.Count());
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage.First());
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.CreateAsync(maxSize: Constants.KB),
                e => Assert.AreEqual("ParentNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task SetMetadataAsync()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await file.SetMetadataAsync(metadata);

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task SetMetadataAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetMetadataAsync(metadata),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            Response<ShareFileInfo> createResponse = await file.CreateAsync(maxSize: Constants.KB);
            Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(createResponse.Value.ETag, getPropertiesResponse.Value.ETag);
            Assert.AreEqual(createResponse.Value.LastModified, getPropertiesResponse.Value.LastModified);
            Assert.AreEqual(createResponse.Value.IsServerEncrypted, getPropertiesResponse.Value.IsServerEncrypted);
            AssertPropertiesEqual(createResponse.Value.SmbProperties, getPropertiesResponse.Value.SmbProperties);
        }

        [Test]
        public async Task GetPropertiesAsync_ShareSAS()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            await using DisposingFile test = await GetTestFileAsync(shareName: shareName, directoryName: directoryName, fileName: fileName);
            ShareFileClient file = test.File;

            // Arrange
            ShareFileClient sasFile = InstrumentClient(
                GetServiceClient_FileServiceSasShare(shareName)
                .GetShareClient(shareName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<ShareFileProperties> response = await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_FileSAS()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            await using DisposingFile test = await GetTestFileAsync(shareName: shareName, directoryName: directoryName, fileName: fileName);
            ShareFileClient file = test.File;

            // Arrange
            ShareFileClient sasFile = InstrumentClient(
                GetServiceClient_FileServiceSasFile(shareName, directoryName + "/" + fileName)
                .GetShareClient(shareName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            Response<ShareFileProperties> response = await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetPropertiesAsync(),
                e =>
                {
                    Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]);
                    if (Mode != RecordedTestMode.Playback)
                    {
                        // The MockResponse type doesn't supply the ReasonPhrase we're
                        // checking for with this test
                        Assert.AreEqual("The specified resource does not exist.", e.Message.Split('(')[1].Split(')')[0].Trim());
                    }
                });
        }

        [Test]
        public async Task SetHttpHeadersAsync()
        {
            var constants = new TestConstants(this);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            await file.SetHttpHeadersAsync(
                httpHeaders: new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                });

            // Assert
            Response<ShareFileProperties> response = await file.GetPropertiesAsync();
            Assert.AreEqual(constants.ContentType, response.Value.ContentType);
            TestHelper.AssertSequenceEqual(constants.ContentMD5.ToList(), response.Value.ContentHash.ToList());
            Assert.AreEqual(1, response.Value.ContentEncoding.Count());
            Assert.AreEqual(constants.ContentEncoding, response.Value.ContentEncoding.First());
            Assert.AreEqual(1, response.Value.ContentLanguage.Count());
            Assert.AreEqual(constants.ContentLanguage, response.Value.ContentLanguage.First());
            Assert.AreEqual(constants.ContentDisposition, response.Value.ContentDisposition);
            Assert.AreEqual(constants.CacheControl, response.Value.CacheControl);
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermission()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(filePermission: filePermission);

            // Assert
            AssertValidStorageFileInfo(response);
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
            await directory.CreateAsync();

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var smbProperties = new FileSmbProperties
            {
                FilePermissionKey = createPermissionResponse.Value.FilePermissionKey,
                FileAttributes = ShareExtensions.ToFileAttributes("Archive|ReadOnly"),
                FileCreatedOn = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero),
                FileLastWrittenOn = new DateTimeOffset(2019, 8, 26, 5, 15, 25, 60, TimeSpan.Zero),
            };


            await file.CreateAsync(maxSize: Constants.KB);

            // Act
            Response<ShareFileInfo> response = await file.SetHttpHeadersAsync(smbProperties: smbProperties);

            // Assert
            AssertValidStorageFileInfo(response);
            Assert.AreEqual(smbProperties.FileAttributes, response.Value.SmbProperties.FileAttributes);
            Assert.AreEqual(smbProperties.FileCreatedOn, response.Value.SmbProperties.FileCreatedOn);
            Assert.AreEqual(smbProperties.FileLastWrittenOn, response.Value.SmbProperties.FileLastWrittenOn);
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionTooLong()
        {
            var constants = new TestConstants(this);

            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var filePermission = new string('*', 9 * Constants.KB);
            await file.CreateAsync(maxSize: Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                file.SetHttpHeadersAsync(
                    filePermission: filePermission),
                e => Assert.AreEqual(
                    "Value must be less than or equal to 8192" + Environment.NewLine
                    + "Parameter name: filePermission", e.Message));
        }

        [Test]
        public async Task SetPropertiesAsync_FilePermissionAndFilePermissionKeySet()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.KB);

            var filePermission = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)";
            var fileSmbProperties = new FileSmbProperties()
            {
                FilePermissionKey = "filePermissionKey"
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                file.SetHttpHeadersAsync(
                    smbProperties: fileSmbProperties,
                    filePermission: filePermission),
                e => Assert.AreEqual("filePermission and filePermissionKey cannot both be set", e.Message));
        }

        [Test]
        public async Task SetPropertiesAsync_Error()
        {
            var constants = new TestConstants(this);
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.SetHttpHeadersAsync(
                    httpHeaders: new ShareFileHttpHeaders
                    {
                        CacheControl = constants.CacheControl,
                        ContentDisposition = constants.ContentDisposition,
                        ContentEncoding = new string[] { constants.ContentEncoding },
                        ContentLanguage = new string[] { constants.ContentLanguage },
                        ContentHash = constants.ContentMD5,
                        ContentType = constants.ContentType
                    }),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task DeleteAsync()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            Response response = await file.DeleteAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        [Test]
        public async Task DeleteAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.DeleteAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task StartCopyAsync()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            // Act
            Response<ShareFileCopyInfo> response = await dest.StartCopyAsync(source.Uri);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task StartCopyAsync_Metata()
        {
            // Arrange
            await using DisposingFile testSource = await GetTestFileAsync();
            ShareFileClient source = testSource.File;
            await using DisposingFile testDest = await GetTestFileAsync();
            ShareFileClient dest = testSource.File;

            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
            }

            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(
                sourceUri: source.Uri,
                metadata: metadata);

            await WaitForCopy(dest);

            // Assert
            Response<ShareFileProperties> response = await dest.GetPropertiesAsync();
            AssertMetadataEquality(metadata, response.Value.Metadata);
        }

        [Test]
        public async Task StartCopyAsync_Error()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.StartCopyAsync(sourceUri: s_invalidUri),
                e => Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task AbortCopyAsync()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient source = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await source.CreateAsync(maxSize: Constants.MB);
            var data = GetRandomBuffer(Constants.MB);

            using (var stream = new MemoryStream(data))
            {
                await source.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.MB),
                    content: stream);
            }

            ShareFileClient dest = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await dest.CreateAsync(maxSize: Constants.MB);
            Response<ShareFileCopyInfo> copyResponse = await dest.StartCopyAsync(source.Uri);

            // Act
            try
            {
                Response response = await dest.AbortCopyAsync(copyResponse.Value.CopyId);

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
            catch (RequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
            {
                // This exception is intentionally.  It is difficult to test AbortCopyAsync() in a deterministic way.
                // this.WarnCopyCompletedTooQuickly();
            }
        }

        [Test]
        public async Task AbortCopyAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            await file.CreateAsync(maxSize: Constants.MB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.AbortCopyAsync("id"),
                e => Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public void WithSnapshot()
        {
            var shareName = GetNewShareName();
            var directoryName = GetNewDirectoryName();
            var fileName = GetNewFileName();

            ShareServiceClient service = GetServiceClient_SharedKey();

            ShareClient share = InstrumentClient(service.GetShareClient(shareName));

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(directoryName));

            ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));

            var builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual("", builder.Snapshot);

            file = InstrumentClient(file.WithSnapshot("foo"));

            builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            file = InstrumentClient(file.WithSnapshot(null));

            builder = new ShareUriBuilder(file.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [Test]
        public async Task DownloadAsync()
        {
            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                // Act
                Response<ShareFileProperties> getPropertiesResponse = await file.GetPropertiesAsync();
                Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(range: new HttpRange(Constants.KB, data.LongLength));

                // Assert

                // Content is equal
                Assert.AreEqual(data.Length, downloadResponse.Value.ContentLength);
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());

                // Properties are equal
                Assert.AreEqual(getPropertiesResponse.Value.LastModified, downloadResponse.Value.Details.LastModified);
                AssertMetadataEquality(getPropertiesResponse.Value.Metadata, downloadResponse.Value.Details.Metadata);
                Assert.AreEqual(getPropertiesResponse.Value.ContentType, downloadResponse.Value.ContentType);
                Assert.AreEqual(getPropertiesResponse.Value.ETag, downloadResponse.Value.Details.ETag);
                Assert.AreEqual(getPropertiesResponse.Value.ContentEncoding, downloadResponse.Value.Details.ContentEncoding);
                Assert.AreEqual(getPropertiesResponse.Value.CacheControl, downloadResponse.Value.Details.CacheControl);
                Assert.AreEqual(getPropertiesResponse.Value.ContentDisposition, downloadResponse.Value.Details.ContentDisposition);
                Assert.AreEqual(getPropertiesResponse.Value.ContentLanguage, downloadResponse.Value.Details.ContentLanguage);
                Assert.AreEqual(getPropertiesResponse.Value.CopyCompletedOn, downloadResponse.Value.Details.CopyCompletedOn);
                Assert.AreEqual(getPropertiesResponse.Value.CopyStatusDescription, downloadResponse.Value.Details.CopyStatusDescription);
                Assert.AreEqual(getPropertiesResponse.Value.CopyId, downloadResponse.Value.Details.CopyId);
                Assert.AreEqual(getPropertiesResponse.Value.CopyProgress, downloadResponse.Value.Details.CopyProgress);
                Assert.AreEqual(getPropertiesResponse.Value.CopySource, downloadResponse.Value.Details.CopySource);
                Assert.AreEqual(getPropertiesResponse.Value.CopyStatus, downloadResponse.Value.Details.CopyStatus);
                Assert.AreEqual(getPropertiesResponse.Value.IsServerEncrypted, downloadResponse.Value.Details.IsServerEncrypted);
                AssertPropertiesEqual(getPropertiesResponse.Value.SmbProperties, downloadResponse.Value.Details.SmbProperties);
            }
        }

        [Test]
        public async Task DownloadAsync_WithUnreliableConnection()
        {
            var fileSize = 2 * Constants.MB;
            var dataSize = 1 * Constants.MB;
            var offset = 512 * Constants.KB;

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directoryFaulty = InstrumentClient(
                new ShareDirectoryClient(
                    directory.Uri,
                    new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey),
                    GetFaultyFileConnectionOptions(raiseAt: 256 * Constants.KB)));

            await directory.CreateAsync();

            // Arrange
            var fileName = GetNewFileName();
            ShareFileClient fileFaulty = InstrumentClient(directoryFaulty.GetFileClient(fileName));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));
            await file.CreateAsync(maxSize: fileSize);

            var data = GetRandomBuffer(dataSize);

            // Act
            using (var stream = new MemoryStream(data))
            {
                await fileFaulty.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(offset, dataSize),
                    content: stream);
            }

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await fileFaulty.DownloadAsync(range: new HttpRange(offset, data.LongLength));
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual, 128 * Constants.KB);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        public async Task GetRangeListAsync()
        {
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            Response<ShareFileRangeInfo> response = await file.GetRangeListAsync(range: new HttpRange(0, Constants.MB));

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetRangeListAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetRangeListAsync(range: new HttpRange(0, Constants.MB)),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task UploadRangeAsync()
        {
            var data = GetRandomBuffer(Constants.KB);

            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            using (var stream = new MemoryStream(data))
            {
                Response<ShareFileUploadInfo> response = await file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream);

                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        public async Task UploadRangeAsync_Error()
        {
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            // Arrange
            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public async Task UploadAsync_Simple()
        {
            const int size = 10 * Constants.KB;
            var data = this.GetRandomBuffer(size);

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = this.GetNewFileName();
            var file = this.InstrumentClient(share.GetRootDirectoryClient().GetFileClient(name));

            await file.CreateAsync(size);
            using var stream = new MemoryStream(data);
            await file.UploadAsync(stream);

            using var bufferedContent = new MemoryStream();
            var download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [Test]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [TestCase(501 * Constants.KB)]
        public async Task UploadAsync_SmallBlobs(int size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await UploadAndVerify(size, Constants.KB);

        [Test]
        [LiveOnly]
        [TestCase(33 * Constants.MB)]
        [TestCase(257 * Constants.MB)]
        [TestCase(1 * Constants.GB)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8354")]
        public async Task UploadAsync_LargeBlobs(int size) =>
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await UploadAndVerify(size, Constants.MB);

        private async Task UploadAndVerify(long size, int singleRangeThreshold)
        {
            var data = GetRandomBuffer(size);

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            var name = GetNewFileName();
            ShareFileClient file = InstrumentClient(share.GetRootDirectoryClient().GetFileClient(name));
            await file.CreateAsync(size);
            using (var stream = new MemoryStream(data))
            {
                await file.UploadInternal(
                    content: stream,
                    progressHandler: default,
                    singleRangeThreshold: singleRangeThreshold,
                    async: true,
                    cancellationToken: CancellationToken.None);
            }

            using var bufferedContent = new MemoryStream();
            Response<ShareFileDownloadInfo> download = await file.DownloadAsync();
            await download.Value.Content.CopyToAsync(bufferedContent);
            TestHelper.AssertSequenceEqual(data, bufferedContent.ToArray());
        }

        [Test]
        public async Task UploadRangeAsync_WithUnreliableConnection()
        {
            var fileSize = 2 * Constants.MB;
            var dataSize = 1 * Constants.MB;
            var offset = 512 * Constants.KB;

            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            ShareDirectoryClient directory = InstrumentClient(share.GetDirectoryClient(GetNewDirectoryName()));
            ShareDirectoryClient directoryFaulty = InstrumentClient(
                new ShareDirectoryClient(
                    directory.Uri,
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetFaultyFileConnectionOptions()));

            await directory.CreateAsync();

            // Arrange
            var fileName = GetNewFileName();
            ShareFileClient fileFaulty = InstrumentClient(directoryFaulty.GetFileClient(fileName));
            ShareFileClient file = InstrumentClient(directory.GetFileClient(fileName));
            await file.CreateAsync(maxSize: fileSize);

            var data = GetRandomBuffer(dataSize);
            var progressList = new List<long>();
            var progressHandler = new Progress<long>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

            // Act
            using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
            {
                Response<ShareFileUploadInfo> result = await fileFaulty.UploadRangeAsync(
                    writeType: ShareFileRangeWriteType.Update,
                    range: new HttpRange(offset, dataSize),
                    content: stream,
                    progressHandler: progressHandler);

                Assert.IsNotNull(result);
                Assert.IsNotNull(result.GetRawResponse().Headers.Date);
                Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
                result.GetRawResponse().Headers.TryGetValue("x-ms-version", out var version);
                Assert.IsNotNull(version);

                await WaitForProgressAsync(progressList, data.LongLength);
                Assert.IsTrue(progressList.Count > 1, "Too few progress received");
                Assert.GreaterOrEqual(data.LongLength, progressList.Last(), "Final progress has unexpected value");
            }

            // Assert
            Response<ShareFileDownloadInfo> downloadResponse = await file.DownloadAsync(range: new HttpRange(offset, data.LongLength));
            var actual = new MemoryStream();
            await downloadResponse.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        [LiveOnly]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8354")]
        // TODO: #7645
        public async Task UploadRangeFromUriAsync()
        {
            var shareName = this.GetNewShareName();
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient share = test.Share;

            // Arrange
            var directoryName = this.GetNewDirectoryName();
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            var fileName = this.GetNewFileName();
            var data = this.GetRandomBuffer(Constants.KB);
            var sourceFile = this.InstrumentClient(directory.GetFileClient(fileName));
            await sourceFile.CreateAsync(maxSize: 1024);
            using (var stream = new MemoryStream(data))
            {
                await sourceFile.UploadRangeAsync(ShareFileRangeWriteType.Update, new HttpRange(0, 1024), stream);
            }

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);
            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);

            var sasFile = this.InstrumentClient(
                this.GetServiceClient_FileServiceSasShare(shareName)
                .GetShareClient(shareName)
                .GetDirectoryClient(directoryName)
                .GetFileClient(fileName));

            // Act
            await destFile.UploadRangeFromUriAsync(
                sourceUri: sasFile.Uri,
                range: destRange,
                sourceRange: sourceRange);

            // Assert
            var sourceDownloadResponse = await sourceFile.DownloadAsync(range: sourceRange);
            var destDownloadResponse = await destFile.DownloadAsync(range: destRange);

            var sourceStream = new MemoryStream();
            await sourceDownloadResponse.Value.Content.CopyToAsync(sourceStream);

            var destStream = new MemoryStream();
            await destDownloadResponse.Value.Content.CopyToAsync(destStream);

            TestHelper.AssertSequenceEqual(sourceStream.ToArray(), destStream.ToArray());
        }

        [Test]
        public async Task UploadRangeFromUriAsync_Error()
        {
            var shareName = this.GetNewShareName();
            await using DisposingShare test = await GetTestShareAsync(shareName: shareName);
            ShareClient share = test.Share;

            // Arrange
            var directoryName = this.GetNewDirectoryName();
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            await directory.CreateAsync();

            var fileName = this.GetNewFileName();
            var sourceFile = this.InstrumentClient(directory.GetFileClient(fileName));

            var destFile = directory.GetFileClient("destFile");
            await destFile.CreateAsync(maxSize: 1024);
            var destRange = new HttpRange(256, 256);
            var sourceRange = new HttpRange(512, 256);


            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                destFile.UploadRangeFromUriAsync(
                sourceUri: destFile.Uri,
                range: destRange,
                sourceRange: sourceRange),
                e => Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode));
        }

        [Test]
        public async Task ListHandles()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Min()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            IList<ShareFileHandle> handles = await file.GetHandlesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(0, handles.Count);
        }

        [Test]
        public async Task ListHandles_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.GetHandlesAsync().ToListAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            await using DisposingFile test = await GetTestFileAsync();
            ShareFileClient file = test.File;

            // Act
            int handlesClosed = await file.ForceCloseAllHandlesAsync();

            // Assert
            Assert.AreEqual(0, handlesClosed);
        }

        [Test]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;


            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ForceCloseAllHandlesAsync(),
                actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ForceCloseHandle_Error()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            ShareDirectoryClient directory = test.Directory;

            ShareFileClient file = InstrumentClient(directory.GetFileClient(GetNewDirectoryName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                file.ForceCloseHandleAsync("nonExistantHandleId"),
                actualException => Assert.AreEqual("InvalidHeaderValue", actualException.ErrorCode));
        }

        private async Task WaitForCopy(ShareFileClient file, int milliWait = 200)
        {
            CopyStatus status = CopyStatus.Pending;
            DateTimeOffset start = Recording.Now;
            while (status != CopyStatus.Success)
            {
                status = (await file.GetPropertiesAsync()).Value.CopyStatus;
                DateTimeOffset currentTime = Recording.Now;
                if (status == CopyStatus.Failed || currentTime.AddMinutes(-1) > start)
                {
                    throw new Exception("Copy failed or took too long");
                }
                await Delay(milliWait);
            }
        }
    }
}
