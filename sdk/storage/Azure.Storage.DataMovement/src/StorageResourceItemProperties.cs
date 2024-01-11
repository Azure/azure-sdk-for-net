// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public long? ContentLength { get; }

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
        /// <param name="contentLength"></param>
        /// <param name="properties"></param>
        public StorageResourceItemProperties(
            long? contentLength,
            Dictionary<string, object> properties)
        {
            ContentLength = contentLength;
            RawProperties = properties;
        }
    }
}
