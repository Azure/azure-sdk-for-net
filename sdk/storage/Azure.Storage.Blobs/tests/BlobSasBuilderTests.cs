// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Microsoft.Rest;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobSasBuilderTests : BlobTestBase
    {
        private const string Permissions = "rwd";
        private static readonly string Snapshot = "snapshot";

        public BlobSasBuilderTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private static UserDelegationKey GetUserDelegationKey(TestConstants constants)
            => new UserDelegationKey
            {
                SignedObjectId = constants.Sas.KeyObjectId,
                SignedTenantId = constants.Sas.KeyTenantId,
                SignedStartsOn = constants.Sas.KeyStart,
                SignedExpiresOn = constants.Sas.KeyExpiry,
                SignedService = constants.Sas.KeyService,
                SignedVersion = constants.Sas.KeyVersion,
                SignedDelegatedUserTenantId = constants.Sas.KeyDelegatedTenantId,
                Value = constants.Sas.KeyValue
            };

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public void ToSasQueryParameters_ContainerTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(
                includeBlob: false,
                includeSnapshot: false,
                includeDelegatedObjectId: false,
                includeRequestHeaders: false,
                includeRequestQueryParameters: false,
                containerName,
                blobName,
                constants);
            var signature = BuildSignature(includeBlob: false, includeSnapshot: false, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
            Assert.That(sasQueryParameters.Services, Is.Null);
            Assert.That(sasQueryParameters.ResourceTypes, Is.Null);
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(constants.Sas.Protocol));
            Assert.That(sasQueryParameters.StartsOn, Is.EqualTo(constants.Sas.StartTime));
            Assert.That(sasQueryParameters.ExpiresOn, Is.EqualTo(constants.Sas.ExpiryTime));
            Assert.That(sasQueryParameters.IPRange, Is.EqualTo(constants.Sas.IPRange));
            Assert.That(sasQueryParameters.Identifier, Is.EqualTo(constants.Sas.Identifier));
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(Constants.Sas.Resource.Container));
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        public void ToSasQueryParameters_ContainerIdentityTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(
                includeBlob: false,
                includeSnapshot: false,
                includeDelegatedObjectId: true,
                includeRequestHeaders: true,
                includeRequestQueryParameters: true,
                containerName,
                blobName,
                constants);
            var signature = BuildIdentitySignature(includeBlob: false, includeSnapshot: false, containerName, blobName, constants);
            string stringToSign = null;

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(GetUserDelegationKey(constants), constants.Sas.Account, out stringToSign);

            // Assert
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
            Assert.That(sasQueryParameters.Services, Is.Null);
            Assert.That(sasQueryParameters.ResourceTypes, Is.Null);
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(constants.Sas.Protocol));
            Assert.That(sasQueryParameters.StartsOn, Is.EqualTo(constants.Sas.StartTime));
            Assert.That(sasQueryParameters.ExpiresOn, Is.EqualTo(constants.Sas.ExpiryTime));
            Assert.That(sasQueryParameters.IPRange, Is.EqualTo(constants.Sas.IPRange));
            Assert.That(sasQueryParameters.Identifier, Is.Empty);
            Assert.That(sasQueryParameters.KeyObjectId, Is.EqualTo(constants.Sas.KeyObjectId));
            Assert.That(sasQueryParameters.KeyTenantId, Is.EqualTo(constants.Sas.KeyTenantId));
            Assert.That(sasQueryParameters.KeyStartsOn, Is.EqualTo(constants.Sas.KeyStart));
            Assert.That(sasQueryParameters.KeyExpiresOn, Is.EqualTo(constants.Sas.KeyExpiry));
            Assert.That(sasQueryParameters.KeyService, Is.EqualTo(constants.Sas.KeyService));
            Assert.That(sasQueryParameters.KeyVersion, Is.EqualTo(constants.Sas.KeyVersion));
            Assert.That(sasQueryParameters.KeyDelegatedUserTenantId, Is.EqualTo(constants.Sas.KeyDelegatedTenantId));
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(Constants.Sas.Resource.Container));
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.DelegatedUserObjectId, Is.EqualTo(constants.Sas.DelegatedObjectId));
            Assert.That(sasQueryParameters.RequestHeaders, Is.EqualTo(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestHeaders)));
            Assert.That(sasQueryParameters.RequestQueryParameters, Is.EqualTo(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestQueryParameters)));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            AssertResponseHeaders(constants, sasQueryParameters);
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public void ToSasQueryParameters_BlobTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(
                includeBlob: true,
                includeSnapshot: false,
                includeDelegatedObjectId: false,
                includeRequestHeaders: false,
                includeRequestQueryParameters: false,
                containerName,
                blobName,
                constants);
            var signature = BuildSignature(includeBlob: true, includeSnapshot: false, containerName, blobName, constants);
            string stringToSign = null;

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential, out stringToSign);

            // Assert
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
            Assert.That(sasQueryParameters.Services, Is.Null);
            Assert.That(sasQueryParameters.ResourceTypes, Is.Null);
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(constants.Sas.Protocol));
            Assert.That(sasQueryParameters.StartsOn, Is.EqualTo(constants.Sas.StartTime));
            Assert.That(sasQueryParameters.ExpiresOn, Is.EqualTo(constants.Sas.ExpiryTime));
            Assert.That(sasQueryParameters.IPRange, Is.EqualTo(constants.Sas.IPRange));
            Assert.That(sasQueryParameters.Identifier, Is.EqualTo(constants.Sas.Identifier));
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(Constants.Sas.Resource.Blob));
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            AssertResponseHeaders(constants, sasQueryParameters);
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        public void ToSasQueryParameters_BlobIdentityTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(
                includeBlob: true,
                includeSnapshot: false,
                includeDelegatedObjectId: true,
                includeRequestHeaders: true,
                includeRequestQueryParameters: true,
                containerName,
                blobName,
                constants);
            var signature = BuildIdentitySignature(includeBlob: true, includeSnapshot: false, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(GetUserDelegationKey(constants), constants.Sas.Account);

            // Assert
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
            Assert.That(sasQueryParameters.Services, Is.Null);
            Assert.That(sasQueryParameters.ResourceTypes, Is.Null);
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(constants.Sas.Protocol));
            Assert.That(sasQueryParameters.StartsOn, Is.EqualTo(constants.Sas.StartTime));
            Assert.That(sasQueryParameters.ExpiresOn, Is.EqualTo(constants.Sas.ExpiryTime));
            Assert.That(sasQueryParameters.IPRange, Is.EqualTo(constants.Sas.IPRange));
            Assert.That(sasQueryParameters.Identifier, Is.Empty);
            Assert.That(sasQueryParameters.KeyObjectId, Is.EqualTo(constants.Sas.KeyObjectId));
            Assert.That(sasQueryParameters.KeyTenantId, Is.EqualTo(constants.Sas.KeyTenantId));
            Assert.That(sasQueryParameters.KeyStartsOn, Is.EqualTo(constants.Sas.KeyStart));
            Assert.That(sasQueryParameters.KeyExpiresOn, Is.EqualTo(constants.Sas.KeyExpiry));
            Assert.That(sasQueryParameters.KeyService, Is.EqualTo(constants.Sas.KeyService));
            Assert.That(sasQueryParameters.KeyVersion, Is.EqualTo(constants.Sas.KeyVersion));
            Assert.That(sasQueryParameters.KeyDelegatedUserTenantId, Is.EqualTo(constants.Sas.KeyDelegatedTenantId));
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(Constants.Sas.Resource.Blob));
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.DelegatedUserObjectId, Is.EqualTo(constants.Sas.DelegatedObjectId));
            Assert.That(sasQueryParameters.RequestHeaders, Is.EqualTo(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestHeaders)));
            Assert.That(sasQueryParameters.RequestQueryParameters, Is.EqualTo(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestQueryParameters)));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_12_06)]
        public void ToSasQueryParameters_SnapshotTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(
                includeBlob: true,
                includeSnapshot: true,
                includeDelegatedObjectId: false,
                includeRequestHeaders: false,
                includeRequestQueryParameters: false,
                containerName,
                blobName,
                constants);
            var signature = BuildSignature(includeBlob: true, includeSnapshot: true, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
            Assert.That(sasQueryParameters.Services, Is.Null);
            Assert.That(sasQueryParameters.ResourceTypes, Is.Null);
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(constants.Sas.Protocol));
            Assert.That(sasQueryParameters.StartsOn, Is.EqualTo(constants.Sas.StartTime));
            Assert.That(sasQueryParameters.ExpiresOn, Is.EqualTo(constants.Sas.ExpiryTime));
            Assert.That(sasQueryParameters.IPRange, Is.EqualTo(constants.Sas.IPRange));
            Assert.That(sasQueryParameters.Identifier, Is.EqualTo(constants.Sas.Identifier));
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(Constants.Sas.Resource.BlobSnapshot));
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2026_04_06)]
        public void ToSasQueryParameters_SnapshotIdentityTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(
                includeBlob: true,
                includeSnapshot: true,
                includeDelegatedObjectId: true,
                includeRequestHeaders: true,
                includeRequestQueryParameters: true,
                containerName,
                blobName,
                constants);
            string signature = BuildIdentitySignature(
                includeBlob: true,
                includeSnapshot: true,
                containerName,
                blobName,
                constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(GetUserDelegationKey(constants), constants.Sas.Account);

            // Assert
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
            Assert.That(sasQueryParameters.Services, Is.Null);
            Assert.That(sasQueryParameters.ResourceTypes, Is.Null);
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(constants.Sas.Protocol));
            Assert.That(sasQueryParameters.StartsOn, Is.EqualTo(constants.Sas.StartTime));
            Assert.That(sasQueryParameters.ExpiresOn, Is.EqualTo(constants.Sas.ExpiryTime));
            Assert.That(sasQueryParameters.IPRange, Is.EqualTo(constants.Sas.IPRange));
            Assert.That(sasQueryParameters.Identifier, Is.Empty);
            Assert.That(sasQueryParameters.KeyObjectId, Is.EqualTo(constants.Sas.KeyObjectId));
            Assert.That(sasQueryParameters.KeyTenantId, Is.EqualTo(constants.Sas.KeyTenantId));
            Assert.That(sasQueryParameters.KeyStartsOn, Is.EqualTo(constants.Sas.KeyStart));
            Assert.That(sasQueryParameters.KeyExpiresOn, Is.EqualTo(constants.Sas.KeyExpiry));
            Assert.That(sasQueryParameters.KeyService, Is.EqualTo(constants.Sas.KeyService));
            Assert.That(sasQueryParameters.KeyVersion, Is.EqualTo(constants.Sas.KeyVersion));
            Assert.That(sasQueryParameters.KeyDelegatedUserTenantId, Is.EqualTo(constants.Sas.KeyDelegatedTenantId));
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(Constants.Sas.Resource.BlobSnapshot));
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.DelegatedUserObjectId, Is.EqualTo(constants.Sas.DelegatedObjectId));
            Assert.That(sasQueryParameters.RequestHeaders, Is.EqualTo(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestHeaders)));
            Assert.That(sasQueryParameters.RequestQueryParameters, Is.EqualTo(SasExtensions.ConvertRequestDictToKeyList(constants.Sas.RequestQueryParameters)));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [RecordedTest]
        public void ToSasQueryParameters_NullSharedKeyCredentialTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(
                includeBlob: true,
                includeSnapshot: true,
                includeDelegatedObjectId: false,
                includeRequestHeaders: false,
                includeRequestQueryParameters: false,
                containerName,
                blobName,
                constants);

            // Act
            Assert.Throws<ArgumentNullException>(() => blobSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        [RecordedTest]
        public void ToSasQueryParameters_IdentifierTest()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string containerName = GetNewContainerName();
            string resource = "c";
            BlobSasBuilder sasBuilder = new BlobSasBuilder()
            {
                Identifier = constants.Sas.Identifier,
                BlobContainerName = containerName,
                Protocol = SasProtocol.Https,
                Resource = resource,
            };

            // Act
            BlobSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.That(sasQueryParameters.Identifier, Is.EqualTo(constants.Sas.Identifier));
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(SasProtocol.Https));
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(resource));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        [TestCase("IFTPUCALYXDWR")]
        [TestCase("rwdxylacuptfi")]
        public async Task AccountPermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = AccountSasServices.Blobs,
                ResourceTypes = AccountSasResourceTypes.All
            };

            accountSasBuilder.SetPermissions(permissionsString);

            Assert.That(accountSasBuilder.Permissions, Is.EqualTo("rwdxylacuptfi"));

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            Uri uri = new Uri($"{test.Container.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            BlobContainerClient sasContainerClient = new BlobContainerClient(uri, GetOptions());

            // Act
            await sasContainerClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountPermissionsRawPermissions_InvalidPermission()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

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
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_10_02)]
        [TestCase("IEMFTLYXDWCAR")]
        [TestCase("racwdxyltfmei")]
        public async Task ContainerPermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = test.Container.Name
            };

            blobSasBuilder.SetPermissions(
                rawPermissions: permissionsString,
                normalize: true);

            Assert.That(blobSasBuilder.Permissions, Is.EqualTo("racwdxyltfmei"));

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                Sas = blobSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            BlobContainerClient sasContainerClient = new BlobContainerClient(blobUriBuilder.ToUri(), GetOptions());

            // Act
            await foreach (BlobItem blobItem in sasContainerClient.GetBlobsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        [RecordedTest]
        public async Task ContainerPermissionsRawPermissions_Invalid()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = test.Container.Name
            };

            // Act
            TestHelper.AssertExpectedException(
                () => blobSasBuilder.SetPermissions(
                    rawPermissions: "ptsdfsd",
                    normalize: true),
                new ArgumentException("s is not a valid SAS permission"));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        [TestCase(BlobSasPermissions.Read)]
        [TestCase(BlobSasPermissions.Read | BlobSasPermissions.Write | BlobSasPermissions.List)]
        [TestCase(BlobSasPermissions.All)]
        public async Task SetPermissions_BlobSasPermissions(BlobSasPermissions permissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlobBaseClient blob = await GetNewBlobClient(test.Container);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = test.Container.Name,
                BlobName = blob.Name
            };
            blobSasBuilder.SetPermissions(permissions);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Sas = blobSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            BlobBaseClient sasBlobClient = InstrumentClient(new BlobBaseClient(blobUriBuilder.ToUri(), GetOptions()));

            // Act
            await sasBlobClient.ExistsAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        [TestCase(BlobContainerSasPermissions.List)]
        [TestCase(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.List)]
        [TestCase(BlobContainerSasPermissions.Move | BlobContainerSasPermissions.Execute | BlobContainerSasPermissions.List)]
        [TestCase(BlobContainerSasPermissions.All)]
        public async Task SetPermissions_BlobContainerSasPermissions(BlobContainerSasPermissions permissions)
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = test.Container.Name
            };

            blobSasBuilder.SetPermissions(permissions);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                Sas = blobSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            BlobContainerClient sasContainerClient = new BlobContainerClient(blobUriBuilder.ToUri(), GetOptions());

            // Act
            await foreach (BlobItem blobItem in sasContainerClient.GetBlobsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        private BlobSasBuilder BuildBlobSasBuilder(
            bool includeBlob,
            bool includeSnapshot,
            bool includeDelegatedObjectId,
            bool includeRequestHeaders,
            bool includeRequestQueryParameters,
            string containerName,
            string blobName, TestConstants constants)
        {
            var builder = new BlobSasBuilder
            {
                Version = null,
                Protocol = constants.Sas.Protocol,
                StartsOn = constants.Sas.StartTime,
                ExpiresOn = constants.Sas.ExpiryTime,
                IPRange = constants.Sas.IPRange,
                Identifier = constants.Sas.Identifier,
                BlobContainerName = containerName,
                BlobName = includeBlob ? blobName : null,
                Snapshot = includeSnapshot ? Snapshot : null,
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

            builder.SetPermissions(BlobAccountSasPermissions.Read | BlobAccountSasPermissions.Write | BlobAccountSasPermissions.Delete);
            return builder;
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task BlobSasBuilder_PreauthorizedAgentObjectId()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string preauthorizedAgentGuid = Recording.Random.NewGuid().ToString();

            await using DisposingContainer test = await GetTestContainerAsync(service: oauthService, containerName: containerName);

            // Arrange
            BlobGetUserDelegationKeyOptions getUserDelegationKeyOptions = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            BlobSasBuilder BlobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = containerName,
                PreauthorizedAgentObjectId = preauthorizedAgentGuid
            };
            BlobSasBuilder.SetPermissions(BlobSasPermissions.All);

            BlobUriBuilder BlobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                Sas = BlobSasBuilder.ToSasQueryParameters(userDelegationKey, test.Container.AccountName)
            };

            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(BlobUriBuilder.ToUri(), GetOptions()));

            // Act
            BlobClient blobClient = containerClient.GetBlobClient(GetNewBlobName());
            await blobClient.UploadAsync(new MemoryStream());
            await blobClient.ExistsAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        public async Task BlobSasBuilder_CorrelationId()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();

            await using DisposingContainer test = await GetTestContainerAsync(service: oauthService, containerName: containerName);

            // Arrange
            BlobGetUserDelegationKeyOptions getUserDelegationKeyOptions = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = containerName,
                CorrelationId = Recording.Random.NewGuid().ToString()
            };

            blobSasBuilder.SetPermissions(BlobSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey, test.Container.AccountName)
            };

            BlobContainerClient containerClient = InstrumentClient(new BlobContainerClient(blobUriBuilder.ToUri(), GetOptions()));

            // Act
            await foreach (BlobItem pathItem in containerClient.GetBlobsAsync())
            {
                // Just make sure the call succeeds.
            }
        }

        [RecordedTest]
        public async Task SasCredentialRequiresUriWithoutSasError_RedactedSasUri()
        {
            // Arrange
            BlobServiceClient oauthService = GetServiceClient_OAuth();
            string containerName = GetNewContainerName();

            await using DisposingContainer test = await GetTestContainerAsync(service: oauthService, containerName: containerName);

            BlobGetUserDelegationKeyOptions getUserDelegationKeyOptions = new BlobGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1))
            {
                StartsOn = Recording.UtcNow.AddHours(-1)
            };
            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                BlobContainerName = containerName,
            };

            blobSasBuilder.SetPermissions(BlobSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey, test.Container.AccountName)
            };

            Uri sasUri = blobUriBuilder.ToUri();

            UriBuilder uriBuilder = new UriBuilder(sasUri);
            uriBuilder.Query = "[REDACTED]";
            string redactedUri = uriBuilder.Uri.ToString();

            ArgumentException ex = Errors.SasCredentialRequiresUriWithoutSas<BlobUriBuilder>(sasUri);

            // Assert
            Assert.That(ex.Message.Contains(redactedUri), Is.True);
            Assert.That(ex.Message.Contains("st="), Is.False);
            Assert.That(ex.Message.Contains("se="), Is.False);
            Assert.That(ex.Message.Contains("sig="), Is.False);
        }

        private string BuildSignature(bool includeBlob, bool includeSnapshot, string containerName, string blobName, TestConstants constants)
        {
            var canonicalName = includeBlob ? $"/blob/{constants.Sas.Account}/{containerName}/{blobName}"
                : $"/blob/{constants.Sas.Account}/{containerName}";

            var resource = Constants.Sas.Resource.Container;

            if (includeBlob && includeSnapshot)
            {
                resource = Constants.Sas.Resource.BlobSnapshot;
            }
            else if (includeBlob)
            {
                resource = Constants.Sas.Resource.Blob;
            }

            var stringToSign = String.Join("\n",
                Permissions,
                SasExtensions.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                canonicalName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(constants.Sas.Protocol),
                SasQueryParametersInternals.DefaultSasVersionInternal,
                resource,
                includeSnapshot ? Snapshot : null,
                constants.Sas.EncryptionScope,
                constants.Sas.CacheControl,
                constants.Sas.ContentDisposition,
                constants.Sas.ContentEncoding,
                constants.Sas.ContentLanguage,
                constants.Sas.ContentType);

            return StorageSharedKeyCredentialInternals.ComputeSasSignature(constants.Sas.SharedKeyCredential, stringToSign);
        }

        private string BuildIdentitySignature(
            bool includeBlob,
            bool includeSnapshot,
            string containerName,
            string blobName,
            TestConstants constants)
        {
            var canonicalName = includeBlob ? $"/blob/{constants.Sas.Account}/{containerName}/{blobName}"
                : $"/blob/{constants.Sas.Account}/{containerName}";

            var resource = Constants.Sas.Resource.Container;

            if (includeBlob && includeSnapshot)
            {
                resource = Constants.Sas.Resource.BlobSnapshot;
            }
            else if (includeBlob)
            {
                resource = Constants.Sas.Resource.Blob;
            }

            var stringToSign = String.Join("\n",
                Permissions,
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
                constants.Sas.KeyDelegatedTenantId,
                constants.Sas.DelegatedObjectId,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(constants.Sas.Protocol),
                SasQueryParametersInternals.DefaultSasVersionInternal,
                resource,
                includeSnapshot ? Snapshot : null,
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
    }
}
