// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;

    /// <summary>
    /// Provides data for the <see cref="EventProcessorOptions.NotifyOfException(string, string, System.Exception, string)"/> event.
    /// </summary>
    public sealed class ExceptionReceivedEventArgs
    {
        internal ExceptionReceivedEventArgs(string hostname, string partitionId, Exception exception, string action)
        {
            this.Hostname = hostname;
            this.PartitionId = partitionId;
            this.Exception = exception;
            this.Action = action;
        }

        /// <summary>
        /// Allows distinguishing the error source if multiple hosts in a single process.
        /// </summary>
        /// <value>The name of the host that experienced the exception.</value>
        public string Hostname { get; }

        /// <summary>
        /// Allows distinguishing the error source if multiple hosts in a single process.
        /// </summary>
        /// <value>The partition id that experienced the exception.</value>
        public string PartitionId { get; }

        /// <summary>
        /// The exception that was thrown.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// A short string that indicates what general activity threw the exception.
        /// See EventProcessorHostActionString for a list of possible values.
        /// </summary>
        public string Action { get; }
    }
}