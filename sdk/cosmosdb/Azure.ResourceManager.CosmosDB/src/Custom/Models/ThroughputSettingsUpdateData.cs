// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat: 1.4.0 GA exposed Resource as a top-level get/set on the TrackedResource
    // wrapper, but MPG emits it as a GET-ONLY flatten proxy because the inner
    // ThroughputSettingsUpdateProperties has a required `resource` ctor arg
    // (BuildSetterForSafeFlatten cannot synthesize a lazy-create setter). Re-emit
    // Properties (internal) and Resource as a setter-bearing proxy that re-creates the
    // inner properties leaf with the new value.
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Resource")]
    public partial class ThroughputSettingsUpdateData
    {
        [WirePath("properties")]
        internal ThroughputSettingsUpdateProperties Properties { get; set; }

        [WirePath("properties.resource")]
        public ThroughputSettingsResourceInfo Resource
        {
            get => Properties?.Resource;
            set => Properties = new ThroughputSettingsUpdateProperties(value);
        }
    }
}
