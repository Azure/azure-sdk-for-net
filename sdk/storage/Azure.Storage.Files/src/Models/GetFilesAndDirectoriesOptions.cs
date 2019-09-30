// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// Specifies options for listing files and directories with the
    /// <see cref="DirectoryClient.GetFilesAndDirectoriesAsync"/>
    /// operation.
    /// </summary>
    public struct GetFilesAndDirectoriesOptions : IEquatable<GetFilesAndDirectoriesOptions>
    {
        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// files and directories whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets an optional share snapshot to query.
        /// </summary>
        public string ShareSnapshot { get; set; }

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is GetFilesAndDirectoriesOptions other && Equals(other);

        /// <summary>
        /// Get a hash code for the GetFilesAndDirectoriesOptions.
        /// </summary>
        /// <returns>Hash code for the GetFilesAndDirectoriesOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (ShareSnapshot?.GetHashCode() ?? 0) ^
            (Prefix?.GetHashCode() ?? 0);

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(GetFilesAndDirectoriesOptions left, GetFilesAndDirectoriesOptions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(GetFilesAndDirectoriesOptions left, GetFilesAndDirectoriesOptions right) =>
            !(left == right);

        /// <summary>
        /// Check if two GetFilesAndDirectoriesOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(GetFilesAndDirectoriesOptions other) =>
            ShareSnapshot == other.ShareSnapshot &&
            Prefix == other.Prefix;
    }
}
