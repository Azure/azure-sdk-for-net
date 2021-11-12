// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobBaseClient.OpenReadAsync(BlobOpenReadOptions, System.Threading.CancellationToken)"/>
    /// </summary>
    public class BlobOpenReadOptions
    {
        /// <summary>
        /// The position within the blob to begin the stream.
        /// Defaults to the beginning of the blob.
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// The buffer size to use when the stream downloads parts
        /// of the blob.  Defaults to 4 MB.
        /// </summary>
        public int? BufferSize { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the download of the blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional transactional hashing options.
        /// </summary>
        public DownloadTransactionalHashingOptions TransactionalHashingOptions { get; set; }

        /// <summary>
        /// <para>
        /// Optional flag to force the <see cref="Stream"/> to supply the requested byte count when calling
        /// <see cref="Stream.ReadAsync(byte[], int, int, System.Threading.CancellationToken)"/>.
        /// By default, the <see cref="Stream"/> will only supply bytes already prepared to be read, which
        /// may be less than the requested count of bytes. The stream will not read beyond the end of the
        /// blob content, and in that case the returned number of bytes read will still be less than the
        /// requested count.
        /// </para>
        /// <para>
        /// It is best practice for the caller to handle this situation with a <see cref="StreamReader"/>
        /// or similar wrapping class, which continues to call
        /// <see cref="Stream.ReadAsync(byte[], int, int, System.Threading.CancellationToken)"/>
        /// as needed until requested bytes have been read. However, this flag will trigger similar behavior
        /// within the provided stream.
        /// </para>
        /// <para>
        /// It is best practice, when applicable, for the caller to configure <see cref="BufferSize"/>
        /// to best support byte counts requested when reading from the stream, as the stream's internal
        /// buffer is the determining factor for what bytes from the blob are prepared to be read.
        /// </para>
        /// </summary>
        public bool FillReadBuffer { get; set; }

        internal bool AllowModifications { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="allowModifications">
        /// If false, a <see cref="RequestFailedException"/> will be thrown if the blob is modified while
        /// it is being read from.
        /// </param>
        public BlobOpenReadOptions(bool allowModifications)
        {
            AllowModifications = allowModifications;
        }
    }
}
