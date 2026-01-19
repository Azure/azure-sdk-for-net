// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    //[CodeGenSerialization(nameof(DeviceDetails), "parentDeviceDetails")]
    //[CodeGenSerialization(nameof(Count), "quantity")]
    public partial class ProductDetails
    {
        /// <summary> Quantity of the product. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Count => ChildConfigurationDeviceDetails.FirstOrDefault().Quantity;
        /// <summary> list of device details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<EdgeOrderProductDeviceDetails> DeviceDetails { get; } = new ChangeTrackingList<EdgeOrderProductDeviceDetails>();
    }
}
