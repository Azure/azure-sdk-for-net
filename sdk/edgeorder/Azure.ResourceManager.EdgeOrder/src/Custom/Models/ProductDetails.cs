// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    [CodeGenSerialization(nameof(Count), new string[] { "count" })]
    [CodeGenSerialization(nameof(DeviceDetails), new string[] { "deviceDetails" })]
    public partial class ProductDetails
    {
        /// <summary> Quantity of the product. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Count { get; }

        /// <summary> list of device details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<EdgeOrderProductDeviceDetails> DeviceDetails { get; }
    }
}
