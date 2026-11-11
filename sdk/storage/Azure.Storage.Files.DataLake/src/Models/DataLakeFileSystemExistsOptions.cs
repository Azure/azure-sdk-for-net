// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for checking whether a file system exists.
    /// </summary>
    public class DataLakeFileSystemExistsOptions
    {
        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
