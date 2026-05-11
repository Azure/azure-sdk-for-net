// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// Spec wraps MongoDBCollectionCreateUpdateParameters in a TrackedResource-extending
// custom model (client.tsp:2183-2197) so the SDK class inherits TrackedResourceData
// for legacy back-compat. The wrapper keeps `properties: MongoDBCollectionCreateUpdateProperties`
// as a nested envelope; MPG emits Resource/Options as GET-ONLY flatten proxies because
// the inner properties model has required ctor args and BuildSetterForSafeFlatten cannot
// synthesize lazy-create setters (@@flattenProperty has the same limitation). Legacy
// AutoRest exposed Resource/Options as top-level read/write via x-ms-client-flatten.
// Suppress the read-only generated members and re-emit Properties (internal),
// Resource and Options as setter-bearing proxies that mutate the inner leaf,
// preserving the legacy SDK shape without a spec change. See client.tsp:2025-2041.
namespace Azure.ResourceManager.CosmosDB.Models
{
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Resource")]
    [CodeGenSuppress("Options")]
    public partial class MongoDBCollectionCreateOrUpdateContent
    {
        [WirePath("properties")]
        internal MongoDBCollectionCreateUpdateProperties Properties { get; set; }

        [WirePath("properties.resource")]
        public MongoDBCollectionResourceInfo Resource
        {
            get => Properties?.Resource;
            set => Properties = new MongoDBCollectionCreateUpdateProperties(value) { Options = Properties?.Options };
        }

        [WirePath("properties.options")]
        public CosmosDBCreateUpdateConfig Options
        {
            get => Properties?.Options;
            set
            {
                if (Properties == null)
                {
                    throw new InvalidOperationException("Options cannot be set before Resource is initialized; set Resource first to establish the inner Properties holder.");
                }
                Properties.Options = value;
            }
        }
    }
}
