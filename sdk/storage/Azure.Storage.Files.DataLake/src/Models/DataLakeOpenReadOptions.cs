// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for <see cref="DataLakeFileClient.OpenReadAsync(DataLakeOpenReadOptions, System.Threading.CancellationToken)"/>
    /// </summary>
    public class DataLakeOpenReadOptions
    {
        /// <summary>
        /// The position within the file to begin the stream.
        /// Defaults to the beginning of the file.
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// The buffer size (in bytes) to use when the stream downloads parts
        /// of the file.  Defaults to 4 MB.
        /// </summary>
        public int? BufferSize { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="DataLakeClientOptions.TransferValidation"/> settings.
        /// </summary>
        public DownloadTransferValidationOptions TransferValidation { get; set; }

        /// <summary>
        /// Determines whether locality-aware routing is used for the buffered range
        /// requests issued by the returned read stream. When enabled, the file's layout
        /// is fetched on demand and cached (with automatic background refresh), and each
        /// range download is routed to the optimal endpoint for the chunk being read.
        /// This is a performance optimization only - the bytes returned are identical
        /// to a non-locality-aware download.
        /// </summary>
        public LayoutAwareRouting LayoutAwareRouting { get; set; } = LayoutAwareRouting.Auto;

        internal bool AllowModifications { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="allowModifications">
        /// If false, a <see cref="RequestFailedException"/> will be thrown if the file is modified while
        /// it is being read from.
        /// </param>
        public DataLakeOpenReadOptions(bool allowModifications)
        {
            AllowModifications = allowModifications;
        }
    }
}
