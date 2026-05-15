// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The set of endpoints returned by Get Blob Layout.  Ranges in
    /// <see cref="DataLakeFileLayoutRanges"/> reference these endpoints by index.
    /// </summary>
    public class DataLakeFileLayoutEndpoints
    {
        /// <summary>
        /// The list of endpoints that the file's data is distributed across.
        /// </summary>
        public IReadOnlyList<DataLakeFileLayoutEndpointsEndpointItem> Endpoint { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="DataLakeFileLayoutEndpoints"/> instances.
        /// You can use <see cref="DataLakeModelFactory"/> instead.
        /// </summary>
        internal DataLakeFileLayoutEndpoints() { }
    }
}
