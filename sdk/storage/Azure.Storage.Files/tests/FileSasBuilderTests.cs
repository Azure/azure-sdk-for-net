// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Test;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Files.Test
{
    [TestFixture]
    public class FileSasBuilderTests
    {
        private static readonly string ShareName = TestHelper.GetNewShareName();
        private static readonly string FilePath = TestHelper.GetNewDirectoryName();
        private const string Permissions = "rcwd";

        [Test]
        public void FileSasBuilder_ToSasQueryParameters_FilePathTest()
        {
            // Arrange
            var fileSasBuilder = this.BuildFileSasBuilder(includeVersion: true, includeFilePath: true);
            var signature = this.BuildSignature(includeFilePath: true, includeVersion: true);

            // Act
            var sasQueryParameters = fileSasBuilder.ToSasQueryParameters(TestConstants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(TestConstants.Sas.Version, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(TestConstants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.File, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void FileSasBuilder_ToSasQueryParameters_NoVersionTest()
        {
            // Arrange
            var fileSasBuilder = this.BuildFileSasBuilder(includeVersion: false, includeFilePath: false);
            var signature = this.BuildSignature(includeFilePath: false, includeVersion: false);

            // Act
            var sasQueryParameters = fileSasBuilder.ToSasQueryParameters(TestConstants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(TestConstants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(TestConstants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(Constants.Sas.Resource.Share, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void FileSasBuilder_NullSharedKeyCredentialTest()
        {
            // Arrange
            var fileSasBuilder = this.BuildFileSasBuilder(includeVersion: true, includeFilePath: true);

            // Act
            Assert.Throws<ArgumentNullException>(() => fileSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        private FileSasBuilder BuildFileSasBuilder(bool includeVersion, bool includeFilePath)
        {
            var fileSasBuilder = new FileSasBuilder
            {
                Version = null,
                Protocol = TestConstants.Sas.Protocol,
                StartTime = TestConstants.Sas.StartTime,
                ExpiryTime = TestConstants.Sas.ExpiryTime,
                Permissions = Permissions,
                IPRange = TestConstants.Sas.IPRange,
                Identifier = TestConstants.Sas.Identifier,
                ShareName = ShareName,
                FilePath = "",
                CacheControl = TestConstants.Sas.CacheControl,
                ContentDisposition = TestConstants.Sas.ContentDisposition,
                ContentEncoding = TestConstants.Sas.ContentEncoding,
                ContentLanguage = TestConstants.Sas.ContentLanguage,
                ContentType = TestConstants.Sas.ContentType
            };

            if (includeVersion)
            {
                fileSasBuilder.Version = TestConstants.Sas.Version;
            }

            if(includeFilePath)
            {
                fileSasBuilder.FilePath = FilePath;
            }

            return fileSasBuilder;
        }

        private string BuildSignature(bool includeFilePath, bool includeVersion)
        {
            var canonicalName = "/file/" + TestConstants.Sas.Account + "/" + ShareName;
            if(includeFilePath)
            {
                canonicalName += "/" + FilePath;
            }

            var stringToSign = String.Join("\n",
                Permissions,
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.ExpiryTime),
                canonicalName,
                TestConstants.Sas.Identifier,
                TestConstants.Sas.IPRange.ToString(),
                TestConstants.Sas.Protocol.ToString(),
                includeVersion ? TestConstants.Sas.Version : SasQueryParameters.SasVersion,
                TestConstants.Sas.CacheControl,
                TestConstants.Sas.ContentDisposition,
                TestConstants.Sas.ContentEncoding,
                TestConstants.Sas.ContentLanguage,
                TestConstants.Sas.ContentType);

            return TestConstants.Sas.SharedKeyCredential.ComputeHMACSHA256(stringToSign);
        }
    }
}
