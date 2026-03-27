// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed EndOn and StartOn as flattened
    // DateTimeOffset properties. The new TypeSpec-generated code does not expose them directly
    // or uses different property names/types. This file preserves the old property surface.
    public partial class NetworkCloudStepState
    {
        /// <summary> The timestamp for when processing of the step reached its terminal state, in ISO 8601 format. </summary>
        public DateTimeOffset? EndOn { get; }

        /// <summary> The timestamp for when processing of the step began, in ISO 8601 format. </summary>
        public DateTimeOffset? StartOn { get; }
    }
}
