// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Properties of a Storage Resource Container.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StorageResourceContainerProperties
    {
        /// <summary>
        /// The Uri of the Storage Resource Container.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri Uri { get; set; }

        /// <summary>
        /// Dictionary of the properties associated with this resource container.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, object> RawProperties { get; set; }

        /// <summary>
        /// Base constructor for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageResourceContainerProperties()
        {
            RawProperties = new Dictionary<string, object>();
        }
    }
}
