// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

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
        /// The buffer size to use when the stream downloads parts
        /// of the file.  Defaults to 4 MB.
        /// </summary>
        public int? BufferSize { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// the download of the file.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

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
        /// file content, and in that case the returned number of bytes read will still be less than the
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
        /// buffer is the determining factor for what bytes from the file are prepared to be read.
        /// </para>
        /// </summary>
        public bool FillReadBuffer { get; set; }

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
