// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for renaming a file or directory.
    /// </summary>
    public class DataLakePathRenameOptions
    {
        /// <summary>
        /// Optional destination file system.  If null, path will be renamed within the
        /// current file system.
        /// </summary>
        public string DestinationFileSystem { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the source on the creation of this file or directory.
        /// </summary>
        public DataLakeRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </summary>
        public DataLakeRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
