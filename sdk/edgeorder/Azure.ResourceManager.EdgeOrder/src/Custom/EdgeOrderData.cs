// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EdgeOrder
{
    public partial class EdgeOrderData
    {
        /// <summary> Initializes a new instance of <see cref="EdgeOrderData"/>. </summary>
        public EdgeOrderData()
        {
            OrderStageHistory = new ChangeTrackingList<EdgeOrderStageDetails>();
        }
    }
}
