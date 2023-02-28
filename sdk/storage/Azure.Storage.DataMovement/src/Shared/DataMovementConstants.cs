// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            internal const int VersionMaxSizeInBytes = 4; //  4 bytes
            internal const int TransferIdStrMaxSize = 36; // 36 chars
            internal const int TransferIdMaxSizeInBytes = 72; // 72 bytes
            internal const int PathStrMaxSize = 4096; // 8182 bytes
            internal const int PathStrMaxSizeInBytes = PathStrMaxSize * 2; // 8182 bytes
            internal const int ExtraQueryMaxSize = 1000; // 1000 char
            internal const int ExtraQueryMaxSizeInBytes = ExtraQueryMaxSize * 2; // 2000 bytes
            internal const int HeaderValueMaxSize = 1000; // 1000 char
            internal const int HeaderValueMaxSizeInBytes = HeaderValueMaxSize * 2; // 2000 bytes
            internal const int OneByte = 1; // 1 byte (bool's are one byte)
            internal const int MetadataStrMaxSize = 4096; // 8182 bytes (can update to be larger if needed)
            internal const int MetadataStrMaxSizeInBytes = MetadataStrMaxSize * 2; // 8182 bytes
            internal const int BlobTagsStrMaxSize = 4096; // 8182 bytes (can update to be larger if needed)
            internal const int BlobTagsStrMaxSizeInBytes = BlobTagsStrMaxSize * 2; // 8182 bytes

            /// <summary>Index: 0</summary>
            internal const int VersionIndex = 0; // Index: 0
            /// <summary>Index: 4</summary>
            internal const int StartTimeIndex = VersionIndex + VersionMaxSizeInBytes; // Index: 4
            /// <summary>Index: 12</summary>
            internal const int TransferIdIndex = StartTimeIndex + LongSizeInBytes; // Index: 12
            /// <summary>Index: 84</summary>
            internal const int PartNumberIndex = TransferIdIndex + TransferIdMaxSizeInBytes; // Index: 84
            /// <summary>Index: 92</summary>
            internal const int SourcePathLengthIndex = PartNumberIndex + LongSizeInBytes; // Index: 92
            /// <summary>Index: 100</summary>
            internal const int SourcePathIndex = SourcePathLengthIndex + LongSizeInBytes; // Index: 100
            /// <summary>Index: 8282</summary>
            internal const int SourceExtraQueryLengthIndex = SourcePathIndex + PathStrMaxSizeInBytes; // Index: 8282
            /// <summary>Index: 8290</summary>
            internal const int SourceExtraQueryIndex = SourceExtraQueryLengthIndex + LongSizeInBytes; // Index: 8290
            /// <summary>Index: 10,290</summary>
            internal const int DestinationPathLengthIndex = SourceExtraQueryIndex + ExtraQueryMaxSize; // Index: 10,290
            /// <summary>Index: 10,298</summary>
            internal const int DestinationPathIndex = DestinationPathLengthIndex + LongSizeInBytes; // Index: 10,298
            /// <summary>Index: 18,480</summary>
            internal const int DestinationExtraQueryLengthIndex = DestinationPathIndex + PathStrMaxSizeInBytes; // Index: 18,480
            /// <summary>Index: 18,488</summary>
            internal const int DestinationExtraQueryIndex = DestinationExtraQueryLengthIndex + LongSizeInBytes; // Index: 18,488
            /// <summary>Index: 20,488</summary>
            internal const int IsFinalPartIndex = DestinationExtraQueryIndex + ExtraQueryMaxSizeInBytes; // Index: 20,488
            /// <summary>Index: 20,489</summary>
            internal const int ForceWriteIndex = IsFinalPartIndex + OneByte; // Index: 20,489
            /// <summary>Index: 20,490</summary>
            internal const int ForceIfReadOnlyIndex = ForceWriteIndex + OneByte; // Index: 20,490
            /// <summary>Index: 20,491</summary>
            internal const int AutoDecompressIndex = ForceIfReadOnlyIndex + OneByte; // Index: 20,491
            /// <summary>Index: 20,492</summary>
            internal const int PriorityIndex = AutoDecompressIndex + OneByte; // Index: 20,492
            /// <summary>Index: 20,493</summary>
            internal const int TTLAfterCompletionIndex = PriorityIndex + OneByte; // Index: 20,493
            /// <summary>Index: 20,501</summary>
            internal const int FromToIndex = TTLAfterCompletionIndex + OneByte; // Index: 20,501
            /// <summary>Index: 20,502</summary>
            internal const int FolderPropertyOptionIndex = FromToIndex + OneByte; // Index: 20,502
            /// <summary>Index: 20,503</summary>
            internal const int NumberChunksIndex = FolderPropertyOptionIndex + OneByte; // Index: 20,503

            // JobPartPlanDestinationBlob Indexes
            /// <summary>Index: 20,511</summary>
            internal const int DstBlobTypeIndex = NumberChunksIndex + LongSizeInBytes; // Index: 20,511
            /// <summary>Index: 20,512</summary>
            internal const int DstBlobNoGuessMimeTypeIndex = DstBlobTypeIndex + OneByte; // Index: 20,512
            /// <summary>Index: 20,513</summary>
            internal const int DstBlobContentTypeLengthIndex = DstBlobNoGuessMimeTypeIndex + OneByte; // Index: 20,513
            /// <summary>Index: 20,521</summary>
            internal const int DstBlobContentTypeIndex = DstBlobContentTypeLengthIndex + LongSizeInBytes; // Index: 20,521
            /// <summary>Index: 20,529</summary>
            internal const int DstBlobContentEncodingLengthIndex = DstBlobContentTypeIndex + HeaderValueMaxSizeInBytes; // Index: 20,529
            /// <summary>Index: 22,529</summary>
            internal const int DstBlobContentEncodingIndex = DstBlobContentEncodingLengthIndex + LongSizeInBytes; // Index: 22,529
            /// <summary>Index: 24,529</summary>
            internal const int DstBlobContentLanguageLengthIndex = DstBlobContentEncodingIndex + HeaderValueMaxSizeInBytes; // Index: 24,529
            /// <summary>Index: 24,537</summary>
            internal const int DstBlobContentLanguageIndex = DstBlobContentLanguageLengthIndex + LongSizeInBytes; // Index: 24,537
            /// <summary>Index: 26,537</summary>
            internal const int DstBlobContentDispositionLengthIndex = DstBlobContentLanguageIndex + HeaderValueMaxSizeInBytes; // Index: 26,537
            /// <summary>Index: 26,545</summary>
            internal const int DstBlobContentDispositionIndex = DstBlobContentDispositionLengthIndex + LongSizeInBytes; // Index: 26,545
            /// <summary>Index: 28,545</summary>
            internal const int DstBlobCacheControlLengthIndex = DstBlobContentDispositionIndex + HeaderValueMaxSizeInBytes; // Index: 28,545
            /// <summary>Index: 28,553</summary>
            internal const int DstBlobCacheControlIndex = DstBlobCacheControlLengthIndex + LongSizeInBytes; // Index: 28,553
            /// <summary>Index: 30,553</summary>
            internal const int DstBlobBlockBlobTierIndex = DstBlobCacheControlIndex + HeaderValueMaxSizeInBytes; // Index: 30,553
            /// <summary>Index: 30,554</summary>
            internal const int DstBlobPageBlobTierIndex = DstBlobBlockBlobTierIndex + OneByte; // Index: 30,554
            /// <summary>Index: 30,554</summary>
            internal const int DstBlobPutMd5Index = DstBlobPageBlobTierIndex + OneByte; // Index: 30,554
            /// <summary>Index: 30,555</summary>
            internal const int DstBlobMetadataLengthIndex = DstBlobPutMd5Index + OneByte; // Index: 30,555
            /// <summary>Index: 30,556</summary>
            internal const int DstBlobMetadataIndex = DstBlobMetadataLengthIndex + LongSizeInBytes; // Index: 30,556
            /// <summary>Index: 38,738</summary>
            internal const int DstBlobTagsLengthIndex = DstBlobMetadataIndex + MetadataStrMaxSizeInBytes; // Index: 38,738
            /// <summary>Index: 38,746</summary>
            internal const int DstBlobTagsIndex = DstBlobTagsLengthIndex + LongSizeInBytes; // Index: 38,746
            /// <summary>Index: 46,928</summary>
            internal const int DstBlobCpkInfoLengthIndex = DstBlobTagsIndex + BlobTagsStrMaxSizeInBytes; // Index: 38,746
            /// <summary>Index: 46,936</summary>
            internal const int DstBlobCpkInfoIndex = DstBlobCpkInfoLengthIndex + LongSizeInBytes; // Index: 38,746
            /// <summary>Index: 46,928</summary>
            internal const int DstBlobCpkScopeInfoLengthIndex = DstBlobTagsIndex + BlobTagsStrMaxSizeInBytes; // Index: 38,746
            /// <summary>Index: 46,936</summary>
            internal const int DstBlobCpkScopeInfoIndex = DstBlobCpkScopeInfoLengthIndex + LongSizeInBytes; // Index: 38,746
            /// <summary>Index: 48,945</summary>
            internal const int DstBlobIsSourceEncrypted = DstBlobCpkInfoIndex + HeaderValueMaxSizeInBytes; // Index: 38,746
            /// <summary>Index: 48,946</summary>
            internal const int DstBlobCpkScopeLengthIndex = DstBlobIsSourceEncrypted + OneByte; // Index: 38,746
            /// <summary>Index: 48,954</summary>
            internal const int DstBlobCpkScopeIndex = DstBlobCpkScopeLengthIndex + LongSizeInBytes; // Index: 38,746
            /// <summary>Index: 50,954</summary>
            internal const int DstBlobBlockSizeIndex = DstBlobCpkScopeIndex + HeaderValueMaxSizeInBytes; // Index: 38,746

            // JobPartPlanDestinationLocal Indexes
            /// <summary>Index: 50,962</summary>
            internal const int DstLocalPreserveLastModifiedTimeIndex = DstBlobBlockSizeIndex + LongSizeInBytes; // Index: 38,746
            /// <summary>Index: 50,963</summary>
            internal const int DstLocalMD5VerificationOptionIndex = DstLocalPreserveLastModifiedTimeIndex + OneByte; // Index: 38,746
            /// <summary>Index: 50,964</summary>
            internal const int PreserveSMBPermissionsIndex = DstLocalMD5VerificationOptionIndex + OneByte;
            /// <summary>Index: 50,965</summary>
            internal const int PreserveSMBInfoIndex = PreserveSMBPermissionsIndex + OneByte;
            /// <summary>Index: 50,966</summary>
            internal const int S2SGetPropertiesInBackendIndex = PreserveSMBInfoIndex + OneByte;
            /// <summary>Index: 50,967</summary>
            internal const int S2SSourceChangeValidationIndex = S2SGetPropertiesInBackendIndex + OneByte;
            /// <summary>Index: 50,968</summary>
            internal const int DestLengthValidationIndex = S2SSourceChangeValidationIndex + OneByte;
            /// <summary>Index: 50,969</summary>
            internal const int S2SInvalidMetadataHandleOptionIndex = DestLengthValidationIndex + OneByte;
            /// <summary>Index: 50,970</summary>
            internal const int DeleteSnapshotsOptionIndex = S2SInvalidMetadataHandleOptionIndex + OneByte;
            /// <summary>Index: 50,971</summary>
            internal const int PermanentDeleteOptionIndex = DeleteSnapshotsOptionIndex + OneByte;
            /// <summary>Index: 50,972</summary>
            internal const int RehydratePriorityTypeIndex = PermanentDeleteOptionIndex + OneByte;
            /// <summary>Index: 50,973</summary>
            internal const int AtomicJobStatusIndex = RehydratePriorityTypeIndex + OneByte;
            /// <summary>Index: 50,974</summary>
            internal const int AtomicPartStatusIndex = AtomicJobStatusIndex + OneByte;
        }
    }
}
