﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

        [Test]
        public void Ctor()
        {
            JobPlanHeader header = CreateDefaultJobHeader();

            Assert.AreEqual(DataMovementConstants.JobPlanFile.SchemaVersion, header.Version);
            Assert.AreEqual(DefaultTransferId, header.TransferId);
            Assert.AreEqual(DefaultCreateTime, header.CreateTime);
            Assert.AreEqual(DefaultJobPlanOperation, header.OperationType);
            Assert.AreEqual(false, header.EnumerationComplete);
            Assert.AreEqual(DefaultJobPlanStatus, header.JobStatus);
            Assert.AreEqual(DefaultSourcePath, header.ParentSourcePath);
            Assert.AreEqual(DefaultDestinationPath, header.ParentDestinationPath);
        }

        [Test]
        public void Serialize()
        {
            JobPlanHeader header = CreateDefaultJobHeader();
            string samplePath = Path.Combine("Resources", "SampleJobPlanFile.b1.ndm");

            using (MemoryStream headerStream = new MemoryStream(DataMovementConstants.JobPlanFile.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                header.Serialize(headerStream);

                BinaryReader reader = new(fileStream);
                byte[] expected = reader.ReadBytes((int) fileStream.Length);
                byte[] actual = headerStream.ToArray();

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Deserialize()
        {
            JobPlanHeader header = CreateDefaultJobHeader();

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
            Assert.AreEqual(false, deserialized.EnumerationComplete);
            Assert.AreEqual(DefaultJobPlanStatus, deserialized.JobStatus);
            Assert.AreEqual(DefaultSourcePath, deserialized.ParentSourcePath);
            Assert.AreEqual(DefaultDestinationPath, deserialized.ParentDestinationPath);
        }
    }
}
