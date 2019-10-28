// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Specifies options for paths blobs
    /// </summary>
    public struct GetPathsOptions : IEquatable<GetPathsOptions>
    {
        /// <summary>
        /// Filters results to paths within the specified directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Optional. Valid only when Hierarchical Namespace is enabled for the account. If
        /// "true", the user identity values returned in the owner and group fields of each list
        /// entry will be transformed from Azure Active Directory Object IDs to User Principal
        /// Names. If "false", the values will be returned as Azure Active Directory Object IDs.
        /// The default value is false. Note that group and application Object IDs are not translated
        /// because they do not have unique friendly names.
        /// </summary>
        public bool Upn { get; set; }

        /// <summary>
        /// If "true", all paths are listed; otherwise, only paths at the root of the filesystem are listed.
        /// If "directory" is specified, the list will only include paths that share the same root.
        /// </summary>
        public bool Recursive { get; set; }

        /// <summary>
        /// Check if two GetBlobsOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is GetPathsOptions other && Equals(other);

        /// <summary>
        /// Get a hash code for the GetBlobsOptions.
        /// </summary>
        /// <returns>Hash code for the GetBlobsOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            ((Upn ? 0b00001 : 0) ^
            (Path?.GetHashCode() ?? 0));

        /// <summary>
        /// Check if two GetBlobsOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(GetPathsOptions left, GetPathsOptions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two GetBlobsOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(GetPathsOptions left, GetPathsOptions right) =>
            !(left == right);

        /// <summary>
        /// Check if two GetBlobsOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(GetPathsOptions other) =>
            Path == other.Path &&
            Upn == other.Upn;
    }
}
