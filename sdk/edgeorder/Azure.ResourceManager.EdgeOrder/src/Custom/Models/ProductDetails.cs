// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    public partial class ProductDetails
    {
        /// <summary> Quantity of the product. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Count => ChildConfigurationDeviceDetails.FirstOrDefault().Quantity;
        /// <summary> list of device details. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<EdgeOrderProductDeviceDetails> DeviceDetails => ParentDeviceDetails != null ? new List<EdgeOrderProductDeviceDetails> { ParentDeviceDetails } : new List<EdgeOrderProductDeviceDetails>();
    }
}
