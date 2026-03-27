// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed StartTime as a string property.
    // The new TypeSpec-generated code uses DateTimeOffset (StartOn). This property preserves
    // the old string-typed accessor to avoid breaking existing consumers.
    public partial class NetworkCloudActionState
    {
        /// <summary> The start time of the action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StartTime => StartOn?.ToString("O");
    }
}
