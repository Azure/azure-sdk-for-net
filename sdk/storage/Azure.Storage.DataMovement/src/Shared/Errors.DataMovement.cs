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
        public static ArgumentException InvalidSourceDestinationParams()
            => new ArgumentException($"Cannot perform transfer because neither source and destination resource cannot produce a Uri." +
                $"Either the source or destination resource, or both resources needs to produce a Uri.");
        public static ArgumentException InvalidTransferId(string command, string transferId)
            => new ArgumentException($"Cannot process {command} for transfer id: \"{transferId}\". Because" +
                $"the respective transfer job does not exist or is no longer stored in the transfer manager.");

        public static ArgumentException PlanFileMissing(string path, string transferId)
            => new ArgumentException($"Cannot resume transfer job, \"{transferId}\", because the job plan file cannot be found at the following path: \"{path}\"");

        public static ArgumentException JobCancelledOrPaused(string transferId)
            => new ArgumentException($"The following transfer job with the respective transfer id: \"{transferId}\" is currently being cancelled or paused.");

        public static ArgumentException JobStatusInvalidResume(string jobStatus)
            => new ArgumentException($"Cannot resume transfer jobs with the following status: \"{jobStatus}\".");

        public static InvalidOperationException TooManyLogFiles(string logFolderPath, string transferId)
            => new InvalidOperationException($"Path:\"{logFolderPath}\" cannot be used to store log file for transfer job \"{transferId}\"" +
                $"due to limit of duplicate transfer job log file names. Please clear out the folder or use a different folder path");

        public static InvalidOperationException TooManyTransferStateFiles(string transferStateFolderPath, string jobId)
            => new InvalidOperationException($"Path:\"{transferStateFolderPath}\" cannot be used to store transfer state file for transfer job \"{jobId}\"" +
                $"due to limit of duplicate transfer job state file names. Please clear out the folder or use a different folder path");

        public static ArgumentException InvalidConnectionString()
            => new ArgumentException($"Cannot resume transfer job due to mismatch of storage account endpoint contained in the connection string passed and " +
                $"the original endpoint which was passed when the transfer job was first scheduled.");

        public static ArgumentException UnableToGetLength()
            => new ArgumentException("Unable to get the length of the source storage resource");
    }
}
