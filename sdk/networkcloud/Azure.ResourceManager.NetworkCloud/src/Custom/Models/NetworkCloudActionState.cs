// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudActionState
    {
        /// <summary> The timestamp when the action ended. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? EndOn => DateTimeOffset.TryParse(EndTime, out var result) ? result : (DateTimeOffset?)null;
    }
}
