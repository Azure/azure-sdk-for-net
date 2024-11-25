// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The details and content returned from reading a DataLake File.
    /// </summary>
    public class DataLakeFileReadResult
    {
        internal DataLakeFileReadResult() { }

        /// <summary>
        /// Details returned when reading a DataLake file
        /// </summary>
        public FileDownloadDetails Details { get; internal set; }

        /// <summary>
        /// Content.
        /// </summary>
        public BinaryData Content { get; internal set; }
    }
}
