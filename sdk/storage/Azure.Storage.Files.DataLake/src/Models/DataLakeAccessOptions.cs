// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Access options to set when creating a path.
    /// </summary>
    public class DataLakeAccessOptions
    {
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
        /// Optional.  The owner of the file or directory.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Optional.  The owning group of the file or directory.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Optional.  The POSIX access control list for the file or directory.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<PathAccessControlItem> AccessControlList { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
