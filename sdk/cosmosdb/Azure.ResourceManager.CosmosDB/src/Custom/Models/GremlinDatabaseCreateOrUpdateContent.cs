// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat: 1.4.0 GA exposed Resource/Options as top-level get/set on the
    // TrackedResource wrapper, but MPG emits them as GET-ONLY flatten proxies because
    // the inner GremlinDatabaseCreateUpdateProperties holder has required ctor args
    // (BuildSetterForSafeFlatten cannot synthesize lazy-create setters). Re-emit
    // Properties (internal) and Resource/Options as setter-bearing proxies;
    // ResourceDatabaseName is a typed convenience for `Resource.Id`.
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("Resource")]
    [CodeGenSuppress("Options")]
    public partial class GremlinDatabaseCreateOrUpdateContent
    {
        [WirePath("properties")]
        internal GremlinDatabaseCreateUpdateProperties Properties { get; set; }

        [WirePath("properties.resource")]
        public GremlinDatabaseResourceInfo Resource
        {
            get => Properties?.Resource;
            set => Properties = new GremlinDatabaseCreateUpdateProperties(value) { Options = Properties?.Options };
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
        public string ResourceDatabaseName
        {
            get => Resource?.DatabaseName;
            set => Resource = new GremlinDatabaseResourceInfo(value);
        }
    }
}
