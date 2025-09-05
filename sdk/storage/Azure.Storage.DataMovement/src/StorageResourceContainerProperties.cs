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
        /// Dictionary of the properties associated with this resource container.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, object> RawProperties { get; }

        /// <summary>
        /// Base constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageResourceContainerProperties(IDictionary<string, object> properties = default)
        {
            RawProperties = properties ?? new Dictionary<string, object>();
        }
    }
}
