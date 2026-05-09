// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// Spec wraps TableCreateUpdateParameters in a TrackedResource-extending
// custom model (client.tsp:2200-2214) so the SDK class inherits TrackedResourceData
// for legacy back-compat. The wrapper keeps `properties: TableCreateUpdateProperties`
// as a nested envelope; MPG emits Resource/Options as GET-ONLY flatten proxies because
// the inner properties model has required ctor args and BuildSetterForSafeFlatten cannot
// synthesize lazy-create setters (@@flattenProperty has the same limitation). Legacy
// AutoRest exposed Resource/Options as top-level read/write via x-ms-client-flatten.
// Suppress the read-only generated members and re-emit Properties (internal),
// Resource and Options as setter-bearing proxies that mutate the inner leaf,
// preserving the legacy SDK shape without a spec change. ResourceTableName is a
// further back-compat convenience (typed equivalent of `Resource.Id`).
// See client.tsp:2025-2041.
namespace Azure.ResourceManager.CosmosDB.Models
{
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Resource")]
    [CodeGenSuppress("Options")]
    public partial class CosmosDBTableCreateOrUpdateContent
    {
        [WirePath("properties")]
        internal TableCreateUpdateProperties Properties { get; set; }

        [WirePath("properties.resource")]
        public CosmosDBTableResourceInfo Resource
        {
            get => Properties?.Resource;
            set => Properties = new TableCreateUpdateProperties(value) { Options = Properties?.Options };
        }

        [WirePath("properties.options")]
        public CosmosDBCreateUpdateConfig Options
        {
            get => Properties?.Options;
            set
            {
                if (Properties == null && value != null)
                {
                    return;
                }
                if (Properties != null)
                {
                    Properties.Options = value;
                }
            }
        }
        public string ResourceTableName
        {
            get => Resource?.TableName;
            set => Resource = new CosmosDBTableResourceInfo(value);
        }
    }
}
