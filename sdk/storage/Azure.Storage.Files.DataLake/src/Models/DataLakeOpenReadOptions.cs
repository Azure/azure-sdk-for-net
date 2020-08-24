// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for <see cref="DataLakeFileClient.OpenReadAsync(DataLakeOpenReadOptions, System.Threading.CancellationToken)"/>
    /// </summary>
    public class DataLakeOpenReadOptions
    {
        /// <summary>
        /// If true, you can continue streaming a file even if it has been modified.
        /// If true, <see cref="Conditions"/> with be ignored.
        /// </summary>
        public bool AllowModified { get; set; }

        /// <summary>
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// The buffer size to use when the stream downloads parts
        /// of the file.  Defaults to 4 MB.
        /// </summary>
        public int? BufferSize { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }
    }
}
