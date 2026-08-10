// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.HealthBot.Models;

namespace Azure.ResourceManager.HealthBot
{
    // Customization rationale:
    // The previous SDK declared a constructor `HealthBotData(AzureLocation location, HealthBotSku sku)`
    // with `sku` as a required (non-nullable) parameter. The TypeSpec-generated constructor only
    // accepts `location` because `sku` is modeled as optional in the spec. Removing the original
    // 2-arg constructor is a breaking change for callers, so we re-add it here as a partial-class
    // customization with the same null-check semantics as before.
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
