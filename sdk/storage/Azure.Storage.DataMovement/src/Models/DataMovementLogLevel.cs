// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Defines the log level of which the Transfers will be logged as
    /// </summary>
    public enum DataMovementLogLevel
    {
        /// <summary>
        /// No log file will be produced during any transfers. This may be the default
        /// </summary>
        None = 0,

        /// <summary>
        /// Provides details of the transfer that may be only troubleshooted. Guessing the highest
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logs all error, warning, and information messages that occur during transfer.
        /// </summary>
        Information = 2,

        /// <summary>
        /// Logs all error and warning messages that occur during transfer
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Logs all error messages that occur during transfer
        /// </summary>
        Error = 4,

        /// <summary>
        /// TODO: I have to look what AzCopy means by panic
        /// </summary>
        Panic = 5,

        /// <summary>
        /// TODO: I have to look what AzCopy means by fatal..
        /// </summary>
        Fatal = 6,
    }
}
