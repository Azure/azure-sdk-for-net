// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Properties of a Storage Resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StorageResourceItemProperties
    {
        /// <summary>
        /// The length of the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? ResourceLength { get; set; }

        /// <summary>
        /// The HTTP ETag of the Storage Resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ETag? ETag { get; set; }

        /// <summary>
        /// The Last Modified Time of the Storage Resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? LastModifiedTime { get; set; }

        /// <summary>
        /// Dictionary of the properties associated with this resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, object> RawProperties { get; set; }

        /// <summary>
        /// Base constructor for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageResourceItemProperties()
        {
            RawProperties = new Dictionary<string, object>();
        }
    }
}
