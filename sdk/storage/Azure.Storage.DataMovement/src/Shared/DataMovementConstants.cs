// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices.ComTypes;

namespace Azure.Storage.DataMovement
{
    internal class DataMovementConstants
    {
        /// <summary>
        /// Constants of the Data Movement library
        /// </summary>
        internal const int InitialMainPoolSize = 32;
        internal const int InitialDownloadFileThreads = 32; // Max is 3000
        internal const int CpuTuningMultiplier = 16;
        internal const int MaxJobPartReaders = 64;
        internal const int MaxJobChunkTasks = 3000;
        internal const int StatusCheckInSec = 10;

        internal static class ConcurrencyTuner
        {
            internal const int StandardMultiplier = 2;
            internal const int BoostedMultiplier = StandardMultiplier * 2;
            internal const int TopOfBoostZone = 256; // boosted multiplier applies up to this many connections
            internal const int SlowdownFactor = 5;
            internal const double MinMulitplier = 1.19; // really this is 1.2, but use a little less to make the floating point comparisons robust
            internal const double FudgeFactor = 0.2;
        }

        /// <summary>
        /// If there are multiple log files or job state files
        ///
        /// if limit is reached the customer should clear out their folder.
        /// </summary>
        internal const int DuplicateFileNameLimit = 100;

        internal const string DefaultCheckpointerPath = ".azstoragedml";

        /// <summary>
        ///  Constants used for logger extensions
        /// </summary>
        internal static class Log
        {
            internal const string FileExtension = ".log";

            /// <summary>
            /// Log File information
            /// </summary>
            internal const string LogTime = "UTC Time: ";
            internal const string LibraryVersion = "Azure.Storage.DataMovement Version: ";
            internal const string OsEnvironment = "OS-Environment: ";
            internal const string OsArchitecture = "OS-Architecture: ";
            internal const string Closing = "Closing log ";
        }

        /// <summary>
        /// Constants used for plan job transfer files
        /// </summary>
        internal static class PlanFile
        {
            // Job Plan file extension. e.g. the file extension will look like {transferid}--{jobpartNumber}.steV{schemaVersion}
            internal const string FileExtension = ".steV";
            internal const string JobPlanFileNameDelimiter = "--";
            internal const string SchemaVersion = "b1"; // TODO: remove b for beta
            internal const int JobPartLength = 5;
            internal const int IdSize = 36; // Size of a guid with hyphens
            // TODO: might change the value
            internal const long MemoryMappedFileSize = 4 * Constants.MB;
            internal const int CustomHeaderMaxBytes = 256;
            internal const int Padding = 8;

            internal const int LongSizeInBytes = 8; // 8 bytes
            internal const int VersionStrMaxSize = 2; // 2 chars
            internal const int TransferIdStrMaxSize = 36; // 36 chars
            internal const int PathStrMaxSize = 4096; // 8182 bytes
            internal const int ExtraQueryMaxSize = 1000; // 1000 char
            internal const int HeaderValueMaxSize = 1000; // 1000 char
            internal const int OneByte = 1; // 1 byte (bool's are one byte)
            internal const int MetadataStrMaxSize = 4096; // 8182 bytes (can update to be larger if needed)
            internal const int BlobTagsStrMaxSize = 4096; // 8182 bytes (can update to be larger if needed)

            /// <summary>Index: 0</summary>
            internal const int VersionIndex = 0; // Index: 0
            /// <summary>Index: 2</summary>
            internal const int StartTimeIndex = VersionIndex + VersionStrMaxSize;
            /// <summary>Index: 10</summary>
            internal const int TransferIdIndex = StartTimeIndex + LongSizeInBytes;
            /// <summary>Index: 46</summary>
            internal const int PartNumberIndex = TransferIdIndex + TransferIdStrMaxSize;
            /// <summary>Index: 52</summary>
            internal const int SourcePathLengthIndex = PartNumberIndex + LongSizeInBytes;
            /// <summary>Index: 60</summary>
            internal const int SourcePathIndex = SourcePathLengthIndex + LongSizeInBytes;
            /// <summary>Index: 4,156</summary>
            internal const int SourceExtraQueryLengthIndex = SourcePathIndex + PathStrMaxSize;
            /// <summary>Index: 4,164</summary>
            internal const int SourceExtraQueryIndex = SourceExtraQueryLengthIndex + LongSizeInBytes;
            /// <summary>Index: 5,164</summary>
            internal const int DestinationPathLengthIndex = SourceExtraQueryIndex + ExtraQueryMaxSize;
            /// <summary>Index: 5,172</summary>
            internal const int DestinationPathIndex = DestinationPathLengthIndex + LongSizeInBytes;
            /// <summary>Index: 9,268</summary>
            internal const int DestinationExtraQueryLengthIndex = DestinationPathIndex + PathStrMaxSize;
            /// <summary>Index: 9,276</summary>
            internal const int DestinationExtraQueryIndex = DestinationExtraQueryLengthIndex + LongSizeInBytes;
            /// <summary>Index: 10,276</summary>
            internal const int IsFinalPartIndex = DestinationExtraQueryIndex + ExtraQueryMaxSize;
            /// <summary>Index: 10,277</summary>
            internal const int ForceWriteIndex = IsFinalPartIndex + OneByte;
            /// <summary>Index: 10,278</summary>
            internal const int ForceIfReadOnlyIndex = ForceWriteIndex + OneByte;
            /// <summary>Index: 10,279</summary>
            internal const int AutoDecompressIndex = ForceIfReadOnlyIndex + OneByte;
            /// <summary>Index: 10,280</summary>
            internal const int PriorityIndex = AutoDecompressIndex + OneByte;
            /// <summary>Index: 10,281</summary>
            internal const int TTLAfterCompletionIndex = PriorityIndex + OneByte;
            /// <summary>Index: 10,289</summary>
            internal const int FromToIndex = TTLAfterCompletionIndex + LongSizeInBytes;
            /// <summary>Index: 10,290</summary>
            internal const int FolderPropertyModeIndex = FromToIndex + OneByte;
            /// <summary>Index: 10,291</summary>
            internal const int NumberChunksIndex = FolderPropertyModeIndex + OneByte;

