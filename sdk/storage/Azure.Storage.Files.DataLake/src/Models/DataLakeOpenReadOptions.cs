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
        /// Constructor.
        /// </summary>
        /// <param name="allowModifications">
        /// If false, a <see cref="RequestFailedException"/> will be thrown if the file is modified while
        /// it is being read from.
        /// </param>
        public DataLakeOpenReadOptions(bool allowModifications)
        {
            // Setting the Conditions to empty means we won't automatically
            // use the ETag as a condition and it will be possible for the blob
            // to change while it's being read from.
            if (allowModifications)
            {
                Conditions = new DataLakeRequestConditions();
            }
        }
    }
}
