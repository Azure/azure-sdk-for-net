// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.DataMovement.JobPlan;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.CheckpointerTesting;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanHeaderTests
    {
        [Test]
        public void Ctor()
        {
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            Assert.That(header.Version, Is.EqualTo(DataMovementConstants.JobPartPlanFile.SchemaVersion));
            Assert.That(header.TransferId, Is.EqualTo(DefaultTransferId));
            Assert.That(header.PartNumber, Is.EqualTo(DefaultPartNumber));
            Assert.That(header.CreateTime, Is.EqualTo(DefaultCreateTime));
            Assert.That(header.SourceTypeId, Is.EqualTo(DefaultSourceTypeId));
            Assert.That(header.DestinationTypeId, Is.EqualTo(DefaultDestinationTypeId));
            Assert.That(header.SourcePath, Is.EqualTo(DefaultSourcePath));
            Assert.That(header.DestinationPath, Is.EqualTo(DefaultDestinationPath));
            Assert.That(header.CreatePreference, Is.EqualTo(DefaultCreatePreference));
            Assert.That(header.InitialTransferSize, Is.EqualTo(DefaultInitialTransferSize));
            Assert.That(header.ChunkSize, Is.EqualTo(DefaultChunkSize));
            Assert.That(header.Priority, Is.EqualTo(DefaultPriority));
            Assert.That(header.JobPartStatus, Is.EqualTo(DefaultPartStatus));
        }

        [Test]
        public void Serialize()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultJobPartHeader();
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.1.ndmpart");

            using (MemoryStream headerStream = new MemoryStream())
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                // Act
                header.Serialize(headerStream);

                // Assert
                BinaryReader reader = new(fileStream);
                byte[] expected = reader.ReadBytes((int)fileStream.Length);
                byte[] actual = headerStream.ToArray();

                Assert.That(actual, Is.EqualTo(expected).AsCollection);
            }
        }

        [Test]
        public void Serialize_Error()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            // Act / Assert
            Assert.Catch<ArgumentNullException>(
                () => header.Serialize(default),
                "Stream cannot be null");
        }

        [Test]
        public void Deserialize()
        {
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);

                // Act / Assert
                DeserializeAndVerify(stream, DataMovementConstants.JobPartPlanFile.SchemaVersion);
            }
        }

        [Test]
        public void Deserialize_File_Version_1()
        {
            // Arrange
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.1.ndmpart");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                // Act / Assert
                DeserializeAndVerify(stream, DataMovementConstants.JobPartPlanFile.SchemaVersion_1);
            }
        }

        [Test]
        public void Deserialize_Error()
        {
            // Act / Assert
            Assert.Catch<ArgumentNullException>(
                () => JobPartPlanHeader.Deserialize(default));
        }

        private void DeserializeAndVerify(
           Stream stream,
           int schemaVersion)
        {
            JobPartPlanHeader deserializedHeader = JobPartPlanHeader.Deserialize(stream);

            // Assert
            Assert.That(deserializedHeader.Version, Is.EqualTo(schemaVersion));
            Assert.That(deserializedHeader.TransferId, Is.EqualTo(DefaultTransferId));
            Assert.That(deserializedHeader.PartNumber, Is.EqualTo(DefaultPartNumber));
            Assert.That(deserializedHeader.CreateTime, Is.EqualTo(DefaultCreateTime));
            Assert.That(deserializedHeader.SourceTypeId, Is.EqualTo(DefaultSourceTypeId));
            Assert.That(deserializedHeader.DestinationTypeId, Is.EqualTo(DefaultDestinationTypeId));
            Assert.That(deserializedHeader.SourcePath, Is.EqualTo(DefaultSourcePath));
            Assert.That(deserializedHeader.DestinationPath, Is.EqualTo(DefaultDestinationPath));
            Assert.That(deserializedHeader.CreatePreference, Is.EqualTo(DefaultCreatePreference));
            Assert.That(deserializedHeader.InitialTransferSize, Is.EqualTo(DefaultInitialTransferSize));
            Assert.That(deserializedHeader.ChunkSize, Is.EqualTo(DefaultChunkSize));
            Assert.That(deserializedHeader.Priority, Is.EqualTo(DefaultPriority));
            Assert.That(deserializedHeader.JobPartStatus, Is.EqualTo(DefaultPartStatus));
        }
    }
}
