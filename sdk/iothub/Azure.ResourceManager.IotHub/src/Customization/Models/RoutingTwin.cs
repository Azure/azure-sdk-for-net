// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.IotHub.Models
{
    // Customization justification:
    // Twin tags are an open-ended JSON object. Keeping this property as BinaryData avoids constraining
    // callers to a generated shape and preserves the previous SDK's pass-through behavior for arbitrary
    // tag payloads.
    /// <summary> Twin reference input parameter. This is an optional parameter. </summary>
    public partial class RoutingTwin
    {
        /// <summary> Twin Tags. </summary>
        public BinaryData Tags { get; set; }
    }
}
