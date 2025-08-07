// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the Error Handling Path to take when a failure or error occurs.
    /// </summary>
    [Flags]
    public enum TransferErrorMode
    {
        /// <summary>
        /// If set all the transfer jobs will ignore failures
        /// and proceed with the other sub-entities of the
        /// transfer job and pending transfer jobs.
        /// If not set the operation will terminate
        /// quickly on encountering failures.
        /// </summary>
        ContinueOnFailure = 1,

        /// <summary>
        /// Default. If set and by default all the transfer jobs will terminate
        /// quickly on encountering failures from the storage service
        /// and filesystem failures.
        /// </summary>
        StopOnAnyFailure = 0,
    }
}
