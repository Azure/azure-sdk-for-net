// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    // After https://github.com/microsoft/typespec/issues/9403 is resolved,
    // [CodeGenSerialization(nameof(DeviceDetails), "deviceDetails")] needs to be added and regenerated
    [CodeGenSerialization(nameof(Count), "count")]
    public partial class ProductDetails
    {
        /// <summary> Quantity of the product. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Count { get; }
        /// <summary> list of device details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<EdgeOrderProductDeviceDetails> DeviceDetails { get; } = new ChangeTrackingList<EdgeOrderProductDeviceDetails>();
    }
}
