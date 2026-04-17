// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: AvailabilityZoneMappings was IList in old API, now IReadOnlyList.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> RegionInfoResource data. </summary>
    public partial class RegionInfoResourceData
    {
        /// <summary> Initializes a new instance of <see cref="RegionInfoResourceData"/> for deserialization. </summary>
        public RegionInfoResourceData()
        {
        }

        /// <summary> Provides logical-to-physical mapping of availability zones for the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<AvailabilityZoneMapping> AvailabilityZoneMappings
        {
            get
            {
                var list = Properties?.AvailabilityZoneMappings;
                return list is null ? null : list.ToList();
            }
        }
    }
}
