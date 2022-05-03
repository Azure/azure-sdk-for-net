// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for creating a file or directory..
    /// </summary>
    public class DataLakePathCreateOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new file or directory.
        /// </summary>
        public PathHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this file or directory.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

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

        /// <summary>
        /// Optional.  Proposed LeaseId.
        /// Does not apply to directories.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Optional.  Specifies the duration of the lease, in seconds, or specify
        /// <see cref="DataLakePathClient.InfiniteLeaseDuration"/> for a lease that never expires.
        /// A non-infinite lease can be between 15 and 60 seconds.
        /// Does not apply to directories.
        /// </summary>
        public TimeSpan? LeaseDuration { get; set; }

        /// <summary>
        /// Duration before file should be deleted.
        /// Does not apply to directories.
        /// <see cref="TimeToExpire"/> and <see cref="ExpiresOn"/> cannot both be set.
        /// </summary>
        public TimeSpan? TimeToExpire { get; set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> to set for when
        /// the file will be deleted.  If null, the existing
        /// ExpiresOn time on the file will be removed, if it exists.
        /// Does not apply to directories.
        /// <see cref="ExpiresOn"/> and <see cref="TimeToExpire"/> cannot both be set.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add
        /// conditions on the creation of this file or directory.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }
    }
}
