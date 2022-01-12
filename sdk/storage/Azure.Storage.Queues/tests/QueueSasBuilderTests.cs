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

        [RecordedTest]
        public void QueueSasBuilder_ToSasQueryParameters_VersionTest()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var queueName = GetNewQueueName();
            QueueSasBuilder queueSasBuilder = BuildQueueSasBuilder(constants, queueName);
            var signature = BuildSignature(constants, queueName);

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

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
    }
}
