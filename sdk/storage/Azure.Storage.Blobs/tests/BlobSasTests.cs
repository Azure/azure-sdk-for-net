// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobSasTests : BlobTestBase
    {
        public BlobSasTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task BlobSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task BlobIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobVersionSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                BlobVersionId = createResponse.Value.VersionId
            };
            blobSasBuilder.SetPermissions(BlobVersionSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                VersionId = createResponse.Value.VersionId,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobVersionIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                BlobVersionId = createResponse.Value.VersionId
            };
            blobSasBuilder.SetPermissions(BlobVersionSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                VersionId = createResponse.Value.VersionId,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobSnapshotSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                Snapshot = snapshotResponse.Value.Snapshot
            };
            blobSasBuilder.SetPermissions(SnapshotSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Snapshot = snapshotResponse.Value.Snapshot,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobSnapshotIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                Snapshot = snapshotResponse.Value.Snapshot
            };
            blobSasBuilder.SetPermissions(SnapshotSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Snapshot = snapshotResponse.Value.Snapshot,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ContainerSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobContainerSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ContainerIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobContainerSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ContainerIdentitySAS_DelegatedObjectId()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                BlobContainerName = test.Container.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            BlobSasQueryParameters blobSasQueryParameters = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            BlockBlobClient identitySasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();
            AssertSasUserDelegationKey(identitySasBlob.Uri, userDelegationKey.Value);

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_02_06)]
        public async Task ContainerIdentitySAS_DelegatedObjectId_Fail()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                BlobContainerName = test.Container.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            BlobSasQueryParameters blobSasQueryParameters = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            // We are deliberately not using the token credential to cause an auth failure
            BlockBlobClient identitySasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasBlob.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        public async Task ContainerIdentitySAS_RequestHeadersAndQueryParameters()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            Dictionary<string, List<string>> requestHeaders = new Dictionary<string, List<string>>()
            {
                { "foo", new List<string>{ "bar" } },
                { "company", new List<string>{ "msft" } },
                { "city", new List<string>{ "redmond", "atlanta", "reston" } },
                { "state", new List<string>{ "washington", "georgia" } }
            };

            Dictionary<string, List<string>> requestQueryParameters = new Dictionary<string, List<string>>()
            {
                { "firstName", new List<string>{ "john", "Tim" } },
                { "lastName", new List<string>{ "Smith", "jones" } },
                { "abra", new List<string>{ "cadabra" } }
            };

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                BlobContainerName = test.Container.Name,
                RequestHeaders = requestHeaders,
                RequestQueryParameters = requestQueryParameters
            };

            BlobSasQueryParameters blobSasQueryParameters = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            CustomRequestHeadersAndQueryParametersPolicy customRequestPolicy = new CustomRequestHeadersAndQueryParametersPolicy();
            // Send the request headers based on 'requestHeaders' Dictionary
            foreach (var header in requestHeaders)
            {
                if (!string.IsNullOrEmpty(header.Key))
                {
                    foreach (string value in header.Value)
                    {
                        customRequestPolicy.AddRequestHeader(header.Key, value);
                    }
                }
            }

            // Send the query parameters based on 'requestQueryParameters' Dictionary
            foreach (var param in requestQueryParameters)
            {
                if (param.Key != null)
                {
                    foreach (string value in param.Value)
                    {
                        customRequestPolicy.AddQueryParameter(param.Key, value);
                    }
                }
            }

            BlobClientOptions blobClientOptions = GetOptions();
            blobClientOptions.AddPolicy(customRequestPolicy, HttpPipelinePosition.PerCall);
            BlockBlobClient identitySasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), TestEnvironment.Credential, blobClientOptions));

            // Act
            Response<BlobProperties> response = await identitySasBlob.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        public async Task ContainerIdentitySAS_RequestHeadersAndQueryParameters_Fail()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            Dictionary<string, List<string>> requestHeaders = new Dictionary<string, List<string>>()
            {
                { "foo", new List<string>{ "bar" } },
            };

            Dictionary<string, List<string>> requestQueryParameters = new Dictionary<string, List<string>>()
            {
                { "abra", new List<string>{ "cadabra" } }
            };

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                BlobContainerName = test.Container.Name,
                RequestHeaders = requestHeaders,
                RequestQueryParameters = requestQueryParameters
            };

            BlobSasQueryParameters blobSasQueryParameters = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            // Deliberately do not send the request header and query parameter to cause an auth failure

            BlobClientOptions blobClientOptions = GetOptions();
            BlockBlobClient identitySasBlob = InstrumentClient(new BlockBlobClient(blobUriBuilder.ToUri(), TestEnvironment.Credential, blobClientOptions));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identitySasBlob.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        [LiveOnly]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        public async Task ContainerIdentitySAS_Roundtrip()
        {
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(test.Container, blobName);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            Dictionary<string, List<string>> requestHeaders = new Dictionary<string, List<string>>()
            {
                { "foo", new List<string>{ "bar" } },
                { "city", new List<string>{ "redmond", "atlanta" } },
                { "state", new List<string>{ "washington", "georgia" } }
            };

            Dictionary<string, List<string>> requestQueryParameters = new Dictionary<string, List<string>>()
            {
                { "firstName", new List<string>{ "john", "Tim" } },
                { "lastName", new List<string>{ "Smith", "jones" } },
                { "abra", new List<string>{ "cadabra" } }
            };

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                BlobContainerName = test.Container.Name,
                RequestHeaders = requestHeaders,
                RequestQueryParameters = requestQueryParameters
            };

            BlobSasQueryParameters blobSasQueryParameters = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName);

            BlobUriBuilder originalBlobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasQueryParameters
            };

            BlobUriBuilder roundtripBlobUriBuilder = new BlobUriBuilder(originalBlobUriBuilder.ToUri());

            Assert.AreEqual(originalBlobUriBuilder.ToUri(), roundtripBlobUriBuilder.ToUri());
            Assert.AreEqual(originalBlobUriBuilder.Sas.ToString(), roundtripBlobUriBuilder.Sas.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder(
                permissions: AccountSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1),
                services: AccountSasServices.Blobs,
                resourceTypes: AccountSasResourceTypes.Object);

            Uri accountSasUri = test.Container.GetParentBlobServiceClient().GenerateAccountSasUri(accountSasBuilder);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(accountSasUri)
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName
            };

            // Assert
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.GetPropertiesAsync();
        }

        /// <summary>
        /// Create ServiceClient with Custom Account SAS without invoking other clients
        /// </summary>
        private BlobServiceClient GetServiceWithCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            return InstrumentClient(new BlobServiceClient(uriBuilder.Uri, GetOptions()));
        }

        /// <summary>
        /// BlobContainerClient with Custom Account SAS without invoking other clients
        /// </summary>
        private BlobContainerClient GetContainerWithCustomAccountSas(
            Uri containerUri,
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(containerUri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(uriBuilder.Uri, GetOptions()));
            return containerClient;
        }

        /// <summary>
        /// Create BlockBlobClient with Custom Account SAS without invoking other clients.
        ///
        /// This will not create the directory tree if a nested directory name/path is provided
        /// </summary>
        private async Task<BlobBaseClient> GetBlobBaseWithCustomAccountSas(
            BlobContainerClient containerClient,
            string blobName = default,
            string permissions = default,
            string services = default,
            string resourceType = default,
            BlobClientOptions options = default)
        {
            blobName ??= GetNewBlobName();
            options ??= GetOptions();
            // Make blobClient
            BlobBaseClient blobClient = await GetNewBlobClient(containerClient, blobName);
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(blobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlockBlobClient baseClient = InstrumentClient(new BlockBlobClient(uriBuilder.Uri, options));

            return baseClient;
        }

        /// <summary>
        /// Create BlockBlobClient with Custom Account SAS without invoking other clients.
        ///
        /// This will not create the directory tree if a nested directory name/path is provided
        /// </summary>
        private async Task<BlockBlobClient> GetBlockBlobWithCustomAccountSas(
            Uri fileSystemUri,
            string blobName = default,
            string permissions = default,
            string services = default,
            string resourceType = default,
            BlobClientOptions options = default)
        {
            blobName ??= GetNewBlobName();
            options ??= GetOptions();
            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(fileSystemUri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            uriBuilder.Path += $"/{blobName}";

            BlockBlobClient baseClient = InstrumentClient(new BlockBlobClient(uriBuilder.Uri, options));
            await baseClient.UploadAsync(default);

            return baseClient;
        }

        #region CreateClientRaw
        private async Task InvokeAccountSasTest(
            string permissions = "rwdylacuptfi",
            string services = "bqtf",
            string resourceType = "sco")
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            UriBuilder blobUriBuilder = new UriBuilder(blob.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            // Assert
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.Uri, GetOptions()));
            await sasBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [TestCase("sco")]
        [TestCase("soc")]
        [TestCase("cos")]
        [TestCase("ocs")]
        [TestCase("os")]
        [TestCase("oc")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
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
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ServiceOrder(string services)
        {
            await InvokeAccountSasTest(services: services);
        }
        #endregion CreateClientRaw

        #region BlobServiceClient
        private async Task InvokeAccountSasServiceToFileSystemTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            BlobServiceClient serviceClient = GetServiceWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(GetNewContainerName());

            try
            {
                // Assert
                Assert.AreEqual(serviceClient.Uri.Query, containerClient.Uri.Query);
                await containerClient.CreateAsync();
                containerClient.GetBlobsAsync();
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
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

        #region BlobContainerClient
        private async Task InvokeAccountSasContainerToServiceTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobContainerClient blobContainerClient = GetContainerWithCustomAccountSas(
                containerUri: test.Container.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobServiceClient serviceClient = blobContainerClient.GetParentBlobServiceClient();

            // Assert
            Assert.AreEqual(blobContainerClient.Uri.Query, serviceClient.Uri.Query);
            await serviceClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ContainerToService()
        {
            string resourceType = "soc";
            await InvokeAccountSasContainerToServiceTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ContainerToService()
        {
            string services = "fqb";
            await InvokeAccountSasContainerToServiceTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ContainerToService()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasContainerToServiceTest(permissions: permissions);
        }

        private async Task InvokeAccountSasContainerToBlobBaseTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            await GetNewBlobClient(test.Container, blobName);
            BlobContainerClient containerClient = GetContainerWithCustomAccountSas(
                containerUri: test.Container.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobBaseClient blobClient = containerClient.GetBlobBaseClient(blobName);

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, blobClient.Uri.Query);
            await blobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ContainerToBlobBase()
        {
            string resourceType = "soc";
            await InvokeAccountSasContainerToBlobBaseTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ContainerToBlobBase()
        {
            string services = "fqb";
            await InvokeAccountSasContainerToBlobBaseTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ContainerToBlobBase()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasContainerToBlobBaseTest(permissions: permissions);
        }

        private async Task InvokeAccountSasContainerToBlobTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            await GetNewBlobClient(test.Container, blobName);
            BlobContainerClient containerClient = GetContainerWithCustomAccountSas(
                containerUri: test.Container.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, blobClient.Uri.Query);
            await blobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ContainerToBlob()
        {
            string resourceType = "soc";
            await InvokeAccountSasContainerToBlobTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ContainerToBlob()
        {
            string services = "fqb";
            await InvokeAccountSasContainerToBlobTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ContainerToBlob()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasContainerToBlobTest(permissions: permissions);
        }

        private async Task InvokeAccountSasContainerToBlockBlobTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            await GetNewBlobClient(test.Container, blobName);
            BlobContainerClient containerClient = GetContainerWithCustomAccountSas(
                containerUri: test.Container.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlockBlobClient blobClient = containerClient.GetBlockBlobClient(blobName);

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, blobClient.Uri.Query);
            await blobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ContainerToBlockBlob()
        {
            string resourceType = "soc";
            await InvokeAccountSasContainerToBlockBlobTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ContainerToBlockBlob()
        {
            string services = "fqb";
            await InvokeAccountSasContainerToBlockBlobTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ContainerToBlockBlob()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasContainerToBlockBlobTest(permissions: permissions);
        }

        private async Task InvokeAccountSasContainerToAppendBlobTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            await GetNewBlobClient(test.Container, blobName);
            BlobContainerClient containerClient = GetContainerWithCustomAccountSas(
                containerUri: test.Container.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            AppendBlobClient blobClient = containerClient.GetAppendBlobClient(blobName);

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, blobClient.Uri.Query);
            await blobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ContainerToAppendBlob()
        {
            string resourceType = "soc";
            await InvokeAccountSasContainerToAppendBlobTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ContainerToAppendBlob()
        {
            string services = "fqb";
            await InvokeAccountSasContainerToAppendBlobTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ContainerToAppendBlob()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasContainerToAppendBlobTest(permissions: permissions);
        }

        private async Task InvokeAccountSasContainerToPageBlobTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            await GetNewBlobClient(test.Container, blobName);
            BlobContainerClient containerClient = GetContainerWithCustomAccountSas(
                containerUri: test.Container.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            PageBlobClient blobClient = containerClient.GetPageBlobClient(blobName);

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, blobClient.Uri.Query);
            await blobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ContainerToPageBlob()
        {
            string resourceType = "soc";
            await InvokeAccountSasContainerToPageBlobTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ContainerToPageBlob()
        {
            string services = "fqb";
            await InvokeAccountSasContainerToPageBlobTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ContainerToPageBlob()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasContainerToPageBlobTest(permissions: permissions);
        }

        private async Task InvokeAccountSasContainerToLeaseTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            await GetNewBlobClient(test.Container, blobName);
            BlobContainerClient containerClient = GetContainerWithCustomAccountSas(
                containerUri: test.Container.Uri,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobLeaseClient blobClient = containerClient.GetBlobLeaseClient(Recording.Random.NewGuid().ToString());

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, blobClient.Uri.Query);
            await blobClient.AcquireAsync(TimeSpan.FromSeconds(15));
            await blobClient.BreakAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ContainerToLease()
        {
            string resourceType = "soc";
            await InvokeAccountSasContainerToLeaseTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ContainerToLease()
        {
            string services = "fqb";
            await InvokeAccountSasContainerToLeaseTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ContainerToLease()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasContainerToLeaseTest(permissions: permissions);
        }
        #endregion BlobContainerClient

        #region BlobBaseClient
        private async Task InvokeAccountSasBlobBaseToContainerTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            await GetNewBlobClient(test.Container, blobName);
            BlobBaseClient blobClient = await GetBlobBaseWithCustomAccountSas(
                containerClient: test.Container,
                blobName: blobName,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobContainerClient containerClient = blobClient.GetParentBlobContainerClient();

            // Assert
            Assert.AreEqual(containerClient.Uri.Query, containerClient.Uri.Query);
            await containerClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobBaseToContainer()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobBaseToContainerTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobBaseToContainer()
        {
            string services = "fqb";
            await InvokeAccountSasBlobBaseToContainerTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobBaseToContainer()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobBaseToContainerTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlobBaseToLeaseTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            await GetNewBlobClient(test.Container);
            BlobBaseClient blobClient = await GetBlobBaseWithCustomAccountSas(
                containerClient: test.Container,
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            BlobLeaseClient leaseClient = blobClient.GetBlobLeaseClient(Recording.Random.NewGuid().ToString());

            // Assert
            Assert.AreEqual(leaseClient.Uri.Query, blobClient.Uri.Query);
            await leaseClient.AcquireAsync(TimeSpan.FromSeconds(15));
            await leaseClient.BreakAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobBaseToLease()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobBaseToLeaseTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobBaseToLease()
        {
            string services = "fqb";
            await InvokeAccountSasBlobBaseToLeaseTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobBaseToLease()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobBaseToLeaseTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlobBaseToCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClient cpkBlobClient = test.Container.GetBlobClient(GetNewBlobName()).WithCustomerProvidedKey(customerProvidedKey);
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await cpkBlobClient.UploadAsync(stream);
            }

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlobBaseClient sasBlobClient = InstrumentClient(new BlobBaseClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobBaseClient cpkSasBlobClient = sasBlobClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
            await cpkSasBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobBaseToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobBaseToCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobBaseToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasBlobBaseToCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobBaseToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobBaseToCpkTest(permissions: permissions);
        }

        private void InvokeAccountSasBlobBaseToEncryptionScopeTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string fakeEncryptionScope = "fakeEncryptionScope";
            BlobClient cpkBlobClient = new BlobClient(new Uri("http://accountname.storage.azure.net/"), GetOptions()).WithEncryptionScope(fakeEncryptionScope);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlobBaseClient sasBlobClient = InstrumentClient(new BlobBaseClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobBaseClient cpkSasBlobClient = sasBlobClient.WithEncryptionScope(fakeEncryptionScope);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
        }

        [RecordedTest]
        public void AccountSasResources_BlobBaseToEncryptionScope()
        {
            string resourceType = "soc";
            InvokeAccountSasBlobBaseToEncryptionScopeTest(resourceType: resourceType);
        }

        [RecordedTest]
        public void AccountSasServices_BlobBaseToEncryptionScope()
        {
            string services = "fqb";
            InvokeAccountSasBlobBaseToEncryptionScopeTest(services: services);
        }

        [RecordedTest]
        public void AccountSasPermissions_BlobBaseToEncryptionScope()
        {
            string permissions = "cuprwdyla";
            InvokeAccountSasBlobBaseToEncryptionScopeTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlobBaseToSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blobClient = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> createSnapshotResponse = await blobClient.CreateSnapshotAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            BlobBaseClient sasBlobClient = InstrumentClient(new BlobBaseClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobBaseClient snapshotBlobClient = sasBlobClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotBlobClient.Uri.Query.EndsWith(sasToken));
            await snapshotBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobBaseToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobBaseToSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobBaseToSnapshot()
        {
            string services = "fqb";
            await InvokeAccountSasBlobBaseToSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobBaseToSnapshot()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobBaseToSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlobBaseToVersionTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blobClient = await GetNewBlobClient(test.Container, blobName);

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            BlobBaseClient sasBlobClient = InstrumentClient(new BlobBaseClient(uriBuilder.Uri, GetOptions()));

            // Act
            string fakeVersion = "2020-04-17T21:55:48.6692074Z";
            BlobBaseClient versionBlobClient = sasBlobClient.WithVersion(fakeVersion);

            // Assert
            // The original client will not have the Version appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(versionBlobClient.Uri.Query.EndsWith(sasToken));
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobBaseToVersion()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobBaseToVersionTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobBaseToVersion()
        {
            string services = "fqb";
            await InvokeAccountSasBlobBaseToVersionTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobBaseToVersion()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobBaseToVersionTest(permissions: permissions);
        }
        #endregion BlobBaseClient

        #region BlobClient
        private async Task InvokeAccountSasBlobToCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlobClient cpkBlobClient = test.Container.GetBlobClient(GetNewBlobName()).WithCustomerProvidedKey(customerProvidedKey);
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await cpkBlobClient.UploadAsync(stream);
            }

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlobClient sasBlobClient = InstrumentClient(new BlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobClient cpkSasBlobClient = sasBlobClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
            await cpkSasBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobToCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasBlobToCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobToCpkTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlobToClientSideEncryptionOptionsTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            ClientSideEncryptionOptions clientSideEncryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V2_0);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(test.Container.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };
            uriBuilder.Path += $"/{blobName}";

            BlobClient sasBlobClient = InstrumentClient(new BlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobClient cpkSasBlobClient = sasBlobClient.WithClientSideEncryptionOptions(clientSideEncryptionOptions);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobToClientSideEncryptionOptions()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobToCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobToClientSideEncryptionOptions()
        {
            string services = "fqb";
            await InvokeAccountSasBlobToCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobToClientSideEncryptionOptions()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobToCpkTest(permissions: permissions);
        }

        private void InvokeAccountSasBlobToEncryptionScopeTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string fakeEncryptionScope = "fakeEncryptionScope";
            BlobClient cpkBlobClient = new BlobClient(new Uri("http://accountname.storage.azure.net/"), GetOptions()).WithEncryptionScope(fakeEncryptionScope);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlobClient sasBlobClient = InstrumentClient(new BlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobClient cpkSasBlobClient = sasBlobClient.WithEncryptionScope(fakeEncryptionScope);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
        }

        [RecordedTest]
        public void AccountSasResources_BlobToEncryptionScope()
        {
            string resourceType = "soc";
            InvokeAccountSasBlobToEncryptionScopeTest(resourceType: resourceType);
        }

        [RecordedTest]
        public void AccountSasServices_BlobToEncryptionScope()
        {
            string services = "fqb";
            InvokeAccountSasBlobToEncryptionScopeTest(services: services);
        }

        [RecordedTest]
        public void AccountSasPermissions_BlobToEncryptionScope()
        {
            string permissions = "cuprwdyla";
            InvokeAccountSasBlobToEncryptionScopeTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlobToSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blobClient = await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> createSnapshotResponse = await blobClient.CreateSnapshotAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            BlobClient sasBlobClient = InstrumentClient(new BlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlobClient snapshotBlobClient = sasBlobClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotBlobClient.Uri.Query.EndsWith(sasToken));
            await snapshotBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobToSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobToSnapshot()
        {
            string services = "fqb";
            await InvokeAccountSasBlobToSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobToSnapshot()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobToSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlobToVersionTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blobClient = await GetNewBlobClient(test.Container, blobName);

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            BlobClient sasBlobClient = InstrumentClient(new BlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            string fakeVersion = "2020-04-17T21:55:48.6692074Z";
            BlobClient versionBlobClient = sasBlobClient.WithVersion(fakeVersion);

            // Assert
            // The original client will not have the Version appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(versionBlobClient.Uri.Query.EndsWith(sasToken));
        }

        [RecordedTest]
        public async Task AccountSasResources_BlobToVersion()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlobToVersionTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlobToVersion()
        {
            string services = "fqb";
            await InvokeAccountSasBlobToVersionTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlobToVersion()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlobToVersionTest(permissions: permissions);
        }
        #endregion BlobClient

        #region AppendBlobClient
        private async Task InvokeAccountSasAppendBlobCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            AppendBlobClient cpkAppendBlobClient = test.Container.GetAppendBlobClient(GetNewBlobName()).WithCustomerProvidedKey(customerProvidedKey);
            await cpkAppendBlobClient.CreateAsync();

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkAppendBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            AppendBlobClient sasAppendBlobClient = InstrumentClient(new AppendBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            AppendBlobClient cpkSasAppendBlobClient = sasAppendBlobClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasAppendBlobClient.Uri.Query, cpkSasAppendBlobClient.Uri.Query);
            await cpkSasAppendBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_AppendBlobToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasAppendBlobCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_AppendBlobToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasAppendBlobCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_AppendBlobToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasAppendBlobCpkTest(permissions: permissions);
        }

        private void InvokeAccountSasAppendBlobToEncryptionScopeTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string fakeEncryptionScope = "fakeEncryptionScope";
            AppendBlobClient cpkBlobClient = new AppendBlobClient(new Uri("http://accountname.storage.azure.net/"), GetOptions()).WithEncryptionScope(fakeEncryptionScope);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            AppendBlobClient cpkSasBlobClient = sasBlobClient.WithEncryptionScope(fakeEncryptionScope);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
        }

        [RecordedTest]
        public void AccountSasResources_AppendBlobToEncryptionScope()
        {
            string resourceType = "soc";
            InvokeAccountSasAppendBlobToEncryptionScopeTest(resourceType: resourceType);
        }

        [RecordedTest]
        public void AccountSasServices_AppendBlobToEncryptionScope()
        {
            string services = "fqb";
            InvokeAccountSasAppendBlobToEncryptionScopeTest(services: services);
        }

        [RecordedTest]
        public void AccountSasPermissions_AppendBlobToEncryptionScope()
        {
            string permissions = "cuprwdyla";
            InvokeAccountSasAppendBlobToEncryptionScopeTest(permissions: permissions);
        }

        private async Task InvokeAccountSasAppendBlobSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlobClient = test.Container.GetAppendBlobClient(blobName);
            await appendBlobClient.CreateAsync();
            Response<BlobSnapshotInfo> createSnapshotResponse = await appendBlobClient.CreateSnapshotAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(appendBlobClient.Uri)
            {
                Query = sasToken
            };

            AppendBlobClient sasAppendBlobClient = InstrumentClient(new AppendBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            AppendBlobClient snapshotAppendBlobClient = sasAppendBlobClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotAppendBlobClient.Uri.Query.EndsWith(sasToken));
            await snapshotAppendBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_AppendBlobToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasAppendBlobSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_AppendBlobToSnapshot()
        {
            string services = "fqb";
            await InvokeAccountSasAppendBlobSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_AppendBlobToSnapshot()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasAppendBlobSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasAppendBlobVersionTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            AppendBlobClient appendBlobClient = test.Container.GetAppendBlobClient(blobName);
            await appendBlobClient.CreateAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(appendBlobClient.Uri)
            {
                Query = sasToken
            };

            AppendBlobClient sasAppendBlobClient = InstrumentClient(new AppendBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            string fakeVersion = "2020-04-17T21:55:48.6692074Z";
            AppendBlobClient versionAppendBlobClient = sasAppendBlobClient.WithVersion(fakeVersion);

            // Assert
            // The original client will not have the Version appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(versionAppendBlobClient.Uri.Query.EndsWith(sasToken));
        }

        [RecordedTest]
        public async Task AccountSasResources_AppendBlobToVersion()
        {
            string resourceType = "soc";
            await InvokeAccountSasAppendBlobVersionTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_AppendBlobToVersion()
        {
            string services = "fqb";
            await InvokeAccountSasAppendBlobVersionTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_AppendBlobToVersion()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasAppendBlobVersionTest(permissions: permissions);
        }
        #endregion AppendBlobClient

        #region BlockBlobClient
        private async Task InvokeAccountSasBlockBlobCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            BlockBlobClient cpkBlockBlobClient = test.Container.GetBlockBlobClient(GetNewBlobName()).WithCustomerProvidedKey(customerProvidedKey);
            var data = GetRandomBuffer(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await cpkBlockBlobClient.UploadAsync(stream);
            }

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlockBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlockBlobClient sasBlockBlobClient = InstrumentClient(new BlockBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlockBlobClient cpkSasBlockBlobClient = sasBlockBlobClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasBlockBlobClient.Uri.Query, cpkSasBlockBlobClient.Uri.Query);
            await cpkSasBlockBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlockBlobToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlockBlobCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlockBlobToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasBlockBlobCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlockBlobToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlockBlobCpkTest(permissions: permissions);
        }

        private void InvokeAccountSasBlockBlobToEncryptionScopeTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string fakeEncryptionScope = "fakeEncryptionScope";
            BlockBlobClient cpkBlobClient = new BlockBlobClient(new Uri("http://accountname.storage.azure.net/"), GetOptions()).WithEncryptionScope(fakeEncryptionScope);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            BlockBlobClient sasBlobClient = InstrumentClient(new BlockBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlockBlobClient cpkSasBlobClient = sasBlobClient.WithEncryptionScope(fakeEncryptionScope);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
        }

        [RecordedTest]
        public void AccountSasResources_BlockBlobToEncryptionScope()
        {
            string resourceType = "soc";
            InvokeAccountSasBlockBlobToEncryptionScopeTest(resourceType: resourceType);
        }

        [RecordedTest]
        public void AccountSasServices_BlockBlobToEncryptionScope()
        {
            string services = "fqb";
            InvokeAccountSasBlockBlobToEncryptionScopeTest(services: services);
        }

        [RecordedTest]
        public void AccountSasPermissions_BlockBlobToEncryptionScope()
        {
            string permissions = "cuprwdyla";
            InvokeAccountSasBlockBlobToEncryptionScopeTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlockBlobSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient BlockBlobClient = (BlockBlobClient) await GetNewBlobClient(test.Container, blobName);
            Response<BlobSnapshotInfo> createSnapshotResponse = await BlockBlobClient.CreateSnapshotAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(BlockBlobClient.Uri)
            {
                Query = sasToken
            };

            BlockBlobClient sasBlockBlobClient = InstrumentClient(new BlockBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            BlockBlobClient snapshotBlockBlobClient = sasBlockBlobClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotBlockBlobClient.Uri.Query.EndsWith(sasToken));
            await snapshotBlockBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_BlockBlobToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlockBlobSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlockBlobToSnapshot()
        {
            string services = "fqb";
            await InvokeAccountSasBlockBlobSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlockBlobToSnapshot()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlockBlobSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasBlockBlobVersionTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient BlockBlobClient = (BlockBlobClient)await GetNewBlobClient(test.Container, blobName);

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(BlockBlobClient.Uri)
            {
                Query = sasToken
            };

            BlockBlobClient sasBlockBlobClient = InstrumentClient(new BlockBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            string fakeVersion = "2020-04-17T21:55:48.6692074Z";
            BlockBlobClient versionBlockBlobClient = sasBlockBlobClient.WithVersion(fakeVersion);

            // Assert
            // The original client will not have the Version appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(versionBlockBlobClient.Uri.Query.EndsWith(sasToken));
        }

        [RecordedTest]
        public async Task AccountSasResources_BlockBlobToVersion()
        {
            string resourceType = "soc";
            await InvokeAccountSasBlockBlobVersionTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_BlockBlobToVersion()
        {
            string services = "fqb";
            await InvokeAccountSasBlockBlobVersionTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_BlockBlobToVersion()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasBlockBlobVersionTest(permissions: permissions);
        }
        #endregion BlockBlobClient

        #region PageBlobClient
        private async Task InvokeAccountSasPageBlobCpkTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            CustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            PageBlobClient cpkPageBlobClient = test.Container.GetPageBlobClient(GetNewBlobName()).WithCustomerProvidedKey(customerProvidedKey);
            await cpkPageBlobClient.CreateAsync(Constants.KB);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkPageBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            PageBlobClient sasPageBlobClient = InstrumentClient(new PageBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            PageBlobClient cpkSasPageBlobClient = sasPageBlobClient.WithCustomerProvidedKey(customerProvidedKey);

            // Assert
            Assert.AreEqual(sasPageBlobClient.Uri.Query, cpkSasPageBlobClient.Uri.Query);
            await cpkSasPageBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_PageBlobToCpk()
        {
            string resourceType = "soc";
            await InvokeAccountSasPageBlobCpkTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_PageBlobToCpk()
        {
            string services = "fqb";
            await InvokeAccountSasPageBlobCpkTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_PageBlobToCpk()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasPageBlobCpkTest(permissions: permissions);
        }

        private void InvokeAccountSasPageBlobToEncryptionScopeTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string fakeEncryptionScope = "fakeEncryptionScope";
            PageBlobClient cpkBlobClient = new PageBlobClient(new Uri("http://accountname.storage.azure.net/"), GetOptions()).WithEncryptionScope(fakeEncryptionScope);

            // Use UriBuilder over DataLakeUriBuilder to apply custom SAS, DataLakeUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(cpkBlobClient.Uri)
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            PageBlobClient sasBlobClient = InstrumentClient(new PageBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            PageBlobClient cpkSasBlobClient = sasBlobClient.WithEncryptionScope(fakeEncryptionScope);

            // Assert
            Assert.AreEqual(sasBlobClient.Uri.Query, cpkSasBlobClient.Uri.Query);
        }

        [RecordedTest]
        public void AccountSasResources_PageBlobToEncryptionScope()
        {
            string resourceType = "soc";
            InvokeAccountSasPageBlobToEncryptionScopeTest(resourceType: resourceType);
        }

        [RecordedTest]
        public void AccountSasServices_PageBlobToEncryptionScope()
        {
            string services = "fqb";
            InvokeAccountSasPageBlobToEncryptionScopeTest(services: services);
        }

        [RecordedTest]
        public void AccountSasPermissions_PageBlobToEncryptionScope()
        {
            string permissions = "cuprwdyla";
            InvokeAccountSasPageBlobToEncryptionScopeTest(permissions: permissions);
        }

        private async Task InvokeAccountSasPageBlobSnapshotTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient PageBlobClient = test.Container.GetPageBlobClient(blobName);
            await PageBlobClient.CreateAsync(Constants.KB);
            Response<BlobSnapshotInfo> createSnapshotResponse = await PageBlobClient.CreateSnapshotAsync();

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(PageBlobClient.Uri)
            {
                Query = sasToken
            };

            PageBlobClient sasPageBlobClient = InstrumentClient(new PageBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            PageBlobClient snapshotPageBlobClient = sasPageBlobClient.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            // Assert
            // The original client will not have the snapshot appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(snapshotPageBlobClient.Uri.Query.EndsWith(sasToken));
            await snapshotPageBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_PageBlobToSnapshot()
        {
            string resourceType = "soc";
            await InvokeAccountSasPageBlobSnapshotTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_PageBlobToSnapshot()
        {
            string services = "fqb";
            await InvokeAccountSasPageBlobSnapshotTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_PageBlobToSnapshot()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasPageBlobSnapshotTest(permissions: permissions);
        }

        private async Task InvokeAccountSasPageBlobVersionTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync();
            PageBlobClient PageBlobClient = test.Container.GetPageBlobClient(blobName);
            await PageBlobClient.CreateAsync(Constants.KB);

            // Use UriBuilder over ShareUriBuilder to apply custom SAS, ShareUriBuilder requires SasQueryParameters
            string sasToken = GetCustomAccountSas(permissions, services, resourceType);
            UriBuilder uriBuilder = new UriBuilder(PageBlobClient.Uri)
            {
                Query = sasToken
            };

            PageBlobClient sasPageBlobClient = InstrumentClient(new PageBlobClient(uriBuilder.Uri, GetOptions()));

            // Act
            string fakeVersion = "2020-04-17T21:55:48.6692074Z";
            PageBlobClient versionPageBlobClient = sasPageBlobClient.WithVersion(fakeVersion);

            // Assert
            // The original client will not have the Version appended to the uri, so having the same SAS
            // in the query should suffice
            Assert.IsTrue(versionPageBlobClient.Uri.Query.EndsWith(sasToken));
        }

        [RecordedTest]
        public async Task AccountSasResources_PageBlobToVersion()
        {
            string resourceType = "soc";
            await InvokeAccountSasPageBlobVersionTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_PageBlobToVersion()
        {
            string services = "fqb";
            await InvokeAccountSasPageBlobVersionTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_PageBlobToVersion()
        {
            string permissions = "cuprwdyla";
            await InvokeAccountSasPageBlobVersionTest(permissions: permissions);
        }
        #endregion PageBlobClient
    }
}
