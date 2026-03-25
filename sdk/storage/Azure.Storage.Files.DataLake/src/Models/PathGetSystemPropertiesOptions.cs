// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for getting the system properties of a path with
    /// <see cref="DataLakePathClient.GetSystemProperties"/>.
    /// </summary>
    public class PathGetSystemPropertiesOptions
    {
        /// <summary>
        /// To add conditions on getting the path's system properties.
        /// </summary>
        public DataLakeRequestConditions RequestConditions { get; set; }
    }
}
