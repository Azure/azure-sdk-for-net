// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Queues.Test
{
    [TestFixture]
    public class QueueSasBuilderTests : QueueTestBase
    {
        private const string Permissions = "raup";

        public QueueSasBuilderTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public void QueueSasBuilder_ToSasQueryParameters_VersionTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueName = this.GetNewQueueName();
            var queueSasBuilder = this.BuildQueueSasBuilder(constants, queueName, includeVersion: true);
            var signature = this.BuildSignature(constants, queueName, includeVersion: true);

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(constants.Sas.Version, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(String.Empty, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void QueueSasBuilder_ToSasQueryParameters_NoVersionTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueName = this.GetNewQueueName();
            var queueSasBuilder = this.BuildQueueSasBuilder(constants, queueName, includeVersion: false);
            var signature = this.BuildSignature(constants, queueName, includeVersion: false);

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.DefaultSasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(constants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(constants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(constants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(constants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(String.Empty, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [Test]
        public void QueueSasBuilder_NullSharedKeyCredentialTest()
        {
            // Arrange
            var constants = new TestConstants(this);
            var queueName = this.GetNewQueueName();
            var queueSasBuilder = this.BuildQueueSasBuilder(constants, queueName, includeVersion: true);

            // Act
            Assert.Throws<ArgumentNullException>(() => queueSasBuilder.ToSasQueryParameters(null), "sharedKeyCredential");
        }

        private QueueSasBuilder BuildQueueSasBuilder(TestConstants constants, string queueName, bool includeVersion)
        {
            var queueSasBuilder = new QueueSasBuilder
            {
                Version = null,
                Protocol = constants.Sas.Protocol,
                StartTime = constants.Sas.StartTime,
                ExpiryTime = constants.Sas.ExpiryTime,
                Permissions = Permissions,
                IPRange = constants.Sas.IPRange,
                Identifier = constants.Sas.Identifier,
                QueueName = queueName,
            };

            if(includeVersion)
            {
                queueSasBuilder.Version = constants.Sas.Version;
            }

            return queueSasBuilder;
        }

        private string BuildSignature(TestConstants constants, string queueName, bool includeVersion)
        {
            var stringToSign = String.Join("\n",
                Permissions,
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(constants.Sas.ExpiryTime),
                "/queue/" + constants.Sas.Account + "/" + queueName,
                constants.Sas.Identifier,
                constants.Sas.IPRange.ToString(),
                SasProtocol.Https.ToString(),
                includeVersion ? constants.Sas.Version:  SasQueryParameters.DefaultSasVersion);

            return constants.Sas.SharedKeyCredential.ComputeHMACSHA256(stringToSign);
        }
    }
}
