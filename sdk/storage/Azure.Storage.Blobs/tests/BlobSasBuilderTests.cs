// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Blobs.Test
{
    public class BlobSasBuilderTests : BlobTestBase
    {
        private const string Permissions = "rwd";
        private static readonly string Snapshot = "snapshot";

        public BlobSasBuilderTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
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
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                canonicalName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                constants.Sas.Protocol.ToProtocolString(),
                SasQueryParameters.DefaultSasVersion,
                resource,
                includeSnapshot ? Snapshot : null,
                constants.Sas.CacheControl,
                constants.Sas.ContentDisposition,
                constants.Sas.ContentEncoding,
                constants.Sas.ContentLanguage,
                constants.Sas.ContentType);

            return constants.Sas.SharedKeyCredential.ComputeHMACSHA256(stringToSign);
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
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                canonicalName,
                constants.Sas.KeyObjectId,
                constants.Sas.KeyTenantId,
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.KeyStart),
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.KeyExpiry),
                constants.Sas.KeyService,
                constants.Sas.KeyVersion,
                constants.Sas.IPRange.ToString(),
                constants.Sas.Protocol.ToProtocolString(),
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
