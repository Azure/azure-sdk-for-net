// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement.Tests
{
    internal class LocalTransferCheckpointerFactory
    {
        internal const int _partCountDefault = 5;
        internal const string _testSourceProviderId = "test";
        internal const string _testSourcePath = "C:/sample-source";
        internal const string _testDestinationProviderId = "test";
        internal const string _testDestinationPath = "C:/sample-destination";
        internal static readonly DataTransferStatus _testPartStatus = new DataTransferStatus(DataTransferState.Queued, false, false);

        private string _checkpointerPath;

        public LocalTransferCheckpointerFactory(string checkpointerPath)
        {
            _checkpointerPath = checkpointerPath;
        }

        public LocalTransferCheckpointer BuildCheckpointer(long transferCount)
        {
            // Create stub files
            for (int i = 0; i < transferCount; i++)
            {
                string transferId = GetNewTransferId();
                CreateStubJobPlanFile(_checkpointerPath, transferId);
                CreateStubJobPartPlanFilesAsync(
                    checkpointerPath: _checkpointerPath,
                    transferId: transferId,
                    jobPartCount: _partCountDefault);
            }

            // Return constructed checkpointer
            return new LocalTransferCheckpointer(_checkpointerPath);
        }

        public LocalTransferCheckpointer BuildCheckpointer(List<DataTransfer> dataTransfers)
        {
            foreach (DataTransfer dataTransfer in dataTransfers)
            {
                CreateStubJobPlanFile(_checkpointerPath, dataTransfer.Id, status: dataTransfer.TransferStatus);
                CreateStubJobPartPlanFilesAsync(
                    checkpointerPath: _checkpointerPath,
                    transferId: dataTransfer.Id,
                    jobPartCount: _partCountDefault,
                    status: new DataTransferStatus(DataTransferState.Paused, false, false));
            }
            return new LocalTransferCheckpointer(_checkpointerPath);
        }

        /// <summary>
        /// Creates stub job plan files. The values within the job plan files are not
        /// real and meant for testing.
        /// </summary>
        internal void CreateStubJobPartPlanFilesAsync(
            string checkpointerPath,
            string transferId,
            int jobPartCount,
            DataTransferStatus status = default,
            List<string> sourcePaths = default,
            List<string> destinationPaths = default,
            string sourceTypeId = "LocalFile",
            string destinationTypeId = "LocalFile")
        {
            status ??= _testPartStatus;
            // Populate sourcePaths if not provided
            if (sourcePaths == default)
            {
                string parentSourcePath = "sample-source";
                sourcePaths = new List<string>();
                for (int i = 0; i < jobPartCount; i++)
                {
                    sourcePaths.Add(Path.Combine(parentSourcePath, $"file{i}"));
                }
            }
            // Populate destPaths if not provided
            if (destinationPaths == default)
            {
                string parentDestinationPath = "sample-dest";
                destinationPaths = new List<string>();
                for (int i = 0; i < jobPartCount; i++)
                {
                    destinationPaths.Add(Path.Combine(parentDestinationPath, $"file{i}"));
                }
            }

            for (int partNumber = 0; partNumber < jobPartCount; partNumber++)
            {
                // Populate the JobPlanFile with a pseudo job plan header

                JobPartPlanHeader header = CheckpointerTesting.CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber,
                    sourceTypeId: sourceTypeId,
                    destinationTypeId: destinationTypeId,
                    sourcePath: sourcePaths.ElementAt(partNumber),
                    destinationPath: destinationPaths.ElementAt(partNumber),
                    jobPartStatus: status);

                JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath, transferId, partNumber);

                using (FileStream stream = File.Create(fileName.FullPath))
                {
                    header.Serialize(stream);
                }
            }
        }

        internal void CreateStubJobPlanFile(
            string checkpointPath,
            string transferId,
            string parentSourcePath = _testSourcePath,
            string parentDestinationPath = _testDestinationPath,
            string sourceProviderId = _testSourceProviderId,
            string destinationProviderId = _testDestinationProviderId,
            bool isContainer = false,
            DataTransferStatus status = default,
            StorageResourceCheckpointData sourceCheckpointData = default,
            StorageResourceCheckpointData destinationCheckpointData = default)
        {
            status ??= new DataTransferStatus();
            sourceCheckpointData ??= MockResourceCheckpointData.DefaultInstance;
            destinationCheckpointData ??= MockResourceCheckpointData.DefaultInstance;

            JobPlanHeader header = new JobPlanHeader(
                DataMovementConstants.JobPlanFile.SchemaVersion,
                transferId,
                DateTimeOffset.UtcNow,
                JobPlanOperation.ServiceToService,
                sourceProviderId,
                destinationProviderId,
                isContainer,
                false, /* enumerationComplete */
                status,
                parentSourcePath,
                parentDestinationPath,
                sourceCheckpointData,
                destinationCheckpointData);

            string filePath = Path.Combine(checkpointPath, $"{transferId}{DataMovementConstants.JobPlanFile.FileExtension}");
            using (FileStream stream = File.Create(filePath))
            {
                header.Serialize(stream);
            }
        }

        public static string GetNewTransferId() => Guid.NewGuid().ToString();
    }
}
