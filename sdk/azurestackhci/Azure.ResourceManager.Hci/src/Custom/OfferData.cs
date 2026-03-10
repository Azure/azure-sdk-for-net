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
    /// <summary> Backward-compat alias for HciClusterOfferData. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferData : HciClusterOfferData
    {
        /// <summary> Initializes a new instance of <see cref="OfferData"/>. </summary>
        public OfferData() : base() { }

        /// <summary> Initializes a new instance of <see cref="OfferData"/>. </summary>
        internal OfferData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, string publisherId, string content, string contentVersion, string provisioningState, IList<HciSkuMappings> skuMappings)
            : base(id, name, resourceType, systemData, additionalBinaryDataProperties,
                  new OfferProperties(provisioningState, publisherId, content, contentVersion, skuMappings, null))
        {
        }
    }
}