            // JobPartPlanDestinationBlob Indexes
            /// <summary>Index: 10,299</summary>
            internal const int DstBlobTypeIndex = NumberChunksIndex + LongSizeInBytes;
            /// <summary>Index: 10,300</summary>
            internal const int DstBlobNoGuessMimeTypeIndex = DstBlobTypeIndex + OneByte;
            /// <summary>Index: 10,301</summary>
            internal const int DstBlobContentTypeLengthIndex = DstBlobNoGuessMimeTypeIndex + OneByte;
            /// <summary>Index: 10,309</summary>
            internal const int DstBlobContentTypeIndex = DstBlobContentTypeLengthIndex + LongSizeInBytes;
            /// <summary>Index: 11,309</summary>
            internal const int DstBlobContentEncodingLengthIndex = DstBlobContentTypeIndex + HeaderValueMaxSize;
            /// <summary>Index: 11,317</summary>
            internal const int DstBlobContentEncodingIndex = DstBlobContentEncodingLengthIndex + LongSizeInBytes;
            /// <summary>Index: 12,317</summary>
            internal const int DstBlobContentLanguageLengthIndex = DstBlobContentEncodingIndex + HeaderValueMaxSize;
            /// <summary>Index: 12,325</summary>
            internal const int DstBlobContentLanguageIndex = DstBlobContentLanguageLengthIndex + LongSizeInBytes;
            internal const int DstBlobContentDispositionLengthIndex = DstBlobContentLanguageIndex + HeaderValueMaxSize;
            internal const int DstBlobContentDispositionIndex = DstBlobContentDispositionLengthIndex + LongSizeInBytes;
            internal const int DstBlobCacheControlLengthIndex = DstBlobContentDispositionIndex + HeaderValueMaxSize;
            internal const int DstBlobCacheControlIndex = DstBlobCacheControlLengthIndex + LongSizeInBytes;
            internal const int DstBlobBlockBlobTierIndex = DstBlobCacheControlIndex + HeaderValueMaxSize;
            internal const int DstBlobPageBlobTierIndex = DstBlobBlockBlobTierIndex + OneByte;
            internal const int DstBlobPutMd5Index = DstBlobPageBlobTierIndex + OneByte;
            internal const int DstBlobMetadataLengthIndex = DstBlobPutMd5Index + OneByte;
            internal const int DstBlobMetadataIndex = DstBlobMetadataLengthIndex + LongSizeInBytes;
            internal const int DstBlobTagsLengthIndex = DstBlobMetadataIndex + MetadataStrMaxSize;
            internal const int DstBlobTagsIndex = DstBlobTagsLengthIndex + LongSizeInBytes;
            internal const int DstBlobCpkInfoLengthIndex = DstBlobTagsIndex + BlobTagsStrMaxSize;
            internal const int DstBlobCpkInfoIndex = DstBlobCpkInfoLengthIndex + LongSizeInBytes;
            internal const int DstBlobIsSourceEncrypted = DstBlobCpkInfoIndex + HeaderValueMaxSize;
            internal const int DstBlobCpkScopeInfoLengthIndex = DstBlobIsSourceEncrypted + OneByte;
            internal const int DstBlobCpkScopeInfoIndex = DstBlobCpkScopeInfoLengthIndex + LongSizeInBytes;
            internal const int DstBlobBlockSizeIndex = DstBlobCpkScopeInfoIndex + HeaderValueMaxSize;

            // JobPartPlanDestinationLocal Indexes
            internal const int DstLocalPreserveLastModifiedTimeIndex = DstBlobBlockSizeIndex + LongSizeInBytes;
            internal const int DstLocalMD5VerificationOptionIndex = DstLocalPreserveLastModifiedTimeIndex + OneByte;
            internal const int PreserveSMBPermissionsIndex = DstLocalMD5VerificationOptionIndex + OneByte;
            internal const int PreserveSMBInfoIndex = PreserveSMBPermissionsIndex + OneByte;
            internal const int S2SGetPropertiesInBackendIndex = PreserveSMBInfoIndex + OneByte;
            internal const int S2SSourceChangeValidationIndex = S2SGetPropertiesInBackendIndex + OneByte;
            internal const int DestLengthValidationIndex = S2SSourceChangeValidationIndex + OneByte;
            internal const int S2SInvalidMetadataHandleOptionIndex = DestLengthValidationIndex + OneByte;
            internal const int DeleteSnapshotsOptionIndex = S2SInvalidMetadataHandleOptionIndex + OneByte;
            internal const int PermanentDeleteOptionIndex = DeleteSnapshotsOptionIndex + OneByte;
            internal const int RehydratePriorityTypeIndex = PermanentDeleteOptionIndex + OneByte;
            internal const int AtomicJobStatusIndex = RehydratePriorityTypeIndex + OneByte;
            internal const int AtomicPartStatusIndex = AtomicJobStatusIndex + OneByte;
            /// <summary>
            /// Size of the JobPart Header
            /// </summary>
            internal const int JobPartHeaderSizeInBytes = AtomicPartStatusIndex + OneByte;
        }
    }
}
