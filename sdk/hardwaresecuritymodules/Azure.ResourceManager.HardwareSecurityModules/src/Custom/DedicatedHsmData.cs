// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.HardwareSecurityModules.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HardwareSecurityModules
{
    public partial class DedicatedHsmData
    {
        /// <summary> Initializes a new instance of <see cref="DedicatedHsmData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> SKU details. </param>
        /// <param name="properties"> Properties of the dedicated HSM. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> or <paramref name="properties"/> is null. </exception>
        public DedicatedHsmData(AzureLocation location, DedicatedHsmSku sku, DedicatedHsmProperties properties) : this(location, properties, sku)
        {
        }
    }
}
