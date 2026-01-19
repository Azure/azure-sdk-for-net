// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    // After https://github.com/microsoft/typespec/issues/9403 is resolved,
    // [CodeGenSerialization(nameof(DeviceDetails), "parentDeviceDetails")] needs to be added and regenerated
    // same as [CodeGenSerialization(nameof(Count), "quantity")]
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
