// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for DataLakePathClient.Delete and DataLakePathClient.DeleteIfExists.
    /// </summary>
    public class DataLakePathDeleteOptions
    {
        /// <summary>
        /// Required and valid only when the resource is a directory. If "true", all paths beneath the directory will be deleted.
        /// If "false" and the directory is non-empty, an error occurs.
        /// </summary>
        public bool? Recursive { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// deleting this path.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
