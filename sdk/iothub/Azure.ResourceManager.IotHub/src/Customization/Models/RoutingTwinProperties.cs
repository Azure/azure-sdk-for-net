// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.IotHub.Models
{
    // Customization justification:
    // Routing twin desired/reported properties are arbitrary JSON documents supplied by users and by
    // device twin state. Modeling them as BinaryData intentionally preserves the old SDK behavior where
    // callers could pass through unknown or service-specific JSON without the generator attempting to
    // flatten it into a fixed schema.
    /// <summary> The RoutingTwinProperties. </summary>
    public partial class RoutingTwinProperties
    {
        /// <summary> Twin desired properties. </summary>
        public BinaryData Desired { get; set; }

        /// <summary> Twin reported properties. </summary>
        public BinaryData Reported { get; set; }
    }
}
