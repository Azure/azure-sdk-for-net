// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Storage.DataMovement.JobPlan;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.CheckpointerTesting;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPlanHeaderTests
    {
        private JobPlanHeader CreateJobPlanHeader()
        {
            return new JobPlanHeader(
                DataMovementConstants.JobPlanFile.SchemaVersion,
                DefaultTransferId,
                DefaultCreateTime,
                DefaultJobPlanOperation,
                DefaultSourceProviderId,
                DefaultDestinationProviderId,
                isContainer: false,
                enumerationComplete: false,
                DefaultJobStatus,
                DefaultSourcePath,
                DefaultDestinationPath,
                MockResourceCheckpointDetails.DefaultInstance,
                MockResourceCheckpointDetails.DefaultInstance);
        }

        [Test]
        public void Ctor()
        {
            JobPlanHeader header = CreateJobPlanHeader();

            Assert.That(header.Version, Is.EqualTo(DataMovementConstants.JobPlanFile.SchemaVersion));
            Assert.That(header.TransferId, Is.EqualTo(DefaultTransferId));
            Assert.That(header.CreateTime, Is.EqualTo(DefaultCreateTime));
            Assert.That(header.OperationType, Is.EqualTo(DefaultJobPlanOperation));
            Assert.That(header.SourceProviderId, Is.EqualTo(DefaultSourceProviderId));
            Assert.That(header.DestinationProviderId, Is.EqualTo(DefaultDestinationProviderId));
            Assert.That(header.IsContainer, Is.False);
            Assert.That(header.EnumerationComplete, Is.False);
            Assert.That(header.JobStatus, Is.EqualTo(DefaultJobStatus));
            Assert.That(header.ParentSourcePath, Is.EqualTo(DefaultSourcePath));
            Assert.That(header.ParentDestinationPath, Is.EqualTo(DefaultDestinationPath));
        }

        [Test]
        public void Serialize()
        {
            JobPlanHeader header = CreateJobPlanHeader();
            string samplePath = Path.Combine("Resources", "SampleJobPlanFile.1.ndm");

            using (MemoryStream headerStream = new MemoryStream(DataMovementConstants.JobPlanFile.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                header.Serialize(headerStream);

                BinaryReader reader = new(fileStream);
                byte[] expected = reader.ReadBytes((int)fileStream.Length);
                byte[] actual = headerStream.ToArray();

                Assert.That(actual, Is.EqualTo(expected).AsCollection);
            }
        }

        [Test]
        public void Deserialize()
        {
            JobPlanHeader header = CreateJobPlanHeader();

            using (Stream stream = new MemoryStream(DataMovementConstants.JobPlanFile.VariableLengthStartIndex))
            {
                header.Serialize(stream);
                DeserializeAndVerify(stream, DataMovementConstants.JobPlanFile.SchemaVersion);
            }
        }

        [Test]
        public void Deserialize_File_Version_1()
        {
            string samplePath = Path.Combine("Resources", "SampleJobPlanFile.1.ndm");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                DeserializeAndVerify(stream, DataMovementConstants.JobPlanFile.SchemaVersion_1);
            }
        }

        private void DeserializeAndVerify(Stream stream, int version)
        {
            JobPlanHeader deserialized = JobPlanHeader.Deserialize(stream);
            Assert.That(deserialized.Version, Is.EqualTo(version));
            Assert.That(deserialized.TransferId, Is.EqualTo(DefaultTransferId));
            Assert.That(deserialized.CreateTime, Is.EqualTo(DefaultCreateTime));
            Assert.That(deserialized.OperationType, Is.EqualTo(DefaultJobPlanOperation));
            Assert.That(deserialized.SourceProviderId, Is.EqualTo(DefaultSourceProviderId));
            Assert.That(deserialized.DestinationProviderId, Is.EqualTo(DefaultDestinationProviderId));
            Assert.That(deserialized.IsContainer, Is.False);
            Assert.That(deserialized.EnumerationComplete, Is.False);
            Assert.That(deserialized.JobStatus, Is.EqualTo(DefaultJobStatus));
            Assert.That(deserialized.ParentSourcePath, Is.EqualTo(DefaultSourcePath));
            Assert.That(deserialized.ParentDestinationPath, Is.EqualTo(DefaultDestinationPath));
            Assert.That(deserialized.SourceCheckpointDetails, Is.EqualTo(MockResourceCheckpointDetails.DefaultInstance.Bytes).AsCollection);
            Assert.That(deserialized.DestinationCheckpointDetails, Is.EqualTo(MockResourceCheckpointDetails.DefaultInstance.Bytes).AsCollection);
        }
    }
}
