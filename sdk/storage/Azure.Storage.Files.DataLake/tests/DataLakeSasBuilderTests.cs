// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        [TestCase("TLXDWCAR")]
        [TestCase("racwdxlt")]
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
    }
}
