// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// Spec wraps ThroughputSettingsUpdateParameters in a TrackedResource-extending
// custom model (client.tsp:2064-2074) so the SDK class inherits TrackedResourceData
// for legacy back-compat. The wrapper keeps `properties: ThroughputSettingsUpdateProperties`
// as a nested envelope; MPG emits Resource as a GET-ONLY flatten proxy because the
// inner properties model has a required `resource` ctor arg and BuildSetterForSafeFlatten
// cannot synthesize a lazy-create setter (@@flattenProperty has the same limitation).
// Legacy AutoRest exposed Resource as a top-level read/write via x-ms-client-flatten.
// Suppress the read-only generated members and re-emit Properties (internal) and
// Resource as a setter-bearing proxy that re-creates the inner CreateUpdateProperties
// leaf with the new resource value, preserving the legacy SDK shape without a spec
// change. See client.tsp:2025-2041.
namespace Azure.ResourceManager.CosmosDB.Models
{
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
