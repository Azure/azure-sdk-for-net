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
        internal const string _testTransferId =
            "c591bacc-5552-4c5c-b068-552685ec5cd5";
        internal const long _testPartNumber = 5;
        internal static readonly DateTimeOffset _testStartTime
            = new DateTimeOffset(2023, 03, 13, 15, 24, 6, default);
        internal const string _testSourceResourceId = "LocalFile";
        internal const string _testSourcePath = "C:/sample-source";
        internal const string _testSourceQuery = "sourcequery";
        internal const string _testDestinationResourceId = "LocalFile";
        internal const string _testDestinationPath = "C:/sample-destination";
        internal const string _testDestinationQuery = "destquery";
        internal const byte _testPriority = 0;
        internal static readonly DateTimeOffset _testTtlAfterCompletion = DateTimeOffset.MaxValue;
        internal const JobPlanOperation _testJobPlanOperation = JobPlanOperation.Upload;
        internal const FolderPropertiesMode _testFolderPropertiesMode = FolderPropertiesMode.None;
        internal const long _testNumberChunks = 1;
        internal const JobPlanBlobType _testBlobType = JobPlanBlobType.BlockBlob;
        internal const string _testContentType = "ContentType / type";
        internal const string _testContentEncoding = "UTF8";
        internal const string _testContentLanguage = "content-language";
        internal const string _testContentDisposition = "content-disposition";
        internal const string _testCacheControl = "cache-control";
        internal const JobPartPlanBlockBlobTier _testBlockBlobTier = JobPartPlanBlockBlobTier.None;
        internal const JobPartPlanPageBlobTier _testPageBlobTier = JobPartPlanPageBlobTier.None;
        internal const string _testCpkScopeInfo = "cpk-scope-info";
        internal const long _testBlockSize = 4 * Constants.KB;
        internal const byte _testS2sInvalidMetadataHandleOption = 0;
        internal const byte _testChecksumVerificationOption = 0;
        internal const JobPartDeleteSnapshotsOption _testDeleteSnapshotsOption = JobPartDeleteSnapshotsOption.None;
        internal const JobPartPermanentDeleteOption _testPermanentDeleteOption = JobPartPermanentDeleteOption.None;
        internal const JobPartPlanRehydratePriorityType _testRehydratePriorityType = JobPartPlanRehydratePriorityType.None;
        internal const DataTransferStatus _testJobStatus = DataTransferStatus.Queued;
        internal const DataTransferStatus _testPartStatus = DataTransferStatus.Queued;

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
                CreateStubJobPartPlanFilesAsync(
                    checkpointerPath: _checkpointerPath,
                    transferId: GetNewTransferId(),
                    jobPartCount: _partCountDefault);
            }

            // Return constructed chekcpointer
            return new LocalTransferCheckpointer(_checkpointerPath);
        }

        public LocalTransferCheckpointer BuildCheckpointer(List<DataTransfer> dataTransfers)
        {
            foreach (DataTransfer dataTransfer in dataTransfers)
            {
                CreateStubJobPartPlanFilesAsync(
                    checkpointerPath: _checkpointerPath,
                    transferId: dataTransfer.Id,
                    jobPartCount: _partCountDefault,
                    status: dataTransfer.TransferStatus);
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
            DataTransferStatus status = DataTransferStatus.Queued,
            List<string> sourcePaths = default,
            List<string> destinationPaths = default,
            string sourceResourceId = "LocalFile",
            string destinationResourceId = "LocalFile")
        {
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

                JobPartPlanHeader header = CreateDefaultJobPartHeader(
                    transferId: transferId,
                    partNumber: partNumber,
                    sourceResourceId: sourceResourceId,
                    sourcePath: sourcePaths.ElementAt(partNumber),
                    destinationResourceId: destinationResourceId,
                    destinationPath: destinationPaths.ElementAt(partNumber),
                    atomicJobStatus: status,
                    atomicPartStatus: status);

                JobPartPlanFileName fileName = new JobPartPlanFileName(checkpointerPath, transferId, partNumber);

                using (FileStream stream = File.Create(fileName.FullPath, DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes))
                {
                    header.Serialize(stream);
                }
            }
        }

        internal JobPartPlanHeader CreateDefaultJobPartHeader(
            string version = DataMovementConstants.JobPartPlanFile.SchemaVersion,
            DateTimeOffset startTime = default,
            string transferId = _testTransferId,
            long partNumber = _testPartNumber,
            string sourceResourceId = _testSourceResourceId,
            string sourcePath = _testSourcePath,
            string sourceExtraQuery = _testSourceQuery,
            string destinationResourceId = _testDestinationResourceId,
            string destinationPath = _testDestinationPath,
            string destinationExtraQuery = _testDestinationQuery,
            bool isFinalPart = false,
            bool forceWrite = false,
            bool forceIfReadOnly = false,
            bool autoDecompress = false,
            byte priority = _testPriority,
            DateTimeOffset ttlAfterCompletion = default,
            JobPlanOperation fromTo = _testJobPlanOperation,
            FolderPropertiesMode folderPropertyMode = _testFolderPropertiesMode,
            long numberChunks = _testNumberChunks,
            JobPlanBlobType blobType = _testBlobType,
            bool noGuessMimeType = false,
            string contentType = _testContentType,
            string contentEncoding = _testContentEncoding,
            string contentLanguage = _testContentLanguage,
            string contentDisposition = _testContentDisposition,
            string cacheControl = _testCacheControl,
            JobPartPlanBlockBlobTier blockBlobTier = _testBlockBlobTier,
            JobPartPlanPageBlobTier pageBlobTier = _testPageBlobTier,
            bool putMd5 = false,
            IDictionary<string, string> metadata = default,
            IDictionary<string, string> blobTags = default,
            bool isSourceEncrypted = false,
            string cpkScopeInfo = _testCpkScopeInfo,
            long blockSize = _testBlockSize,
            bool preserveLastModifiedTime = false,
            byte checksumVerificationOption = _testChecksumVerificationOption,
            bool preserveSMBPermissions = false,
            bool preserveSMBInfo = false,
            bool s2sGetPropertiesInBackend = false,
            bool s2sSourceChangeValidation = false,
            bool destLengthValidation = false,
            byte s2sInvalidMetadataHandleOption = _testS2sInvalidMetadataHandleOption,
            JobPartDeleteSnapshotsOption deleteSnapshotsOption = _testDeleteSnapshotsOption,
            JobPartPermanentDeleteOption permanentDeleteOption = _testPermanentDeleteOption,
            JobPartPlanRehydratePriorityType rehydratePriorityType = _testRehydratePriorityType,
            DataTransferStatus atomicJobStatus = _testJobStatus,
            DataTransferStatus atomicPartStatus = _testPartStatus)
        {
            if (startTime == default)
            {
                startTime = _testStartTime;
            }
            if (ttlAfterCompletion == default)
            {
                ttlAfterCompletion = _testTtlAfterCompletion;
            }
            metadata ??= BuildMetadata();
            blobTags ??= BuildTags();

            JobPartPlanDestinationBlob dstBlobData = new JobPartPlanDestinationBlob(
                blobType: blobType,
                noGuessMimeType: noGuessMimeType,
                contentType: contentType,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentDisposition: contentDisposition,
                cacheControl: cacheControl,
                blockBlobTier: blockBlobTier,
                pageBlobTier: pageBlobTier,
                putMd5: putMd5,
                metadata: metadata,
                blobTags: blobTags,
                isSourceEncrypted: isSourceEncrypted,
                cpkScopeInfo: cpkScopeInfo,
                blockSize: blockSize);

            JobPartPlanDestinationLocal dstLocalData = new JobPartPlanDestinationLocal(
                preserveLastModifiedTime: preserveLastModifiedTime,
                checksumVerificationOption: checksumVerificationOption);

            return new JobPartPlanHeader(
                version: version,
                startTime: startTime,
                transferId: transferId,
                partNumber: partNumber,
                sourceResourceId: sourceResourceId,
                sourcePath: sourcePath,
                sourceExtraQuery: sourceExtraQuery,
                destinationResourceId: destinationResourceId,
                destinationPath: destinationPath,
                destinationExtraQuery: destinationExtraQuery,
                isFinalPart: isFinalPart,
                forceWrite: forceWrite,
                forceIfReadOnly: forceIfReadOnly,
                autoDecompress: autoDecompress,
                priority: priority,
                ttlAfterCompletion: ttlAfterCompletion,
                jobPlanOperation: fromTo,
                folderPropertyMode: folderPropertyMode,
                numberChunks: numberChunks,
                dstBlobData: dstBlobData,
                dstLocalData: dstLocalData,
                preserveSMBPermissions: preserveSMBPermissions,
                preserveSMBInfo: preserveSMBInfo,
                s2sGetPropertiesInBackend: s2sGetPropertiesInBackend,
                s2sSourceChangeValidation: s2sSourceChangeValidation,
                destLengthValidation: destLengthValidation,
                s2sInvalidMetadataHandleOption: s2sInvalidMetadataHandleOption,
                deleteSnapshotsOption: deleteSnapshotsOption,
                permanentDeleteOption: permanentDeleteOption,
                rehydratePriorityType: rehydratePriorityType,
                atomicJobStatus: atomicJobStatus,
                atomicPartStatus: atomicPartStatus);
        }

        public static string GetNewTransferId() => Guid.NewGuid().ToString();
        private IDictionary<string, string> BuildMetadata()
            => new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "foo", "bar" },
                    { "meta", "data" },
                    { "Capital", "letter" },
                    { "UPPER", "case" }
                };

        private Dictionary<string, string> BuildTags()
            => new Dictionary<string, string>
            {
                { "tagKey0", "tagValue0" },
                { "tagKey1", "tagValue1" }
            };
    }
}
