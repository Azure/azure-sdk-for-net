﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeSasBuilderTests : DataLakeTestBase
    {
        public DataLakeSasBuilderTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private readonly DataLakeSasPermissions _sasPermissions = DataLakeSasPermissions.All;

        [Test]
        public void EnsureStateTests()
        {
            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder();

            // No Identifier, Permissions and ExpiresOn not present.
            TestHelper.AssertExpectedException(
                () => sasBuilder.EnsureState(),
                new InvalidOperationException("SAS is missing required parameter: Permissions"));

            sasBuilder.SetPermissions(_sasPermissions);

            // No Identifier, ExpiresOn not present.
            TestHelper.AssertExpectedException(
                () => sasBuilder.EnsureState(),
                new InvalidOperationException("SAS is missing required parameter: ExpiresOn"));
        }

        [Test]
        [TestCase("TLXDWCAR")]
        [TestCase("racwdxlt")]
        public async Task AccountPermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = AccountSasServices.Blobs,
                ResourceTypes = AccountSasResourceTypes.All
            };

            await test.FileSystem.GetPropertiesAsync();

            accountSasBuilder.SetPermissions(permissionsString);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigHierarchicalNamespace.AccountName, TestConfigHierarchicalNamespace.AccountKey);

            Uri uri = new Uri($"{test.FileSystem.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            DataLakeFileSystemClient sasFileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());

            // Act
            await sasFileSystemClient.GetPropertiesAsync();
        }

        [Test]
        public async Task AccountPermissionsRawPermissions_InvalidPermission()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = AccountSasServices.Blobs,
                ResourceTypes = AccountSasResourceTypes.All
            };

            // Act
            TestHelper.AssertExpectedException(
                () => accountSasBuilder.SetPermissions("werteyfg"),
                new ArgumentException("e is not a valid SAS permission"));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase("LDWCAR")]
        [TestCase("racwdl")]
        public async Task FileSystemPermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name
            };

            dataLakeSasBuilder.SetPermissions(
                rawPermissions: permissionsString,
                normalize: true);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigHierarchicalNamespace.AccountName, TestConfigHierarchicalNamespace.AccountKey);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            DataLakeFileSystemClient sasFileSystemClient = new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
        }


        [Test]
        public async Task FileSystemPermissionsRawPermissions_Invalid()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = test.FileSystem.Name
            };

            // Act
            TestHelper.AssertExpectedException(
                () => blobSasBuilder.SetPermissions(
                    rawPermissions: "ptsdfsd",
                    normalize: true),
                new ArgumentException("s is not a valid SAS permission"));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        [TestCase("LDWCAMEROP")]
        [TestCase("racwdlmeop")]
        [TestCase("rlm")]
        public async Task DataLakeSasBuilderRawPermissions_2020_02_10(string permissionsString)
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name
            };

            dataLakeSasBuilder.SetPermissions(
                rawPermissions: permissionsString,
                normalize: true);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeFileSystemClient sasFileSystemClient = new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_DirectoryRawPermissions_Exists()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            // Set the Resource = "d" and the DirectoryDepth = 1
            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                Path = directory.Path,
                IsDirectory = true,
                DirectoryDepth = 1
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeDirectoryClient sasDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            await sasDirectoryClient.ExistsAsync();
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_DirectoryRawPermissions_List()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                Path = directory.Path,
                IsDirectory = true,
                DirectoryDepth = 1
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeFileSystemClient sasFileSystemClient = new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions());

            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync(directory.Path))
            {
                // Just make sure the call succeeds.
            }
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_DirectoryDepth_Error()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                Path = directory.Path,
                IsDirectory = true,
                DirectoryDepth = 5 // Set the incorrect number of Directory Depth
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeDirectoryClient sasDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasDirectoryClient.ExistsAsync(),
                e => Assert.IsNotNull(e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_PreauthorizedAgentObjectId()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                PreauthorizedAgentObjectId = Recording.Random.NewGuid().ToString()
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeFileSystemClient sasFileSystemClient = new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_AgentObjectId()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();
            string unknownGuid = Recording.Random.NewGuid().ToString();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = test.FileSystem.GetRootDirectoryClient();

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            // Give UnknownGuid rights
            IList<PathAccessControlItem> accessControlList = new List<PathAccessControlItem>()
            {
                new PathAccessControlItem(
                    AccessControlType.User,
                    RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute,
                    false,
                    unknownGuid)
            };

            await directory.SetAccessControlListAsync(accessControlList);

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                AgentObjectId = unknownGuid
            };
            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeDirectoryClient sasDirectoryClient = new DataLakeDirectoryClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            DataLakeFileClient file = await sasDirectoryClient.CreateFileAsync(GetNewFileName());
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_AgentObjectId_Error()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                AgentObjectId = Recording.Random.NewGuid().ToString()
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeFileSystemClient sasFileSystemClient = new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasFileSystemClient.ExistsAsync(),
                e => Assert.IsNotNull(e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_BothObjectId_Error()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                PreauthorizedAgentObjectId = Recording.Random.NewGuid().ToString(),
                AgentObjectId = Recording.Random.NewGuid().ToString()
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            TestHelper.AssertExpectedException<InvalidOperationException>(
                () => dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName),
                new InvalidOperationException("SAS cannot have the following parameters specified in conjunction: PreauthorizedAgentObjectId, AgentObjectId"));
        }

        [Test]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_CorrelationId()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            // Arrange
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(directoryName);
            DataLakeFileClient file = await directory.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                CorrelationId = Recording.Random.NewGuid().ToString()
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeFileSystemClient sasFileSystemClient = new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions());

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
        }
    }
}
