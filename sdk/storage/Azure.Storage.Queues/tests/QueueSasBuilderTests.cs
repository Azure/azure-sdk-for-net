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
            Assert.That(sasQueryParameters.Resource, Is.EqualTo(Constants.Sas.Resource.Queue));
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.DelegatedUserObjectId, Is.EqualTo(constants.Sas.DelegatedObjectId));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            Assert.That(stringToSign, Is.Not.Null);
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
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
            Assert.That(sasQueryParameters.Services, Is.Null);
            Assert.That(sasQueryParameters.ResourceTypes, Is.Null);
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(SasProtocol.Https));
            Assert.That(sasQueryParameters.StartsOn, Is.EqualTo(constants.Sas.StartTime));
            Assert.That(sasQueryParameters.ExpiresOn, Is.EqualTo(constants.Sas.ExpiryTime));
            Assert.That(sasQueryParameters.IPRange, Is.EqualTo(constants.Sas.IPRange));
            Assert.That(sasQueryParameters.Identifier, Is.EqualTo(constants.Sas.Identifier));
            Assert.That(sasQueryParameters.Resource, Is.Empty);
            Assert.That(sasQueryParameters.Permissions, Is.EqualTo(Permissions));
            Assert.That(sasQueryParameters.Signature, Is.EqualTo(signature));
            Assert.That(stringToSign, Is.Not.Null);
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
            Assert.That(sasQueryParameters.Identifier, Is.EqualTo(constants.Sas.Identifier));
            Assert.That(sasQueryParameters.Protocol, Is.EqualTo(SasProtocol.Https));
            Assert.That(sasQueryParameters.Version, Is.EqualTo(SasQueryParametersInternals.DefaultSasVersionInternal));
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

            Assert.That(accountSasBuilder.Permissions, Is.EqualTo("rwdxylacuptfi"));

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
            Assert.That(fileUriBuilder.Scheme, Is.EqualTo("http"));
            Assert.That(fileUriBuilder.Host, Is.EqualTo("docker_container"));
            Assert.That(fileUriBuilder.AccountName, Is.EqualTo("devstoreaccount1"));
            Assert.That(fileUriBuilder.QueueName, Is.EqualTo("sharename"));
            Assert.That(fileUriBuilder.Sas, Is.Null);
            Assert.That(fileUriBuilder.Query, Is.Empty);
            Assert.That(fileUriBuilder.Port, Is.EqualTo(10000));

            Assert.That(newUri, Is.EqualTo(originalUri));
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
            Assert.That(fileUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(fileUriBuilder.Host, Is.EqualTo("www.mycustomname.com"));
            Assert.That(fileUriBuilder.AccountName, Is.Empty);
            Assert.That(fileUriBuilder.QueueName, Is.EqualTo("queuename"));
            Assert.That(fileUriBuilder.Sas, Is.Null);
            Assert.That(fileUriBuilder.Query, Is.Empty);
            Assert.That(fileUriBuilder.Port, Is.EqualTo(443));

            Assert.That(newUri, Is.EqualTo(originalUri));
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
            Assert.That(ex.Message.Contains(redactedUri), Is.True);
            Assert.That(ex.Message.Contains("st="), Is.False);
            Assert.That(ex.Message.Contains("se="), Is.False);
            Assert.That(ex.Message.Contains("sig="), Is.False);
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
                constants.Sas.KeyDelegatedTenantId,
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
                SignedDelegatedUserTenantId = constants.Sas.KeyDelegatedTenantId,
                Value = constants.Sas.KeyValue
            };
    }
}
