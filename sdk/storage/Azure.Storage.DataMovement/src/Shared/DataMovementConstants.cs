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
            internal const string SchemaVersion_b1 = "b1";
            internal const string SchemaVersion = SchemaVersion_b1; // TODO: remove b for beta

            // Job Plan file extension. e.g. the file extension will look like {transferid}--{jobpartNumber}.steV{schemaVersion}
            internal const string FileExtension = ".steV";
            internal const string JobPlanFileNameDelimiter = "--";
            internal const int JobPartLength = 5;
            internal const int IdSize = 36; // Size of a guid with hyphens
            internal const int CustomHeaderMaxBytes = 256;
            internal const int Padding = 8;

            internal const int OneByte = 1;
            internal const int LongSizeInBytes = 8;
            internal const int UShortSizeInBytes = 2;

            // UTF-8 encoding, so 2 bytes per char
            internal const int VersionStrLength = 2;
            internal const int VersionStrNumBytes = VersionStrLength * 2;
            internal const int TransferIdStrLength = 36;
            internal const int TransferIdStrNumBytes = TransferIdStrLength * 2;
            internal const int PathStrMaxLength = 4096;
            internal const int PathStrNumBytes = PathStrMaxLength * 2;
            internal const int ExtraQueryMaxLength = 1000;
            internal const int ExtraQueryNumBytes = ExtraQueryMaxLength * 2;
            internal const int HeaderValueMaxLength = 1000;
            internal const int HeaderValueNumBytes = HeaderValueMaxLength * 2;
            internal const int MetadataStrMaxLength = 4096;
            internal const int MetadataStrNumBytes = MetadataStrMaxLength * 2;
            internal const int BlobTagsStrMaxLength = 4096;
            internal const int BlobTagsStrNumBytes = BlobTagsStrMaxLength * 2;

            /// <summary>Index: 0</summary>
            internal const int VersionIndex = 0; // Index: 0
            /// <summary>Index: 4</summary>
            internal const int StartTimeIndex = VersionIndex + VersionStrNumBytes;
            /// <summary>Index: 12</summary>
            internal const int TransferIdIndex = StartTimeIndex + LongSizeInBytes;
            /// <summary>Index: 84</summary>
            internal const int PartNumberIndex = TransferIdIndex + TransferIdStrNumBytes;
            /// <summary>Index: 92</summary>
            internal const int SourcePathLengthIndex = PartNumberIndex + LongSizeInBytes;
            /// <summary>Index: 94</summary>
            internal const int SourcePathIndex = SourcePathLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 8,286</summary>
            internal const int SourceExtraQueryLengthIndex = SourcePathIndex + PathStrNumBytes;
            /// <summary>Index: 8,288</summary>
            internal const int SourceExtraQueryIndex = SourceExtraQueryLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 10,288</summary>
            internal const int DestinationPathLengthIndex = SourceExtraQueryIndex + ExtraQueryNumBytes;
            /// <summary>Index: 10,290</summary>
            internal const int DestinationPathIndex = DestinationPathLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 18,482</summary>
            internal const int DestinationExtraQueryLengthIndex = DestinationPathIndex + PathStrNumBytes;
            /// <summary>Index: 18,484</summary>
            internal const int DestinationExtraQueryIndex = DestinationExtraQueryLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 20,484</summary>
            internal const int IsFinalPartIndex = DestinationExtraQueryIndex + ExtraQueryNumBytes;
            /// <summary>Index: 20,485</summary>
            internal const int ForceWriteIndex = IsFinalPartIndex + OneByte;
            /// <summary>Index: 20,486</summary>
            internal const int ForceIfReadOnlyIndex = ForceWriteIndex + OneByte;
            /// <summary>Index: 20,487</summary>
            internal const int AutoDecompressIndex = ForceIfReadOnlyIndex + OneByte;
            /// <summary>Index: 20,488</summary>
            internal const int PriorityIndex = AutoDecompressIndex + OneByte;
            /// <summary>Index: 20,489</summary>
            internal const int TTLAfterCompletionIndex = PriorityIndex + OneByte;
            /// <summary>Index: 20,497</summary>
            internal const int FromToIndex = TTLAfterCompletionIndex + LongSizeInBytes;
            /// <summary>Index: 20,498</summary>
            internal const int FolderPropertyModeIndex = FromToIndex + OneByte;
            /// <summary>Index: 20,499</summary>
            internal const int NumberChunksIndex = FolderPropertyModeIndex + OneByte;

            // JobPartPlanDestinationBlob Indexes
            /// <summary>Index: 10,299</summary>
            internal const int DstBlobTypeIndex = NumberChunksIndex + LongSizeInBytes;
            /// <summary>Index: 10,300</summary>
            internal const int DstBlobNoGuessMimeTypeIndex = DstBlobTypeIndex + OneByte;
            /// <summary>Index: 10,301</summary>
            internal const int DstBlobContentTypeLengthIndex = DstBlobNoGuessMimeTypeIndex + OneByte;
            /// <summary>Index: 10,309</summary>
            internal const int DstBlobContentTypeIndex = DstBlobContentTypeLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 11,309</summary>
            internal const int DstBlobContentEncodingLengthIndex = DstBlobContentTypeIndex + HeaderValueNumBytes;
            /// <summary>Index: 11,317</summary>
            internal const int DstBlobContentEncodingIndex = DstBlobContentEncodingLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 12,317</summary>
            internal const int DstBlobContentLanguageLengthIndex = DstBlobContentEncodingIndex + HeaderValueNumBytes;
            /// <summary>Index: 12,325</summary>
            internal const int DstBlobContentLanguageIndex = DstBlobContentLanguageLengthIndex + UShortSizeInBytes;
            internal const int DstBlobContentDispositionLengthIndex = DstBlobContentLanguageIndex + HeaderValueNumBytes;
            internal const int DstBlobContentDispositionIndex = DstBlobContentDispositionLengthIndex + UShortSizeInBytes;
            internal const int DstBlobCacheControlLengthIndex = DstBlobContentDispositionIndex + HeaderValueNumBytes;
            internal const int DstBlobCacheControlIndex = DstBlobCacheControlLengthIndex + UShortSizeInBytes;
            internal const int DstBlobBlockBlobTierIndex = DstBlobCacheControlIndex + HeaderValueNumBytes;
            internal const int DstBlobPageBlobTierIndex = DstBlobBlockBlobTierIndex + OneByte;
            internal const int DstBlobPutMd5Index = DstBlobPageBlobTierIndex + OneByte;
            internal const int DstBlobMetadataLengthIndex = DstBlobPutMd5Index + OneByte;
            internal const int DstBlobMetadataIndex = DstBlobMetadataLengthIndex + UShortSizeInBytes;
            internal const int DstBlobTagsLengthIndex = DstBlobMetadataIndex + MetadataStrNumBytes;
            internal const int DstBlobTagsIndex = DstBlobTagsLengthIndex + LongSizeInBytes;
            internal const int DstBlobIsSourceEncrypted = DstBlobTagsIndex + BlobTagsStrNumBytes;
            internal const int DstBlobCpkScopeInfoLengthIndex = DstBlobIsSourceEncrypted + OneByte;
            internal const int DstBlobCpkScopeInfoIndex = DstBlobCpkScopeInfoLengthIndex + UShortSizeInBytes;
            internal const int DstBlobBlockSizeIndex = DstBlobCpkScopeInfoIndex + HeaderValueNumBytes;

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

        internal static class ErrorCode
        {
            internal static readonly string[] CannotOverwrite = { "BlobAlreadyExists", "Cannot overwite file." };
            internal static readonly string[] AccessDenied = { "AuthenticationFailed", "AuthorizationFailure", "access denied" };
        }
    }
}
