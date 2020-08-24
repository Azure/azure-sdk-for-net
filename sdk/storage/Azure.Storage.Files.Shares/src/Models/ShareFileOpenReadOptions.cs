// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for <see cref="ShareFileClient.OpenReadAsync(bool, long, int?, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ShareFileOpenReadOptions
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
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }
    }
}
