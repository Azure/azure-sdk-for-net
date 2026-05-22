// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The set of byte ranges returned by Get Blob Layout.  Each range maps to an
    /// endpoint by index in <see cref="DataLakeFileLayoutEndpoints"/>.
    /// </summary>
    public class DataLakeFileLayoutRanges
    {
        /// <summary>
        /// The list of byte ranges that make up the file's layout.
        /// </summary>
        public IReadOnlyList<DataLakeFileLayoutRangesRangeItem> Range { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="DataLakeFileLayoutRanges"/> instances.
        /// You can use <see cref="DataLakeModelFactory"/> instead.
        /// </summary>
        internal DataLakeFileLayoutRanges() { }
    }
}
