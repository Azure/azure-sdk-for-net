// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.TestConstants;

namespace Azure.Storage.Files.Shares.Tests
{
    public class FileSasBuilderTests : FileTestBase
    {
        private const string Permissions = "rcwd";

        public FileSasBuilderTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
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

        [Test]
        public void FileSasBuilder_IdentifierTest()
        {
            // Arrange
            TestConstants constants = new TestConstants(this);
            string shareName = GetNewShareName();
            string resource = "s";
            ShareSasBuilder sasBuilder = new ShareSasBuilder
            {
                Identifier = constants.Sas.Identifier,
                ShareName = shareName,
                Resource = resource,
                Protocol = SasProtocol.Https,
                Version = constants.Sas.Version
            };

            // Act
            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(resource, sasQueryParameters.Resource);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.Version, sasQueryParameters.Version);
        }

        [Test]
        [TestCase("FTPUCALXDWR")]
        [TestCase("rwdxlacuptf")]
        public async Task AccountPermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = AccountSasServices.Files,
                ResourceTypes = AccountSasResourceTypes.All
            };

            accountSasBuilder.SetPermissions(permissionsString);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            Uri uri = new Uri($"{test.Share.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            ShareClient sasShareClient = new ShareClient(uri, GetOptions());

            // Act
            await sasShareClient.GetPropertiesAsync();
        }

        [Test]
        public async Task AccountPermissionsRawPermissions_InvalidPermission()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

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
        [TestCase("LDWCR")]
        [TestCase("rcwdl")]
        public async Task SharePermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

            ShareSasBuilder blobSasBuilder = new ShareSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                ShareName = test.Share.Name
            };

            blobSasBuilder.SetPermissions(
                rawPermissions: permissionsString,
                normalize: true);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            ShareUriBuilder blobUriBuilder = new ShareUriBuilder(test.Share.Uri)
            {
                Sas = blobSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            ShareClient sasShareClient = new ShareClient(blobUriBuilder.ToUri(), GetOptions());

            // Act
            await sasShareClient.GetRootDirectoryClient().GetPropertiesAsync();
        }

        [Test]
        public async Task SharePermissionsRawPermissions_Invalid()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();
            ShareSasBuilder blobSasBuilder = new ShareSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                ShareName = test.Share.Name
            };

            // Act
            TestHelper.AssertExpectedException(
                () => blobSasBuilder.SetPermissions(
                    rawPermissions: "ptsdfsd",
                    normalize: true),
                new ArgumentException("s is not a valid SAS permission"));
        }

        [Test]
        public void ShareUriBuilder_LocalDockerUrl_PortTest()
        {
            // Arrange
            // BlobEndpoint from https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator#connect-to-the-emulator-account-using-the-well-known-account-name-and-key
            var uriString = "http://docker_container:10000/devstoreaccount1/sharename";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", fileUriBuilder.Scheme);
            Assert.AreEqual("docker_container", fileUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", fileUriBuilder.AccountName);
            Assert.AreEqual("sharename", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("", fileUriBuilder.Query);
            Assert.AreEqual(10000, fileUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void ShareUriBuilder_CustomUri_AccountShareFileTest()
        {
            // Arrange
            var uriString = "https://www.mycustomname.com/sharename/filename";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("www.mycustomname.com", fileUriBuilder.Host);
            Assert.AreEqual(String.Empty, fileUriBuilder.AccountName);
            Assert.AreEqual("sharename", fileUriBuilder.ShareName);
            Assert.AreEqual("filename", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("", fileUriBuilder.Query);
            Assert.AreEqual(443, fileUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
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
                SasExtensions.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                canonicalName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(constants.Sas.Protocol),
                includeVersion ? constants.Sas.Version : SasQueryParameters.DefaultSasVersion,
                constants.Sas.CacheControl,
                constants.Sas.ContentDisposition,
                constants.Sas.ContentEncoding,
                constants.Sas.ContentLanguage,
                constants.Sas.ContentType);

            return StorageSharedKeyCredentialInternals.ComputeSasSignature(constants.Sas.SharedKeyCredential, stringToSign);
        }
    }
}
