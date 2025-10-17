// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        [TestCase("IFTPUCALYXDWR")]
        [TestCase("rwdxylacuptfi")]
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

            Assert.AreEqual("rwdxylacuptfi", accountSasBuilder.Permissions);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(Tenants.TestConfigHierarchicalNamespace.AccountName, Tenants.TestConfigHierarchicalNamespace.AccountKey);

            Uri uri = new Uri($"{test.FileSystem.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uri, GetOptions()));

            // Act
            await sasFileSystemClient.GetPropertiesAsync();
        }

        [RecordedTest]
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

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase(DataLakeFileSystemSasPermissions.List)]
        [TestCase(DataLakeFileSystemSasPermissions.Read | DataLakeFileSystemSasPermissions.List)]
        [TestCase(DataLakeFileSystemSasPermissions.All)]
        public async Task SetPermissions_Filesystem(DataLakeFileSystemSasPermissions permissions)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name
            };

            dataLakeSasBuilder.SetPermissions(permissions);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(Tenants.TestConfigHierarchicalNamespace.AccountName, Tenants.TestConfigHierarchicalNamespace.AccountKey);

            string stringToSign = null;

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(sharedKeyCredential, out stringToSign)
            };

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        [TestCase("LDWCMEAOPR")]
        [TestCase("racwdlmeop")]
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

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(Tenants.TestConfigHierarchicalNamespace.AccountName, Tenants.TestConfigHierarchicalNamespace.AccountKey);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        [RecordedTest]
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

        [RecordedTest]
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

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        [RecordedTest]
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

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                Path = directory.Path,
                IsDirectory = true
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(directory.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await sasDirectoryClient.ExistsAsync();
        }

        [RecordedTest]
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
                IsDirectory = true
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Path = directory.Path,
            };

            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync(options))
            {
                // Just make sure the call succeeds.
            }
        }

        [RecordedTest]
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

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_AgentObjectId()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
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

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            DataLakeFileClient file = await sasDirectoryClient.CreateFileAsync(GetNewFileName());
        }

        [RecordedTest]
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

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                sasFileSystemClient.ExistsAsync(),
                e => Assert.IsNotNull(e.ErrorCode));
        }

        [RecordedTest]
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

        [RecordedTest]
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

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.List);

            string stringToSign = null;

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(test.FileSystem.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName, out stringToSign)
            };

            DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await foreach (PathItem pathItem in sasFileSystemClient.GetPathsAsync())
            {
                // Just make sure the call succeeds.
            }
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_DirectoryDepth_SharedKey()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory2 = await subdirectory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = await subdirectory3.CreateFileAsync(GetNewFileName());

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                Path = subdirectory3.Path,
                IsDirectory = true
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(Tenants.TestConfigHierarchicalNamespace.AccountName, Tenants.TestConfigHierarchicalNamespace.AccountKey);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(subdirectory3.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await sasDirectoryClient.ExistsAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_DirectoryDepth_Exists()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory = await directory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory2 = await subdirectory.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeDirectoryClient subdirectory3 = await subdirectory2.CreateSubDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = await subdirectory3.CreateFileAsync(GetNewFileName());

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                Path = subdirectory3.Path,
                IsDirectory = true
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(subdirectory3.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName)
            };

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await sasDirectoryClient.ExistsAsync();
        }

        [RecordedTest]
        [TestCase("/")] // Root Directory
        [TestCase("d1")]
        [TestCase("d1/d2/d3/d4/d5")]
        [TestCase("/d1")]
        [TestCase("d1/")]
        [TestCase("/d1/")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_DirectoryDepth(string directoryName)
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                FileSystemName = test.FileSystem.Name,
                Path = directoryName,
                IsDirectory = true
            };

            dataLakeSasBuilder.SetPermissions(DataLakeSasPermissions.All);

            DataLakeSasQueryParameters sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName);
            int expectedDepth = directoryName.Split('/').Length;
            if (expectedDepth > 0)
            {
                expectedDepth -= directoryName.ElementAt(0) == '/' ? 1 : 0;
                expectedDepth -= directoryName.ElementAt(directoryName.Length - 1) == '/' ? 1 : 0;
            }
            Assert.AreEqual(expectedDepth, sas.DirectoryDepth);
        }

        [RecordedTest]
        [TestCase("/")] // Root Directory
        [TestCase("d1")]
        [TestCase("d1/d2/d3/d4/d5")]
        [TestCase("d1/d2/d3/d4/d5/d6/d7/d8/d9/d10")]
        [TestCase("d1/d2/d3/d4/d5/d6/d7/d8/d9/d10/d11/d12/d13")]
        [TestCase("/d1")]
        [TestCase("d1/")]
        [TestCase("/d1/")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task DataLakeSasBuilder_DirectoryDepth_CustomSas(string directoryName)
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            // Make a SAS with the DirectoryDepth/sdd
            DataLakeSasBuilder dataLakeSasBuilder = new(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                FileSystemName = test.FileSystem.Name,
                Path = directoryName,
                IsDirectory = true
            };

            // Get the expected depth
            DataLakeSasQueryParameters sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.FileSystem.AccountName);
            int expectedDepth = directoryName.Split('/').Length;
            if (expectedDepth > 0)
            {
                expectedDepth -= directoryName.ElementAt(0) == '/' ? 1 : 0;
                expectedDepth -= directoryName.ElementAt(directoryName.Length - 1) == '/' ? 1 : 0;
            }
            // Make a Uri with a SAS with a DirectoryDepth/sdd
            DataLakeUriBuilder expectedbuilder = new(directory.Uri)
            {
                Sas = sas,
            };

            // Act - Parse the Uri with sas via the SasQueryParameter constructor
            DataLakeUriBuilder newUriBuilder = new(expectedbuilder.ToUri());

            // Assert
            Assert.AreEqual(expectedDepth, newUriBuilder.Sas.DirectoryDepth);
        }

        [RecordedTest]
        public async Task SasCredentialRequiresUriWithoutSasError_RedactedSasUri()
        {
            // Arrange
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string directoryName = GetNewDirectoryName();

            await using DisposingFileSystem test = await GetNewFileSystem(service: oauthService, fileSystemName: fileSystemName);

            DataLakeDirectoryClient directory = test.FileSystem.GetDirectoryClient(directoryName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            // Make a SAS with the DirectoryDepth/sdd
            DataLakeSasBuilder dataLakeSasBuilder = new(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Path = directoryName,
                IsDirectory = true
            };

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(test.Container.Uri)
            {
                Sas = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey, test.Container.AccountName)
            };

            Uri sasUri = uriBuilder.ToUri();

            UriBuilder uriBuilder2 = new UriBuilder(sasUri);
            uriBuilder2.Query = "[REDACTED]";
            string redactedUri = uriBuilder2.Uri.ToString();

            ArgumentException ex = Errors.SasCredentialRequiresUriWithoutSas<DataLakeUriBuilder>(sasUri);

            // Assert
            Assert.IsTrue(ex.Message.Contains(redactedUri));
            Assert.IsFalse(ex.Message.Contains("st="));
            Assert.IsFalse(ex.Message.Contains("se="));
            Assert.IsFalse(ex.Message.Contains("sig="));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public void ToSasQueryParameters_FileIdentityTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            string containerName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            DataLakeSasBuilder dataLakeSasBuilder = BuildDataLakeSasBuilder(
                includePath: true,
                includeDelegatedObjectId: true,
                includeRequestHeaders: true,
                includeRequestQueryParameters: true,
                fileSystemName: containerName,
                path: fileName,
                constants);
            var signature = BuildIdentitySignature(includePath: true, containerName, fileName, constants);

            // Act
            DataLakeSasQueryParameters sasQueryParameters = dataLakeSasBuilder.ToSasQueryParameters(
                GetUserDelegationKey(constants),
                constants.Sas.Account);

            // Assert
            Assert.AreEqual(SasQueryParametersInternals.DefaultSasVersionInternal, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(constants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(String.Empty, sasQueryParameters.Identifier);
            Assert.AreEqual(constants.Sas.KeyObjectId, sasQueryParameters.KeyObjectId);
            Assert.AreEqual(constants.Sas.KeyTenantId, sasQueryParameters.KeyTenantId);
            Assert.AreEqual(constants.Sas.KeyStart, sasQueryParameters.KeyStartsOn);
            Assert.AreEqual(constants.Sas.KeyExpiry, sasQueryParameters.KeyExpiresOn);
            Assert.AreEqual(constants.Sas.KeyService, sasQueryParameters.KeyService);
            Assert.AreEqual(constants.Sas.KeyVersion, sasQueryParameters.KeyVersion);
            Assert.AreEqual(Constants.Sas.Resource.Blob, sasQueryParameters.Resource);
            Assert.AreEqual(_sasPermissions.ToPermissionsString(), sasQueryParameters.Permissions);
            Assert.AreEqual(constants.Sas.DelegatedObjectId, sasQueryParameters.DelegatedUserObjectId);
            Assert.AreEqual(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestHeaders), sasQueryParameters.RequestHeaders);
            Assert.AreEqual(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestQueryParameters), sasQueryParameters.RequestQueryParameters);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        private DataLakeSasBuilder BuildDataLakeSasBuilder(
            bool includePath,
            bool includeDelegatedObjectId,
            bool includeRequestHeaders,
            bool includeRequestQueryParameters,
            string fileSystemName,
            string path,
            TestConstants constants)
        {
            DataLakeSasBuilder builder = new DataLakeSasBuilder
            {
                Version = null,
                Protocol = constants.Sas.Protocol,
                StartsOn = constants.Sas.StartTime,
                ExpiresOn = constants.Sas.ExpiryTime,
                IPRange = constants.Sas.IPRange,
                Identifier = constants.Sas.Identifier,
                FileSystemName = fileSystemName,
                Path = includePath ? path : null,
                CacheControl = constants.Sas.CacheControl,
                ContentDisposition = constants.Sas.ContentDisposition,
                ContentEncoding = constants.Sas.ContentEncoding,
                ContentLanguage = constants.Sas.ContentLanguage,
                ContentType = constants.Sas.ContentType,
                EncryptionScope = constants.Sas.EncryptionScope
            };

            if (includeDelegatedObjectId)
            {
                builder.DelegatedUserObjectId = constants.Sas.DelegatedObjectId;
            }
            if (includeRequestHeaders)
            {
                builder.RequestHeaders = constants.Sas.RequestHeaders;
            }
            if (includeRequestQueryParameters)
            {
                builder.RequestQueryParameters = constants.Sas.RequestQueryParameters;
            }

            builder.SetPermissions(_sasPermissions);
            return builder;
        }

        private string BuildIdentitySignature(
            bool includePath,
            string fileSystemName,
            string path,
            TestConstants constants)
        {
            string canonicalName = includePath ? $"/blob/{constants.Sas.Account}/{fileSystemName}/{path}"
                : $"/blob/{constants.Sas.Account}/{fileSystemName}";

            string resource = Constants.Sas.Resource.Container;

            if (includePath)
            {
                resource = Constants.Sas.Resource.Blob;
            }

            string stringToSign = String.Join("\n",
                _sasPermissions.ToPermissionsString(),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                canonicalName,
                constants.Sas.KeyObjectId,
                constants.Sas.KeyTenantId,
                SasExtensions.FormatTimesForSasSigning(constants.Sas.KeyStart),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.KeyExpiry),
                constants.Sas.KeyService,
                constants.Sas.KeyVersion,
                null,
                null,
                null,
                null, // SignedKeyDelegatedUserTenantId, will be added in a future release.
                constants.Sas.DelegatedObjectId,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(constants.Sas.Protocol),
                SasQueryParametersInternals.DefaultSasVersionInternal,
                resource,
                null,
                constants.Sas.EncryptionScope,
                SasExtensions.FormatRequestHeadersForSasSigning(constants.Sas.RequestHeaders),
                SasExtensions.FormatRequestQueryParametersForSasSigning(constants.Sas.RequestQueryParameters),
                constants.Sas.CacheControl,
                constants.Sas.ContentDisposition,
                constants.Sas.ContentEncoding,
                constants.Sas.ContentLanguage,
                constants.Sas.ContentType);

            return ComputeHMACSHA256(constants.Sas.KeyValue, stringToSign);
        }

        private string ComputeHMACSHA256(string userDelegationKeyValue, string message) =>
            Convert.ToBase64String(
                new HMACSHA256(
                    Convert.FromBase64String(userDelegationKeyValue))
                .ComputeHash(Encoding.UTF8.GetBytes(message)));

        private static UserDelegationKey GetUserDelegationKey(TestConstants constants)
            => new UserDelegationKey
            {
                SignedObjectId = constants.Sas.KeyObjectId,
                SignedTenantId = constants.Sas.KeyTenantId,
                SignedStartsOn = constants.Sas.KeyStart,
                SignedExpiresOn = constants.Sas.KeyExpiry,
                SignedService = constants.Sas.KeyService,
                SignedVersion = constants.Sas.KeyVersion,
                Value = constants.Sas.KeyValue
            };
    }
}
