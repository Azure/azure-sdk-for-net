// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub.Models
{
    public partial class RoutingTwinProperties
    {
        /// <summary> Twin desired properties. </summary>
        [CodeGenMember("Desired")]
        public BinaryData Desired { get; set; }

        /// <summary> Twin reported properties. </summary>
        [CodeGenMember("Reported")]
        public BinaryData Reported { get; set; }
    }
}
