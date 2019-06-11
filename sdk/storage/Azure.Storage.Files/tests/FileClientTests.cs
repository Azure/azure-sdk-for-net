// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Files.Test
{
    [TestFixture]
    public class FileClientTests
    {
        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var shareName = TestHelper.GetNewShareName();
            var filePath = TestHelper.GetNewFileName();

            var file = new FileClient(connectionString.ToString(true), shareName, filePath, TestHelper.GetOptions<FileConnectionOptions>());

            var builder = new FileUriBuilder(file.Uri);

            Assert.AreEqual(shareName, builder.ShareName);
            Assert.AreEqual(filePath, builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());

                // Act
                var response = await file.CreateAsync(maxSize: Constants.MB);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync_Metadata()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());
                var metadata = TestHelper.BuildMetadata();

                // Act
                await file.CreateAsync(
                    maxSize: Constants.MB,
                    metadata: metadata);

                // Assert
                var response = await file.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync_Headers()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());

                // Act
                await file.CreateAsync(
                    maxSize: Constants.MB,
                    httpHeaders: new FileHttpHeaders
                    {
                        CacheControl = TestConstants.CacheControl,
                        ContentDisposition = TestConstants.ContentDisposition,
                        ContentEncoding = new string[] { TestConstants.ContentEncoding },
                        ContentLanguage = new string[] { TestConstants.ContentLanguage },
                        ContentHash = TestConstants.ContentMD5,
                        ContentType = TestConstants.ContentType
                    });

                // Assert
                var response = await file.GetPropertiesAsync();
                Assert.AreEqual(TestConstants.ContentType, response.Value.ContentType);
                Assert.IsTrue(TestConstants.ContentMD5.ToList().SequenceEqual(response.Value.ContentHash.ToList()));
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(TestConstants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(TestConstants.ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(TestConstants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(TestConstants.CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        [Category("Live")]
        public async Task CreateAsync_Error()
        {
            using (TestHelper.GetNewShare(out var share))
            {
                // Arrange
                var directory = share.GetDirectoryClient(TestHelper.GetNewDirectoryName());
                var file = directory.GetFileClient(TestHelper.GetNewFileName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.CreateAsync(maxSize: Constants.KB),
                    e => Assert.AreEqual("ParentNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        [Category("Live")]
        public async Task SetMetadataAsync()
        {
            using (TestHelper.GetNewFile(out var file))
            {
                // Arrange
                var metadata = TestHelper.BuildMetadata();

                // Act
                await file.SetMetadataAsync(metadata);

                // Assert
                var response = await file.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        [Category("Live")]
        public async Task SetMetadataAsync_Error()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());
                var metadata = TestHelper.BuildMetadata();

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.SetMetadataAsync(metadata),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetPropertiesAsync()
        {
            using (TestHelper.GetNewFile(out var file))
            {
                // Act
                var response = await file.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetPropertiesAsync_ShareSAS()
        {
            var shareName = TestHelper.GetNewShareName();
            var directoryName = TestHelper.GetNewDirectoryName();
            var fileName = TestHelper.GetNewFileName();
            using (TestHelper.GetNewFile(out _, shareName: shareName, directoryName: directoryName, fileName: fileName))
            {
                // Arrange
                var sasFile = TestHelper.GetServiceClient_FileServiceSasShare(shareName)
                    .GetShareClient(shareName)
                    .GetDirectoryClient(directoryName)
                    .GetFileClient(fileName);

                // Act
                var response = await sasFile.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetPropertiesAsync_FileSAS()
        {
            var shareName = TestHelper.GetNewShareName();
            var directoryName = TestHelper.GetNewDirectoryName();
            var fileName = TestHelper.GetNewFileName();
            using (TestHelper.GetNewFile(out _, shareName: shareName, directoryName: directoryName, fileName: fileName))
            {
                // Arrange
                var sasFile = TestHelper.GetServiceClient_FileServiceSasFile(shareName, directoryName + "/" + fileName)
                    .GetShareClient(shareName)
                    .GetDirectoryClient(directoryName)
                    .GetFileClient(fileName);

                // Act
                var response = await sasFile.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetPropertiesAsync_Error()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.GetPropertiesAsync(),
                    e =>
                    {
                        Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]);
                        Assert.AreEqual("The specified resource does not exist.", e.Message.Split('(')[1].Split(')')[0].Trim());
                    });
            }
        }

        [Test]
        [Category("Live")]
        public async Task SetHttpHeadersAsync()
        {
            using (TestHelper.GetNewFile(out var file))
            {
                // Act
                await file.SetHttpHeadersAsync(
                    httpHeaders: new FileHttpHeaders
                    {
                        CacheControl = TestConstants.CacheControl,
                        ContentDisposition = TestConstants.ContentDisposition,
                        ContentEncoding = new string[] { TestConstants.ContentEncoding },
                        ContentLanguage = new string[] { TestConstants.ContentLanguage },
                        ContentHash = TestConstants.ContentMD5,
                        ContentType = TestConstants.ContentType
                    });

                // Assert
                var response = await file.GetPropertiesAsync();
                Assert.AreEqual(TestConstants.ContentType, response.Value.ContentType);
                Assert.IsTrue(TestConstants.ContentMD5.ToList().SequenceEqual(response.Value.ContentHash.ToList()));
                Assert.AreEqual(1, response.Value.ContentEncoding.Count());
                Assert.AreEqual(TestConstants.ContentEncoding, response.Value.ContentEncoding.First());
                Assert.AreEqual(1, response.Value.ContentLanguage.Count());
                Assert.AreEqual(TestConstants.ContentLanguage, response.Value.ContentLanguage.First());
                Assert.AreEqual(TestConstants.ContentDisposition, response.Value.ContentDisposition);
                Assert.AreEqual(TestConstants.CacheControl, response.Value.CacheControl);
            }
        }

        [Test]
        [Category("Live")]
        public async Task SetPropertiesAsync_Error()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.SetHttpHeadersAsync(
                        httpHeaders: new FileHttpHeaders
                        {
                            CacheControl = TestConstants.CacheControl,
                            ContentDisposition = TestConstants.ContentDisposition,
                            ContentEncoding = new string[] { TestConstants.ContentEncoding },
                            ContentLanguage = new string[] { TestConstants.ContentLanguage },
                            ContentHash = TestConstants.ContentMD5,
                            ContentType = TestConstants.ContentType
                        }),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }


        [Test]
        [Category("Live")]
        public async Task DeleteAsync()
        {
            using (TestHelper.GetNewFile(out var file))
            {
                // Act
                var response = await file.DeleteAsync();

                // Assert
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task DeleteAsync_Error()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.DeleteAsync(),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        [Category("Live")]
        public async Task StartCopyAsync()
        {
            using (TestHelper.GetNewFile(out var source))
            using (TestHelper.GetNewFile(out var dest))
            {
                // Arrange
                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await source.UploadRangeAsync(
                    writeType: FileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
                }

                // Act
                var response = await dest.StartCopyAsync(source.Uri);

                // Assert
                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task StartCopyAsync_Metata()
        {
            using (TestHelper.GetNewFile(out var source))
            using (TestHelper.GetNewFile(out var dest))
            {
                // Arrange
                await source.CreateAsync(maxSize: Constants.MB);
                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await source.UploadRangeAsync(
                    writeType: FileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.KB),
                    content: stream);
                }

                var metadata = TestHelper.BuildMetadata();

                // Act
                var copyResponse = await dest.StartCopyAsync(
                    sourceUri: source.Uri,
                    metadata: metadata);

                await this.WaitForCopy(dest);

                // Assert
                var response = await dest.GetPropertiesAsync();
                TestHelper.AssertMetadataEquality(metadata, response.Value.Metadata);
            }
        }

        [Test]
        [Category("Live")]
        public async Task StartCopyAsync_Error()
        {
            using (TestHelper.GetNewFile(out var file))
            {
                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.StartCopyAsync(sourceUri: TestHelper.InvalidUri),
                    e => Assert.AreEqual("CannotVerifyCopySource", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        [Category("Live")]
        public async Task AbortCopyAsync()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var source = directory.GetFileClient(TestHelper.GetNewFileName());
                await source.CreateAsync(maxSize: Constants.MB);
                var data = TestHelper.GetRandomBuffer(Constants.MB);

                using (var stream = new MemoryStream(data))
                {
                    await source.UploadRangeAsync(
                    writeType: FileRangeWriteType.Update,
                    range: new HttpRange(0, Constants.MB),
                    content: stream);
                }

                var dest = directory.GetFileClient(TestHelper.GetNewFileName());
                await dest.CreateAsync(maxSize: Constants.MB);
                var copyResponse = await dest.StartCopyAsync(source.Uri);

                // Act
                try
                {
                    var response = await dest.AbortCopyAsync(copyResponse.Value.CopyId);

                    // Assert
                    Assert.IsNotNull(response.Headers.RequestId);
                }
                catch (StorageRequestFailedException e) when (e.ErrorCode == "NoPendingCopyOperation")
                {
                    // This exception is intentionally.  It is difficult to test AbortCopyAsync() in a deterministic way.
                }
            }
        }

        [Test]
        [Category("Live")]
        public async Task AbortCopyAsync_Error()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());
                await file.CreateAsync(maxSize: Constants.MB);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.AbortCopyAsync("id"),
                    e => Assert.AreEqual("InvalidQueryParameterValue", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        public void WithSnapshot()
        {
            var shareName = TestHelper.GetNewShareName();
            var directoryName = TestHelper.GetNewDirectoryName();
            var fileName = TestHelper.GetNewFileName();

            var service = TestHelper.GetServiceClient_SharedKey();

            var share = service.GetShareClient(shareName);

            var directory = share.GetDirectoryClient(directoryName);

            var file = directory.GetFileClient(fileName);

            var builder = new FileUriBuilder(file.Uri);

            Assert.AreEqual("", builder.Snapshot);

            file = file.WithSnapshot("foo");

            builder = new FileUriBuilder(file.Uri);

            Assert.AreEqual("foo", builder.Snapshot);

            file = file.WithSnapshot(null);

            builder = new FileUriBuilder(file.Uri);

            Assert.AreEqual("", builder.Snapshot);
        }

        [Test]
        [Category("Live")]
        public async Task DownloadAsync()
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(Constants.KB);
            using (TestHelper.GetNewFile(out var file))
            using (var stream = new MemoryStream(data))
            {
                await file.UploadRangeAsync(
                    writeType: FileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, data.LongLength),
                    content: stream);

                // Act
                var response = await file.DownloadAsync(range: new HttpRange(Constants.KB, data.LongLength));
                
                // Assert
                Assert.AreEqual(data.Length, response.Value.ContentLength);
                var actual = new MemoryStream();
                await response.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                var actualData = actual.GetBuffer();
                Assert.IsTrue(data.SequenceEqual(actualData));
            }
        }

        [Test]
        [Category("Live")]
        public async Task DownloadAsync_WithUnreliableConnection()
        {
            var fileSize = 2 * Constants.MB;
            var dataSize = 1 * Constants.MB;
            var offset = 512 * Constants.KB;

            using (TestHelper.GetNewShare(out var share))
            {
                var directory = share.GetDirectoryClient(TestHelper.GetNewDirectoryName());
                var directoryFaulty = new DirectoryClient(
                    directory.Uri,
                    TestHelper.GetFaultyFileConnectionOptions(
                        new SharedKeyCredentials(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey),
                        raiseAt: 256 * Constants.KB));

                await directory.CreateAsync();

                // Arrange
                var fileName = TestHelper.GetNewFileName();
                var fileFaulty = directoryFaulty.GetFileClient(fileName);
                var file = directory.GetFileClient(fileName);
                await file.CreateAsync(maxSize: fileSize);

                var data = TestHelper.GetRandomBuffer(dataSize);

                // Act
                using (var stream = new MemoryStream(data))
                {
                    await fileFaulty.UploadRangeAsync(
                        writeType: FileRangeWriteType.Update,
                        range: new HttpRange(offset, dataSize), 
                        content: stream);
                }

                // Assert
                var downloadResponse = await fileFaulty.DownloadAsync(range: new HttpRange(offset, data.LongLength));
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                Assert.IsTrue(data.SequenceEqual(actual.GetBuffer()));
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetRangeListAsync()
        {
            using (TestHelper.GetNewFile(out var file))
            {
                var response = await file.GetRangeListAsync(range: new HttpRange(0, Constants.MB));

                Assert.IsNotNull(response);
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetRangeListAsync_Error()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.GetRangeListAsync(range: new HttpRange(0, Constants.MB)),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
            }
        }

        [Test]
        [Category("Live")]
        public async Task UploadRangeAsync()
        {
            var data = TestHelper.GetRandomBuffer(Constants.KB);

            using (TestHelper.GetNewFile(out var file))
            using (var stream = new MemoryStream(data))
            {
                var response = await file.UploadRangeAsync(
                    writeType: FileRangeWriteType.Update,
                    range: new HttpRange(Constants.KB, Constants.KB),
                    content: stream);

                Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
            }
        }

        [Test]
        [Category("Live")]
        public async Task UploadRangeAsync_Error()
        {
            using (TestHelper.GetNewDirectory(out var directory))
            {
                // Arrange
                var file = directory.GetFileClient(TestHelper.GetNewFileName());
                var data = TestHelper.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    // Act
                    await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.UploadRangeAsync(
                        writeType: FileRangeWriteType.Update,
                        range: new HttpRange(Constants.KB, Constants.KB),
                        content: stream),
                    e => Assert.AreEqual("ResourceNotFound", e.ErrorCode.Split('\n')[0]));
                }
            }
        }

        [Test]
        [Category("Live")]
        public async Task UploadRangeAsync_WithUnreliableConnection()
        {
            var fileSize = 2 * Constants.MB;
            var dataSize = 1 * Constants.MB;
            var offset = 512 * Constants.KB;

            using (TestHelper.GetNewShare(out var share))
            {
                var directory = share.GetDirectoryClient(TestHelper.GetNewDirectoryName());
                var directoryFaulty = new DirectoryClient(
                    directory.Uri,
                    TestHelper.GetFaultyFileConnectionOptions(new SharedKeyCredentials(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey)));

                await directory.CreateAsync();

                // Arrange
                var fileName = TestHelper.GetNewFileName();
                var fileFaulty = directoryFaulty.GetFileClient(fileName);
                var file = directory.GetFileClient(fileName);
                await file.CreateAsync(maxSize: fileSize);

                var data = TestHelper.GetRandomBuffer(dataSize);
                var progressList = new List<StorageProgress>();
                var progressHandler = new Progress<StorageProgress>(progress => { progressList.Add(progress); /*logger.LogTrace("Progress: {progress}", progress.BytesTransferred);*/ });

                // Act
                using (var stream = new FaultyStream(new MemoryStream(data), 256 * Constants.KB, 1, new Exception("Simulated stream fault")))
                {
                    var result = await fileFaulty.UploadRangeAsync(
                        writeType: FileRangeWriteType.Update,
                        range: new HttpRange(offset, dataSize),
                        content: stream, 
                        progressHandler: progressHandler);

                    Assert.IsNotNull(result);
                    Assert.IsNotNull(result.GetRawResponse().Headers.Date);
                    Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
                    result.GetRawResponse().Headers.TryGetValue("x-ms-version", out var version);
                    Assert.IsNotNull(version);

                    await Task.Delay(1000); // wait 1s to allow lingering progress events to execute

                    Assert.IsTrue(progressList.Count > 1, "Too few progress received");

                    var lastProgress = progressList.Last();

                    Assert.AreEqual(data.LongLength, lastProgress.BytesTransferred, "Final progress has unexpected value");
                }

                // Assert
                var downloadResponse = await file.DownloadAsync(range: new HttpRange(offset, data.LongLength));
                var actual = new MemoryStream();
                await downloadResponse.Value.Content.CopyToAsync(actual);
                Assert.AreEqual(data.Length, actual.Length);
                Assert.IsTrue(data.SequenceEqual(actual.GetBuffer()));
            }
        }

        [Test]
        [Category("Live")]
        public async Task ListHandles()
        {
            // Arrange
            using (TestHelper.GetNewFile(out var file))
            {
                // Act
                var response = await file.ListHandlesAsync(maxResults: 5);

                // Assert
                Assert.AreEqual(0, response.Value.Handles.Count());
                Assert.AreEqual(String.Empty, response.Value.NextMarker);
            }
        }

        [Test]
        [Category("Live")]
        public async Task ListHandles_Min()
        {
            // Arrange
            using (TestHelper.GetNewFile(out var file))
            {
                // Act
                var response = await file.ListHandlesAsync();

                // Assert
                Assert.AreEqual(0, response.Value.Handles.Count());
                Assert.AreEqual(String.Empty, response.Value.NextMarker);
            }
        }

        [Test]
        [Category("Live")]
        public async Task ListHandles_Error()
        {
            // Arrange
            using (TestHelper.GetNewDirectory(out var directory))
            {
                var file = directory.GetFileClient(TestHelper.GetNewDirectoryName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.ListHandlesAsync(),
                    actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));

            }
        }

        [Test]
        [Category("Live")]
        public async Task ForceCloseHandles_Min()
        {
            // Arrange
            using (TestHelper.GetNewFile(out var file))
            {
                // Act
                var response = await file.ForceCloseHandlesAsync();

                // Assert
                Assert.AreEqual(0, response.Value.NumberOfHandlesClosed);
            }
        }

        [Test]
        [Category("Live")]
        public async Task ForceCloseHandles_Error()
        {
            // Arrange
            using (TestHelper.GetNewDirectory(out var directory))
            {
                var file = directory.GetFileClient(TestHelper.GetNewDirectoryName());

                // Act
                await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                    file.ForceCloseHandlesAsync(),
                    actualException => Assert.AreEqual("ResourceNotFound", actualException.ErrorCode));

            }
        }

        private async Task WaitForCopy(FileClient file, int milliWait = 200)
        {
            var status = CopyStatus.Pending;
            var start = DateTimeOffset.Now;
            while (status != CopyStatus.Success)
            {
                status = (await file.GetPropertiesAsync()).Value.CopyStatus;
                var currentTime = DateTimeOffset.Now;
                if (status == CopyStatus.Failed || currentTime.AddMinutes(-1) > start)
                {
                    throw new Exception("Copy failed or took too long");
                }
                await Task.Delay(milliWait);
            }
        }
    }
}
