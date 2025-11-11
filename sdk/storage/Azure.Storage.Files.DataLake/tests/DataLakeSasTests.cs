// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Files.DataLake.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeSasTests : DataLakeTestBase
    {
        public DataLakeSasTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Create ServiceClient with Custom Account SAS without invoking other clients
        /// </summary>
        private DataLakeServiceClient GetServiceWithCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            return InstrumentClient(new DataLakeServiceClient(uriBuilder.Uri, GetOptions()));
        }

        /// <summary>
        /// DataLakeFileSystemClient with Custom Account SAS without invoking other clients
        /// </summary>
        private DataLakeFileSystemClient GetFileSystemWithCustomAccountSas(
            Uri fileSystemUri,
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(fileSystemUri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uriBuilder.Uri, GetOptions()));
            return fileSystemClient;
        }

        /// <summary>
        /// Create DataLakeDirectoryClient with Custom Account SAS without invoking other clients.
        ///
        /// This will not create the directory tree if a nested directory name/path is provided
        /// </summary>
        private async Task<DataLakeDirectoryClient> GetDirectoryWithCustomAccountSas(
            Uri fileSystemUri,
            string directoryName = default,
            string permissions = default,
            string services = default,
            string resourceType = default,
            DataLakeClientOptions options = default)
        {
            directoryName ??= GetNewDirectoryName();
            options ??= GetOptions();
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(fileSystemUri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            uriBuilder.Path += $"/{directoryName}";

            DataLakeDirectoryClient directoryClient = InstrumentClient(new DataLakeDirectoryClient(uriBuilder.Uri, options));
            await directoryClient.CreateAsync();

            return directoryClient;
        }

        /// <summary>
        /// Create DataLakeDirectoryClient with Custom Account SAS without invoking other clients.
        ///
        /// This will not create the directory tree if a nested directory name/path is provided.
        /// This will at most create one directory parent for the file.
        /// </summary>
        private async Task<DataLakeFileClient> GetFileWithCustomAccountSas(
            DataLakeFileSystemClient fileSystem,
            string directoryName = default,
            string fileName = default,
            string permissions = default,
            string services = default,
            string resourceType = default,
            DataLakeClientOptions options = default)
        {
            directoryName ??= GetNewDirectoryName();
            options ??= GetOptions();

            DataLakeDirectoryClient directoryClient = await fileSystem.CreateDirectoryAsync(directoryName);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(directoryClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            fileName ??= GetNewFileName();
            uriBuilder.Path += $"/{fileName}";

            DataLakeFileClient fileClient = InstrumentClient(new DataLakeFileClient(uriBuilder.Uri, options));
            await fileClient.CreateAsync();
            return fileClient;
        }

        /// <summary>
        /// Create DataLakeDirectoryClient with Custom Account SAS without invoking other clients.
        ///
        /// This will not create the directory tree if a nested directory name/path is provided.
        /// This will at most create one directory parent for the file.
        /// </summary>
        private async Task<DataLakePathClient> GetPathClientWithCustomAccountSas(
            Uri fileSystemUri,
            string path = default,
            string permissions = default,
            string services = default,
            string resourceType = default,
            DataLakeClientOptions options = default)
        {
            path ??= GetNewFileName();
            options ??= GetOptions();

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(fileSystemUri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            uriBuilder.Path += $"/{path}";

            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(uriBuilder.Uri, options));
            await pathClient.CreateAsync(PathResourceType.File);
            return pathClient;
        }

        #region CreateClientRaw
        private async Task InvokeAccountSasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string fileName = GetNewFileName();
            DataLakeFileClient file = InstrumentClient(test.Container.GetFileClient(fileName));

            string sasQueryParams = GetCustomAccountSas(permissions: permissions, services: services, resourceType: resourceType);
            UriBuilder uriBuilder = new UriBuilder(file.Uri)
            {
                Query = sasQueryParams
            };

            // Assert
            DataLakeFileClient sasFileClient = InstrumentClient(new DataLakeFileClient(uriBuilder.Uri, GetOptions()));

            Assert.AreEqual("?" + sasQueryParams, sasFileClient.BlobUri.Query);
            Assert.AreEqual("?" + sasQueryParams, sasFileClient.DfsUri.Query);
            // Call an API that calls a DFS endpoint
            await sasFileClient.CreateAsync();
            // Call an API that calls a Blob endpoint
            await sasFileClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [TestCase("sco")]
        [TestCase("soc")]
        [TestCase("cos")]
        [TestCase("ocs")]
        [TestCase("os")]
        [TestCase("oc")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ResourceTypeOrder(string resourceType)
        {
            await InvokeAccountSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        [TestCase("bfqt")]
        [TestCase("qftb")]
        [TestCase("tqfb")]
        [TestCase("bqt")]
        [TestCase("qb")]
        [TestCase("fb")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ServiceOrder(string services)
        {
            await InvokeAccountSasTest(services: services);
        }
        #endregion

        #region DataLakeServiceClient
        private async Task InvokeAccountSasServiceToFileSystemTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            DataLakeServiceClient serviceClient = GetServiceWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeFileSystemClient fileSystemClient = serviceClient.GetFileSystemClient(GetNewFileSystemName());

            try
            {
                // Assert
                Assert.AreEqual(serviceClient.Uri.Query, fileSystemClient.Uri.Query);
                await fileSystemClient.CreateAsync();
                fileSystemClient.GetPathsAsync();
            }
            finally
            {
                await fileSystemClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task AccountSasResources_ServiceToFileSystem()
        {
            string resourceType = "soc";
            await InvokeAccountSasServiceToFileSystemTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ServiceToFileSystem()
        {
            string services = "fqb";
            await InvokeAccountSasServiceToFileSystemTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ServiceToFileSystem()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasServiceToFileSystemTest(permissions: permissions);
        }
        #endregion

        #region DataLakeFileSystemClient
        private async Task InvokeAccountSasFileSystemToServiceTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileSystemClient dataLakeFileSystemClient = GetFileSystemWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeServiceClient serviceClient = dataLakeFileSystemClient.GetParentServiceClient();

            // Assert
            Assert.AreEqual(dataLakeFileSystemClient.Uri.Query, serviceClient.Uri.Query);
            await serviceClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileSystemToService()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileSystemToServiceTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileSystemToService()
        {
            string services = "fqb";
            await InvokeAccountSasFileSystemToServiceTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileSystemToService()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasFileSystemToServiceTest(permissions: permissions);
        }

        private async Task InvokeAccountSasFileSystemToDirectoryTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileSystemClient dataLakeFileSystemClient = GetFileSystemWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeDirectoryClient directoryClient = dataLakeFileSystemClient.GetDirectoryClient(GetNewDirectoryName());

            // Assert
            Assert.AreEqual(dataLakeFileSystemClient.Uri.Query, directoryClient.Uri.Query);
            await directoryClient.CreateAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileSystemToDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileSystemToDirectoryTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileSystemToDirectory()
        {
            string services = "fqb";
            await InvokeAccountSasFileSystemToDirectoryTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileSystemToDirectory()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasFileSystemToDirectoryTest(permissions: permissions);
        }

        private async Task InvokeAccountSasFileSystemToFileTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileSystemClient dataLakeFileSystemClient = GetFileSystemWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeFileClient fileClient = dataLakeFileSystemClient.GetFileClient(GetNewFileName());

            // Assert
            Assert.AreEqual(dataLakeFileSystemClient.Uri.Query, fileClient.Uri.Query);
            await fileClient.CreateAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileSystemToFile()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileSystemToFileTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileSystemToFile()
        {
            string services = "fqb";
            await InvokeAccountSasFileSystemToFileTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileSystemToFile()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasFileSystemToFileTest(permissions: permissions);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_04_06)]
        public async Task FileSystemIdentitySAS_DelegatedTenantId()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName, service: oauthService);

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(fileName));
            await file.CreateAsync();

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            DataLakeGetUserDelegationKeyOptions options = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder(DataLakeFileSystemSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                FileSystemName = test.Container.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            DataLakeSasQueryParameters dataLakeSasQueryParameters = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(file.Uri)
            {
                Sas = dataLakeSasQueryParameters
            };

            DataLakeFileClient identitySasFile = InstrumentClient(new DataLakeFileClient(dataLakeUriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act
            Response<PathProperties> response = await identitySasFile.GetPropertiesAsync();
            AssertSasUserDelegationKey(identitySasFile.Uri, userDelegationKey.Value);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_04_06)]
        public async Task FileSystemIdentitySAS_DelegatedTenantId_Fail()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName, service: oauthService);

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(fileName));
            await file.CreateAsync();

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            DataLakeGetUserDelegationKeyOptions options = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder(DataLakeFileSystemSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                FileSystemName = test.Container.Name,
                // We are deliberately not passing in DelegatedUserObjectId to cause an auth failure
            };

            DataLakeSasQueryParameters dataLakeSasQueryParameters = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(file.Uri)
            {
                Sas = dataLakeSasQueryParameters
            };

            DataLakeFileClient identitySasFile = InstrumentClient(new DataLakeFileClient(dataLakeUriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act & Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasFile.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        [LiveOnly]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_04_06)]
        public async Task FileSystemIdentitySAS_DelegatedTenantId_Roundtrip()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName, service: oauthService);

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(fileName));
            await file.CreateAsync();

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            DataLakeGetUserDelegationKeyOptions options = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder(DataLakeFileSystemSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                FileSystemName = test.Container.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            DataLakeSasQueryParameters dataLakeSasQueryParameters = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            DataLakeUriBuilder originalDataLakeUriBuilder = new DataLakeUriBuilder(file.Uri)
            {
                Sas = dataLakeSasQueryParameters
            };

            DataLakeUriBuilder roundtripDataLakeUriBuilder = new DataLakeUriBuilder(originalDataLakeUriBuilder.ToUri());

            Assert.AreEqual(originalDataLakeUriBuilder.ToUri(), roundtripDataLakeUriBuilder.ToUri());
            Assert.AreEqual(originalDataLakeUriBuilder.Sas.ToString(), roundtripDataLakeUriBuilder.Sas.ToString());
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task FileSystemIdentitySAS_DelegatedObjectId()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName, service: oauthService);

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(fileName));
            await file.CreateAsync();

            DataLakeGetUserDelegationKeyOptions options = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder(DataLakeFileSystemSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                FileSystemName = test.Container.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            DataLakeSasQueryParameters dataLakeSasQueryParameters = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(file.Uri)
            {
                Sas = dataLakeSasQueryParameters
            };

            DataLakeFileClient identitySasFile = InstrumentClient(new DataLakeFileClient(dataLakeUriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act
            Response<PathProperties> response = await identitySasFile.GetPropertiesAsync();
            AssertSasUserDelegationKey(identitySasFile.Uri, userDelegationKey.Value);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2026_02_06)]
        public async Task FileSystemIdentitySAS_DelegatedObjectId_Fail()
        {
            DataLakeServiceClient oauthService = GetServiceClient_OAuth();
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName, service: oauthService);

            // Arrange
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(fileName));
            await file.CreateAsync();

            DataLakeGetUserDelegationKeyOptions options = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: options);

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            DataLakeSasBuilder dataLakeSasBuilder = new DataLakeSasBuilder(DataLakeFileSystemSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                FileSystemName = test.FileSystem.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            DataLakeSasQueryParameters dataLakeSasQueryParameters = dataLakeSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(file.Uri)
            {
                Sas = dataLakeSasQueryParameters
            };

            // We are deliberately not using the token credential to cause an auth failure
            DataLakeFileClient identitySasFile = InstrumentClient(new DataLakeFileClient(dataLakeUriBuilder.ToUri(), GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasFile.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }
        #endregion DataLakeFileSystemClient

        #region DataLakeDirectoryClient
        private async Task InvokeAccountSasDirectoryToFileTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directoryClient = await GetDirectoryWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeFileClient fileClient = directoryClient.GetFileClient(GetNewFileName());

            // Assert
            Assert.AreEqual(directoryClient.Uri.Query, fileClient.Uri.Query);
            await fileClient.CreateAsync();
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
            string services = "fqb";
            await InvokeAccountSasDirectoryToFileTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToFile()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasDirectoryToFileTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToSubDirectoryTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directoryClient = await GetDirectoryWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeDirectoryClient subdirectoryClient = directoryClient.GetSubDirectoryClient(GetNewDirectoryName());

            // Assert
            Assert.AreEqual(directoryClient.Uri.Query, subdirectoryClient.Uri.Query);
            await subdirectoryClient.CreateAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToSubdirectory()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToSubDirectoryTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServicesDirectoryToSubdirectory()
        {
            string services = "fqb";
            await InvokeAccountSasDirectoryToSubDirectoryTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToSubdirectory()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasDirectoryToSubDirectoryTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToFileSystemTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directoryClient = await GetDirectoryWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeFileSystemClient dataLakeFileSystemClient = directoryClient.GetParentFileSystemClient();

            // Assert
            Assert.AreEqual(directoryClient.Uri.Query, dataLakeFileSystemClient.Uri.Query);
            await dataLakeFileSystemClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToFileSystem()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToFileSystemTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_DirectoryToFileSystem()
        {
            string services = "fqb";
            await InvokeAccountSasDirectoryToFileSystemTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToFileSystem()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasDirectoryToFileSystemTest(permissions: permissions);
        }

        private async Task InvokeAccountSasDirectoryToCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeDirectoryClient cpkDirectoryClient = test.FileSystem.GetDirectoryClient(GetNewDirectoryName()).WithCustomerProvidedKey(customerProvidedKey);
            await cpkDirectoryClient.CreateAsync();

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkDirectoryClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            DataLakeDirectoryClient sasDirectoryClient = InstrumentClient(new DataLakeDirectoryClient(uriBuilder.Uri, GetOptions()));

            // Act
            DataLakeDirectoryClient cpkSasDirectoryClient = sasDirectoryClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasDirectoryClient.Uri.Query, cpkSasDirectoryClient.Uri.Query);
            await cpkSasDirectoryClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_DirectoryToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasDirectoryToCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_DirectoryToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasDirectoryToCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_DirectoryToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasDirectoryToCpkTest(permissions: permissions);
        }
        #endregion DataLakeDirectoryClient

        #region DataLakeFileClient
        private async Task InvokeAccountSasFileToFileSystemTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = await GetFileWithCustomAccountSas(
                fileSystem: test.FileSystem,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeFileSystemClient dataLakeFileSystemClient = fileClient.GetParentFileSystemClient();

            // Assert
            Assert.AreEqual(fileClient.Uri.Query, dataLakeFileSystemClient.Uri.Query);
            await dataLakeFileSystemClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileToFileSystem()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileToFileSystemTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileToFileSystem()
        {
            string services = "fqb";
            await InvokeAccountSasFileToFileSystemTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileToFileSystem()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasFileToFileSystemTest(permissions: permissions);
        }

        private async Task InvokeAccountFileToDirectorySasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = await GetFileWithCustomAccountSas(
                fileSystem: test.FileSystem,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeDirectoryClient directoryClient = fileClient.GetParentDirectoryClient();

            // Assert
            Assert.AreEqual(fileClient.Uri.Query, directoryClient.Uri.Query);
            await directoryClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileToDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountFileToDirectorySasTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileToDirectory()
        {
            string services = "fqb";
            await InvokeAccountFileToDirectorySasTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileToDirectory()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountFileToDirectorySasTest(permissions: permissions);
        }

        private async Task InvokeAccountSasFileToCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeFileClient cpkFileClient = test.FileSystem.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey);
            await cpkFileClient.CreateAsync();

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkFileClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            DataLakeFileClient sasFileClient = InstrumentClient(new DataLakeFileClient(uriBuilder.Uri, GetOptions()));

            // Act
            DataLakeFileClient cpkSasFileClient = sasFileClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasFileClient.Uri.Query, cpkSasFileClient.Uri.Query);
            await cpkSasFileClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_FileToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasFileToCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_FileToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasFileToCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_FileToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasFileToCpkTest(permissions: permissions);
        }
        #endregion DataLakeFileClient

        #region DataLakePathClient
        private async Task InvokeAccountSasPathToFileSystemTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakePathClient pathClient = await GetPathClientWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeFileSystemClient dataLakeFileSystemClient = pathClient.GetParentFileSystemClient();

            // Assert
            Assert.AreEqual(pathClient.Uri.Query, dataLakeFileSystemClient.Uri.Query);
            await dataLakeFileSystemClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_PathToFileSystem()
        {
            string resourceType = "soc";
            await InvokeAccountSasPathToFileSystemTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_PathToFileSystem()
        {
            string services = "fqb";
            await InvokeAccountSasPathToFileSystemTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_PathToFileSystem()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasPathToFileSystemTest(permissions: permissions);
        }

        private async Task InvokeAccountPathToDirectorySasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string parentDirectory = GetNewDirectoryName();
            string fileName = GetNewFileName();
            await test.FileSystem.CreateDirectoryAsync(parentDirectory);
            DataLakePathClient pathClient = await GetPathClientWithCustomAccountSas(
                fileSystemUri: test.FileSystem.Uri,
                path: $"{parentDirectory}/{fileName}",
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            DataLakeDirectoryClient directoryClient = pathClient.GetParentDirectoryClient();

            // Assert
            Assert.AreEqual(pathClient.Uri.Query, directoryClient.Uri.Query);
            await directoryClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_PathToDirectory()
        {
            string resourceType = "soc";
            await InvokeAccountPathToDirectorySasTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_PathToDirectory()
        {
            string services = "fqb";
            await InvokeAccountPathToDirectorySasTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_PathToDirectory()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountPathToDirectorySasTest(permissions: permissions);
        }

        private async Task InvokeAccountSasPathToCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakePathClient cpkFileClient = test.FileSystem.GetFileClient(GetNewFileName()).WithCustomerProvidedKey(customerProvidedKey);
            await cpkFileClient.CreateAsync(PathResourceType.File);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkFileClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            DataLakePathClient sasPathClient = InstrumentClient(new DataLakePathClient(uriBuilder.Uri, GetOptions()));

            // Act
            DataLakePathClient cpkSasPathClient = sasPathClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasPathClient.Uri.Query, cpkSasPathClient.Uri.Query);
            await cpkSasPathClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_PathToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasPathToCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_PathToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasPathToCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_PathToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasPathToCpkTest(permissions: permissions);
        }
        #endregion DataLakePathClient
    }
}
