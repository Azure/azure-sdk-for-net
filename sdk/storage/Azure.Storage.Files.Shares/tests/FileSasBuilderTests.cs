// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
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

        [RecordedTest]
        public void FileSasBuilder_ToSasQueryParameters_FilePathTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var shareName = GetNewShareName();
            var filePath = GetNewDirectoryName();
            ShareSasBuilder fileSasBuilder = BuildFileSasBuilder(includeFilePath: true, constants, shareName, filePath, includeDelegatedUserObjectId: false);
            var signature = BuildSignature(includeFilePath: true, constants, shareName, filePath);

            string stringToSign = null;

            // Act
            var sasQueryParameters = fileSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential, out stringToSign);

            // Assert
            Assert.AreEqual(SasQueryParametersInternals.DefaultSasVersionInternal, sasQueryParameters.Version);
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
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void FileSasBuilder_NullSharedKeyCredentialTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var shareName = GetNewShareName();
            var filePath = GetNewDirectoryName();
            ShareSasBuilder fileSasBuilder = BuildFileSasBuilder(includeFilePath: true, constants, shareName, filePath, includeDelegatedUserObjectId: false);

            // Act
            Assert.Throws<ArgumentNullException>(() => fileSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        [RecordedTest]
        public void FileSasBuilder_IdentifierTest()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string shareName = GetNewShareName();
            string resource = "s";
            ShareSasBuilder sasBuilder = new ShareSasBuilder
            {
                Identifier = constants.Sas.Identifier,
                ShareName = shareName,
                Resource = resource,
                Protocol = SasProtocol.Https,
            };

            // Act
            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(resource, sasQueryParameters.Resource);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(SasQueryParametersInternals.DefaultSasVersionInternal, sasQueryParameters.Version);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_10_02)]
        [TestCase("IFTPUCALYXDWR")]
        [TestCase("rwdxylacuptfi")]
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

            Assert.AreEqual("rwdxylacuptfi", accountSasBuilder.Permissions);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            Uri uri = new Uri($"{test.Share.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            ShareClient sasShareClient = new ShareClient(uri, GetOptions());

            // Act
            await sasShareClient.GetPropertiesAsync();
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task SasCredentialRequiresUriWithoutSasError_RedactedSasUri()
        {
            // Arrange
            await using DisposingShare test = await GetTestShareAsync();

            ShareSasBuilder fileSasBuilder = new ShareSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                ShareName = test.Share.Name
            };

            fileSasBuilder.SetPermissions(
                rawPermissions: "LDWCR",
                normalize: true);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            ShareUriBuilder fileUriBuilder = new ShareUriBuilder(test.Share.Uri)
            {
                Sas = fileSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            Uri sasUri = fileUriBuilder.ToUri();

            UriBuilder uriBuilder = new UriBuilder(sasUri);
            uriBuilder.Query = "[REDACTED]";
            string redactedUri = uriBuilder.Uri.ToString();

            ArgumentException ex = Errors.SasCredentialRequiresUriWithoutSas<ShareUriBuilder>(sasUri);

            // Assert
            Assert.IsTrue(ex.Message.Contains(redactedUri));
            Assert.IsFalse(ex.Message.Contains("st="));
            Assert.IsFalse(ex.Message.Contains("se="));
            Assert.IsFalse(ex.Message.Contains("sig="));
        }

        [RecordedTest]
        public void ShareSasBuilder_ToSasQuerParameters_IdentitySas()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            string shareName = GetNewShareName();
            string filePath = GetNewDirectoryName();
            ShareSasBuilder fileSasBuilder = BuildFileSasBuilder(includeFilePath: true, constants, shareName, filePath, includeDelegatedUserObjectId: true);
            string signature = BuildUserDelegationSasSignature(includeFilePath: true, constants, shareName, filePath);
            string stringToSign = null;

            // Act
            ShareSasQueryParameters sasQueryParameters = fileSasBuilder.ToSasQueryParameters(
                GetUserDelegationKey(constants),
                constants.Sas.Account,
                out stringToSign);

            // Assert
            Assert.AreEqual(SasQueryParametersInternals.DefaultSasVersionInternal, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(constants.Sas.Protocol, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(string.Empty, sasQueryParameters.Identifier);
            Assert.AreEqual(constants.Sas.KeyObjectId, sasQueryParameters.KeyObjectId);
            Assert.AreEqual(constants.Sas.KeyTenantId, sasQueryParameters.KeyTenantId);
            Assert.AreEqual(constants.Sas.KeyStart, sasQueryParameters.KeyStartsOn);
            Assert.AreEqual(constants.Sas.KeyExpiry, sasQueryParameters.KeyExpiresOn);
            Assert.AreEqual(constants.Sas.KeyService, sasQueryParameters.KeyService);
            Assert.AreEqual(constants.Sas.KeyVersion, sasQueryParameters.KeyVersion);
            Assert.AreEqual(constants.Sas.KeyDelegatedTenantId, sasQueryParameters.KeyDelegatedUserTenantId);
            Assert.AreEqual(Constants.Sas.Resource.File, sasQueryParameters.Resource);
            Assert.AreEqual(constants.Sas.CacheControl, sasQueryParameters.CacheControl);
            Assert.AreEqual(constants.Sas.ContentDisposition, sasQueryParameters.ContentDisposition);
            Assert.AreEqual(constants.Sas.ContentEncoding, sasQueryParameters.ContentEncoding);
            Assert.AreEqual(constants.Sas.ContentLanguage, sasQueryParameters.ContentLanguage);
            Assert.AreEqual(constants.Sas.ContentType, sasQueryParameters.ContentType);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(constants.Sas.DelegatedObjectId, sasQueryParameters.DelegatedUserObjectId);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            Assert.IsNotNull(stringToSign);
        }

        private ShareSasBuilder BuildFileSasBuilder(
            bool includeFilePath,
            TestConstants constants,
            string shareName,
            string filePath,
            bool includeDelegatedUserObjectId)
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

            if (includeFilePath)
            {
                fileSasBuilder.FilePath = filePath;
            }

            if (includeDelegatedUserObjectId)
            {
                fileSasBuilder.DelegatedUserObjectId = constants.Sas.DelegatedObjectId;
            }

            return fileSasBuilder;
        }

        private string BuildSignature(bool includeFilePath, TestConstants constants, string shareName, string filePath)
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
                SasQueryParametersInternals.DefaultSasVersionInternal,
                constants.Sas.CacheControl,
                constants.Sas.ContentDisposition,
                constants.Sas.ContentEncoding,
                constants.Sas.ContentLanguage,
                constants.Sas.ContentType);

            return StorageSharedKeyCredentialInternals.ComputeSasSignature(constants.Sas.SharedKeyCredential, stringToSign);
        }

        private string BuildUserDelegationSasSignature(
            bool includeFilePath,
            TestConstants constants,
            string shareName,
            string filePath)
        {
            string canonicalName = "/file/" + constants.Sas.Account + "/" + shareName;
            if (includeFilePath)
            {
                canonicalName += "/" + filePath;
            }

            string stringToSign = string.Join("\n",
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
                constants.Sas.KeyDelegatedTenantId,
                constants.Sas.DelegatedObjectId,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(constants.Sas.Protocol),
                SasQueryParametersInternals.DefaultSasVersionInternal,
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
    }
}
