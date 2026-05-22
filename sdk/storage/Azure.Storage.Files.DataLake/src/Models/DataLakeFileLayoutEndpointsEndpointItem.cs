// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// A single endpoint entry within a <see cref="DataLakeFileLayoutEndpoints"/> collection.
    /// </summary>
    public class DataLakeFileLayoutEndpointsEndpointItem
    {
        /// <summary>
        /// The zero-based index of this endpoint within the parent endpoints collection.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// The endpoint value (for example, a host name) that ranges associated with
        /// this index should be routed to.
        /// </summary>
        public string Value { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="DataLakeFileLayoutEndpointsEndpointItem"/> instances.
        /// You can use <see cref="DataLakeModelFactory"/> instead.
        /// </summary>
        internal DataLakeFileLayoutEndpointsEndpointItem() { }
    }
}
