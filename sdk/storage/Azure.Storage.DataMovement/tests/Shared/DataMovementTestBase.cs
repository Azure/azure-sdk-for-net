﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using System.IO;
using System.Collections.Generic;
using System;
using Azure.Storage.Test;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models.JobPlan;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Base class for Blob DataMovement Tests tests
    /// </summary>
    public abstract class DataMovementTestBase : StorageTestBase<StorageTestEnvironment>
    {
        public enum TransferType
        {
            Upload,
            Download,
            AsyncCopy,
            SyncCopy
        }

        public DataMovementTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [SetUp]
        public void Setup()
        {
        }
        public static string GetNewTransferId() => Guid.NewGuid().ToString();

        public List<string> ListFilesInDirectory(string directory)
        {
            List<string> files = new List<string>();

            // Create a queue of folders to enumerate files from, starting with provided path
            Queue<string> folders = new();
            folders.Enqueue(directory);

            while (folders.Count > 0)
            {
                // Grab a folder from the queue
                string dir = folders.Dequeue();

                // Try to enumerate and queue all subdirectories of the current folder
                try
                {
                    foreach (string subdir in Directory.EnumerateDirectories(dir))
                    {
                        folders.Enqueue(subdir);
                    }
                }
                catch
                {
                    // If we lack permissions to enumerate, throw if the caller specifies
                    // that we shouldn't continue on error.
                    //
                    // TODO: Logging for missing permissions to enumerate folder
                    //
                    // Afterthought: once logging is implemented, we can just log any problems
                    // (whether with given dir or subdir), and skip if told to/throw if not. No need for
                    // the `dir == _basePath` check (which right now is just a filler signal
                    // for something going wrong, as opposed to an "success" with an empty list).
                    if (dir == directory)
                    {
                        throw;
                    }

                    // Otherwise, just log the failed subdirectory and continue to list as many
                    // files as accessible.
                    continue;
                }

                // Send all files in the directory to the scan results
                foreach (string file in Directory.EnumerateFiles(dir))
                {
                    files.Add(file);
                }
            }
            return files;
        }

        public Dictionary<string, string> BuildTags()
            => new Dictionary<string, string>
            {
                { "tagKey0", "tagValue0" },
                { "tagKey1", "tagValue1" }
            };

        internal const string _testTransferId =
            "c591bacc-5552-4c5c-b068-552685ec5cd5";
        internal const long _testPartNumber = 5;
        internal static readonly DateTimeOffset _testStartTime
            = new DateTimeOffset(2023, 03, 13, 15, 24, 6, default);
        internal const string _testSourcePath = "C:/sample-source";
        internal const string _testSourceQuery = "sourcequery";
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
        internal const StorageTransferStatus _testJobStatus = StorageTransferStatus.Queued;
        internal const StorageTransferStatus _testPartStatus = StorageTransferStatus.Queued;

        internal JobPartPlanHeader CreateDefaultJobPartHeader(
            string version = DataMovementConstants.PlanFile.SchemaVersion,
            DateTimeOffset startTime = default,
            string transferId = _testTransferId,
            long partNumber = _testPartNumber,
            string sourcePath = _testSourcePath,
            string sourceExtraQuery = _testSourceQuery,
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
            StorageTransferStatus atomicJobStatus = _testJobStatus,
            StorageTransferStatus atomicPartStatus = _testPartStatus)
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
                sourcePath: sourcePath,
                sourceExtraQuery: sourceExtraQuery,
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
            int headerSize = DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes;
            using var originalHeaderStream = new MemoryStream(headerSize);
            header.Serialize(originalHeaderStream);
            originalHeaderStream.Seek(0, SeekOrigin.Begin);
            stream.Seek(0, SeekOrigin.Begin);

            for (var i = 0; i < headerSize; i += Constants.DefaultBufferSize * 5 / 2)
            {
                var startIndex = i;
                var count = Math.Min(Constants.DefaultBufferSize, (int)(headerSize - startIndex));

                var buffer = new byte[count];
                var actual = new byte[count];
                stream.Seek(i, SeekOrigin.Begin);
                originalHeaderStream.Seek(i, SeekOrigin.Begin);
                await stream.ReadAsync(buffer, 0, count);
                await originalHeaderStream.ReadAsync(actual, 0, count);

                TestHelper.AssertSequenceEqual(
                    actual,
                    buffer);
            }
        }
    }
}
