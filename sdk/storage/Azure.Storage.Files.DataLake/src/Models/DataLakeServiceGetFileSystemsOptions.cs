// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for listing file systems.
    /// </summary>
    public class DataLakeServiceGetFileSystemsOptions
    {
        /// <summary>
        /// Specifies trait options for shaping the file systems.
        /// </summary>
        public FileSystemTraits Traits { get; set; }

        /// <summary>
        /// Specifies state options for filtering the file systems.
        /// </summary>
        public FileSystemStates States { get; set; }

        /// <summary>
        /// Filters the results to return only file systems whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
