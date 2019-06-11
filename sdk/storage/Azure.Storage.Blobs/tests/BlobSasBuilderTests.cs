// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Blobs.Test
{
    [TestFixture]
    public class BlobSasBuilderTests
    {
        private const string Permissions = "rwd";
        private static readonly string ContainerName = TestHelper.GetNewContainerName();
        private static readonly string BlobName = TestHelper.GetNewBlobName();
        private static readonly string Snapshot = "snapshot";

        public static readonly UserDelegationKey UserDelegationKey = new UserDelegationKey
        {
            SignedOid = TestConstants.Sas.KeyOid,
            SignedTid = TestConstants.Sas.KeyTid,
            SignedStart = TestConstants.Sas.KeyStart,
            SignedExpiry = TestConstants.Sas.KeyExpiry,
            SignedService = TestConstants.Sas.KeyService,
            SignedVersion = TestConstants.Sas.KeyVersion,
            Value = TestConstants.Sas.KeyValue
        };

        [Test]
        public void ToSasQueryParameters_ContainerTest()
        {
            // Arrange
            var blobSasBuilder = this.BuildBlobSasBuilder(includeBlob: false, includeSnapshot: false);
            var signature = this.BuildSignature(includeBlob: false, includeSnapshot: false);

            // Act
            var sasQueryParameters = blobSasBuilder.ToSasQueryParameters(TestConstants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(TestConstants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.Container, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void ToSasQueryParameters_ContainerIdentityTest()
        {
            // Arrange
            var blobSasBuilder = this.BuildBlobSasBuilder(includeBlob: false, includeSnapshot: false);
            var signature = this.BuildIdentitySignature(includeBlob: false, includeSnapshot: false);

            // Act
            var sasQueryParameters = blobSasBuilder.ToSasQueryParameters(UserDelegationKey, TestConstants.Sas.Account);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(String.Empty, sasQueryParameters.Identifier);
            Assert.AreEqual(TestConstants.Sas.KeyOid, sasQueryParameters.KeyOid);
            Assert.AreEqual(TestConstants.Sas.KeyTid, sasQueryParameters.KeyTid);
            Assert.AreEqual(TestConstants.Sas.KeyStart, sasQueryParameters.KeyStart);
            Assert.AreEqual(TestConstants.Sas.KeyExpiry, sasQueryParameters.KeyExpiry);
            Assert.AreEqual(TestConstants.Sas.KeyService, sasQueryParameters.KeyService);
            Assert.AreEqual(TestConstants.Sas.KeyVersion, sasQueryParameters.KeyVersion);
            Assert.AreEqual(Constants.Sas.Resource.Container, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void ToSasQueryParameters_BlobTest()
        {
            // Arrange
            var blobSasBuilder = this.BuildBlobSasBuilder(includeBlob: true, includeSnapshot: false);
            var signature = this.BuildSignature(includeBlob: true, includeSnapshot: false);

            // Act
            var sasQueryParameters = blobSasBuilder.ToSasQueryParameters(TestConstants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(TestConstants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.Blob, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void ToSasQueryParameters_BlobIdentityTest()
        {
            // Arrange
            var blobSasBuilder = this.BuildBlobSasBuilder(includeBlob: true, includeSnapshot: false);
            var signature = this.BuildIdentitySignature(includeBlob: true, includeSnapshot: false);

            // Act
            var sasQueryParameters = blobSasBuilder.ToSasQueryParameters(UserDelegationKey, TestConstants.Sas.Account);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(String.Empty, sasQueryParameters.Identifier);
            Assert.AreEqual(TestConstants.Sas.KeyOid, sasQueryParameters.KeyOid);
            Assert.AreEqual(TestConstants.Sas.KeyTid, sasQueryParameters.KeyTid);
            Assert.AreEqual(TestConstants.Sas.KeyStart, sasQueryParameters.KeyStart);
            Assert.AreEqual(TestConstants.Sas.KeyExpiry, sasQueryParameters.KeyExpiry);
            Assert.AreEqual(TestConstants.Sas.KeyService, sasQueryParameters.KeyService);
            Assert.AreEqual(TestConstants.Sas.KeyVersion, sasQueryParameters.KeyVersion);
            Assert.AreEqual(Constants.Sas.Resource.Blob, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void ToSasQueryParameters_SnapshotTest()
        {
            // Arrange
            var blobSasBuilder = this.BuildBlobSasBuilder(includeBlob: true, includeSnapshot: true);
            var signature = this.BuildSignature(includeBlob: true, includeSnapshot: true);

            // Act
            var sasQueryParameters = blobSasBuilder.ToSasQueryParameters(TestConstants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(TestConstants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.BlobSnapshot, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void ToSasQueryParameters_SnapshotIdentityTest()
        {
            // Arrange
            var blobSasBuilder = this.BuildBlobSasBuilder(includeBlob: true, includeSnapshot: true);
            var signature = this.BuildIdentitySignature(includeBlob: true, includeSnapshot: true);

            // Act
            var sasQueryParameters = blobSasBuilder.ToSasQueryParameters(UserDelegationKey, TestConstants.Sas.Account);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(String.Empty, sasQueryParameters.Identifier);
            Assert.AreEqual(TestConstants.Sas.KeyOid, sasQueryParameters.KeyOid);
            Assert.AreEqual(TestConstants.Sas.KeyTid, sasQueryParameters.KeyTid);
            Assert.AreEqual(TestConstants.Sas.KeyStart, sasQueryParameters.KeyStart);
            Assert.AreEqual(TestConstants.Sas.KeyExpiry, sasQueryParameters.KeyExpiry);
            Assert.AreEqual(TestConstants.Sas.KeyService, sasQueryParameters.KeyService);
            Assert.AreEqual(TestConstants.Sas.KeyVersion, sasQueryParameters.KeyVersion);
            Assert.AreEqual(Constants.Sas.Resource.BlobSnapshot, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void ToSasQueryParameters_NullSharedKeyCredentialTest()
        {
            // Arrange
            var blobSasBuilder = this.BuildBlobSasBuilder(includeBlob: true, includeSnapshot: true);

            // Act
            Assert.Throws<ArgumentNullException>(() => blobSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        private BlobSasBuilder BuildBlobSasBuilder(bool includeBlob, bool includeSnapshot)
            => new BlobSasBuilder
            {
                Version = null,
                Protocol = TestConstants.Sas.Protocol,
                StartTime = TestConstants.Sas.StartTime,
                ExpiryTime = TestConstants.Sas.ExpiryTime,
                Permissions = Permissions,
                IPRange = TestConstants.Sas.IPRange,
                Identifier = TestConstants.Sas.Identifier,
                ContainerName = ContainerName,
                BlobName = includeBlob ? BlobName : null,
                Snapshot = includeSnapshot ? Snapshot : null,
                CacheControl = TestConstants.Sas.CacheControl,
                ContentDisposition = TestConstants.Sas.ContentDisposition,
                ContentEncoding = TestConstants.Sas.ContentEncoding,
                ContentLanguage = TestConstants.Sas.ContentLanguage,
                ContentType = TestConstants.Sas.ContentType
            };

        private string BuildSignature(bool includeBlob, bool includeSnapshot)
        {
            var canonicalName = includeBlob ? $"/blob/{TestConstants.Sas.Account}/{ContainerName}/{BlobName}"
                : $"/blob/{TestConstants.Sas.Account}/{ContainerName}";

            var resource = Constants.Sas.Resource.Container;

            if(includeBlob && includeSnapshot)
            {
                resource = Constants.Sas.Resource.BlobSnapshot;
            }
            else if(includeBlob)
            {
                resource = Constants.Sas.Resource.Blob;
            }

            var stringToSign = String.Join("\n",
                Permissions,
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.ExpiryTime),
                canonicalName,
                TestConstants.Sas.Identifier,
                TestConstants.Sas.IPRange.ToString(),
                TestConstants.Sas.Protocol.ToString(),
                SasQueryParameters.SasVersion,
                resource,
                includeSnapshot ? Snapshot : null,
                TestConstants.Sas.CacheControl,
                TestConstants.Sas.ContentDisposition,
                TestConstants.Sas.ContentEncoding,
                TestConstants.Sas.ContentLanguage,
                TestConstants.Sas.ContentType);

            return TestConstants.Sas.SharedKeyCredential.ComputeHMACSHA256(stringToSign);
        }

        private string BuildIdentitySignature(bool includeBlob, bool includeSnapshot)
        {
            var canonicalName = includeBlob ? $"/blob/{TestConstants.Sas.Account}/{ContainerName}/{BlobName}"
                : $"/blob/{TestConstants.Sas.Account}/{ContainerName}";

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
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.ExpiryTime),
                canonicalName,
                TestConstants.Sas.KeyOid,
                TestConstants.Sas.KeyTid,
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.KeyStart),
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.KeyExpiry),
                TestConstants.Sas.KeyService,
                TestConstants.Sas.KeyVersion,
                TestConstants.Sas.IPRange.ToString(),
                TestConstants.Sas.Protocol.ToString(),
                SasQueryParameters.SasVersion,
                resource,
                includeSnapshot ? Snapshot : null,
                TestConstants.Sas.CacheControl,
                TestConstants.Sas.ContentDisposition,
                TestConstants.Sas.ContentEncoding,
                TestConstants.Sas.ContentLanguage,
                TestConstants.Sas.ContentType);

            return this.ComputeHMACSHA256(TestConstants.Sas.KeyValue, stringToSign);
        }

        private string ComputeHMACSHA256(string userDelegationKeyValue, string message) =>
            Convert.ToBase64String(
                new HMACSHA256(
                    Convert.FromBase64String(userDelegationKeyValue))
                .ComputeHash(Encoding.UTF8.GetBytes(message)));
    }
}
