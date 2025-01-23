// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Properties of a Storage Resource.
    /// </summary>
    public class StorageResourceItemProperties
    {
        /// <summary>
        /// The length of the resource.
        /// </summary>
        public long? ResourceLength { get; set; }

        /// <summary>
        /// The HTTP ETag of the Storage Resource.
        /// </summary>
        public ETag? ETag { get; set; }

        /// <summary>
        /// The Last Modified Time of the Storage Resource.
        /// </summary>
        public DateTimeOffset? LastModifiedTime { get; set; }

        /// <summary>
        /// Dictionary of the properties associated with this resource.
        /// </summary>
        public IDictionary<string, object> RawProperties { get; set; }

        /// <summary>
        /// Base constructor for mocking.
        /// </summary>
        public StorageResourceItemProperties()
        {
            RawProperties = new Dictionary<string, object>();
        }
    }
}
