// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

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
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                "/queue/" + constants.Sas.Account + "/" + queueName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                SasProtocol.Https.ToProtocolString(),
                includeVersion ? constants.Sas.Version : SasQueryParameters.DefaultSasVersion);

            return constants.Sas.SharedKeyCredential.ComputeHMACSHA256(stringToSign);
        }
    }
}
