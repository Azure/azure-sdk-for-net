// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// The AssetConversionStatus.
    /// </summary>
    [CodeGenModel("JobStatus")]
    public enum AssetConversionStatus
    {
        /// <summary>
        /// NotStarted.
        /// </summary>
        NotStarted,

        /// <summary>
        /// Running.
        /// </summary>
        Running,

        /// <summary>
        /// Succeeded.
        /// </summary>
        Succeeded,

        /// <summary>
        /// Failed.
        /// </summary>
        Failed,

        /// <summary>
        /// Cancelled.
        /// </summary>
        Cancelled
    }
}
