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
            internal const int VersionMaxSizeInBytes = 2; //  4 bytes
            internal const int TransferIdStrMaxSize = 36; // 36 chars
            internal const int TransferIdMaxSizeInBytes = 72; // 72 bytes
            internal const int PathStrMaxSize = 4096; // 8182 bytes
            internal const int PathStrMaxSizeInBytes = PathStrMaxSize * 2; // 8182 bytes
            internal const int ExtraQueryMaxSize = 1000; // 1000 char
            internal const int ExtraQueryMaxSizeInBytes = ExtraQueryMaxSize * 2; // 2000 bytes
            internal const int HeaderValueMaxSize = 1000; // 1000 char
            internal const int HeaderValueMaxSizeInBytes = HeaderValueMaxSize * 2; // 2000 char

            internal const int VersionIndex = 0; // Index: 0
            internal const int StartTimeIndex = VersionIndex + LongSizeInBytes; // Index: 8
            internal const int TransferIdIndex = 12; // Index: 12
            internal const int PartNumberIndex = 84; // Index: 84
            internal const int SourcePathLengthIndex = 92; // Index: 92
            internal const int SourcePathIndex = 100; // Index: 100
            internal const int SourceExtraQueryLengthIndex = 8282; // Index: 8282
            internal const int SourceExtraQueryIndex = 8290; // Index: 8290
            internal const int DestinationPathLengthIndex = 10290; // Index: 10,290
            internal const int DestinationPathIndex = 10298; // Index: 10,298
            internal const int DestinationExtraQueryLengthIndex = 18480; // Index: 18,480
            internal const int DestinationExtraQueryIndex = 18488; // Index: 18,488
            internal const int IsFinalPartIndex = 20488; // Index: 20,488
            internal const int ForceWriteIndex = 20489; // Index: 20,489
            internal const int ForceIfReadOnlyIndex = 20490; // Index: 20,490
            internal const int AutoDecompressIndex = 20491; // Index: 20,491
            internal const int PriorityIndex = 20492; // Index: 20,492
            internal const int TTLAfterCompletionIndex = 20493; // Index: 20,493
            internal const int FromToIndex = 20501; // Index: 20,501
            internal const int FolderPropertyOptionIndex = 20502; // Index: 20,502
            internal const int NumberChunksIndex = 20503; // Index: 20,503

            internal const int DstBlobTypeIndex = 20511; // Index: 20,511
            internal const int DstBlobNoGuessMimeTypeIndex = 20512; // Index: 20,512
            internal const int DstBlobContentTypeLengthIndex = 20513; // Index: 20,513
            internal const int DstBlobContentTypeIndex = 20521; // Index: 20,521
            internal const int DstBlobContentEncodingLengthIndex = 20521; // Index: 20,521
        }
    }
}
