// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Storage.DataMovement.JobPlan;
using static Azure.Storage.DataMovement.Tests.TransferUtility;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalTransferCheckpointerTests : DataMovementTestBase
    {
        private static TransferStatus SuccessfulCompletedStatus => new TransferStatus(TransferState.Completed, false, false);
        private static TransferStatus PausedStatus => new TransferStatus(TransferState.Paused, false, false);

        public LocalTransferCheckpointerTests(bool async)
            : base(async, null)
        {
        }

        /// <summary>
        /// Creates stub job plan files. The values within the job plan files are not
        /// real and meant for testing.
        /// </summary>
        internal void CreateStubJobPartPlanFile(
            string checkpointerPath,
            string transferId,
            int partNumber,
            int jobPartCount,
            List<string> sourcePaths = default,
            List<string> destinationPaths = default)
        {
            // Populate sourcePaths if not provided
            if (sourcePaths == default)
            {
                string sourcePath = "sample-source";
                sourcePaths = new List<string>();
                for (int i = 0; i < jobPartCount; i++)
                {
                    sourcePaths.Add(Path.Combine(sourcePath, $"file{i}"));
                }
            }
            // Populate destPaths if not provided
            if (destinationPaths == default)
            {
                string destPath = "sample-dest";
                destinationPaths = new List<string>();
                for (int i = 0; i < jobPartCount; i++)
                {
                    destinationPaths.Add(Path.Combine(destPath, $"file{i}"));
                }
            }

            for (int i = 0; i < jobPartCount; i++)
            {
                // Populate the JobPlanFile with a pseudo job plan header

                JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber,
                    sourcePath: sourcePaths.ElementAt(i),
                    destinationPath: destinationPaths.ElementAt(i));

                JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath, transferId, i);

                using (FileStream stream = File.Create(fileName.FullPath))
                {
                    header.Serialize(stream);
                }
            }
        }

        internal async Task AddJobToCheckpointer(
            SerializerTransferCheckpointer transferCheckpointer,
            string transferId,
            string sourcePath = CheckpointerTesting.DefaultWebSourcePath,
            string destinationPath = CheckpointerTesting.DefaultWebDestinationPath)
        {
            StorageResource source = MockStorageResourceItem.MakeSourceResource(10, uri: new(sourcePath));
            StorageResource destination = MockStorageResourceItem.MakeDestinationResource(uri: new(destinationPath));

            await transferCheckpointer.AddNewJobAsync(transferId, source, destination);
        }

        [Test]
        public void Ctor()
        {
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(default);

            Assert.NotNull(transferCheckpointer);
        }

        [Test]
        public void Ctor_CustomPath()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory(Guid.NewGuid().ToString());
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            Assert.NotNull(transferCheckpointer);
        }

        [Test]
        public void Ctor_Error()
        {
            string customPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Assert.Catch<ArgumentException>(
                () => new LocalTransferCheckpointer(customPath));
        }

        [Test]
        public async Task AddNewJobAsync()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));
        }

        [Test]
        public async Task AddNewJobAsync_Error()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            // Arrange
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await AddJobToCheckpointer(transferCheckpointer, transferId));
        }

        [Test]
        public async Task AddNewJobAsync_Multiple()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange / Act
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            int jobCount = 3;
            List<string> expectedTransferIds = new();
            for (int i = 0; i < jobCount; i++)
            {
                string transferId = GetNewTransferId();
                expectedTransferIds.Add(transferId);

                string sourcePath = CheckpointerTesting.DefaultWebSourcePath + i;
                string destinationPath = CheckpointerTesting.DefaultWebDestinationPath + i;
                await AddJobToCheckpointer(transferCheckpointer, transferId, sourcePath, destinationPath);
            }

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            CollectionAssert.AreEquivalent(expectedTransferIds, transferIds);
        }

        [Test]
        public async Task AddNewJobAsync_AddAfterRemove()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);

            // Act
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));
        }

        [Test]
        public async Task AddNewJobPartAsync()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: partNumber,
                header: header);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));

            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);
            Assert.AreEqual(1, partCount);

            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, partNumber, header);
        }

        [Test]
        public async Task AddNewJobPartAsync_Error()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            string transferId = GetNewTransferId();
            int partNumber = 0;
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);

            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: partNumber,
                header: header);

            // Add the same job part twice
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: partNumber,
                header: header));

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));

            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);
            Assert.AreEqual(1, partCount);
        }

        [Test]
        public async Task AddNewJobPartAsync_MultipleParts()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Add multiple parts for the same job
            string transferId = GetNewTransferId();
            JobPartPlanHeader header1 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0);
            JobPartPlanHeader header2 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 1);
            JobPartPlanHeader header3 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 2);
            JobPartPlanHeader header4 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 3);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);

            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 0,
                header: header1);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 1,
                header: header2);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 2,
                header: header3);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 3,
                header: header4);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));

            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, 0, header1);
            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, 1, header2);
            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, 2, header3);
            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, 3, header4);
        }

        [Test]
        public async Task AddNewJobPartAsync_AddAfterRemove()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string transferId = GetNewTransferId();
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 1);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);

            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 1,
                header: header);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
            await AddJobToCheckpointer(transferCheckpointer, transferId);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 1,
                header: header);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));

            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, 1, header);
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);

            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(0, transferIds.Count);
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync_Error()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();

            // Assert
            Assert.IsFalse(await transferCheckpointer.TryRemoveStoredTransferAsync(transferId));
        }

        [Test]
        public async Task GetStoredTransfersAsync_Empty()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            int partNumber = 0;
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            // Act
            List<string> transfers = await transferCheckpointer.GetStoredTransfersAsync();

            // Assert
            Assert.IsEmpty(transfers);
        }

        [Test]
        public async Task GetStoredTransfersAsync_OneJob()
        {
            // Arrange - add 1 job
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act
            List<string> transfers = await transferCheckpointer.GetStoredTransfersAsync();

            // Assert
            Assert.AreEqual(1, transfers.Count);
            Assert.AreEqual(transfers.First(), transferId);
        }

        [Test]
        public async Task GetStoredTransfersAsync_MultipleJobs()
        {
            // Arrange - add 1 job
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            int jobCount = 3;
            List<string> expectedTransferIds = new();
            for (int i = 0; i < jobCount; i++)
            {
                string transferId = GetNewTransferId();
                expectedTransferIds.Add(transferId);

                string sourcePath = CheckpointerTesting.DefaultWebSourcePath + i;
                string destinationPath = CheckpointerTesting.DefaultWebDestinationPath + i;
                await AddJobToCheckpointer(transferCheckpointer, transferId, sourcePath, destinationPath);
            }

            // Act
            List<string> transfers = await transferCheckpointer.GetStoredTransfersAsync();

            // Assert
            CollectionAssert.AreEquivalent(expectedTransferIds, transfers);
        }

        [Test]
        public async Task GetStoredTransfersAsync_StoredJobs()
        {
            // Arrange - populate checkpointer directory with existing jobs
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string transferId2 = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);
            await AddJobToCheckpointer(transferCheckpointer, transferId2);

            int numberOfParts = 2;
            CreateStubJobPartPlanFile(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);
            CreateStubJobPartPlanFile(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId2,
                partNumber: 0,
                jobPartCount: numberOfParts);

            // Act
            List<string> transfers = await transferCheckpointer.GetStoredTransfersAsync();

            // Assert
            Assert.AreEqual(2, transfers.Count);
            Assert.IsTrue(transfers.Contains(transferId));
            Assert.IsTrue(transfers.Contains(transferId2));

            // Arrange - add more job to the checkpointer
            string transferId3 = GetNewTransferId();
            string transferId4 = GetNewTransferId();

            await AddJobToCheckpointer(transferCheckpointer, transferId3);
            await AddJobToCheckpointer(transferCheckpointer, transferId4);

            // Act
            List<string> transfersAfterAdditions = await transferCheckpointer.GetStoredTransfersAsync();

            // Assert
            Assert.AreEqual(4, transfersAfterAdditions.Count);
            Assert.IsTrue(transfersAfterAdditions.Contains(transferId));
            Assert.IsTrue(transfersAfterAdditions.Contains(transferId2));
            Assert.IsTrue(transfersAfterAdditions.Contains(transferId3));
            Assert.IsTrue(transfersAfterAdditions.Contains(transferId4));
        }

        [Test]
        public async Task CurrentJobPartCountAsync_Empty()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act
            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);

            // Assert
            Assert.AreEqual(0, partCount);
        }

        [Test]
        public async Task CurrentJobPartCountAsync_OneJob()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);

            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: partNumber,
                header: header);

            // Act
            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);

            // Assert
            Assert.AreEqual(1, partCount);
        }

        [Test]
        public async Task CurrentJobPartCountAsync_MultipleJobs()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            JobPartPlanHeader header1 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0);
            JobPartPlanHeader header2 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 1);
            JobPartPlanHeader header3 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 2);
            JobPartPlanHeader header4 = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 3);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);

            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 0,
                header: header1);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 1,
                header: header2);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 2,
                header: header3);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: 3,
                header: header4);

            // Act
            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);

            // Assert
            Assert.AreEqual(4, partCount);
        }

        [Test]
        public void CurrentJobPartCountAsync_Error()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.CurrentJobPartCountAsync(transferId));
        }

        [Test]
        public async Task ReadJobPlanFileAsync()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act
            JobPlanHeader header;
            using (Stream stream = await transferCheckpointer.ReadJobPlanFileAsync(transferId, offset: 0, length: 0))
            {
                header = JobPlanHeader.Deserialize(stream);
            }

            // Assert
            Assert.IsNotNull(header);
            Assert.AreEqual(DataMovementConstants.JobPlanFile.SchemaVersion, header.Version);
            Assert.AreEqual(transferId, header.TransferId);
            Assert.AreEqual(CheckpointerTesting.DefaultWebSourcePath, header.ParentSourcePath);
            Assert.AreEqual(CheckpointerTesting.DefaultWebDestinationPath, header.ParentDestinationPath);
        }

        [Test]
        public async Task ReadJobPlanFileAsync_Partial()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act
            string actualTransferId;
            int length = DataMovementConstants.GuidSizeInBytes;
            using (Stream stream = await transferCheckpointer.ReadJobPlanFileAsync(
                transferId,
                DataMovementConstants.JobPlanFile.TransferIdIndex,
                length))
            {
                BinaryReader reader = new BinaryReader(stream);
                byte[] transferIdBytes = reader.ReadBytes(length);
                actualTransferId = new Guid(transferIdBytes).ToString();
            }

            TransferStatus actualJobStatus = await transferCheckpointer.GetJobStatusAsync(transferId);

            // Assert
            Assert.AreEqual(transferId, actualTransferId);
            Assert.AreEqual(actualJobStatus, new TransferStatus());
        }

        [Test]
        public async Task ReadJobPartPlanFileAsync()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: partNumber,
                header: header);

            // Act
            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, partNumber, header);
        }

        [Test]
        public void ReadJobPartPlanFileAsync_Error()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                length: 0));
        }

        [Test]
        public async Task WriteToJobPlanFileAsync()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act
            // Change enumerationComplete (test with extra byte)
            byte[] enumerationCompleteBytes = { 0x00, Convert.ToByte(true) };
            await transferCheckpointer.WriteToJobPlanFileAsync(
                transferId,
                DataMovementConstants.JobPlanFile.EnumerationCompleteIndex,
                enumerationCompleteBytes,
                bufferOffset: 1,
                length: DataMovementConstants.OneByte);

            // Change Job Status
            JobPlanStatus jobPlanStatus = JobPlanStatus.Completed | JobPlanStatus.HasSkipped;
            byte[] jobPlanStatusBytes = BitConverter.GetBytes((int)jobPlanStatus);
            await transferCheckpointer.WriteToJobPlanFileAsync(
                transferId,
                DataMovementConstants.JobPlanFile.JobStatusIndex,
                jobPlanStatusBytes,
                bufferOffset: 0,
                length: DataMovementConstants.IntSizeInBytes);

            // Assert
            int start = DataMovementConstants.JobPlanFile.EnumerationCompleteIndex;
            int readLength = DataMovementConstants.JobPlanFile.ParentSourcePathOffsetIndex - start;
            using (Stream stream = await transferCheckpointer.ReadJobPlanFileAsync(
                transferId,
                offset: start,
                length: readLength))
            {
                BinaryReader reader = new BinaryReader(stream);
                bool enumerationComplete = Convert.ToBoolean(reader.ReadByte());
                Assert.IsTrue(enumerationComplete);

                JobPlanStatus actualJobPlanStatus = (JobPlanStatus)reader.ReadInt32();
                Assert.AreEqual(jobPlanStatus, actualJobPlanStatus);
            }
        }

        [Test]
        public void WriteToJobPlanFileAsync_Error()
        {
            // Arrange
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string transferId = GetNewTransferId();
            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act / Assert
            byte[] bytes = { 0x00 };
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.WriteToJobPlanFileAsync(
                    transferId: Guid.NewGuid().ToString(),
                    fileOffset: 0,
                    buffer: bytes,
                    bufferOffset: 0,
                    length: 1));
            }

        [Test]
        public async Task SetJobTransferStatusAsync()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            TransferStatus newStatus = PausedStatus;

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            // Act
            await transferCheckpointer.SetJobTransferStatusAsync(transferId, newStatus);

            // Assert
            using (Stream stream = await transferCheckpointer.ReadJobPlanFileAsync(
                transferId,
                DataMovementConstants.JobPlanFile.JobStatusIndex,
                DataMovementConstants.IntSizeInBytes))
            {
                BinaryReader reader = new BinaryReader(stream);
                JobPlanStatus jobPlanStatus = (JobPlanStatus)reader.ReadInt32();

                Assert.That(jobPlanStatus.ToTransferStatus(), Is.EqualTo(newStatus));
            }
        }

        [Test]
        public void SetJobTransferStatusAsync_Error()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            TransferStatus newStatus = SuccessfulCompletedStatus;

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.SetJobTransferStatusAsync(transferId, newStatus));
        }

        [Test]
        public async Task SetJobPartTransferStatusAsync()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            // originally the default is set to Queued
            TransferStatus newStatus = SuccessfulCompletedStatus;
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await AddJobToCheckpointer(transferCheckpointer, transferId);
            await transferCheckpointer.AddNewJobPartAsync(
                transferId: transferId,
                partNumber: partNumber,
                header: header);

            // Act
            await transferCheckpointer.SetJobPartTransferStatusAsync(transferId, partNumber, newStatus);

            // Assert
            header.JobPartStatus = newStatus;
            await transferCheckpointer.AssertJobPlanHeaderAsync(transferId, partNumber, header);
        }

        [Test]
        public void SetJobPartTransferStatusAsync_Error()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            // originally the default is set to Queued
            TransferStatus newStatus = SuccessfulCompletedStatus;
            JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            SerializerTransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.SetJobPartTransferStatusAsync(transferId, partNumber, newStatus));
        }

        [Test]
        public async Task JobDeletedOnComplete()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            LocalTransferCheckpointer transferCheckpointer = new(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            Assert.That(await transferCheckpointer.GetJobStatusAsync(transferId), Is.Not.Null);

            await transferCheckpointer.SetJobTransferStatusAsync(transferId, SuccessfulCompletedStatus);

            Assert.That(async () => await transferCheckpointer.GetJobStatusAsync(transferId), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public async Task JobUncachedOnPause()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            LocalTransferCheckpointer transferCheckpointer = new(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await AddJobToCheckpointer(transferCheckpointer, transferId);

            Assert.That(await transferCheckpointer.GetJobStatusAsync(transferId), Is.Not.Null);

            await transferCheckpointer.SetJobTransferStatusAsync(transferId, PausedStatus);

            Assert.That(transferCheckpointer._transferStates.ContainsKey(transferId), Is.False);
            Assert.That(await transferCheckpointer.GetJobStatusAsync(transferId), Is.Not.Null);
            Assert.That(transferCheckpointer._transferStates.ContainsKey(transferId), Is.True);
        }
    }
}
