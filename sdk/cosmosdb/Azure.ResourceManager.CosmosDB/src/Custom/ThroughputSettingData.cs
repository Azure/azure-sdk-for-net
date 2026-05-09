// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// MPG emits ThroughputSettingData (the Get/list response data type for throughput
// settings) with `Properties: ThroughputSettingsProperties` as a nested envelope and
// the flattened `Resource` accessor as GET-ONLY because ThroughputSettingsProperties
// has a required `resource` ctor arg, so BuildSetterForSafeFlatten cannot synthesize
// a lazy-create setter (@@flattenProperty has the same limitation). The legacy
// AutoRest-generated SDK exposed `Resource` as top-level read/write via
// x-ms-client-flatten. Suppress the read-only generated members and re-emit
// Properties (internal) plus Resource as a setter-bearing proxy that re-creates the
// inner ThroughputSettingsProperties leaf with the new value, preserving the
// historical SDK shape without a spec change.
namespace Azure.ResourceManager.CosmosDB
{
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
