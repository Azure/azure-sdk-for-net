// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Queues.Test
{
    [TestClass]
    public class QueueSasBuilderTests
    {
        private const string Permissions = "raup";
        private static readonly string QueueName = TestHelper.GetNewQueueName();

        [TestMethod]
        public void QueueSasBuilder_ToSasQueryParameters_VersionTest()
        {
            // Arrange
            var queueSasBuilder = this.BuildQueueSasBuilder(includeVersion: true);
            var signature = this.BuildSignature(includeVersion: true);

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(TestConstants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(TestConstants.Sas.Version, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(TestConstants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(String.Empty, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [TestMethod]
        public void QueueSasBuilder_ToSasQueryParameters_NoVersionTest()
        {
            // Arrange
            var queueSasBuilder = this.BuildQueueSasBuilder(includeVersion: false);
            var signature = this.BuildSignature(includeVersion: false);

            // Act
            var sasQueryParameters = queueSasBuilder.ToSasQueryParameters(TestConstants.Sas.SharedKeyCredential);

            // Assert
            Assert.AreEqual(SasQueryParameters.SasVersion, sasQueryParameters.Version);
            Assert.AreEqual(String.Empty, sasQueryParameters.Services);
            Assert.AreEqual(String.Empty, sasQueryParameters.ResourceTypes);
            Assert.AreEqual(SasProtocol.Https, sasQueryParameters.Protocol);
            Assert.AreEqual(TestConstants.Sas.StartTime, sasQueryParameters.StartTime);
            Assert.AreEqual(TestConstants.Sas.ExpiryTime, sasQueryParameters.ExpiryTime);
            Assert.AreEqual(TestConstants.Sas.IPRange, sasQueryParameters.IPRange);
            Assert.AreEqual(TestConstants.Sas.Identifier, sasQueryParameters.Identifier);
            Assert.AreEqual(String.Empty, sasQueryParameters.Resource);
            Assert.AreEqual(Permissions, sasQueryParameters.Permissions);
            Assert.AreEqual(signature, sasQueryParameters.Signature);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "sharedKeyCredential")]
        public void QueueSasBuilder_NullSharedKeyCredentialTest()
        {
            // Arrange
            var queueSasBuilder = this.BuildQueueSasBuilder(includeVersion: true);

            // Act
            queueSasBuilder.ToSasQueryParameters(null);
        }

        private QueueSasBuilder BuildQueueSasBuilder(bool includeVersion)
        {
            var queueSasBuilder = new QueueSasBuilder
            {
                Version = null,
                Protocol = TestConstants.Sas.Protocol,
                StartTime = TestConstants.Sas.StartTime,
                ExpiryTime = TestConstants.Sas.ExpiryTime,
                Permissions = Permissions,
                IPRange = TestConstants.Sas.IPRange,
                Identifier = TestConstants.Sas.Identifier,
                QueueName = QueueName,
            };

            if(includeVersion)
            {
                queueSasBuilder.Version = TestConstants.Sas.Version;
            }

            return queueSasBuilder;
        }

        private string BuildSignature(bool includeVersion)
        {
            var stringToSign = String.Join("\n",
                Permissions,
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.StartTime),
                SasQueryParameters.FormatTimesForSasSigning(TestConstants.Sas.ExpiryTime),
                "/queue/" + TestConstants.Sas.Account + "/" + QueueName,
                TestConstants.Sas.Identifier,
                TestConstants.Sas.IPRange.ToString(),
                SasProtocol.Https.ToString(),
                includeVersion ? TestConstants.Sas.Version:  SasQueryParameters.SasVersion);

            return TestConstants.Sas.SharedKeyCredential.ComputeHMACSHA256(stringToSign);
        }
    }
}
