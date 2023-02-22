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
            internal const int PathStrMaxSizeInBytes = 8182; // 8182 bytes
            internal const int ExtraQueryMaxSize = 1000; // 2048 char
            internal const int ExtraQueryMaxSizeInBytes = 2000; // 2000 bytes

            internal const int VersionIndex = 0; // Index: 0
            internal const int StartTimeIndex = 4; // Index: 4
            internal const int TransferIdIndex = 12; // Index: 12
            internal const int PartNumberIndex = 84; // Index: 84
            internal const int SourcePathLengthIndex = 92; // Index: 92
            internal const int SourcePathIndex = 100; // Index: 100
            internal const int SourceExtraQueryLengthIndex = 8282; // Index: 8282
            internal const int SourceExtraQueryIndex = 8290; // Index: 8290
            internal const int DestinationPathIndex = 10274; // Index: 10274
            internal const int DestinationExtraQueryIndex = 18456; // Index: 18456
            internal const int IsFinalPartIndex = 20456; // Index: 20456
            internal const int ForceWriteIndex = 20457; // Index: 20457
            internal const int ForceIfReadOnlyIndex = 20458; // Index: 20458
            internal const int AutoDecompressIndex = 20459; // Index: 20459
            internal const int PriorityIndex = 20460; // Index: 20460
            internal const int TTLAfterCompletionIndex = 20461; // Index: 20461
            internal const int FromToIndex = 20469; // Index: 20469
            internal const int FolderPropertyOptionIndex = 20470; // Index: 20470
            internal const int NumberChunksIndex = 20471; // Index: 20471
            internal const int DstBlobDataIndex = 20479; // Index: 20472
        }
    }
}
