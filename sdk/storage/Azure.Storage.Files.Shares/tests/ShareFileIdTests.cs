// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class ShareFileIdTests : FileTestBase
    {
        private const string FileId = "12384898975283830";
        private const string ShareUriString = "https://account.file.core.windows.net/share";

        public ShareFileIdTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private ShareClient GetShareClient()
            => new ShareClient(new Uri(ShareUriString), GetOptions());

        private ShareFileClient GetFileIdFileClient()
            => GetShareClient().GetFileClientByFileId(FileId);

        private ShareDirectoryClient GetFileIdDirectoryClient()
            => GetShareClient().GetDirectoryClientByFileId(FileId);

        [RecordedTest]
        public void GetFileClientByFileId_Uri()
        {
            ShareFileClient fileClient = GetFileIdFileClient();

            Assert.AreEqual($"{ShareUriString}?fileid={FileId}", fileClient.Uri.AbsoluteUri);
            Assert.AreEqual("share", fileClient.ShareName);
            Assert.AreEqual(FileId, fileClient.FileId);

            ShareUriBuilder builder = new ShareUriBuilder(fileClient.Uri);
            Assert.AreEqual(FileId, builder.FileId);
            Assert.AreEqual(string.Empty, builder.DirectoryOrFilePath);
        }

        [RecordedTest]
        public void GetDirectoryClientByFileId_Uri()
        {
            ShareDirectoryClient directoryClient = GetFileIdDirectoryClient();

            Assert.AreEqual($"{ShareUriString}?fileid={FileId}", directoryClient.Uri.AbsoluteUri);
            Assert.AreEqual("share", directoryClient.ShareName);
            Assert.AreEqual(FileId, directoryClient.FileId);

            ShareUriBuilder builder = new ShareUriBuilder(directoryClient.Uri);
            Assert.AreEqual(FileId, builder.FileId);
            Assert.AreEqual(string.Empty, builder.DirectoryOrFilePath);
        }

        [RecordedTest]
        public void GetFileClientByFileId_InvalidFileId()
        {
            ShareClient shareClient = GetShareClient();

            Assert.Throws<ArgumentNullException>(() => shareClient.GetFileClientByFileId(null));
            Assert.Throws<ArgumentException>(() => shareClient.GetFileClientByFileId(string.Empty));
            Assert.Throws<ArgumentNullException>(() => shareClient.GetDirectoryClientByFileId(null));
            Assert.Throws<ArgumentException>(() => shareClient.GetDirectoryClientByFileId(string.Empty));
        }

        [RecordedTest]
        public void GetFileClientByFileId_PreservesShareSnapshot()
        {
            ShareClient shareClient = new ShareClient(
                new Uri($"{ShareUriString}?sharesnapshot=2011-03-09T01:42:34.9360000Z"),
                GetOptions());

            ShareFileClient fileClient = shareClient.GetFileClientByFileId(FileId);

            ShareUriBuilder builder = new ShareUriBuilder(fileClient.Uri);
            Assert.AreEqual(FileId, builder.FileId);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", builder.Snapshot);
        }

        [RecordedTest]
        public void Ctor_FileIdUri_IsFileIdAddressed()
        {
            // A Uri that already contains a file ID produces a file ID addressed
            // client, even when passed to the path based constructors.
            ShareFileClient fileClient = new ShareFileClient(
                new Uri($"{ShareUriString}?fileid={FileId}"),
                GetOptions());

            Assert.IsEmpty(fileClient.Name);
            Assert.IsEmpty(fileClient.Path);
            Assert.AreEqual(FileId, fileClient.FileId);
        }

        [RecordedTest]
        public void FileId_IsEmpty_ForPathAddressedClient()
        {
            ShareFileClient fileClient = new ShareFileClient(
                new Uri($"{ShareUriString}/directory/file"),
                GetOptions());
            ShareDirectoryClient directoryClient = new ShareDirectoryClient(
                new Uri($"{ShareUriString}/directory"),
                GetOptions());

            Assert.IsEmpty(fileClient.FileId);
            Assert.IsEmpty(directoryClient.FileId);

            // The path based members keep working.
            Assert.AreEqual("file", fileClient.Name);
            Assert.AreEqual("directory", directoryClient.Name);
        }

        [RecordedTest]
        public void WithSnapshot_PreservesFileId()
        {
            ShareFileClient fileClient = GetFileIdFileClient()
                .WithSnapshot("2011-03-09T01:42:34.9360000Z");

            ShareUriBuilder builder = new ShareUriBuilder(fileClient.Uri);
            Assert.AreEqual(FileId, builder.FileId);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", builder.Snapshot);

            // The derived client is still file ID addressed.
            Assert.AreEqual(FileId, fileClient.FileId);
            Assert.IsEmpty(fileClient.Path);
        }

        [RecordedTest]
        public void FileClient_UnsupportedMembers_Throw()
        {
            ShareFileClient fileClient = GetFileIdFileClient();

            Assert.Throws<InvalidOperationException>(() => fileClient.GetParentShareDirectoryClient());
            Assert.Throws<InvalidOperationException>(
                () => fileClient.GenerateSasUri(ShareFileSasPermissions.Read, Recording.UtcNow.AddDays(1)));

            // Name and Path are not known when addressing by file ID, but they
            // return empty rather than throwing.
            Assert.IsEmpty(fileClient.Name);
            Assert.IsEmpty(fileClient.Path);

            // The share is still known, so these remain available.
            Assert.AreEqual("share", fileClient.ShareName);
            Assert.IsFalse(fileClient.CanGenerateSasUri);
            Assert.IsNotNull(fileClient.GetParentShareClient());
        }

        [RecordedTest]
        public void DirectoryClient_UnsupportedMembers_Throw()
        {
            ShareDirectoryClient directoryClient = GetFileIdDirectoryClient();

            Assert.Throws<InvalidOperationException>(() => directoryClient.GetFileClient("file"));
            Assert.Throws<InvalidOperationException>(() => directoryClient.GetSubdirectoryClient("subdirectory"));
            Assert.Throws<InvalidOperationException>(
                () => directoryClient.GenerateSasUri(ShareFileSasPermissions.Read, Recording.UtcNow.AddDays(1)));

            // Name and Path are not known when addressing by file ID, but they
            // return empty rather than throwing.
            Assert.IsEmpty(directoryClient.Name);
            Assert.IsEmpty(directoryClient.Path);

            Assert.AreEqual("share", directoryClient.ShareName);
            Assert.IsFalse(directoryClient.CanGenerateSasUri);
        }

        [RecordedTest]
        public async Task FileClient_UnsupportedOperations_Throw()
        {
            ShareFileClient fileClient = GetFileIdFileClient();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.CreateAsync(Constants.KB));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.DeleteAsync());
            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.ExistsAsync());
            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.DownloadAsync());
            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.GetRangeListAsync());
            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.SetMetadataAsync(default));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.RenameAsync("destination"));

            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task DirectoryClient_UnsupportedOperations_Throw()
        {
            ShareDirectoryClient directoryClient = GetFileIdDirectoryClient();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await directoryClient.CreateAsync());
            Assert.ThrowsAsync<InvalidOperationException>(async () => await directoryClient.DeleteAsync());
            Assert.ThrowsAsync<InvalidOperationException>(async () => await directoryClient.ExistsAsync());
            Assert.ThrowsAsync<InvalidOperationException>(async () => await directoryClient.SetMetadataAsync(default));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await directoryClient.RenameAsync("destination"));

            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task GetFileLinks_PathAddressedClient_Throws()
        {
            // GetFileLinks is only supported when the file is addressed by its
            // file ID.  The request should never be sent.
            ShareFileClient fileClient = new ShareFileClient(
                new Uri($"{ShareUriString}/directory/file"),
                GetOptions());

            Assert.ThrowsAsync<InvalidOperationException>(async () => await fileClient.GetFileLinksAsync());

            await Task.CompletedTask;
        }

        #region Live tests
        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetPropertiesAsync_ByFileId()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            Response<ShareFileProperties> pathProperties = await file.GetPropertiesAsync();
            string fileId = pathProperties.Value.SmbProperties.FileId;

            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId(fileId));

            // Act
            Response<ShareFileProperties> response = await fileIdClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileId, response.Value.SmbProperties.FileId);
            Assert.AreEqual(pathProperties.Value.SmbProperties.ParentId, response.Value.SmbProperties.ParentId);
            Assert.AreEqual(file.Name, response.Value.FileName);
            Assert.AreEqual(pathProperties.Value.ContentLength, response.Value.ContentLength);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetPropertiesAsync_ByFileId_Directory()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));

            Response<ShareDirectoryProperties> pathProperties = await directory.GetPropertiesAsync();
            string fileId = pathProperties.Value.SmbProperties.FileId;

            ShareDirectoryClient fileIdClient = InstrumentClient(test.Share.GetDirectoryClientByFileId(fileId));

            // Act
            Response<ShareDirectoryProperties> response = await fileIdClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileId, response.Value.SmbProperties.FileId);
            Assert.AreEqual(pathProperties.Value.SmbProperties.ParentId, response.Value.SmbProperties.ParentId);
            Assert.AreEqual(directory.Name, response.Value.FileName);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetPropertiesAsync_ByFileId_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId("11111111111111111111"));

            // Act / Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileIdClient.GetPropertiesAsync(),
                e => Assert.IsNotNull(e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetFileLinksAsync()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            Response<ShareFileProperties> pathProperties = await file.GetPropertiesAsync();
            string fileId = pathProperties.Value.SmbProperties.FileId;

            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId(fileId));

            // Act
            Response<ShareFileLinks> response = await fileIdClient.GetFileLinksAsync();

            // Assert
            Assert.IsNotNull(response.Value.Properties);
            Assert.AreEqual(fileId, response.Value.Properties.SmbProperties.FileId);
            Assert.AreEqual(Constants.KB, response.Value.Properties.ContentLength);
            Assert.AreEqual("application/octet-stream", response.Value.Properties.ContentType);

            FileSmbProperties smbProperties = response.Value.Properties.SmbProperties;
            Assert.AreEqual(pathProperties.Value.SmbProperties.ParentId, smbProperties.ParentId);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileAttributes, smbProperties.FileAttributes);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FilePermissionKey, smbProperties.FilePermissionKey);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileCreatedOn, smbProperties.FileCreatedOn);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileLastWrittenOn, smbProperties.FileLastWrittenOn);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileChangedOn, smbProperties.FileChangedOn);

            Assert.IsNotNull(response.Value.Links);
            Assert.AreEqual(1, response.Value.Links.Count);
            Assert.AreEqual(file.Name, response.Value.Links[0].Name);
            Assert.AreEqual(pathProperties.Value.SmbProperties.ParentId, response.Value.Links[0].ParentId);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetFileLinksAsync_ContentHeaders()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            // Set every content property
            await file.SetHttpHeadersAsync(new ShareFileSetHttpHeadersOptions
            {
                HttpHeaders = new ShareFileHttpHeaders
                {
                    CacheControl = constants.CacheControl,
                    ContentDisposition = constants.ContentDisposition,
                    ContentEncoding = new string[] { constants.ContentEncoding },
                    ContentLanguage = new string[] { constants.ContentLanguage },
                    ContentHash = constants.ContentMD5,
                    ContentType = constants.ContentType
                }
            });

            Response<ShareFileProperties> pathProperties = await file.GetPropertiesAsync();
            string fileId = pathProperties.Value.SmbProperties.FileId;
            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId(fileId));

            // Act
            Response<ShareFileLinks> response = await fileIdClient.GetFileLinksAsync();

            // Assert
            Assert.AreEqual(constants.CacheControl, response.Value.Properties.CacheControl);
            Assert.AreEqual(constants.ContentDisposition, response.Value.Properties.ContentDisposition);
            TestHelper.AssertSequenceEqual(constants.ContentMD5, response.Value.Properties.ContentHash);
            Assert.AreEqual(1, response.Value.Properties.ContentEncoding.Count());
            Assert.AreEqual(constants.ContentEncoding, response.Value.Properties.ContentEncoding.First());
            Assert.AreEqual(1, response.Value.Properties.ContentLanguage.Count());
            Assert.AreEqual(constants.ContentLanguage, response.Value.Properties.ContentLanguage.First());

            FileSmbProperties smbProperties = response.Value.Properties.SmbProperties;
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileAttributes, smbProperties.FileAttributes);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FilePermissionKey, smbProperties.FilePermissionKey);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileCreatedOn, smbProperties.FileCreatedOn);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileLastWrittenOn, smbProperties.FileLastWrittenOn);
            Assert.AreEqual(pathProperties.Value.SmbProperties.FileChangedOn, smbProperties.FileChangedOn);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetFileLinksAsync_Encoded()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));

            // \uFFFE cannot be represented in XML, so the service percent-encodes the
            // FileName element and marks it with Encoded="true".
            string specialCharFileName = $"{GetNewFileName()}\uFFFE";
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(specialCharFileName, maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;
            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId(fileId));

            // Act
            Response<ShareFileLinks> response = await fileIdClient.GetFileLinksAsync();

            // Assert
            Assert.AreEqual(1, response.Value.Links.Count);
            Assert.AreEqual(specialCharFileName, response.Value.Links[0].Name);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetFileLinksAsync_ShareSnapshot()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;

            Response<ShareSnapshotInfo> snapshotResponse = await test.Share.CreateSnapshotAsync();
            ShareClient snapshotShare = InstrumentClient(test.Share.WithSnapshot(snapshotResponse.Value.Snapshot));

            ShareFileClient fileIdClient = InstrumentClient(snapshotShare.GetFileClientByFileId(fileId));

            // Act
            Response<ShareFileLinks> response = await fileIdClient.GetFileLinksAsync();

            // Assert
            Assert.IsNotNull(response.Value.Properties);
            Assert.AreEqual(1, response.Value.Links.Count);
            Assert.AreEqual(file.Name, response.Value.Links[0].Name);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetFileLinksAsync_Lease()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;

            ShareLeaseClient leaseClient = InstrumentClient(file.GetShareLeaseClient(Recording.Random.NewGuid().ToString()));
            ShareFileLease lease = await leaseClient.AcquireAsync();

            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId(fileId));

            try
            {
                // Act
                Response<ShareFileLinks> response = await fileIdClient.GetFileLinksAsync(
                    conditions: new ShareFileRequestConditions { LeaseId = lease.LeaseId });

                // Assert
                Assert.AreEqual(1, response.Value.Links.Count);
            }
            finally
            {
                await leaseClient.ReleaseAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetFileLinksAsync_Error()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId("11111111111111111111"));

            // Act / Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileIdClient.GetFileLinksAsync(),
                e => Assert.IsNotNull(e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task GetFileLinksAsync_OAuth()
        {
            // Arrange
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync(service: oauthServiceClient);

            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;

            ShareFileClient fileIdClient = InstrumentClient(test.Share.GetFileClientByFileId(fileId));

            // Act
            Response<ShareFileLinks> response = await fileIdClient.GetFileLinksAsync();

            // Assert
            Assert.AreEqual(1, response.Value.Links.Count);
            Assert.AreEqual(file.Name, response.Value.Links[0].Name);
        }
        #endregion

        #region Constructor tests
        /// <summary>
        /// Builds the file ID addressed Uri of a resource without going through
        /// the <see cref="ShareClient"/> navigation methods, so that the
        /// constructors can be exercised directly.
        /// </summary>
        private static Uri GetFileIdUri(ShareClient share, string fileId)
            => new ShareUriBuilder(share.Uri)
            {
                DirectoryOrFilePath = null,
                FileId = fileId
            }.ToUri();

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task Ctor_SharedKey_ByFileId()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;
            string directoryId = (await directory.GetPropertiesAsync()).Value.SmbProperties.FileId;

            // Act
            ShareFileClient fileIdClient = InstrumentClient(new ShareFileClient(
                GetFileIdUri(test.Share, fileId),
                Tenants.GetNewSharedKeyCredentials(),
                GetOptions()));
            ShareDirectoryClient directoryIdClient = InstrumentClient(new ShareDirectoryClient(
                GetFileIdUri(test.Share, directoryId),
                Tenants.GetNewSharedKeyCredentials(),
                GetOptions()));

            // Assert
            Response<ShareFileProperties> fileProperties = await fileIdClient.GetPropertiesAsync();
            Assert.AreEqual(fileId, fileProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(file.Name, fileProperties.Value.FileName);

            Response<ShareDirectoryProperties> directoryProperties = await directoryIdClient.GetPropertiesAsync();
            Assert.AreEqual(directoryId, directoryProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(directory.Name, directoryProperties.Value.FileName);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task Ctor_TokenCredential_ByFileId()
        {
            // Arrange
            ShareServiceClient oauthServiceClient = GetServiceClient_OAuth();
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync(service: oauthServiceClient);

            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;
            string directoryId = (await directory.GetPropertiesAsync()).Value.SmbProperties.FileId;

            ShareClientOptions options = GetOptionsWithAudience(ShareAudience.DefaultAudience);

            // Act
            ShareFileClient fileIdClient = InstrumentClient(new ShareFileClient(
                GetFileIdUri(test.Share, fileId),
                TestEnvironment.Credential,
                options));
            ShareDirectoryClient directoryIdClient = InstrumentClient(new ShareDirectoryClient(
                GetFileIdUri(test.Share, directoryId),
                TestEnvironment.Credential,
                options));

            // Assert
            Response<ShareFileProperties> fileProperties = await fileIdClient.GetPropertiesAsync();
            Assert.AreEqual(fileId, fileProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(file.Name, fileProperties.Value.FileName);

            Response<ShareDirectoryProperties> directoryProperties = await directoryIdClient.GetPropertiesAsync();
            Assert.AreEqual(directoryId, directoryProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(directory.Name, directoryProperties.Value.FileName);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task Ctor_AzureSasCredential_ByFileId()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;
            string directoryId = (await directory.GetPropertiesAsync()).Value.SmbProperties.FileId;

            // A file ID addressed request has no path to sign, so a share level
            // SAS is used.
            string sas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();

            // Act
            ShareFileClient fileIdClient = InstrumentClient(new ShareFileClient(
                GetFileIdUri(test.Share, fileId),
                new AzureSasCredential(sas),
                GetOptions()));
            ShareDirectoryClient directoryIdClient = InstrumentClient(new ShareDirectoryClient(
                GetFileIdUri(test.Share, directoryId),
                new AzureSasCredential(sas),
                GetOptions()));

            // Assert
            Response<ShareFileProperties> fileProperties = await fileIdClient.GetPropertiesAsync();
            Assert.AreEqual(fileId, fileProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(file.Name, fileProperties.Value.FileName);

            Response<ShareDirectoryProperties> directoryProperties = await directoryIdClient.GetPropertiesAsync();
            Assert.AreEqual(directoryId, directoryProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(directory.Name, directoryProperties.Value.FileName);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task Ctor_SasInUri_ByFileId()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;

            string sas = GetNewFileServiceSasCredentialsShare(test.Share.Name).ToString();
            Uri fileIdUriWithSas = new ShareUriBuilder(test.Share.Uri)
            {
                DirectoryOrFilePath = null,
                FileId = fileId,
                Query = sas
            }.ToUri();

            // Act
            ShareFileClient fileIdClient = InstrumentClient(new ShareFileClient(fileIdUriWithSas, GetOptions()));

            // Assert
            Response<ShareFileProperties> response = await fileIdClient.GetPropertiesAsync();
            Assert.AreEqual(fileId, response.Value.SmbProperties.FileId);
            Assert.AreEqual(file.Name, response.Value.FileName);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2027_03_07)]
        public async Task Ctor_ConnectionString_ByFileId()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directory = InstrumentClient(
                await test.Share.GetRootDirectoryClient().CreateSubdirectoryAsync(GetNewDirectoryName()));
            ShareFileClient file = InstrumentClient(
                await directory.CreateFileAsync(GetNewFileName(), maxSize: Constants.KB));

            string fileId = (await file.GetPropertiesAsync()).Value.SmbProperties.FileId;
            string directoryId = (await directory.GetPropertiesAsync()).Value.SmbProperties.FileId;

            StorageConnectionString connectionString = new StorageConnectionString(
                Tenants.GetNewSharedKeyCredentials(),
                fileStorageUri: (
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    new Uri(TestConfigDefault.FileServiceSecondaryEndpoint)));

            ShareClient shareClient = InstrumentClient(new ShareClient(
                connectionString.ToString(exportSecrets: true),
                test.Share.Name,
                GetOptions()));

            // Act
            ShareFileClient fileIdClient = InstrumentClient(shareClient.GetFileClientByFileId(fileId));
            ShareDirectoryClient directoryIdClient = InstrumentClient(shareClient.GetDirectoryClientByFileId(directoryId));

            // Assert
            Response<ShareFileProperties> fileProperties = await fileIdClient.GetPropertiesAsync();
            Assert.AreEqual(fileId, fileProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(file.Name, fileProperties.Value.FileName);

            Response<ShareDirectoryProperties> directoryProperties = await directoryIdClient.GetPropertiesAsync();
            Assert.AreEqual(directoryId, directoryProperties.Value.SmbProperties.FileId);
            Assert.AreEqual(directory.Name, directoryProperties.Value.FileName);
        }
        #endregion
    }
}
