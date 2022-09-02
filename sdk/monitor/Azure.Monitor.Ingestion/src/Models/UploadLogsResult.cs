// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The model class containing the result of a logs upload operation.
    /// </summary>
    public class UploadLogsResult
    {
        internal UploadLogsResult(IReadOnlyList<UploadLogsError> errors, UploadLogsStatus status)
        {
            Argument.AssertNotNull(errors, nameof(errors));
            Errors = errors;
            Status = status;
        }

        /// <summary>
        /// The list of errors that occurred when uploading logs, if any.
        /// </summary>
        public IReadOnlyList<UploadLogsError> Errors { get; }

        /// <summary>
        /// The status of the logs upload operation.
        /// </summary>
        public UploadLogsStatus Status { get; }
    }
}
