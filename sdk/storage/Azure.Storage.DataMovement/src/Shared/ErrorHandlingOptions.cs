// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the Error Handling Path to take when a failure or error.
    /// </summary>
    [Flags]
    public enum ErrorHandlingOptions
    {
        /// <summary>
        /// If set all the transfer jobs will ignore storage service related
        /// failures and proceed with the other sub-entities of the
        /// transfer job and pending transfer jobs.
        /// If not set the operation will terminate
        /// quickly on encountering failures from the storage service.
        /// </summary>
        ContinueOnServiceFailure = 1,

        /// <summary>
        /// If set, the all the transfer jobs will ignore local filesytem failures
        /// and proceed with the other sub-entities of the transfer job
        /// and pending transfer jobs. If not set, the all the transfer jobs will
        /// terminate quickly on encountering user filesystem failures.
        /// </summary>
        ContinueOnLocalFilesystemFailure = 2,

        /// <summary>
        /// If set and by default all the transfer jobs will terminate
        /// quickly on encountering failures from the storage service
        /// and filesystem failures.
        /// </summary>
        PauseOnAllFailures = ~0,
    }
}
