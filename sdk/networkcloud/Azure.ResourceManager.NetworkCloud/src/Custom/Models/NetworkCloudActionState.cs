// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudActionState
    {
        /// <summary> The start time of the action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StartTime => StartOn?.ToString("O");
    }
}
