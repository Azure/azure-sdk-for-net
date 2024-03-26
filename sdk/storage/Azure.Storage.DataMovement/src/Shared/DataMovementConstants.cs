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
        internal const int DefaultArrayPoolArraySize = 4 * 1024;

        internal const long DefaultInitialTransferSize = 32 * Constants.MB;
        internal const long DefaultChunkSize = 4 * Constants.MB;

        public const char PathForwardSlashDelimiterChar = '/';

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
        internal const int ShortSizeInBytes = 2;
        internal const int LongSizeInBytes = 8;
        internal const int IntSizeInBytes = 4;
        internal const int GuidSizeInBytes = 16;

        /// <summary>
        /// Constants used for job plan files.
        /// </summary>
        internal static class JobPlanFile
        {
            internal const string SchemaVersion_b1 = "b1";
            internal const string SchemaVersion = SchemaVersion_b1;

            internal const string FileExtension = ".ndm";

            internal const int VersionStrLength = 2;
            internal const int VersionStrNumBytes = VersionStrLength * 2;
            internal const int ProviderIdMaxLength = 5;
            internal const int ProviderIdNumBytes = ProviderIdMaxLength * 2;

            internal const int VersionIndex = 0;
            internal const int TransferIdIndex = VersionIndex + VersionStrNumBytes;
            internal const int CrateTimeIndex = TransferIdIndex + GuidSizeInBytes;
            internal const int OperationTypeIndex = CrateTimeIndex + LongSizeInBytes;
            internal const int SourceProviderIdIndex = OperationTypeIndex + OneByte;
            internal const int DestinationProviderIdIndex = SourceProviderIdIndex + ProviderIdNumBytes;
            internal const int IsContainerIndex = DestinationProviderIdIndex + ProviderIdNumBytes;
            internal const int EnumerationCompleteIndex = IsContainerIndex + OneByte;
            internal const int JobStatusIndex = EnumerationCompleteIndex + OneByte;
            internal const int ParentSourcePathOffsetIndex = JobStatusIndex + IntSizeInBytes;
            internal const int ParentSourcePathLengthIndex = ParentSourcePathOffsetIndex + IntSizeInBytes;
            internal const int ParentDestPathOffsetIndex = ParentSourcePathLengthIndex + IntSizeInBytes;
            internal const int ParentDestPathLengthIndex = ParentDestPathOffsetIndex + IntSizeInBytes;
            internal const int SourceCheckpointDataOffsetIndex = ParentDestPathLengthIndex + IntSizeInBytes;
            internal const int SourceCheckpointDataLengthIndex = SourceCheckpointDataOffsetIndex + IntSizeInBytes;
            internal const int DestinationCheckpointDataOffsetIndex = SourceCheckpointDataLengthIndex + IntSizeInBytes;
            internal const int DestinationCheckpointDataLengthIndex = DestinationCheckpointDataOffsetIndex + IntSizeInBytes;
            internal const int VariableLengthStartIndex = DestinationCheckpointDataLengthIndex + IntSizeInBytes;
        }

        /// <summary>
        /// Constants used for job part plan files.
        /// </summary>
        internal static class JobPartPlanFile
        {
            internal const string SchemaVersion_b1 = "b1";
            internal const string SchemaVersion_b2 = "b2";
            internal const string SchemaVersion_b3 = "b3";
            internal const string SchemaVersion = SchemaVersion_b3; // TODO: remove b for beta

            // Job Plan file extension. e.g. the file extension will look like {transferid}.{jobpartNumber}.ndmpart
            internal const string FileExtension = ".ndmpart";
            internal const int JobPartLength = 5;
            internal const int IdSize = 36; // Size of a guid with hyphens

            // UTF-8 encoding, so 2 bytes per char
            internal const int VersionStrLength = 2;
            internal const int VersionStrNumBytes = VersionStrLength * 2;
            internal const int TypeIdMaxStrLength = 10;
            internal const int TypeIdNumBytes = TypeIdMaxStrLength * 2;

            internal const int VersionIndex = 0;
            internal const int TransferIdIndex = VersionIndex + VersionStrNumBytes;
            internal const int PartNumberIndex = TransferIdIndex + GuidSizeInBytes;
            internal const int CreateTimeIndex = PartNumberIndex + LongSizeInBytes;
            internal const int SourceTypeIdIndex = CreateTimeIndex + LongSizeInBytes;
            internal const int DestinationTypeIdIndex = SourceTypeIdIndex + TypeIdNumBytes;
            internal const int SourcePathOffsetIndex = DestinationTypeIdIndex + TypeIdNumBytes;
            internal const int SourcePathLengthIndex = SourcePathOffsetIndex + IntSizeInBytes;
            internal const int DestinationPathOffsetIndex = SourcePathLengthIndex + IntSizeInBytes;
            internal const int DestinationPathLengthIndex = DestinationPathOffsetIndex + IntSizeInBytes;
            internal const int CreatePreferenceIndex = DestinationPathLengthIndex + IntSizeInBytes;
            internal const int InitialTransferSizeIndex = CreatePreferenceIndex + OneByte;
            internal const int ChunkSizeIndex = InitialTransferSizeIndex + LongSizeInBytes;
            internal const int PriorityIndex = ChunkSizeIndex + LongSizeInBytes;
            internal const int JobPartStatusIndex = PriorityIndex + OneByte;
            internal const int VariableLengthStartIndex = JobPartStatusIndex + IntSizeInBytes;
        }

        internal static class ErrorCode
        {
            internal static readonly string[] CannotOverwrite = { "BlobAlreadyExists", "Cannot overwrite file." };
            internal static readonly string[] AccessDenied = { "AuthenticationFailed", "AuthorizationFailure", "access denied" };
        }

        internal static class ResourceProperties
        {
            internal const string AccessTier = "AccessTier";
            internal const string BlobType = "BlobType";
            internal const string CreationTime = "CreationTime";
            internal const string ContentType = "ContentType";
            internal const string ContentHash = "ContentHash";
            internal const string ContentEncoding = "ContentEncoding";
            internal const string ContentLanguage = "ContentLanguage";
            internal const string ContentDisposition = "ContentDisposition";
            internal const string CacheControl = "CacheControl";
            internal const string ETag = "ETag";
            internal const string LastModified = "LastModified";
            internal const string Metadata = "Metadata";
        }
    }
}
