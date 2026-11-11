// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for setting the metadata of a file or directory.
    /// </summary>
    public class DataLakePathSetMetadataOptions
    {
        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's metadata.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
