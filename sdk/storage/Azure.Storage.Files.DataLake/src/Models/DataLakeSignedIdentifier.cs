// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// signed identifier.
    /// </summary>
    public class DataLakeSignedIdentifier
    {
        /// <summary>
        /// a unique id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// An Access policy.
        /// </summary>
        public DataLakeAccessPolicy AccessPolicy { get; set; }
    }
}
