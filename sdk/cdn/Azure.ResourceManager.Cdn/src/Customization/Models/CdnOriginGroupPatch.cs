// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class CdnOriginGroupPatch
    {
        // Backward compatibility: old API used TrafficRestorationTimeToHealedOrNewEndpointsInMinutes
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes
        {
            get => TrafficRestorationTimeInMinutes;
            set => TrafficRestorationTimeInMinutes = value;
        }
    }
}
