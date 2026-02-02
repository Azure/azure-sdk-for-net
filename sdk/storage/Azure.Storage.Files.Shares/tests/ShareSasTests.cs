// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class ShareSasTests : FileTestBase
    {
        public ShareSasTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Create ServiceClient with Custom Account SAS without invoking other clients
        /// </summary>
        private ShareServiceClient GetShareServiceClientWithCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            return InstrumentClient(new ShareServiceClient(uriBuilder.Uri, GetOptions()));
        }

        /// <summary>
        /// Create ShareClient with Custom Account SAS without invoking other clients
        /// </summary>
        private ShareClient GetShareClientWithCustomAccountSas(
            ShareClient shareClient,
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            UriBuilder blobUriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Path = shareClient.Name,
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            return InstrumentClient(new ShareClient(blobUriBuilder.Uri, GetOptions()));
        }

        /// <summary>
        /// Create ShareDirectoryClient with Custom Account SAS without invoking other clients.
        ///
        /// This will not create the directory tree if a nested directory name/path is provided
        /// </summary>
        private async Task<ShareDirectoryClient> GetDirectoryClientWithCustomAccountSas(
            ShareClient shareClient,
            string directoryName = default,
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            directoryName = directoryName ?? GetNewDirectoryName();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(shareClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            uriBuilder.Path += $"/{directoryName}";

            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(uriBuilder.Uri, GetOptions()));
            await directoryClient.CreateAsync();

            return directoryClient;
        }

        /// <summary>
        /// Create ShareDirectoryClient with Custom Account SAS without invoking other clients.
        ///
        /// This will not create the directory tree if a nested directory name/path is provided.
        /// This will at most create one directory parent for the file.
        /// </summary>
        private async Task<ShareFileClient> GetFileClientWithCustomAccountSas(
            ShareClient shareClient,
            string directoryName = default,
            string fileName = default,
            string permissions = default,
            string services = default,
            string resourceType = default,
            long fileSize = Constants.KB)
        {
            directoryName = directoryName ?? GetNewDirectoryName();

            ShareDirectoryClient directoryClient = await shareClient.CreateDirectoryAsync(directoryName);

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(directoryClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            fileName ??= GetNewFileName();
            uriBuilder.Path += $"/{fileName}";

            ShareFileClient fileClient = InstrumentClient(new ShareFileClient(uriBuilder.Uri, GetOptions()));
            await fileClient.CreateAsync(fileSize);

            return fileClient;
        }

        // Creating client with Uri with SAS token, not using GetFileClient
        #region CreateClientRaw
        private async Task InvokeAccountSasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string directoryName = GetNewDirectoryName();
            string fileName = GetNewFileName();
            ShareDirectoryClient directory = InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            await directory.CreateAsync().ConfigureAwait(false);
            ShareFileClient file = directory.GetFileClient(fileName);
            await file.CreateAsync(Constants.MB).ConfigureAwait(false);

            string sasQueryParams = GetCustomAccountSas(
                permissions:permissions,
                services:services,
                resourceType: resourceType);
            UriBuilder uriBuilder = new UriBuilder(file.Uri)
            {
                Query = sasQueryParams
            };

            // Assert
            ShareFileClient sasFileClient = InstrumentClient(new ShareFileClient(uriBuilder.Uri, GetOptions()));
            Assert.AreEqual("?" + sasQueryParams, sasFileClient.Uri.Query);
            await sasFileClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [TestCase("sco")]
        [TestCase("soc")]
        [TestCase("cos")]
        [TestCase("ocs")]
        [TestCase("os")]
        [TestCase("oc")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ResourceTypeOrder(string resourceType)
        {
            await InvokeAccountSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        [TestCase("bfqt")]
        [TestCase("qftb")]
        [TestCase("tqfb")]
        [TestCase("fqt")]
        [TestCase("qf")]
        [TestCase("fb")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ServiceOrder(string services)
        {
            await InvokeAccountSasTest(services: services);
        }
        #endregion

        // Creating Client from GetStorageClient
        #region ShareServiceClient
        private async Task InvokeAccountSasServiceToShareTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            ShareServiceClient serviceClient = GetShareServiceClientWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareClient shareClient = serviceClient.GetShareClient(GetNewShareName());

            // Assert
            Assert.AreEqual(serviceClient.Uri.Query, shareClient.Uri.Query);
            await shareClient.CreateAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ServiceToShare()
        {
            string resourceType = "soc";
            await InvokeAccountSasServiceToShareTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ServiceToShare()
        {
            string services = "tfb";
            await InvokeAccountSasServiceToShareTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ServiceToShare()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasServiceToShareTest(permissions: permissions);
        }
        #endregion

        #region ShareClient
        private async Task InvokeAccountSasShareToServiceTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient shareClient = GetShareClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareServiceClient serviceClient = shareClient.GetParentServiceClient();

            // Assert
            Assert.AreEqual(shareClient.Uri.Query, serviceClient.Uri.Query);
            await serviceClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ShareToService()
        {
            string resourceType = "soc";
            await InvokeAccountSasShareToServiceTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ShareToService()
        {
            string services = "tfb";
            await InvokeAccountSasShareToServiceTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ShareToService()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasShareToServiceTest(permissions: permissions);
        }

        private async Task InvokeAccountSasShareToLeaseTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient shareClient = GetShareClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareLeaseClient leaseClient = shareClient.GetShareLeaseClient(Recording.Random.NewGuid().ToString());

            // Assert
            Assert.AreEqual(shareClient.Uri.Query, leaseClient.Uri.Query);
            await leaseClient.AcquireAsync();
            await leaseClient.BreakAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ShareToLease()
        {
            string resourceType = "soc";
            await InvokeAccountSasShareToLeaseTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ShareToLease()
        {
            string services = "tfb";
            await InvokeAccountSasShareToLeaseTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ShareToLease()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasShareToLeaseTest(permissions: permissions);
        }

        private async Task InvokeAccountSasShareToSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient shareClient = GetShareClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);
            Response<ShareSnapshotInfo> createSnapshotResponse = await shareClient.CreateSnapshotAsync();

            // Act
            ShareClient snapshotShareClient = shareClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // Trim the ? at the beginning
            string snapshotSasToken = shareClient.Uri.Query.Substring(1);
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotShareClient.Uri.Query.EndsWith(snapshotSasToken));
            await snapshotShareClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ShareToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasShareToSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ShareToSnapshot()
        {
            string services = "tfb";
            await InvokeAccountSasShareToSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ShareToSnapshot()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasShareToSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasShareToRootDirectoryTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient shareClient = GetShareClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareDirectoryClient directoryClient = shareClient.GetRootDirectoryClient();

            // Assert
            Assert.AreEqual(shareClient.Uri.Query, directoryClient.Uri.Query);
            await directoryClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ShareToRootDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountSasShareToRootDirectoryTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ShareToRootDirectory()
        {
            string services = "tfb";
            await InvokeAccountSasShareToRootDirectoryTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ShareToRootDirectory()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasShareToRootDirectoryTest(permissions: permissions);
        }

        private async Task InvokeAccountSasShareToDirectoryTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareClient shareClient = GetShareClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareDirectoryClient directoryClient = shareClient.GetDirectoryClient(GetNewDirectoryName());

            // Assert
            Assert.AreEqual(shareClient.Uri.Query, directoryClient.Uri.Query);
            await directoryClient.CreateAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ShareToDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountSasShareToDirectoryTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ShareToDirectory()
        {
            string services = "tfb";
            await InvokeAccountSasShareToDirectoryTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ShareToDirectory()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasShareToDirectoryTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string directoryName = GetNewDirectoryName();
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = await test.Share.CreateDirectoryAsync(directoryName);

            Response<ShareSnapshotInfo> createSnapshotResponse = await test.Share.CreateSnapshotAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(directoryClient.Uri)
            {
                Query = sasToken
            };

            ShareDirectoryClient sasDirectoryClient = InstrumentClient(new ShareDirectoryClient(uriBuilder.Uri, GetOptions()));

            // Act
            ShareDirectoryClient snapshotDirectoryClient = sasDirectoryClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // Trim the ? at the beginning
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotDirectoryClient.Uri.Query.EndsWith(sasToken));
            await snapshotDirectoryClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_DirectoryToSnapshot()
        {
            string services = "tfb";
            await InvokeAccountSasDirectoryToSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToSnapshot()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasDirectoryToSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToFileTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = await GetDirectoryClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareFileClient fileClient = directoryClient.GetFileClient(GetNewFileName());

            // Assert
            Assert.AreEqual(directoryClient.Uri.Query, fileClient.Uri.Query);
            await fileClient.CreateAsync(Constants.MB);
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToFile()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToFileTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_DirectoryToFile()
        {
            string services = "tfb";
            await InvokeAccountSasDirectoryToFileTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToFile()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasDirectoryToFileTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToSubDirectoryTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = await GetDirectoryClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareDirectoryClient subdirectoryClient = directoryClient.GetSubdirectoryClient(GetNewDirectoryName());

            // Assert
            Assert.AreEqual(directoryClient.Uri.Query, subdirectoryClient.Uri.Query);
            await subdirectoryClient.CreateAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToSubDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToSubDirectoryTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_DirectoryToSubDirectory()
        {
            string services = "tfb";
            await InvokeAccountSasDirectoryToSubDirectoryTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToSubDirectory()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasDirectoryToSubDirectoryTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToParentDirectoryTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            string parentDirectoryName = GetNewDirectoryName();
            await test.Share.CreateDirectoryAsync(parentDirectoryName);

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(test.Share.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            uriBuilder.Path += $"/{parentDirectoryName}/{GetNewDirectoryName()}";

            ShareDirectoryClient directoryClient = InstrumentClient(new ShareDirectoryClient(uriBuilder.Uri, GetOptions()));

            // Act
            ShareDirectoryClient parentDirectoryClient = directoryClient.GetParentDirectoryClient();

            // Assert
            Assert.AreEqual(directoryClient.Uri.Query, parentDirectoryClient.Uri.Query);
            await parentDirectoryClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToParentDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToParentDirectoryTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_DirectoryToParentDirectory()
        {
            string services = "tfb";
            await InvokeAccountSasDirectoryToParentDirectoryTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToParentDirectory()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasDirectoryToParentDirectoryTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToShareTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareDirectoryClient directoryClient = await GetDirectoryClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareClient shareClient = directoryClient.GetParentShareClient();

            // Assert
            Assert.AreEqual(directoryClient.Uri.Query, shareClient.Uri.Query);
            await shareClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToShare()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToShareTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_DirectoryToShare()
        {
            string services = "tfb";
            await InvokeAccountSasDirectoryToShareTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToShare()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasDirectoryToShareTest(permissions: permissions);
        }

        private async Task InvokeAccountSasFileToSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string fileName = GetNewFileName();
            await using DisposingShare test = await GetTestShareAsync();
            ShareFileClient fileClient = await test.Share.GetRootDirectoryClient().CreateFileAsync(fileName, Constants.MB);
            Response<ShareSnapshotInfo> createSnapshotResponse = await test.Share.CreateSnapshotAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(fileClient.Uri)
            {
                Query = sasToken
            };

            ShareFileClient sasFileClient = InstrumentClient(new ShareFileClient(uriBuilder.Uri, GetOptions()));

            // Act
            ShareFileClient snapshotFileClient = sasFileClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotFileClient.Uri.Query.EndsWith(sasToken));
            await snapshotFileClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileToSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileToSnapshot()
        {
            string services = "tfb";
            await InvokeAccountSasFileToSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileToSnapshot()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasFileToSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasFileToShareTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareFileClient fileClient = await GetFileClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareClient shareClient = fileClient.GetParentShareClient();

            // Assert
            Assert.AreEqual(fileClient.Uri.Query, shareClient.Uri.Query);
            await shareClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileToShare()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileToShareTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileToShare()
        {
            string services = "tfb";
            await InvokeAccountSasFileToShareTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileToShare()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasFileToShareTest(permissions: permissions);
        }

        private async Task InvokeAccountSasFileToDirectoryTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareFileClient fileClient = await GetFileClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareDirectoryClient directoryClient = fileClient.GetParentShareDirectoryClient();

            // Assert
            Assert.AreEqual(fileClient.Uri.Query, directoryClient.Uri.Query);
            await directoryClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileToDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileToDirectoryTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileToDirectory()
        {
            string services = "tfb";
            await InvokeAccountSasFileToDirectoryTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileToDirectory()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasFileToDirectoryTest(permissions: permissions);
        }

        private async Task InvokeAccountSasFileToLeaseTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareFileClient shareFileClient = await GetFileClientWithCustomAccountSas(
                shareClient: test.Share,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            ShareLeaseClient leaseClient = shareFileClient.GetShareLeaseClient(Recording.Random.NewGuid().ToString());

            // Assert
            Assert.AreEqual(shareFileClient.Uri.Query, leaseClient.Uri.Query);
            await leaseClient.AcquireAsync();
            await leaseClient.BreakAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileToLease()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileToLeaseTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileToLease()
        {
            string services = "tfb";
            await InvokeAccountSasFileToLeaseTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileToLease()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountSasFileToLeaseTest(permissions: permissions);
        }
        #endregion

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ShareClient_GetUserDelegationSAS()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            ShareGetUserDelegationKeyOptions getUserDelegationKeyOptions = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            Uri sasUri = share.GenerateUserDelegationSasUri(
                ShareSasPermissions.All,
                expiresOn: Recording.UtcNow.AddHours(1),
                userDelegationKeyResponse.Value,
                out string stringToSign);
            ShareClientOptions options = GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareClient sasShare = InstrumentClient(new ShareClient(sasUri, options));

            // Act
            await sasShare.CreateDirectoryAsync(GetNewDirectoryName());

            // Assert
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ShareClient_GetUserDelegationSAS_Builder()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            ShareGetUserDelegationKeyOptions getUserDelegationKeyOptions = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            ShareSasBuilder builder = new ShareSasBuilder(
                permissions: ShareSasPermissions.All,
                expiresOn: Recording.UtcNow.AddHours(1));

            Uri sasUri = share.GenerateUserDelegationSasUri(builder, userDelegationKeyResponse.Value, out string stringToSign);
            ShareClientOptions options = GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareClient sasShare = InstrumentClient(new ShareClient(sasUri, options));

            // Act
            await sasShare.CreateDirectoryAsync(GetNewDirectoryName());

            // Assert
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task FileClient_GetUserDelegationSAS()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(service);
            ShareFileClient file = test.File;

            ShareGetUserDelegationKeyOptions getUserDelegationKeyOptions = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            Uri sasUri = file.GenerateUserDelegationSasUri(
                ShareFileSasPermissions.All,
                expiresOn: Recording.UtcNow.AddHours(1),
                userDelegationKeyResponse.Value,
                out string stringToSign);
            ShareClientOptions options = GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareFileClient sasFile = InstrumentClient(new ShareFileClient(sasUri, options));

            // Act
            await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task FileClient_GetUserDelegationSAS_Builder()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingFile test = await SharesClientBuilder.GetTestFileAsync(service);
            ShareFileClient file = test.File;

            ShareGetUserDelegationKeyOptions getUserDelegationKeyOptions = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            ShareSasBuilder builder = new ShareSasBuilder(
                permissions: ShareFileSasPermissions.All,
                expiresOn: Recording.UtcNow.AddHours(1));

            Uri sasUri = file.GenerateUserDelegationSasUri(
                builder,
                userDelegationKeyResponse.Value,
                out string stringToSign);
            ShareClientOptions options = GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareFileClient sasFile = InstrumentClient(new ShareFileClient(sasUri, options));

            // Act
            await sasFile.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_04_06)]
        public async Task ShareClient_UserDelegationSas_DelegatedTenantId()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            ShareGetUserDelegationKeyOptions options = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await service.GetUserDelegationKeyAsync(
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions: ShareSasPermissions.All, expiresOn: Recording.UtcNow.AddHours(1))
            {
                ShareName = share.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            ShareSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(userDelegationKey.Value, service.AccountName);

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(share.Uri)
            {
                Sas = sasQueryParameters
            };

            ShareClientOptions clientOptions = GetOptions();
            clientOptions.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareClient sasShare = InstrumentClient(new ShareClient(shareUriBuilder.ToUri(), TestEnvironment.Credential, clientOptions));

            // Act
            Response<ShareDirectoryClient> response = await sasShare.CreateDirectoryAsync(GetNewDirectoryName());

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_04_06)]
        public async Task ShareClient_UserDelegationSas_DelegatedTenantId_Fail()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            ShareGetUserDelegationKeyOptions options = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await service.GetUserDelegationKeyAsync(
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions: ShareSasPermissions.Read, expiresOn: Recording.UtcNow.AddHours(1))
            {
                ShareName = share.Name,
                // We are deliberately not passing in DelegatedUserObjectId to cause an auth failure
            };

            ShareSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(userDelegationKey.Value, service.AccountName);

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(share.Uri)
            {
                Sas = sasQueryParameters
            };

            ShareClient sasShare = InstrumentClient(new ShareClient(shareUriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act & Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasShare.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        [LiveOnly]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_04_06)]
        public async Task ShareClient_UserDelegationSas_DelegatedTenantId_Roundtrip()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            ShareGetUserDelegationKeyOptions options = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await service.GetUserDelegationKeyAsync(
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            ShareSasBuilder sasBuilder = new ShareSasBuilder(permissions: ShareSasPermissions.Read, expiresOn: Recording.UtcNow.AddHours(1))
            {
                ShareName = share.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            ShareSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(userDelegationKey.Value, service.AccountName);

            ShareUriBuilder originalShareUriBuilder = new ShareUriBuilder(share.Uri)
            {
                Sas = sasQueryParameters
            };

            ShareUriBuilder roundtripShareUriBuilder = new ShareUriBuilder(originalShareUriBuilder.ToUri());

            Assert.AreEqual(originalShareUriBuilder.ToUri(), roundtripShareUriBuilder.ToUri());
            Assert.AreEqual(originalShareUriBuilder.Sas.ToString(), roundtripShareUriBuilder.Sas.ToString());
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ShareClient_UserDelegationSas_DelegatedObjectId()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            ShareGetUserDelegationKeyOptions getUserDelegationKeyOptions = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            ShareSasBuilder sasBuilder = new ShareSasBuilder(
                permissions: ShareSasPermissions.All,
                expiresOn: Recording.UtcNow.AddHours(1))
            {
                ShareName = share.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            ShareSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(userDelegationKeyResponse.Value, service.AccountName);

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(share.Uri)
            {
                Sas = sasQueryParameters
            };

            Uri sasUri = shareUriBuilder.ToUri();

            ShareClientOptions options = GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareClient sasShare = InstrumentClient(new ShareClient(sasUri, TestEnvironment.Credential, options));

            // Act
            await sasShare.CreateDirectoryAsync(GetNewDirectoryName());
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ShareClient_UserDelegationSas_DelegatedObjectId_Fail()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            ShareGetUserDelegationKeyOptions getUserDelegationKeyOptions = new ShareGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            ShareSasBuilder sasBuilder = new ShareSasBuilder(
                permissions: ShareSasPermissions.All,
                expiresOn: Recording.UtcNow.AddHours(1))
            {
                ShareName = share.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            ShareSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(userDelegationKeyResponse.Value, service.AccountName);

            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(share.Uri)
            {
                Sas = sasQueryParameters
            };

            Uri sasUri = shareUriBuilder.ToUri();

            ShareClientOptions options = GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;

            // We are deliberately not using the token credential to cause an auth failure
            ShareClient sasShare = InstrumentClient(new ShareClient(sasUri, options));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasShare.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }
    }
}
