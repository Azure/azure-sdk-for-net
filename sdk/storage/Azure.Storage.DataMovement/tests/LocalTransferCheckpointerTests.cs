// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using Azure.Storage.Test;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalTransferCheckpointerTests
    {
        public static string GetNewTransferId() => Guid.NewGuid().ToString();
        public static DisposingLocalDirectory GetTestLocalDirectoryAsync(string directoryPath = default)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            }
            Directory.CreateDirectory(directoryPath);
            return new DisposingLocalDirectory(directoryPath);
        }

        internal JobPartPlanHeader CreateJobPartHeader(
            string transferId,
            int partNumber,
            string sourcePath,
            string destinationPath,
            string schemaVersion = default)
        {
            byte[] sourceRoot = Encoding.UTF8.GetBytes(sourcePath);
            byte[] destinationRoot = Encoding.UTF8.GetBytes(destinationPath);
            schemaVersion ??= DataMovementConstants.PlanFile.SchemaVersion;
            return new JobPartPlanHeader()
            {
                Version = Encoding.Unicode.GetBytes(schemaVersion),
                StartTime = 0, // TODO: update to job start time
                TransferId = transferId,
                PartNum = (uint)partNumber,
                SourceRootLength = (ushort)sourceRoot.Length,
                SourceRoot = sourceRoot,
                SourceExtraQueryLength = 0,
                SourceExtraQuery = default,
                DestinationRootLength = (ushort)destinationRoot.Length,
                DestinationRoot = destinationRoot,
                DestExtraQueryLength = 0,
                DestExtraQuery = default,
                IsFinalPart = false,
                ForceWrite = false,
                ForceIfReadOnly = false,
                AutoDecompress = false,
                Priority = 0,
                TTLAfterCompletion = 0,
                FromTo = 0,
                FolderPropertyOption = FolderPropertiesMode.None,
                NumTransfers = 0,
                DstBlobData = default,
                DstLocalData = default,
                PreserveSMBPermissions = 0,
                PreserveSMBInfo = false,
                S2SGetPropertiesInBackend = false,
                S2SSourceChangeValidation = false,
                DestLengthValidation = false,
                S2SInvalidMetadataHandleOption = 0,
                atomicJobStatus = (uint)StorageTransferStatus.Queued,
                atomicPartStatus = (uint)StorageTransferStatus.Queued,
                DeleteSnapshotsOption = JobPartDeleteSnapshotsOption.None,
                PermanentDeleteOption = JobPartPermanentDeleteOption.None,
                RehydratePriorityType = JobPartPlanRehydratePriorityType.None,
            };
        }

        /// <summary>
        /// Creates stub job plan files. The values within the job plan files are not
        /// real and meant for testing.
        /// </summary>
        internal async Task CreateStubJobPlanFileAsync(
            string checkpointerPath,
            string transferId,
            int partNumber,
            int jobPartCount,
            List<string> sourcePaths = default,
            List<string> destinationPaths = default)
        {
            Random rand = new Random();

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

                JobPartPlanHeader header = CreateJobPartHeader(
                    transferId,
                    partNumber,
                    sourcePaths.ElementAt(i),
                    destinationPaths.ElementAt(i));

                JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath, transferId, i);
                using (Stream fileStream = File.Create(fileName.ToString()))
                {
                    using Stream stream = header.ToStream();
                    await stream.CopyToAsync(fileStream).ConfigureAwait(false);
                    fileStream.Close();
                }
            }
        }

        [Test]
        public void Ctor()
        {
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer();

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
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            string transferId = GetNewTransferId();
            int numberOfParts = 2;
            await CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(transferId);
        }

        [Test]
        public async Task AddNewJobAsync_Error()
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);

            // Add the same job twice
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.AddNewJobAsync(transferId));
        }

        [Test]
        public async Task AddNewJobAsync_Multiple()
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(GetNewTransferId());
            await transferCheckpointer.AddNewJobAsync(GetNewTransferId());
            await transferCheckpointer.AddNewJobAsync(GetNewTransferId());
        }

        [Test]
        public async Task AddNewJobAsync_AddAfterRemove()
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
            await transferCheckpointer.AddNewJobAsync(transferId);
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync()
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync_Error()
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
        }

        [Test]
        public async Task AddExistingJobAsync()
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

            string transferId = GetNewTransferId();
            int numberOfParts = 2;

            await CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddExistingJobAsync(transferId);
        }

        [Test]
        // The test does contain async, it's just inside the Assert.CatchAsync method
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddExistingJobAsync_Error()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();

            // Add non-existent job
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.AddExistingJobAsync(transferId));
        }

        [Test]
        // The test does contain async, it's just inside the Assert.CatchAsync method
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AddExistingJobAsync_InvalidHeaderError()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            int partNumber = 0;

            JobPartPlanHeader header = CreateJobPartHeader(
                    transferId,
                    partNumber,
                    "source",
                    "dest",
                    "badV");

            JobPartPlanFileName fileName = new JobPartPlanFileName(test.DirectoryPath, transferId, partNumber);
            using (Stream fileStream = File.Create(fileName.ToString()))
            {
                using Stream stream = header.ToStream();
                await stream.CopyToAsync(fileStream).ConfigureAwait(false);
                fileStream.Close();
            }

            // Add job with bad schema version in header
            Assert.CatchAsync<ArgumentException>(
                async () => await transferCheckpointer.AddExistingJobAsync(transferId));
        }

        [Test]
        public async Task AddExistingJobAsync_Multiple()
        {
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId1 = GetNewTransferId();
            string transferId2 = GetNewTransferId();
            string transferId3 = GetNewTransferId();
            int numberOfParts = 2;

            await CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId1,
                partNumber: 0,
                jobPartCount: numberOfParts);
            await CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId2,
                partNumber: 0,
                jobPartCount: numberOfParts);
            await CreateStubJobPlanFileAsync(
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
            DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            int numberOfParts = 2;

            await CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);

            await transferCheckpointer.AddExistingJobAsync(transferId);

            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);

            await CreateStubJobPlanFileAsync(
                checkpointerPath: test.DirectoryPath,
                transferId: transferId,
                partNumber: 0,
                jobPartCount: numberOfParts);

            await transferCheckpointer.AddExistingJobAsync(transferId);
        }
    }
}
