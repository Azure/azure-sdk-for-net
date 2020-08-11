// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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

        public QueueSasBuilderTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void QueueSasBuilder_ToSasQueryParameters_VersionTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueName = GetNewQueueName();
            QueueSasBuilder queueSasBuilder = BuildQueueSasBuilder(constants, queueName, includeVersion: true);
            var signature = BuildSignature(constants, queueName, includeVersion: true);

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Version, sasQueryParameters.Version);
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
        }

        [Test]
        public void QueueSasBuilder_ToSasQueryParameters_NoVersionTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueName = GetNewQueueName();
            QueueSasBuilder queueSasBuilder = BuildQueueSasBuilder(constants, queueName, includeVersion: false);
            var signature = BuildSignature(constants, queueName, includeVersion: false);

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
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
        }

        [Test]
        public void QueueSasBuilder_NullSharedKeyCredentialTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueName = GetNewQueueName();
            QueueSasBuilder queueSasBuilder = BuildQueueSasBuilder(constants, queueName, includeVersion: true);

            // Act
            Assert.Throws<ArgumentNullException>(() => queueSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        [Test]
        public void ToSasQueryParameters_IdentifierTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueName = GetNewQueueName();

            QueueSasBuilder sasBuilder = new QueueSasBuilder
            {
                Identifier = constants.Sas.Identifier,
                QueueName = queueName,
                Protocol = SasProtocol.Https,
                Version = constants.Sas.Version
            };

            // Act
            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.Version, sasQueryParameters.Version);
        }

        [Test]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2019_12_12)]
        [TestCase("FTPUCALXDWR")]
        [TestCase("rwdxlacuptf")]
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

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);

            Uri uri = new Uri($"{test.Queue.Uri}?{accountSasBuilder.ToSasQueryParameters(sharedKeyCredential)}");

            QueueClient queueClient = new QueueClient(uri, GetOptions());

            // Act
            await queueClient.GetPropertiesAsync();
        }

        [Test]
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

        [Test]
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

        [Test]
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

        private QueueSasBuilder BuildQueueSasBuilder(TestConstants constants, string queueName, bool includeVersion)
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
            };
            queueSasBuilder.SetPermissions(Permissions);

            if (includeVersion)
            {
                queueSasBuilder.Version = constants.Sas.Version;
            }

            return queueSasBuilder;
        }

        private string BuildSignature(TestConstants constants, string queueName, bool includeVersion)
        {
            var stringToSign = string.Join("\n",
                Permissions,
                SasExtensions.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasExtensions.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                "/queue/" + constants.Sas.Account + "/" + queueName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                SasExtensions.ToProtocolString(SasProtocol.Https),
                includeVersion ? constants.Sas.Version : SasQueryParameters.DefaultSasVersion);

            return StorageSharedKeyCredentialInternals.ComputeSasSignature(constants.Sas.SharedKeyCredential, stringToSign);
        }
    }
}
