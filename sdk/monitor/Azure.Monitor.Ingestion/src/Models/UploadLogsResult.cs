// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// test
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
        /// test
        /// </summary>
        public IReadOnlyList<UploadLogsError> Errors { get; }

        /// <summary>
        /// test
        /// </summary>
        public UploadLogsStatus Status { get; }
    }
}
