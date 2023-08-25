// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;

using Azure.Storage.Test;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
#if BlobDataMovementSDK
using DMBlobs::Azure.Storage.DataMovement.JobPlan;
#else
using Azure.Storage.DataMovement.JobPlan;
#endif
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    internal class CheckpointerTesting
    {
        private const int KB = 1024;
        private const int MB = 1024 * KB;
        internal const string DefaultTransferId =
            "c591bacc-5552-4c5c-b068-552685ec5cd5";
        internal const long DefaultPartNumber = 5;
        internal static readonly DateTimeOffset DefaultStartTime
            = new DateTimeOffset(2023, 03, 13, 15, 24, 6, default);
        internal const string DefaultSourceResourceId = "LocalFile";
        internal const string DefaultSourcePath = "C:/sample-source";
        internal const string DefaultSourceQuery = "sourcequery";
        internal const string DefaultDestinationResourceId = "LocalFile";
        internal const string DefaultDestinationPath = "C:/sample-destination";
        internal const string DefaultDestinationQuery = "destquery";
        internal const byte DefaultPriority = 0;
        internal static readonly DateTimeOffset DefaultTtlAfterCompletion = DateTimeOffset.MaxValue;
        internal const JobPlanOperation DefaultJobPlanOperation = JobPlanOperation.Upload;
        internal const FolderPropertiesMode DefaultFolderPropertiesMode = FolderPropertiesMode.None;
        internal const long DefaultNumberChunks = 1;
        internal const JobPlanBlobType DefaultBlobType = JobPlanBlobType.BlockBlob;
        internal const string DefaultContentType = "ContentType / type";
        internal const string DefaultContentEncoding = "UTF8";
        internal const string DefaultContentLanguage = "content-language";
        internal const string DefaultContentDisposition = "content-disposition";
        internal const string DefaultCacheControl = "cache-control";
        internal const JobPartPlanBlockBlobTier DefaultBlockBlobTier = JobPartPlanBlockBlobTier.None;
        internal const JobPartPlanPageBlobTier DefaultPageBlobTier = JobPartPlanPageBlobTier.None;
        internal const string DefaultCpkScopeInfo = "cpk-scope-info";
        internal const long DefaultBlockSize = 4 * KB;
        internal const byte DefaultS2sInvalidMetadataHandleOption = 0;
        internal const byte DefaultChecksumVerificationOption = 0;
        internal const JobPartDeleteSnapshotsOption DefaultDeleteSnapshotsOption = JobPartDeleteSnapshotsOption.None;
        internal const JobPartPermanentDeleteOption DefaultPermanentDeleteOption = JobPartPermanentDeleteOption.None;
        internal const JobPartPlanRehydratePriorityType DefaultRehydratePriorityType = JobPartPlanRehydratePriorityType.None;
        internal const DataTransferStatus DefaultJobStatus = DataTransferStatus.Queued;
        internal const DataTransferStatus DefaultPartStatus = DataTransferStatus.Queued;

        internal static JobPartPlanHeader CreateDefaultJobPartHeader(
            string version = DataMovementConstants.JobPartPlanFile.SchemaVersion,
            DateTimeOffset startTime = default,
            string transferId = DefaultTransferId,
            long partNumber = DefaultPartNumber,
            string sourceResourceId = DefaultSourceResourceId,
            string sourcePath = DefaultSourcePath,
            string sourceExtraQuery = DefaultSourceQuery,
            string destinationResourceId = DefaultDestinationResourceId,
            string destinationPath = DefaultDestinationPath,
            string destinationExtraQuery = DefaultDestinationQuery,
            bool isFinalPart = false,
            bool forceWrite = false,
            bool forceIfReadOnly = false,
            bool autoDecompress = false,
            byte priority = DefaultPriority,
            DateTimeOffset ttlAfterCompletion = default,
            JobPlanOperation fromTo = DefaultJobPlanOperation,
            FolderPropertiesMode folderPropertyMode = DefaultFolderPropertiesMode,
            long numberChunks = DefaultNumberChunks,
            JobPlanBlobType blobType = DefaultBlobType,
            bool noGuessMimeType = false,
            string contentType = DefaultContentType,
            string contentEncoding = DefaultContentEncoding,
            string contentLanguage = DefaultContentLanguage,
            string contentDisposition = DefaultContentDisposition,
            string cacheControl = DefaultCacheControl,
            JobPartPlanBlockBlobTier blockBlobTier = DefaultBlockBlobTier,
            JobPartPlanPageBlobTier pageBlobTier = DefaultPageBlobTier,
            bool putMd5 = false,
            IDictionary<string, string> metadata = default,
            IDictionary<string, string> blobTags = default,
            bool isSourceEncrypted = false,
            string cpkScopeInfo = DefaultCpkScopeInfo,
            long blockSize = DefaultBlockSize,
            bool preserveLastModifiedTime = false,
            byte checksumVerificationOption = DefaultChecksumVerificationOption,
            bool preserveSMBPermissions = false,
            bool preserveSMBInfo = false,
            bool s2sGetPropertiesInBackend = false,
            bool s2sSourceChangeValidation = false,
            bool destLengthValidation = false,
            byte s2sInvalidMetadataHandleOption = DefaultS2sInvalidMetadataHandleOption,
            JobPartDeleteSnapshotsOption deleteSnapshotsOption = DefaultDeleteSnapshotsOption,
            JobPartPermanentDeleteOption permanentDeleteOption = DefaultPermanentDeleteOption,
            JobPartPlanRehydratePriorityType rehydratePriorityType = DefaultRehydratePriorityType,
            DataTransferStatus atomicJobStatus = DefaultJobStatus,
            DataTransferStatus atomicPartStatus = DefaultPartStatus)
        {
            if (startTime == default)
            {
                startTime = DefaultStartTime;
            }
            if (ttlAfterCompletion == default)
            {
                ttlAfterCompletion = DefaultTtlAfterCompletion;
            }
            metadata ??= DataProvider.BuildMetadata();
            blobTags ??= DataProvider.BuildTags();

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

        internal static async Task AssertJobPlanHeaderAsync(JobPartPlanHeader header, Stream stream)
        {
            int headerSize = DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes;
            using var originalHeaderStream = new MemoryStream(headerSize);
            header.Serialize(originalHeaderStream);
            originalHeaderStream.Seek(0, SeekOrigin.Begin);
            stream.Seek(0, SeekOrigin.Begin);

            for (var i = 0; i < headerSize; i += (int)DefaultBlockSize * 5 / 2)
            {
                var startIndex = i;
                var count = Math.Min((int)DefaultBlockSize, (int)(headerSize - startIndex));

                var buffer = new byte[count];
                var actual = new byte[count];
                stream.Seek(i, SeekOrigin.Begin);
                originalHeaderStream.Seek(i, SeekOrigin.Begin);
                await stream.ReadAsync(buffer, 0, count);
                await originalHeaderStream.ReadAsync(actual, 0, count);

                CollectionAssert.AreEqual(
                    actual,
                    buffer);
            }
        }
    }
}
