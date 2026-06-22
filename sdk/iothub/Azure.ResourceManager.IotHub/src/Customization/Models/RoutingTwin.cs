// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub.Models
{
    // Customization justification:
    // Twin tags are an open-ended JSON object. Keeping this property as BinaryData avoids constraining
    // callers to a generated shape and preserves the previous SDK's pass-through behavior for arbitrary
    // tag payloads. CodeGenMember maps the custom accessor to the generated "Tags" serialized member.
    public partial class RoutingTwin
    {
        /// <summary> Twin Tags. </summary>
        [CodeGenMember("Tags")]
        public BinaryData Tags { get; set; }
    }
}
