// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

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
