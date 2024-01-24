// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Properties of a Storage Resource
    /// </summary>
    public class StorageResourceItemProperties
    {
        /// <summary>
        /// The length of the resource.
        /// </summary>
        public long? ResourceLength { get; }

        /// <summary>
        /// The HTTP ETag of the Storage Resource.
        /// </summary>
        public ETag? ETag { get; }

        /// <summary>
        /// The Last Modified Time of the Storage Resource.
        /// </summary>
        public DateTimeOffset? LastModifiedTime { get; }

        /// <summary>
        /// Dictionary of the properties associated with this resource.
        /// </summary>
        public Dictionary<string, object> RawProperties { get; }

        /// <summary>
        /// Base constructor for mocking.
        /// </summary>
        protected StorageResourceItemProperties()
        {
            RawProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Constructor for StorageResourceProperties
        /// </summary>
        /// <param name="resourceLength"></param>
        /// <param name="eTag"></param>
        /// <param name="lastModifiedTime"></param>
        /// <param name="properties"></param>
        public StorageResourceItemProperties(
            long? resourceLength,
            ETag? eTag,
            DateTimeOffset? lastModifiedTime,
            Dictionary<string, object> properties)
        {
            ResourceLength = resourceLength;
            ETag = eTag;
            LastModifiedTime = lastModifiedTime;
            RawProperties = properties;
        }
    }
}
