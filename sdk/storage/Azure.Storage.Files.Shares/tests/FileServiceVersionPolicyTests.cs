// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
{
    public class FileServiceVersionPolicyTests : FileTestBase
    {
        public FileServiceVersionPolicyTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task FileLeaseTest()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            string fileName = GetNewFileName();
            ShareFileClient fileClient = InstrumentClient(test.Directory.GetFileClient(fileName));
            await fileClient.CreateAsync(1024);

            ShareClientOptions shareClientOptions = GetOptions(ShareClientOptions.ServiceVersion.V2019_02_02);
            ShareFileClient oldVersionFileClient = InstrumentClient(new ShareFileClient(fileClient.Uri, shareClientOptions));
            FileLeaseClient fileLeaseClient = InstrumentClient(oldVersionFileClient.GetFileLeaseClient(Recording.Random.NewGuid().ToString()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                fileLeaseClient.AcquireAsync(),
                e => Assert.AreEqual("x-ms-lease-duration is not supported for any file API in service version 2019-02-02", e.Message));
        }

        [Test]
        public async Task FileCopyTest()
        {
            // Arrange
            await using DisposingDirectory test = await GetTestDirectoryAsync();
            string fileName = GetNewFileName();
            ShareFileClient fileClient = InstrumentClient(test.Directory.GetFileClient(fileName));
            await fileClient.CreateAsync(1024);

            ShareClientOptions shareClientOptions = GetOptions(ShareClientOptions.ServiceVersion.V2019_02_02);
            ShareFileClient oldVersionFileClient = InstrumentClient(new ShareFileClient(fileClient.Uri, shareClientOptions));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, filePermission: "filePermission"),
                e => Assert.AreEqual("x-ms-file-permission is not supported for copy file in service version 2019-02-02", e.Message));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, filePermissionCopyMode: PermissionCopyModeType.Override),
                e => Assert.AreEqual("x-ms-file-permission-copy-mode is not supported for copy file in service version 2019-02-02", e.Message));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, ignoreReadOnly: true),
                e => Assert.AreEqual("x-ms-file-copy-ignore-read-only is not supported for copy file in service version 2019-02-02", e.Message));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, setArchiveAttribute: true),
                e => Assert.AreEqual("x-ms-file-copy-set-archive is not supported for copy file in service version 2019-02-02", e.Message));

            FileSmbProperties smbProperties = new FileSmbProperties
            {
                FilePermissionKey = "FilePermissionKey"
            };

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, smbProperties: smbProperties),
                e => Assert.AreEqual("x-ms-file-permission-key is not supported for copy file in service version 2019-02-02", e.Message));

            smbProperties.FilePermissionKey = null;
            smbProperties.FileAttributes = NtfsFileAttributes.Archive;

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, smbProperties: smbProperties),
                e => Assert.AreEqual("x-ms-file-attributes is not supported for copy file in service version 2019-02-02", e.Message));

            smbProperties.FileAttributes = null;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(2019, 8, 15, 5, 15, 25, 60, TimeSpan.Zero);
            smbProperties.FileCreatedOn = dateTimeOffset;

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, smbProperties: smbProperties),
                e => Assert.AreEqual("x-ms-file-creation-time is not supported for copy file in service version 2019-02-02", e.Message));

            smbProperties.FileCreatedOn = null;
            smbProperties.FileLastWrittenOn = dateTimeOffset;

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                oldVersionFileClient.StartCopyAsync(fileClient.Uri, smbProperties: smbProperties),
                e => Assert.AreEqual("x-ms-file-last-write-time is not supported for copy file in service version 2019-02-02", e.Message));
        }
    }
}
