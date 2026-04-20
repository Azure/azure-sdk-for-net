// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterPublisherData. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterPublisherData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PublisherData : HciClusterPublisherData
    {
        /// <summary> Initializes a new instance of <see cref="PublisherData"/>. </summary>
        public PublisherData() : base() { }

        /// <summary> Initializes a new instance of <see cref="PublisherData"/>. </summary>
        internal PublisherData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, string provisioningState)
            : base(id, name, resourceType, systemData, additionalBinaryDataProperties,
                  new PublisherProperties(provisioningState, null))
        {
        }
    }
}
