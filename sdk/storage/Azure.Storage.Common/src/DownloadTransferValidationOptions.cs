// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Options for additional content integrity checks on download.
    /// </summary>
    public class DownloadTransferValidationOptions
    {
        /// <summary>
        /// Checksum algorithm to use. If left unset (<see cref="ValidationAlgorithm.Auto"/>),
        /// the library will pick for you.
        /// </summary>
        public ValidationAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Defaults to true. Indicates whether the library should validate the content
        /// body against the content checksum before returning contents to the caller
        /// or destination. If set to false, caller is responsible for extracting the
        /// checksum out of the <see cref="Response{T}"/> and validating it themselves.
        /// </summary>
        public bool Validate { get; set; } = true;
    }
}
