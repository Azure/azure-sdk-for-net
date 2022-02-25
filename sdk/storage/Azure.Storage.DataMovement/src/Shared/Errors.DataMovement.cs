// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage
{
    /// <summary>
    /// Exceptions throw specific to the Data Movement Library
    /// </summary>
    internal partial class Errors
    {
        public static ArgumentException InvalidJobId(string command, string jobId)
            => new ArgumentException($"Cannot process {command} for job id: \"{jobId}\". Because" +
                $"the respective job does not exist or is no longer stored in the transfer manager.");

        public static ArgumentException PlanFileMissing(string path, string jobId)
            => new ArgumentException($"Cannot resume job, \"{jobId}\", because the job plan file cannot be found at the following path: \"{path}\"");

        public static ArgumentException JobCancelledOrPaused(string jobId)
            => new ArgumentException($"The following job with the respective job id: \"{jobId}\" is currently being cancelled or paused.");

        public static ArgumentException JobStatusInvalidResume(string jobStatus)
            => new ArgumentException($"Cannot resume jobs with the following status: \"{jobStatus}\".");

        public static InvalidOperationException TooManyLogFiles(string logFolderPath, string jobId)
            => new InvalidOperationException($"Path:\"{logFolderPath}\" cannot be used to store log file for job \"{jobId}\"" +
                $"due to limit of duplicate job log file names. Please clear out the folder or use a different folder path");

        public static InvalidOperationException TooManyTransferStateFiles(string transferStateFolderPath, string jobId)
            => new InvalidOperationException($"Path:\"{transferStateFolderPath}\" cannot be used to store transfer state file for job \"{jobId}\"" +
                $"due to limit of duplicate job transfer state file names. Please clear out the folder or use a different folder path");
    }
}
