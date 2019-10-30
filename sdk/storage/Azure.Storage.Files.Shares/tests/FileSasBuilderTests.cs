// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Sas;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Files.Test
{
    public class FileSasBuilderTests : FileTestBase
    {
        private const string Permissions = "rcwd";

        public FileSasBuilderTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void FileSasBuilder_ToSasQueryParameters_FilePathTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var shareName = GetNewShareName();
            var filePath = GetNewDirectoryName();
            ShareSasBuilder fileSasBuilder = BuildFileSasBuilder(includeVersion: true, includeFilePath: true, constants, shareName, filePath);
            var signature = BuildSignature(includeFilePath: true, includeVersion: true, constants, shareName, filePath);

            // Act
            var sasQueryParameters = fileSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Version, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(constants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.File, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void FileSasBuilder_ToSasQueryParameters_NoVersionTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var shareName = GetNewShareName();
            var filePath = GetNewDirectoryName();
            ShareSasBuilder fileSasBuilder = BuildFileSasBuilder(includeVersion: false, includeFilePath: false, constants, shareName, filePath);
            var signature = BuildSignature(includeFilePath: false, includeVersion: false, constants, shareName, filePath);

            // Act
            var sasQueryParameters = fileSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(constants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.Share, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            AssertResponseHeaders(constants, sasQueryParameters);
        }

        [Test]
        public void FileSasBuilder_NullSharedKeyCredentialTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var shareName = GetNewShareName();
            var filePath = GetNewDirectoryName();
            ShareSasBuilder fileSasBuilder = BuildFileSasBuilder(includeVersion: true, includeFilePath: true, constants, shareName, filePath);

            // Act
            Assert.Throws<ArgumentNullException>(() => fileSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        private ShareSasBuilder BuildFileSasBuilder(bool includeVersion, bool includeFilePath, TestConstants constants, string shareName, string filePath)
        {
            var fileSasBuilder = new ShareSasBuilder
            {
                Version = null,
                Protocol = constants.Sas.Protocol,
                StartsOn = constants.Sas.StartTime,
                ExpiresOn = constants.Sas.ExpiryTime,
                IPRange = constants.Sas.IPRange,
                Identifier = constants.Sas.Identifier,
                ShareName = shareName,
                FilePath = "",
                CacheControl = constants.Sas.CacheControl,
                ContentDisposition = constants.Sas.ContentDisposition,
                ContentEncoding = constants.Sas.ContentEncoding,
                ContentLanguage = constants.Sas.ContentLanguage,
                ContentType = constants.Sas.ContentType
            };
            fileSasBuilder.SetPermissions(ShareFileSasPermissions.All);

            if (includeVersion)
            {
                fileSasBuilder.Version = constants.Sas.Version;
            }

            if (includeFilePath)
            {
                fileSasBuilder.FilePath = filePath;
            }

            return fileSasBuilder;
        }

        private string BuildSignature(bool includeFilePath, bool includeVersion, TestConstants constants, string shareName, string filePath)
        {
            var canonicalName = "/file/" + constants.Sas.Account + "/" + shareName;
            if (includeFilePath)
            {
                canonicalName += "/" + filePath;
            }

            var stringToSign = string.Join("\n",
                Permissions,
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                canonicalName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                constants.Sas.Protocol.ToProtocolString(),
                includeVersion ? constants.Sas.Version : SasQueryParameters.DefaultSasVersion,
                constants.Sas.CacheControl,
                constants.Sas.ContentDisposition,
                constants.Sas.ContentEncoding,
                constants.Sas.ContentLanguage,
                constants.Sas.ContentType);

            return constants.Sas.SharedKeyCredential.ComputeHMACSHA256(stringToSign);
        }
    }
}
