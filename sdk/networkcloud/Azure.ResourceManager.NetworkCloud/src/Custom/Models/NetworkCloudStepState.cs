// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudStepState
    {
        /// <summary> The timestamp when the step started. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? StartOn => DateTimeOffset.TryParse(StartTime, out var result) ? result : (DateTimeOffset?)null;

        /// <summary> The timestamp when the step ended. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? EndOn => DateTimeOffset.TryParse(EndTime, out var result) ? result : (DateTimeOffset?)null;
    }
}
