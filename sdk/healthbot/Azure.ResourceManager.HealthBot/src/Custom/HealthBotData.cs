// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.HealthBot.Models;

namespace Azure.ResourceManager.HealthBot
{
    // Add it back manually to ensure compatibility
    public partial class HealthBotData
    {
        /// <summary> Initializes a new instance of <see cref="HealthBotData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> SKU of the Azure Health Bot. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public HealthBotData(AzureLocation location, HealthBotSku sku) : base(location)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
        }
    }
}
