// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for uploading to a Data Lake file.
    /// </summary>
    public class DataLakeFileUploadOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the file.
        /// </summary>
        public PathHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this file.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Optional and only valid if Hierarchical Namespace is enabled for the account. Sets POSIX access
        /// permissions for the file owner, the file owning group, and others. Each class may be granted read,
        /// write, or execute permission. The sticky bit is also supported. Both symbolic (rwxrw-rw-) and 4-digit
        /// octal notation (e.g. 0766) are supported.
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Optional and only valid if Hierarchical Namespace is enabled for the account.
        /// When creating a file or directory and the parent folder does not have a default ACL,
        /// the umask restricts the permissions of the file or directory to be created. The resulting
        /// permission is given by p bitwise-and ^u, where p is the permission and u is the umask. For example,
        /// if p is 0777 and u is 0057, then the resulting permission is 0720. The default permission is
        /// 0777 for a directory and 0666 for a file. The default umask is 0027. The umask must be specified
        /// in 4-digit octal notation (e.g. 0766).
        /// </summary>
        public string Umask { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to apply to the request.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }
    }
}
