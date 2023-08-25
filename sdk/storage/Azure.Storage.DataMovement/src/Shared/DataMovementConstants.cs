// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;

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

        internal const int OneByte = 1;
        internal const int LongSizeInBytes = 8;
        internal const int UShortSizeInBytes = 2;

        /// <summary>
        /// Constants used for job plan files.
        /// </summary>
        internal static class JobPlanFile
        {
            internal const string SchemaVersion_b1 = "b1";
            internal const string SchemaVersion = SchemaVersion_b1;

            internal const string FileExtension = ".ndm";
        }

        /// <summary>
        /// Constants used for job part plan files.
        /// </summary>
        internal static class JobPartPlanFile
        {
            internal const string SchemaVersion_b1 = "b1";
            internal const string SchemaVersion_b2 = "b2";
            internal const string SchemaVersion = SchemaVersion_b2; // TODO: remove b for beta

            // Job Plan file extension. e.g. the file extension will look like {transferid}--{jobpartNumber}.steV{schemaVersion}
            internal const string FileExtension = ".steV";
            internal const string JobPlanFileNameDelimiter = "--";
            internal const int JobPartLength = 5;
            internal const int IdSize = 36; // Size of a guid with hyphens
            internal const int CustomHeaderMaxBytes = 256;

            // UTF-8 encoding, so 2 bytes per char
            internal const int VersionStrLength = 2;
            internal const int VersionStrNumBytes = VersionStrLength * 2;
            internal const int TransferIdStrLength = 36;
            internal const int TransferIdStrNumBytes = TransferIdStrLength * 2;
            internal const int ResourceIdMaxStrLength = 20;
            internal const int ResourceIdNumBytes = ResourceIdMaxStrLength * 2;
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
            internal const int SourceResourceIdLengthIndex = PartNumberIndex + LongSizeInBytes;
            /// <summary>Index: 94</summary>
            internal const int SourceResourceIdIndex = SourceResourceIdLengthIndex + UShortSizeInBytes;

            /// <summary>Index: 134</summary>
            internal const int SourcePathLengthIndex = SourceResourceIdIndex + ResourceIdNumBytes;
            /// <summary>Index: 136</summary>
            internal const int SourcePathIndex = SourcePathLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 8328</summary>
            internal const int SourceExtraQueryLengthIndex = SourcePathIndex + PathStrNumBytes;
            /// <summary>Index: 8330</summary>
            internal const int SourceExtraQueryIndex = SourceExtraQueryLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 10330</summary>
            internal const int DestinationResourceIdLengthIndex = SourceExtraQueryIndex + ExtraQueryNumBytes;
            /// <summary>Index: 10332</summary>
            internal const int DestinationResourceIdIndex = DestinationResourceIdLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 10372</summary>
            internal const int DestinationPathLengthIndex = DestinationResourceIdIndex + ResourceIdNumBytes;
            /// <summary>Index: 10374</summary>
            internal const int DestinationPathIndex = DestinationPathLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 18566</summary>
            internal const int DestinationExtraQueryLengthIndex = DestinationPathIndex + PathStrNumBytes;
            /// <summary>Index: 18568</summary>
            internal const int DestinationExtraQueryIndex = DestinationExtraQueryLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 20568</summary>
            internal const int IsFinalPartIndex = DestinationExtraQueryIndex + ExtraQueryNumBytes;
            /// <summary>Index: 20569</summary>
            internal const int ForceWriteIndex = IsFinalPartIndex + OneByte;
            /// <summary>Index: 20570</summary>
            internal const int ForceIfReadOnlyIndex = ForceWriteIndex + OneByte;
            /// <summary>Index: 20571</summary>
            internal const int AutoDecompressIndex = ForceIfReadOnlyIndex + OneByte;
            /// <summary>Index: 20572</summary>
            internal const int PriorityIndex = AutoDecompressIndex + OneByte;
            /// <summary>Index: 20573</summary>
            internal const int TTLAfterCompletionIndex = PriorityIndex + OneByte;
            /// <summary>Index: 20581</summary>
            internal const int FromToIndex = TTLAfterCompletionIndex + LongSizeInBytes;
            /// <summary>Index: 20582</summary>
            internal const int FolderPropertyModeIndex = FromToIndex + OneByte;
            /// <summary>Index: 20583</summary>
            internal const int NumberChunksIndex = FolderPropertyModeIndex + OneByte;

            // JobPartPlanDestinationBlob Indexes
            /// <summary>Index: 20591</summary>
            internal const int DstBlobTypeIndex = NumberChunksIndex + LongSizeInBytes;
            /// <summary>Index: 20592</summary>
            internal const int DstBlobNoGuessMimeTypeIndex = DstBlobTypeIndex + OneByte;
            /// <summary>Index: 20593</summary>
            internal const int DstBlobContentTypeLengthIndex = DstBlobNoGuessMimeTypeIndex + OneByte;
            /// <summary>Index: 20595</summary>
            internal const int DstBlobContentTypeIndex = DstBlobContentTypeLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 22595</summary>
            internal const int DstBlobContentEncodingLengthIndex = DstBlobContentTypeIndex + HeaderValueNumBytes;
            /// <summary>Index: 22597</summary>
            internal const int DstBlobContentEncodingIndex = DstBlobContentEncodingLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 24597</summary>
            internal const int DstBlobContentLanguageLengthIndex = DstBlobContentEncodingIndex + HeaderValueNumBytes;
            /// <summary>Index: 24599</summary>
            internal const int DstBlobContentLanguageIndex = DstBlobContentLanguageLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 26599</summary>
            internal const int DstBlobContentDispositionLengthIndex = DstBlobContentLanguageIndex + HeaderValueNumBytes;
            /// <summary>Index: 26601</summary>
            internal const int DstBlobContentDispositionIndex = DstBlobContentDispositionLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 28601</summary>
            internal const int DstBlobCacheControlLengthIndex = DstBlobContentDispositionIndex + HeaderValueNumBytes;
            /// <summary>Index: 28603</summary>
            internal const int DstBlobCacheControlIndex = DstBlobCacheControlLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 30603</summary>
            internal const int DstBlobBlockBlobTierIndex = DstBlobCacheControlIndex + HeaderValueNumBytes;
            /// <summary>Index: 30604</summary>
            internal const int DstBlobPageBlobTierIndex = DstBlobBlockBlobTierIndex + OneByte;
            /// <summary>Index: 30605</summary>
            internal const int DstBlobPutMd5Index = DstBlobPageBlobTierIndex + OneByte;
            /// <summary>Index: 30606</summary>
            internal const int DstBlobMetadataLengthIndex = DstBlobPutMd5Index + OneByte;
            /// <summary>Index: 30608</summary>
            internal const int DstBlobMetadataIndex = DstBlobMetadataLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 38800</summary>
            internal const int DstBlobTagsLengthIndex = DstBlobMetadataIndex + MetadataStrNumBytes;
            /// <summary>Index: 38808</summary>
            internal const int DstBlobTagsIndex = DstBlobTagsLengthIndex + LongSizeInBytes;
            /// <summary>Index: 47000</summary>
            internal const int DstBlobIsSourceEncrypted = DstBlobTagsIndex + BlobTagsStrNumBytes;
            /// <summary>Index: 47001</summary>
            internal const int DstBlobCpkScopeInfoLengthIndex = DstBlobIsSourceEncrypted + OneByte;
            /// <summary>Index: 47003</summary>
            internal const int DstBlobCpkScopeInfoIndex = DstBlobCpkScopeInfoLengthIndex + UShortSizeInBytes;
            /// <summary>Index: 49003</summary>
            internal const int DstBlobBlockSizeIndex = DstBlobCpkScopeInfoIndex + HeaderValueNumBytes;

            // JobPartPlanDestinationLocal Indexes
            /// <summary>Index: 49011</summary>
            internal const int DstLocalPreserveLastModifiedTimeIndex = DstBlobBlockSizeIndex + LongSizeInBytes;
            /// <summary>Index: 49012</summary>
            internal const int DstLocalMD5VerificationOptionIndex = DstLocalPreserveLastModifiedTimeIndex + OneByte;

            /// <summary>Index: 49013</summary>
            internal const int PreserveSMBPermissionsIndex = DstLocalMD5VerificationOptionIndex + OneByte;
            /// <summary>Index: 49014</summary>
            internal const int PreserveSMBInfoIndex = PreserveSMBPermissionsIndex + OneByte;
            /// <summary>Index: 49015</summary>
            internal const int S2SGetPropertiesInBackendIndex = PreserveSMBInfoIndex + OneByte;
            /// <summary>Index: 49016</summary>
            internal const int S2SSourceChangeValidationIndex = S2SGetPropertiesInBackendIndex + OneByte;
            /// <summary>Index: 49017</summary>
            internal const int DestLengthValidationIndex = S2SSourceChangeValidationIndex + OneByte;
            /// <summary>Index: 49018</summary>
            internal const int S2SInvalidMetadataHandleOptionIndex = DestLengthValidationIndex + OneByte;
            /// <summary>Index: 49019</summary>
            internal const int DeleteSnapshotsOptionIndex = S2SInvalidMetadataHandleOptionIndex + OneByte;
            /// <summary>Index: 49020</summary>
            internal const int PermanentDeleteOptionIndex = DeleteSnapshotsOptionIndex + OneByte;
            /// <summary>Index: 49021</summary>
            internal const int RehydratePriorityTypeIndex = PermanentDeleteOptionIndex + OneByte;
            /// <summary>Index: 49022</summary>
            internal const int AtomicJobStatusIndex = RehydratePriorityTypeIndex + OneByte;
            /// <summary>Index: 49023</summary>
            internal const int AtomicPartStatusIndex = AtomicJobStatusIndex + OneByte;
            /// <summary>
            /// Size of the JobPart Header: 49024
            /// </summary>
            internal const int JobPartHeaderSizeInBytes = AtomicPartStatusIndex + OneByte;
        }

        internal static class ErrorCode
        {
            internal static readonly string[] CannotOverwrite = { "BlobAlreadyExists", "Cannot overwrite file." };
            internal static readonly string[] AccessDenied = { "AuthenticationFailed", "AuthorizationFailure", "access denied" };
        }
    }
}
