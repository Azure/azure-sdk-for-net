// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// NFS only.  Options for creating a symbolic link.
    /// </summary>
    public class ShareFileCreateSymbolicLinkOptions
    {
        /// <summary>
        /// Optional custom metadata to set for the symbolic link.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// The creation time of the symbolic link.
        /// </summary>
        public DateTimeOffset? FileCreatedOn { get; set; }

        /// <summary>
        /// The last write time of the symbolic link.
        /// </summary>
        public DateTimeOffset? FileLastWrittenOn { get; set; }

        /// <summary>
        /// Optional. The owner user identifier (UID) to be set on the symbolic link. The default value is 0 (root).
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Optional. The owner group identifier (GID) to be set on the symbolic link. The default value is 0 (root group).
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the symbolic link.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }
    }
}
