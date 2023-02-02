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

        internal const string DefaultTransferFilesPath = ".azstoragedml";

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
        }
    }
}
