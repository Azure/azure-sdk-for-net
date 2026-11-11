// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for setting the access policy of a file system.
    /// </summary>
    public class DataLakeFileSystemSetAccessPolicyOptions
    {
        /// <summary>
        /// Optionally specifies whether data in the file system may be accessed publicly and the level of access.
        /// </summary>
        public PublicAccessType AccessType { get; set; } = PublicAccessType.None;

        /// <summary>
        /// Stored access policies that you can use to provide fine grained control over file system permissions.
        /// </summary>
        public IEnumerable<DataLakeSignedIdentifier> Permissions { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on this operation.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
