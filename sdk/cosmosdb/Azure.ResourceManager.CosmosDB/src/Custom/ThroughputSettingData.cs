// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB
{
    // Back-compat: 1.4.0 GA exposed Resource as top-level { get; set; } via x-ms-client-flatten.
    // MPG emits it as get-only because ThroughputSettingsProperties has a required `resource` ctor arg
    // (BuildSetterForSafeFlatten cannot synthesize lazy-create setters). Suppress and re-emit
    // Properties (internal) + Resource as a setter-bearing proxy that re-creates the inner holder.
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Resource")]
    public partial class ThroughputSettingData
    {
        [WirePath("properties")]
        internal ThroughputSettingsProperties Properties { get; set; }

        [WirePath("properties.resource")]
        public ExtendedThroughputSettingsResourceInfo Resource
        {
            get => Properties?.Resource;
            set => Properties = new ThroughputSettingsProperties(value, null);
        }
    }
}
