// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.JobPlanModels;
using Azure.Core.TestFramework;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalTransferCheckpointerTests : DataMovementTestBase
    {
        public LocalTransferCheckpointerTests(bool async)
            : base(async, null)
        {
        }

        /// <summary>
        /// Creates stub job plan files. The values within the job plan files are not
        /// real and meant for testing.
        /// </summary>
        internal void CreateStubJobPlanFileAsync(
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

                JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber,
                    sourcePath: sourcePaths.ElementAt(i),
                    destinationPath: destinationPaths.ElementAt(i));

                JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath, transferId, i);

                using (FileStream stream = File.Create(fileName.FullPath, DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes))
                {
                    header.Serialize(stream);
                }
            }
        }

        [Test]
        public void Ctor()
        {
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(default);

            Assert.NotNull(transferCheckpointer);
        }

        [Test]
        public void Ctor_CustomPath()
        {
            string customPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync(customPath);
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act
            await transferCheckpointer.AddNewJobAsync(transferId);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));
        }

        [Test]
        public async Task AddNewJobAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            // Arrange
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.AddNewJobAsync(transferId));
        }

        [Test]
        public async Task AddNewJobAsync_Multiple()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string transferId2 = GetNewTransferId();
            string transferId3 = GetNewTransferId();

            // Act
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.AddNewJobAsync(transferId2);
            await transferCheckpointer.AddNewJobAsync(transferId3);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(3, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));
            Assert.IsTrue(transferIds.Contains(transferId2));
            Assert.IsTrue(transferIds.Contains(transferId3));
        }

        [Test]
        public async Task AddNewJobAsync_AddAfterRemove()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);

            // Act
            await transferCheckpointer.AddNewJobAsync(transferId);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));
        }

        [Test]
        public async Task AddNewJobPartAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            int chunksTotal = 1;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);

                // Act
                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: partNumber,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));

            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);
            Assert.AreEqual(1, partCount);
        }

        [Test]
        public async Task AddNewJobPartAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            string transferId = GetNewTransferId();
            int partNumber = 0;
            int chunksTotal = 1;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: partNumber,
                    chunksTotal: chunksTotal,
                    headerStream: stream);

                // Add the same job part twice
                Assert.CatchAsync<ArgumentException>(
                    async () => await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: partNumber,
                    chunksTotal: chunksTotal,
                    headerStream: stream));
            }

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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Add multiple parts for the same job
            string transferId = GetNewTransferId();
            int chunksTotal = 1;
            JobPartPlanHeader header1 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0);
            JobPartPlanHeader header2 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 1);
            JobPartPlanHeader header3 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 2);
            JobPartPlanHeader header4 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 3);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            using (Stream stream = new MemoryStream())
            {
                header1.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 0,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header2.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 1,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header3.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 2,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header4.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 3,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));
        }

        [Test]
        public async Task AddNewJobPartAsync_AddAfterRemove()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            string transferId = GetNewTransferId();
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 1);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 1,
                    chunksTotal: 2,
                    headerStream: stream);
            }
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
            await transferCheckpointer.AddNewJobAsync(transferId);
            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 1,
                    chunksTotal: 2,
                    headerStream: stream);
            }

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
            Assert.IsTrue(transferIds.Contains(transferId));
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);

            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(0, transferIds.Count);
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();

            // Assert
            Assert.IsFalse(await transferCheckpointer.TryRemoveStoredTransferAsync(transferId));
        }

        [Test]
        public async Task AddExistingJobAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            string transferId = GetNewTransferId();
            int numberOfParts = 2;

            CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddExistingJobAsync(transferId);

            // Assert
            List<string> transferIds = await transferCheckpointer.GetStoredTransfersAsync();
            Assert.AreEqual(1, transferIds.Count);
        }

        [Test]
        // The test does contain async, it's just inside the Assert.CatchAsync method
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddExistingJobAsync_Error()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();

            // Add non-existent job
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.AddExistingJobAsync(transferId));
        }

        [Test]
        public async Task AddExistingJobAsync_InvalidHeaderError()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            int partNumber = 0;

            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber,
                    version: "bV");

            JobPartPlanFileName fileName = new JobPartPlanFileName(test.DirectoryPath, transferId, partNumber);
            JobPartPlanFile jobFile;
            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);
                jobFile = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                    fileName: fileName,
                    headerStream: stream).ConfigureAwait(false);
            }

            // Add job with bad schema version in header
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.AddExistingJobAsync(transferId));
        }

        [Test]
        public async Task AddExistingJobAsync_Multiple()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId1 = GetNewTransferId();
            string transferId2 = GetNewTransferId();
            string transferId3 = GetNewTransferId();
            int numberOfParts = 2;

            CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId1,
                partNumber: 0,
                jobPartCount: numberOfParts);
            CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId2,
                partNumber: 0,
                jobPartCount: numberOfParts);
            CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId3,
                partNumber: 0,
                jobPartCount: numberOfParts);

            await transferCheckpointer.AddExistingJobAsync(transferId1);
            await transferCheckpointer.AddExistingJobAsync(transferId2);
            await transferCheckpointer.AddExistingJobAsync(transferId3);
        }

        [Test]
        public async Task AddExistingJobAsync_AddAfterRemove()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            int numberOfParts = 2;

            CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);

            await transferCheckpointer.AddExistingJobAsync(transferId);

            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);

            CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);

            await transferCheckpointer.AddExistingJobAsync(transferId);
        }

        [Test]
        public async Task GetStoredTransfersAsync_Empty()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            int partNumber = 0;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);

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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);
            string transferId = GetNewTransferId();
            string transferId2 = GetNewTransferId();
            string transferId3 = GetNewTransferId();

            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.AddNewJobAsync(transferId2);
            await transferCheckpointer.AddNewJobAsync(transferId3);

            // Act
            List<string> transfers = await transferCheckpointer.GetStoredTransfersAsync();

            // Assert
            Assert.AreEqual(3, transfers.Count);
            Assert.IsTrue(transfers.Contains(transferId));
            Assert.IsTrue(transfers.Contains(transferId2));
            Assert.IsTrue(transfers.Contains(transferId3));
        }

        [Test]
        public async Task CurrentJobPartCountAsync_Empty()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            // Act
            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);

            // Assert
            Assert.AreEqual(0, partCount);
        }

        [Test]
        public async Task CurrentJobPartCountAsync_OneJob()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            int chunksTotal = 1;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            using (Stream stream = new MemoryStream())
            {
                header.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: partNumber,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Act
            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);

            // Assert
            Assert.AreEqual(1, partCount);
        }

        [Test]
        public async Task CurrentJobPartCountAsync_MultipleJobs()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int chunksTotal = 1;
            JobPartPlanHeader header1 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0);
            JobPartPlanHeader header2 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 1);
            JobPartPlanHeader header3 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 2);
            JobPartPlanHeader header4 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 3);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            using (Stream stream = new MemoryStream())
            {
                header1.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 0,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header2.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 1,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header3.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 2,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header4.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 3,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Act
            int partCount = await transferCheckpointer.CurrentJobPartCountAsync(transferId);

            // Assert
            Assert.AreEqual(4, partCount);
        }

        [Test]
        public void CurrentJobPartCountAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.CurrentJobPartCountAsync(transferId));
        }

        [Test]
        public async Task ReadableStreamAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            int chunksTotal = 1;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);
            using (MemoryStream stream = new MemoryStream())
            {
                header.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: partNumber,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Act
            using (Stream stream = await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize))
            {
                // Assert
                await AssertJobPlanHeaderAsync(header, stream);
            }
        }

        [Test]
        public void ReadableStreamAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize));
        }

        [Test]
        public async Task SetJobTransferStatusAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            int chunksTotal = 1;
            StorageTransferStatus newStatus = StorageTransferStatus.Completed;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);
            using (MemoryStream stream = new MemoryStream())
            {
                header.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: partNumber,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Act
            await transferCheckpointer.SetJobTransferStatusAsync(transferId, newStatus);

            // Assert
            header.AtomicJobStatus = newStatus;
            using (Stream stream = await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize))
            {
                await AssertJobPlanHeaderAsync(header, stream);
            }
        }

        [Test]
        public async Task SetJobTransferStatusAsync_MultipleParts()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            int chunksTotal = 1;
            StorageTransferStatus newStatus = StorageTransferStatus.Completed;
            JobPartPlanHeader header1 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 0);
            JobPartPlanHeader header2 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 1);
            JobPartPlanHeader header3 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 2);
            JobPartPlanHeader header4 = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: 3);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);

            using (Stream stream = new MemoryStream())
            {
                header1.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 0,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header2.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 1,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header3.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 2,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }
            using (Stream stream = new MemoryStream())
            {
                header4.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: 3,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Act
            await transferCheckpointer.SetJobTransferStatusAsync(transferId, newStatus);

            // Assert
            header1.AtomicJobStatus = newStatus;
            using (Stream stream = await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize))
            {
                await AssertJobPlanHeaderAsync(header1, stream);
            }
            header2.AtomicJobStatus = newStatus;
            using (Stream stream = await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize))
            {
                await AssertJobPlanHeaderAsync(header2, stream);
            }
            header3.AtomicJobStatus = newStatus;
            using (Stream stream = await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize))
            {
                await AssertJobPlanHeaderAsync(header3, stream);
            }
            header4.AtomicJobStatus = newStatus;
            using (Stream stream = await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize))
            {
                await AssertJobPlanHeaderAsync(header4, stream);
            }
        }

        [Test]
        public void SetJobTransferStatusAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            StorageTransferStatus newStatus = StorageTransferStatus.Completed;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.SetJobTransferStatusAsync(transferId, newStatus));
        }

        [Test]
        public async Task SetJobPartTransferStatusAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            int chunksTotal = 1;
            // originally the default is set to Queued
            StorageTransferStatus newStatus = StorageTransferStatus.Completed;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);
            using (MemoryStream stream = new MemoryStream())
            {
                header.Serialize(stream);

                await transferCheckpointer.AddNewJobPartAsync(
                    transferId: transferId,
                    partNumber: partNumber,
                    chunksTotal: chunksTotal,
                    headerStream: stream);
            }

            // Act
            await transferCheckpointer.SetJobPartTransferStatusAsync(transferId, partNumber, newStatus);

            // Assert
            header.AtomicPartStatus = newStatus;
            using (Stream stream = await transferCheckpointer.ReadableStreamAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                readSize: DataMovementConstants.PlanFile.HeaderValueMaxSize))
            {
                await AssertJobPlanHeaderAsync(header, stream);
            }
        }

        [Test]
        public void SetJobPartTransferStatusAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            // Arrange
            string transferId = GetNewTransferId();
            int partNumber = 0;
            // originally the default is set to Queued
            StorageTransferStatus newStatus = StorageTransferStatus.Completed;
            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber);

            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            // Act / Assert
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.SetJobPartTransferStatusAsync(transferId, partNumber, newStatus));
        }
    }
}
