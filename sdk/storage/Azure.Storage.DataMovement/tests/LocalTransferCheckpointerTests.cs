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

        internal JobPartPlanHeader CreateJobPartHeader(
            string transferId,
            long partNumber,
            string sourcePath,
            string destinationPath,
            string schemaVersion = default)
        {
            schemaVersion ??= DataMovementConstants.PlanFile.SchemaVersion;
            return new JobPartPlanHeader(
                version: schemaVersion,
                startTime: DateTimeOffset.UtcNow,
                transferId: transferId,
                partNumber: partNumber,
                sourcePath: sourcePath,
                sourceExtraQuery: "samplequery",
                destinationPath: destinationPath,
                destinationExtraQuery: "sampleQuery",
                isFinalPart: false,
                forceWrite: false,
                forceIfReadOnly: false,
                autoDecompress: false,
                priority: 0,
                ttlAfterCompletion: DateTimeOffset.MinValue,
                fromTo: 0,
                folderPropertyOption: FolderPropertiesMode.None,
                numberChunks: 0,
                dstBlobData: default,
                dstLocalData: default,
                preserveSMBPermissions: false,
                preserveSMBInfo: false,
                s2sGetPropertiesInBackend: false,
                s2sSourceChangeValidation: false,
                destLengthValidation: false,
                s2sInvalidMetadataHandleOption: 0,
                deleteSnapshotsOption: JobPartDeleteSnapshotsOption.None,
                permanentDeleteOption: JobPartPermanentDeleteOption.None,
                rehydratePriorityType: JobPartPlanRehydratePriorityType.None,
                atomicJobStatus: StorageTransferStatus.Queued,
                atomicPartStatus: StorageTransferStatus.Queued);
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

                JobPartPlanFile jobFile;
                using (Stream stream = new MemoryStream())
                {
                    header.Serialize(stream);
                    jobFile = await JobPartPlanFile.CreateJobPartPlanFileAsync(
                        fileName: fileName,
                        headerStream: stream).ConfigureAwait(false);
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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            await transferCheckpointer.AddNewJobAsync(GetNewTransferId());
            await transferCheckpointer.AddNewJobAsync(GetNewTransferId());
            await transferCheckpointer.AddNewJobAsync(GetNewTransferId());
        }

        [Test]
        public async Task AddNewJobAsync_AddAfterRemove()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
            await transferCheckpointer.AddNewJobAsync(transferId);
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
        }

        [Test]
        public async Task TryRemoveStoredTransferAsync_Error()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
            TransferCheckpointer transferCheckpointer = new LocalTransferCheckpointer(test.DirectoryPath);

            string transferId = GetNewTransferId();
            await transferCheckpointer.AddNewJobAsync(transferId);
            await transferCheckpointer.TryRemoveStoredTransferAsync(transferId);
        }

        [Test]
        public async Task AddExistingJobAsync()
        {
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();

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

            JobPartPlanHeader header = CreateJobPartHeader(
                    transferId,
                    partNumber,
                    "source",
                    "dest",
                    "badV");

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
            using DisposingLocalDirectory test = GetTestLocalDirectoryAsync();
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
