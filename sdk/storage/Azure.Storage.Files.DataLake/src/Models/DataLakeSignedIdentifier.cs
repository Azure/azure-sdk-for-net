// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// A Signed identifier for a shared access policy.
    /// </summary>
    public class DataLakeSignedIdentifier
    {
        /// <summary>
        /// A unique id for the <see cref="DataLakeSignedIdentifier"/>.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// An <see cref="DataLakeAccessPolicy"/>.
        /// </summary>
        public DataLakeAccessPolicy AccessPolicy { get; set; }
    }
}
