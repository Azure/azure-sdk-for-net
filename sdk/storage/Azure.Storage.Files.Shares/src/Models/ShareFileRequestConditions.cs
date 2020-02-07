// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specifies lease access conditions for a file.
    /// </summary>
    public class ShareFileRequestConditions
    {
        /// <summary>
        /// Optionally limit requests to resources with an active lease
        /// matching this Id.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Converts the value of the current RequestConditions object to
        /// its equivalent string representation.
        /// </summary>
        /// <returns>
        /// A string representation of the RequestConditions.
        /// </returns>
        public override string ToString()
            => $"[{nameof(LeaseId)}={LeaseId}]";
    }
}
