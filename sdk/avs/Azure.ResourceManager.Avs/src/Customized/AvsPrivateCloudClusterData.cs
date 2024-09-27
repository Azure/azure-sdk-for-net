// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Avs.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Avs
{
    /// <summary>
    /// A class representing the AvsPrivateCloudCluster data model.
    /// A cluster resource.
    /// </summary>
    public partial class AvsPrivateCloudClusterData : ResourceData
    {
        /// <summary> The name of the SKU. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SkuName
        {
            get => Sku is null ? default : Sku.Name;
            set => Sku = new AvsSku(value);
        }
    }
}