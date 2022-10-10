// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for creating a File System.
    /// </summary>
    public class DataLakeFileSystemCreateOptions
    {
        /// <summary>
        /// Optionally specifies whether data in the file system may be accessed
        /// publicly and the level of access. <see cref="PublicAccessType.FileSystem"/>
        /// specifies full public read access for file system and path data.
        /// Clients can enumerate paths within the file system via anonymous
        /// request, but cannot enumerate file systems within the storage
        /// account.  <see cref="PublicAccessType.Path"/> specifies public
        /// read access for paths.  Path data within this file system can be
        /// read via anonymous request, but file system data is not available.
        /// Clients cannot enumerate paths within the file system via anonymous
        /// request.  <see cref="PublicAccessType.None"/> specifies that the
        /// file system data is private to the account owner.
        /// </summary>
        public PublicAccessType PublicAccessType { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this file system.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Optional encryption scope options to set for this file system.
        /// </summary>
        public DataLakeFileSystemEncryptionScopeOptions EncryptionScopeOptions { get; set; }
    }
}
