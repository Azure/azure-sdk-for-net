// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for setting the access control list of a file or directory.
    /// </summary>
    public class DataLakePathSetAccessControlListOptions
    {
        /// <summary>
        /// The owner of the file or directory.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The owning group of the file or directory.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's access control.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
