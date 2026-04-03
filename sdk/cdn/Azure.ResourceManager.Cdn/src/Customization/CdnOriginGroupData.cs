// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn
{
    public partial class CdnOriginGroupData
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
