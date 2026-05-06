// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

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
