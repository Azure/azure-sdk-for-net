// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.DataMovement.JobPlan;
using System.IO;
using System.Threading.Tasks;
using System;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    internal static class CheckpointerTesting
    {
        internal const string DefaultTransferId = "c591bacc-5552-4c5c-b068-552685ec5cd5";
        internal const long DefaultPartNumber = 5;
        internal const string DefaultSourceProviderId = "test";
        internal const string DefaultSourceTypeId = "LocalFile";
        internal const string DefaultSourcePath = "C:/sample-source";
        internal const string DefaultWebSourcePath = "https://example.com/source";
        internal const string DefaultDestinationProviderId = "test";
        internal const string DefaultDestinationTypeId = "BlockBlob";
        internal const string DefaultDestinationPath = "C:/sample-destination";
        internal const string DefaultWebDestinationPath = "https://example.com/destination";
        internal const StorageResourceCreationPreference DefaultCreatePreference = StorageResourceCreationPreference.FailIfExists;
        internal const long DefaultInitialTransferSize = 32 * Constants.MB;
        internal const long DefaultChunkSize = 4 * Constants.MB;
        internal const byte DefaultPriority = 0;
        internal const JobPlanOperation DefaultJobPlanOperation = JobPlanOperation.Upload;
        internal const long DefaultBlockSize = 4 * Constants.KB;
        internal const byte DefaultS2sInvalidMetadataHandleOption = 0;
        internal const byte DefaultChecksumVerificationOption = 0;
        internal static readonly DateTimeOffset DefaultCreateTime = new DateTimeOffset(2023, 08, 28, 17, 26, 0, default);
        internal static readonly DataTransferStatus DefaultJobStatus = new DataTransferStatus(DataTransferState.Queued, false, false);
        internal static readonly DataTransferStatus DefaultPartStatus = new DataTransferStatus(DataTransferState.Queued, false, false);

        internal static JobPartPlanHeader CreateDefaultJobPartHeader(
            string version = DataMovementConstants.JobPartPlanFile.SchemaVersion,
            string transferId = DefaultTransferId,
            long partNumber = DefaultPartNumber,
            DateTimeOffset createTime = default,
            string sourceTypeId = DefaultSourceTypeId,
            string destinationTypeId = DefaultDestinationTypeId,
            string sourcePath = DefaultSourcePath,
            string destinationPath = DefaultDestinationPath,
            StorageResourceCreationPreference createPreference = DefaultCreatePreference,
            long initialTransferSize = DefaultInitialTransferSize,
            long chunkSize = DefaultChunkSize,
            byte priority = DefaultPriority,
            DataTransferStatus jobPartStatus = default)
        {
            if (createTime == default)
            {
                createTime = DefaultCreateTime;
            }
            jobPartStatus ??= DefaultPartStatus;

            return new JobPartPlanHeader(
                version,
                transferId,
                partNumber,
                createTime,
                sourceTypeId,
                destinationTypeId,
                sourcePath,
                destinationPath,
                createPreference,
                initialTransferSize,
                chunkSize,
                priority,
                jobPartStatus);
        }

        internal static async Task AssertJobPlanHeaderAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            int partNumber,
            JobPartPlanHeader expectedHeader)
        {
            JobPartPlanHeader actualHeader;
            using (Stream actualStream = await checkpointer.ReadJobPartPlanFileAsync(
                transferId: transferId,
                partNumber: partNumber,
                offset: 0,
                length: 0)) // Read whole file
            {
                actualHeader = JobPartPlanHeader.Deserialize(actualStream);
            }

            Assert.That(actualHeader.Equals(expectedHeader));
        }
    }
}
