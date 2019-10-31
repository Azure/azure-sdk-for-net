// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The Access Control for a Path.
    /// </summary>
    public class PathAccessControl
    {
        /// <summary>
        /// The owner of the file or directory. Included in the response if Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string Owner { get; internal set; }

        /// <summary>
        /// The owning group of the file or directory. Included in the response if Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string Group { get; internal set; }

        /// <summary>
        /// The POSIX access permissions for the file owner, the file owning group, and others. Included in the response if Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string Permissions { get; internal set; }

        /// <summary>
        /// The POSIX access control list for the file or directory.  Included in the response only if Hierarchical Namespace is enabled for the account.
        /// </summary>
        public string Acl { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PathAccessControl instances.
        /// You can use DataLakeModelFactory.PathAccessControl instead.
        /// </summary>
        internal PathAccessControl() { }
    }
}
