// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.DataMovement.JobPlan;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.CheckpointerTesting;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanHeaderTests : DataMovementTestBase
    {
        public JobPartPlanHeaderTests(bool async) : base(async, default)
        {
        }

        [Test]
        public void Ctor()
        {
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            Assert.AreEqual(DataMovementConstants.JobPartPlanFile.SchemaVersion, header.Version);
            Assert.AreEqual(DefaultTransferId, header.TransferId);
            Assert.AreEqual(DefaultPartNumber, header.PartNumber);
            Assert.AreEqual(DefaultCreateTime, header.CreateTime);
            Assert.AreEqual(DefaultSourceTypeId, header.SourceTypeId);
            Assert.AreEqual(DefaultDestinationTypeId, header.DestinationTypeId);
            Assert.AreEqual(DefaultSourcePath, header.SourcePath);
            Assert.AreEqual(DefaultDestinationPath, header.DestinationPath);
            Assert.AreEqual(DefaultCreatePreference, header.CreatePreference);
            Assert.AreEqual(DefaultInitialTransferSize, header.InitialTransferSize);
            Assert.AreEqual(DefaultChunkSize, header.ChunkSize);
            Assert.AreEqual(DefaultPriority, header.Priority);
            Assert.AreEqual(DefaultPartStatus, header.JobPartStatus);
        }

        [Test]
        public void Serialize()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultJobPartHeader();
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.b3.ndmpart");

            using (MemoryStream headerStream = new MemoryStream())
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                // Act
                header.Serialize(headerStream);

                // Assert
                BinaryReader reader = new(fileStream);
                byte[] expected = reader.ReadBytes((int)fileStream.Length);
                byte[] actual = headerStream.ToArray();

                CollectionAssert.AreEqual(expected, actual);
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
        public void Deserialize_File_Version_b1()
        {
            // Arrange
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.steVb1");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                // Act / Assert
                Assert.Catch<ArgumentException>(
                    () => JobPartPlanHeader.Deserialize(stream),
                    $"The checkpoint file schema version {DataMovementConstants.JobPartPlanFile.SchemaVersion_b1} is not supported by this version of the SDK.");
            }
        }

        [Test]
        public void Deserialize_File_Version_b2()
        {
            // Arrange
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.steVb2");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                // Act / Assert
                Assert.Catch<ArgumentException>(
                    () => JobPartPlanHeader.Deserialize(stream),
                    $"The checkpoint file schema version {DataMovementConstants.JobPartPlanFile.SchemaVersion_b2} is not supported by this version of the SDK.");
            }
        }

        [Test]
        public void Deserialize_File_Version_b3()
        {
            // Arrange
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.b3.ndmpart");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                // Act / Assert
                DeserializeAndVerify(stream, DataMovementConstants.JobPartPlanFile.SchemaVersion_b3);
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
           string schemaVersion)
        {
            JobPartPlanHeader deserializedHeader = JobPartPlanHeader.Deserialize(stream);

            // Assert
            Assert.AreEqual(schemaVersion, deserializedHeader.Version);
            Assert.AreEqual(DefaultTransferId, deserializedHeader.TransferId);
            Assert.AreEqual(DefaultPartNumber, deserializedHeader.PartNumber);
            Assert.AreEqual(DefaultCreateTime, deserializedHeader.CreateTime);
            Assert.AreEqual(DefaultSourceTypeId, deserializedHeader.SourceTypeId);
            Assert.AreEqual(DefaultDestinationTypeId, deserializedHeader.DestinationTypeId);
            Assert.AreEqual(DefaultSourcePath, deserializedHeader.SourcePath);
            Assert.AreEqual(DefaultDestinationPath, deserializedHeader.DestinationPath);
            Assert.AreEqual(DefaultCreatePreference, deserializedHeader.CreatePreference);
            Assert.AreEqual(DefaultInitialTransferSize, deserializedHeader.InitialTransferSize);
            Assert.AreEqual(DefaultChunkSize, deserializedHeader.ChunkSize);
            Assert.AreEqual(DefaultPriority, deserializedHeader.Priority);
            Assert.AreEqual(DefaultPartStatus, deserializedHeader.JobPartStatus);
        }
    }
}
