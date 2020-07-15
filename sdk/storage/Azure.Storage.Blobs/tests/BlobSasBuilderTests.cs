// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
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
                Value = constants.Sas.KeyValue
            };

        [Test]
        public void ToSasQueryParameters_ContainerTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(includeBlob: false, includeSnapshot: false, containerName, blobName, constants);
            var signature = BuildSignature(includeBlob: false, includeSnapshot: false, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(constants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.Container, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void ToSasQueryParameters_ContainerIdentityTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(includeBlob: false, includeSnapshot: false, containerName, blobName, constants);
            var signature = BuildIdentitySignature(includeBlob: false, includeSnapshot: false, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(GetUserDelegationKey(constants), constants.Sas.Account);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
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
            Assert.AreEqual(Constants.Sas.Resource.Container, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void ToSasQueryParameters_BlobTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(includeBlob: true, includeSnapshot: false, containerName, blobName, constants);
            var signature = BuildSignature(includeBlob: true, includeSnapshot: false, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(constants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.Blob, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void ToSasQueryParameters_BlobIdentityTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(includeBlob: true, includeSnapshot: false, containerName, blobName, constants);
            var signature = BuildIdentitySignature(includeBlob: true, includeSnapshot: false, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(GetUserDelegationKey(constants), constants.Sas.Account);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
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
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void ToSasQueryParameters_SnapshotTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(includeBlob: true, includeSnapshot: true, containerName, blobName, constants);
            var signature = BuildSignature(includeBlob: true, includeSnapshot: true, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(constants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.BlobSnapshot, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void ToSasQueryParameters_SnapshotIdentityTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(includeBlob: true, includeSnapshot: true, containerName, blobName, constants);
            var signature = BuildIdentitySignature(includeBlob: true, includeSnapshot: true, containerName, blobName, constants);

            // Act
            BlobSasQueryParameters sasQueryParameters = blobSasBuilder.ToSasQueryParameters(GetUserDelegationKey(constants), constants.Sas.Account);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
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
            Assert.AreEqual(Constants.Sas.Resource.BlobSnapshot, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void ToSasQueryParameters_NullSharedKeyCredentialTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();
            BlobSasBuilder blobSasBuilder = BuildBlobSasBuilder(includeBlob: true, includeSnapshot: true, containerName, blobName, constants);

            // Act
            Assert.Throws<ArgumentNullException>(() => blobSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        [Test]
        public void ToSasQueryParameters_IdentifierTest()
        {
            // Arrange
            TestConstants constants = new TestConstants(this);
            string containerName = GetNewContainerName();
            string resource = "c";
            BlobSasBuilder sasBuilder = new BlobSasBuilder()
            {
                Identifier = constants.Sas.Identifier,
                BlobContainerName = containerName,
                Protocol = SasProtocol.Https,
                Resource = resource,
                Version = constants.Sas.Version
            };

            // Act
            BlobSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(resource, sasQueryParameters.Resource);
            Assert.AreEqual(constants.Sas.Version, sasQueryParameters.Version);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase("FTPUCALXDWR")]
        [TestCase("rwdxlacuptf")]
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

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            Uri uri = new Uri($"{test.Container.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            BlobContainerClient sasContainerClient = new BlobContainerClient(uri, GetOptions());

            // Act
            await sasContainerClient.GetPropertiesAsync();
        }

        [Test]
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

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase("TLXDWCAR")]
        [TestCase("racwdxlt")]
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

        [Test]
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

        private BlobSasBuilder BuildBlobSasBuilder(bool includeBlob, bool includeSnapshot, string containerName, string blobName, TestConstants constants)
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
                ContentType = constants.Sas.ContentType
            };
            builder.SetPermissions(BlobAccountSasPermissions.Read | BlobAccountSasPermissions.Write | BlobAccountSasPermissions.Delete);
            return builder;
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
                SasQueryParameters.DefaultSasVersion,
                resource,
                includeSnapshot ? Snapshot : null,
                constants.Sas.CacheControl,
                constants.Sas.ContentDisposition,
                constants.Sas.ContentEncoding,
                constants.Sas.ContentLanguage,
                constants.Sas.ContentType);

            return StorageSharedKeyCredentialInternals.ComputeSasSignature(constants.Sas.SharedKeyCredential, stringToSign);
        }

        private string BuildIdentitySignature(bool includeBlob, bool includeSnapshot, string containerName, string blobName, TestConstants constants)
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
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(constants.Sas.Protocol),
                SasQueryParameters.DefaultSasVersion,
                resource,
                includeSnapshot ? Snapshot : null,
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
