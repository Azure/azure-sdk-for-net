// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    public partial class EdgeOrderData
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderData"/>. </summary>
        public EdgeOrderData()
        {
            Properties = new OrderProperties();
        }
    }
}
