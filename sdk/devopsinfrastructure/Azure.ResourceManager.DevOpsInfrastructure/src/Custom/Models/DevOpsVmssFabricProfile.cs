// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.DevOpsInfrastructure;

namespace Azure.ResourceManager.DevOpsInfrastructure.Models
{
    public partial class DevOpsVmssFabricProfile
    {
        /// <summary> Initializes a new instance of <see cref="DevOpsVmssFabricProfile"/>. </summary>
        /// <param name="skuName"> The Azure SKU name of the machines in the pool. </param>
        /// <param name="images"> The VM images of the machines in the pool. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="skuName"/> or <paramref name="images"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DevOpsVmssFabricProfile(string skuName, IEnumerable<DevOpsPoolVmImage> images) : base("Vmss")
        {
            Argument.AssertNotNull(skuName, nameof(skuName));
            Argument.AssertNotNull(images, nameof(images));

            Sku = new DevOpsAzureSku(skuName);
            Images = images.ToList();
        }

        /// <summary> The Azure SKU name of the machines in the pool. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SkuName
        {
            get => Sku is null ? default : Sku.Name;
            set => Sku = new DevOpsAzureSku(value);
        }
    }
}
