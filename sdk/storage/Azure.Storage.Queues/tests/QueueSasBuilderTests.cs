// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.TestConstants;

namespace Azure.Storage.Queues.Test
{
    public class QueueSasBuilderTests : QueueTestBase
    {
        private const string Permissions = "raup";

        public QueueSasBuilderTests(bool async, QueueClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public void QueueSasBuilder_ToSasQueryParameters_IdentitySas()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            string queueName = GetNewQueueName();
            QueueSasBuilder queueSasBuilder = BuildQueueSasBuilder(constants, queueName);
            string signature = BuildUserDelegationSignature(constants, queueName);
            string stringToSign = null;

            // Act
            QueueSasQueryParameters sasQueryParameters = queueSasBuilder.ToSasQueryParameters(GetUserDelegationKey(constants), constants.Sas.Account, out stringToSign);

            // Assert
            Assert.AreEqual(SasQueryParametersInternals.DefaultSasVersionInternal, sasQueryParameters.Version);
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
            Assert.AreEqual(Constants.Sas.Resource.Queue, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(constants.Sas.DelegatedObjectId, sasQueryParameters.DelegatedUserObjectId);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void QueueSasBuilder_ToSasQueryParameters_VersionTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var queueName = GetNewQueueName();
            QueueSasBuilder queueSasBuilder = BuildQueueSasBuilder(constants, queueName);
            var signature = BuildSignature(constants, queueName);

            string stringToSign = null;

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential, out stringToSign);

            // Assert
            Assert.AreEqual(SasQueryParametersInternals.DefaultSasVersionInternal, sasQueryParameters.Version);
            Assert.IsNull(sasQueryParameters.Services);
            Assert.IsNull(sasQueryParameters.ResourceTypes);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartsOn);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiresOn);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(string.Empty, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void QueueSasBuilder_NullSharedKeyCredentialTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var queueName = GetNewQueueName();
            QueueSasBuilder queueSasBuilder = BuildQueueSasBuilder(constants, queueName);

            // Act
            Assert.Throws<ArgumentNullException>(() => queueSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        [RecordedTest]
        public void ToSasQueryParameters_IdentifierTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var queueName = GetNewQueueName();

            QueueSasBuilder sasBuilder = new QueueSasBuilder
            {
                Identifier = constants.Sas.Identifier,
                QueueName = queueName,
                Protocol = SasProtocol.Https,
            };

            // Act
            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(SasQueryParametersInternals.DefaultSasVersionInternal, sasQueryParameters.Version);
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2020_10_02)]
        [TestCase("IFTPUCALYXDWR")]
        [TestCase("rwdxylacuptfi")]
        public async Task AccountPermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = AccountSasServices.Queues,
                ResourceTypes = AccountSasResourceTypes.All
            };

            accountSasBuilder.SetPermissions(permissionsString);

            Assert.AreEqual("rwdxylacuptfi", accountSasBuilder.Permissions);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            Uri uri = new Uri($"{test.Queue.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            QueueClient queueClient = new QueueClient(uri, GetOptions());

            // Act
            await queueClient.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task AccountPermissionsRawPermissions_InvalidPermission()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = AccountSasServices.Queues,
                ResourceTypes = AccountSasResourceTypes.All
            };

            TestHelper.AssertExpectedException(
                () => accountSasBuilder.SetPermissions("werteyfg"),
                new ArgumentException("e is not a valid SAS permission"));
        }

        [RecordedTest]
        [TestCase("PUAR")]
        [TestCase("raup")]
        public async Task QueuePermissionsRawPermissions(string permissionsString)
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                QueueName = test.Queue.Name
            };

            queueSasBuilder.SetPermissions(
                rawPermissions: permissionsString,
                normalize: true);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            QueueUriBuilder queueUriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = queueSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            QueueClient sasQueueClient = new QueueClient(queueUriBuilder.ToUri(), GetOptions());

            // Act
            await sasQueueClient.PeekMessagesAsync();
        }

        [RecordedTest]
        public async Task QueuePermissionsRawPermissions_Invalid()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                QueueName = test.Queue.Name
            };

            // Act
            TestHelper.AssertExpectedException(
                () => queueSasBuilder.SetPermissions(
                    rawPermissions: "ptsdfsd",
                    normalize: true),
                new ArgumentException("s is not a valid SAS permission"));
        }

        [RecordedTest]
        public void QueueUriBuilder_LocalDockerUrl_PortTest()
        {
            // Arrange
            // BlobEndpoint from https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator#connect-to-the-emulator-account-using-the-well-known-account-name-and-key
            var uriString = "http://docker_container:10000/devstoreaccount1/sharename";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", fileUriBuilder.Scheme);
            Assert.AreEqual("docker_container", fileUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", fileUriBuilder.AccountName);
            Assert.AreEqual("sharename", fileUriBuilder.QueueName);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("", fileUriBuilder.Query);
            Assert.AreEqual(10000, fileUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void QueueUriBuilder_CustomUri_AccountShareFileTest()
        {
            // Arrange
            var uriString = "https://www.mycustomname.com/queuename";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new QueueUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("www.mycustomname.com", fileUriBuilder.Host);
            Assert.AreEqual(String.Empty, fileUriBuilder.AccountName);
            Assert.AreEqual("queuename", fileUriBuilder.QueueName);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("", fileUriBuilder.Query);
            Assert.AreEqual(443, fileUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public async Task SasCredentialRequiresUriWithoutSasError_RedactedSasUri()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder
            {
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1),
                QueueName = test.Queue.Name
            };

            queueSasBuilder.SetPermissions(
                rawPermissions: "raup",
                normalize: true);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            QueueUriBuilder queueUriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = queueSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            Uri sasUri = queueUriBuilder.ToUri();

            UriBuilder uriBuilder = new UriBuilder(sasUri);
            uriBuilder.Query = "[REDACTED]";
            string redactedUri = uriBuilder.Uri.ToString();

            ArgumentException ex = Errors.SasCredentialRequiresUriWithoutSas<QueueUriBuilder>(sasUri);

            // Assert
            Assert.IsTrue(ex.Message.Contains(redactedUri));
            Assert.IsFalse(ex.Message.Contains("st="));
            Assert.IsFalse(ex.Message.Contains("se="));
            Assert.IsFalse(ex.Message.Contains("sig="));
        }

        private QueueSasBuilder BuildQueueSasBuilder(TestConstants constants, string queueName)
        {
            var queueSasBuilder = new QueueSasBuilder
            {
                Version = null,
                Protocol = constants.Sas.Protocol,
                StartsOn = constants.Sas.StartTime,
                ExpiresOn = constants.Sas.ExpiryTime,
                IPRange = constants.Sas.IPRange,
                Identifier = constants.Sas.Identifier,
                QueueName = queueName,
                DelegatedUserObjectId = constants.Sas.DelegatedObjectId,
            };
            queueSasBuilder.SetPermissions(Permissions);

            return queueSasBuilder;
        }

        private string BuildSignature(TestConstants constants, string queueName)
        {
            var stringToSign = string.Join("\n",
                Permissions,
                SasExtensions.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                "/queue/" + constants.Sas.Account + "/" + queueName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(SasProtocol.Https),
                SasQueryParametersInternals.DefaultSasVersionInternal);

            return StorageSharedKeyCredentialInternals.ComputeSasSignature(constants.Sas.SharedKeyCredential, stringToSign);
        }

        private string BuildUserDelegationSignature(TestConstants constants, string queueName)
        {
            var stringToSign = string.Join("\n",
                Permissions,
                SasExtensions.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                "/queue/" + constants.Sas.Account + "/" + queueName,
                constants.Sas.KeyObjectId,
                constants.Sas.KeyTenantId,
                SasExtensions.FormatTimesForSasSigning(constants.Sas.KeyStart),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.KeyExpiry),
                constants.Sas.KeyService,
                constants.Sas.KeyVersion,
                null,
                constants.Sas.DelegatedObjectId,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(SasProtocol.Https),
                SasQueryParametersInternals.DefaultSasVersionInternal);

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
                Value = constants.Sas.KeyValue
            };
    }
}
