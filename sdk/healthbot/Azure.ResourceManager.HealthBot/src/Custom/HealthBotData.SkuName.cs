// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.HealthBot.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HealthBot
{
    public partial class HealthBotData
    {
        // Customization rationale:
        // The previous SDK exposed a top-level `SkuName` convenience property on HealthBotData that
        // delegated to Sku.Name. There is no flatten in the TypeSpec spec that would synthesize this
        // accessor, and adding such a flatten would conflict with the existing `Sku` property. To
        // preserve the public API surface we re-introduce `SkuName` here as a customization that
        // forwards reads/writes to the underlying `Sku` instance. `[CodeGenMember("SkuName")]`
        // suppresses any duplicate auto-generated stub from the model factory.
        /// <summary> The name of the Azure Health Bot SKU. </summary>
        [CodeGenMember("SkuName")]
        public HealthBotSkuName? SkuName
        {
            get => Sku?.Name;
            set
            {
                if (value.HasValue)
                {
                    Sku = new HealthBotSku(value.Value);
                }
                else
                {
                    Sku = null;
                }
            }
        }
    }
}
