// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// TODO
    /// </summary>
    public class StorageResourceProperties2
    {
        /// <summary>
        /// The length of the resource.
        /// </summary>
        public long? ContentLength { get; set; }

        /// <summary>
        /// The HTTP ETag of the resource.
        /// </summary>
        public ETag? ETag { get; set; }

        /// <summary>
        /// Dictionary of the properties associated with this resource.
        /// </summary>
        public Dictionary<string, object> Properties { get; set; }
    }
}
