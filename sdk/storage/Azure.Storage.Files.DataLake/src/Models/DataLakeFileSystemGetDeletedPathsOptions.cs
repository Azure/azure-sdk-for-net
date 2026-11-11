// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for getting the soft deleted paths in a file system.
    /// </summary>
    public class DataLakeFileSystemGetDeletedPathsOptions
    {
        /// <summary>
        /// Filters results to paths within the specified directory.
        /// </summary>
        public string PathPrefix { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
