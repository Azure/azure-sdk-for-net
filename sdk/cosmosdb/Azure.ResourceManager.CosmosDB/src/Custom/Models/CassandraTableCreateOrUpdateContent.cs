// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat: 1.4.0 GA exposed Resource/Options as top-level get/set on the
    // TrackedResource wrapper, but MPG emits them as GET-ONLY flatten proxies because
    // the inner CassandraTableCreateUpdateProperties holder has required ctor args
    // (BuildSetterForSafeFlatten cannot synthesize lazy-create setters). We considered
    // @@usage(input|output) on the inner model in client.tsp but verified empirically
    // that it does not change implicit-flatten emission for TrackedResource +
    // OmitProperties wrappers. Re-emit Properties (internal) and Resource/Options as
    // setter-bearing proxies; Options delegates directly because the typed ctor
    // guarantees Properties is non-null after construction.
    // TODO: revisit when https://github.com/Azure/azure-sdk-for-net/issues/59498 is fixed.
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Resource")]
    [CodeGenSuppress("Options")]
    public partial class CassandraTableCreateOrUpdateContent
    {
        [WirePath("properties")]
        internal CassandraTableCreateUpdateProperties Properties { get; set; }

        [WirePath("properties.resource")]
        public CassandraTableResourceInfo Resource
        {
            get => Properties?.Resource;
            set => Properties = new CassandraTableCreateUpdateProperties(value) { Options = Properties?.Options };
        }

        [WirePath("properties.options")]
        public CosmosDBCreateUpdateConfig Options
        {
            get => Properties.Options;
            set => Properties.Options = value;
        }
    }
}
