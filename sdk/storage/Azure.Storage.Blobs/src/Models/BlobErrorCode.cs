// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Error codes returned by the service.
    /// </summary>
    [CodeGenModel("ErrorCode")]
    public partial struct BlobErrorCode
    {
        private const string SnaphotOperationRateExceededValue = "SnaphotOperationRateExceeded";

        /// <summary> SnaphotOperationRateExceeded. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobErrorCode SnaphotOperationRateExceeded { get; } = new BlobErrorCode(SnaphotOperationRateExceededValue);
    }
}
