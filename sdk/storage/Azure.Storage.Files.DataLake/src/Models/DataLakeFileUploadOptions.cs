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
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

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
        /// Azure Storage Events allow applications to receive notifications when files change. When Azure Storage Events are enabled,
        /// a file changed event is raised. This event has a property indicating whether this is the final change to distinguish the
        /// difference between an intermediate flush to a file stream and the final close of a file stream. The close query parameter
        /// is valid only when the action is "flush" and change notifications are enabled. If the value of close is "true" and the
        /// flush operation completes successfully, the service raises a file change notification with a property indicating that
        /// this is the final update (the file stream has been closed). If "false" a change notification is raised indicating the
        /// file has changed. The default is false. This query parameter is set to true by the Hadoop ABFS driver to indicate that
        /// the file stream has been closed.
        /// </summary>
        public bool? Close { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }
    }
}
