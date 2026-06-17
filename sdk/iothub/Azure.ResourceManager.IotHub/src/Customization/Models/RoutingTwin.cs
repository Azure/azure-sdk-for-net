// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub.Models
{
    public partial class RoutingTwin
    {
        /// <summary> Twin Tags. </summary>
        [CodeGenMember("Tags")]
        public BinaryData Tags { get; set; }
    }
}
