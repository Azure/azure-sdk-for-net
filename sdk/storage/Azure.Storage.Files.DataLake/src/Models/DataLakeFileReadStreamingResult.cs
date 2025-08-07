// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The details and content returned from reading a datalake file.
    /// </summary>
    public class DataLakeFileReadStreamingResult : IDisposable
    {
        internal DataLakeFileReadStreamingResult() { }

        /// <summary>
        /// Details returned when reading a datalake file.
        /// </summary>
        public FileDownloadDetails Details { get; internal set; }

        /// <summary>
        /// Content.
        /// </summary>
        public Stream Content { get; internal set; }

        /// <summary>
        /// Disposes the <see cref="DataLakeFileReadStreamingResult"/> by calling Dispose on the underlying <see cref="Content"/> stream.
        /// </summary>
        public void Dispose()
        {
            Content?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
