// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Storage.DataMovement.JobPlan;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.CheckpointerTesting;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPlanHeaderTests : DataMovementTestBase
    {
        public JobPlanHeaderTests(bool async) : base(async, default)
        {
        }

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
                MockResourceCheckpointData.DefaultInstance,
                MockResourceCheckpointData.DefaultInstance);
        }

        [Test]
        public void Ctor()
        {
            JobPlanHeader header = CreateJobPlanHeader();

            Assert.AreEqual(DataMovementConstants.JobPlanFile.SchemaVersion, header.Version);
            Assert.AreEqual(DefaultTransferId, header.TransferId);
            Assert.AreEqual(DefaultCreateTime, header.CreateTime);
            Assert.AreEqual(DefaultJobPlanOperation, header.OperationType);
            Assert.AreEqual(DefaultSourceProviderId, header.SourceProviderId);
            Assert.AreEqual(DefaultDestinationProviderId, header.DestinationProviderId);
            Assert.IsFalse(header.IsContainer);
            Assert.IsFalse(header.EnumerationComplete);
            Assert.AreEqual(DefaultJobStatus, header.JobStatus);
            Assert.AreEqual(DefaultSourcePath, header.ParentSourcePath);
            Assert.AreEqual(DefaultDestinationPath, header.ParentDestinationPath);
        }

        [Test]
        public void Serialize()
        {
            JobPlanHeader header = CreateJobPlanHeader();
            string samplePath = Path.Combine("Resources", "SampleJobPlanFile.b1.ndm");

            using (MemoryStream headerStream = new MemoryStream(DataMovementConstants.JobPlanFile.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                header.Serialize(headerStream);

                BinaryReader reader = new(fileStream);
                byte[] expected = reader.ReadBytes((int)fileStream.Length);
                byte[] actual = headerStream.ToArray();

                CollectionAssert.AreEqual(expected, actual);
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
        public void Deserialize_File_Version_b1()
        {
            string samplePath = Path.Combine("Resources", "SampleJobPlanFile.b1.ndm");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                DeserializeAndVerify(stream, DataMovementConstants.JobPlanFile.SchemaVersion_b1);
            }
        }

        private void DeserializeAndVerify(Stream stream, string version)
        {
            JobPlanHeader deserialized = JobPlanHeader.Deserialize(stream);
            Assert.AreEqual(version, deserialized.Version);
            Assert.AreEqual(DefaultTransferId, deserialized.TransferId);
            Assert.AreEqual(DefaultCreateTime, deserialized.CreateTime);
            Assert.AreEqual(DefaultJobPlanOperation, deserialized.OperationType);
            Assert.AreEqual(DefaultSourceProviderId, deserialized.SourceProviderId);
            Assert.AreEqual(DefaultDestinationProviderId, deserialized.DestinationProviderId);
            Assert.IsFalse(deserialized.IsContainer);
            Assert.IsFalse(deserialized.EnumerationComplete);
            Assert.AreEqual(DefaultJobStatus, deserialized.JobStatus);
            Assert.AreEqual(DefaultSourcePath, deserialized.ParentSourcePath);
            Assert.AreEqual(DefaultDestinationPath, deserialized.ParentDestinationPath);
            CollectionAssert.AreEqual(MockResourceCheckpointData.DefaultInstance.Bytes, deserialized.SourceCheckpointData);
            CollectionAssert.AreEqual(MockResourceCheckpointData.DefaultInstance.Bytes, deserialized.DestinationCheckpointData);
        }
    }
}
