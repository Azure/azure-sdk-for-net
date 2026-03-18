// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Purview.Models
{
    // Backward compatibility: old SDK (1.1.0) had a factory method for PurviewPrivateLinkResourceProperties.
    // The new generator doesn't produce one, so we add it manually to satisfy ApiCompat.
    public static partial class ArmPurviewModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PurviewPrivateLinkResourceProperties"/>. </summary>
        /// <param name="groupId"> The private link resource group identifier. </param>
        /// <param name="requiredMembers"> The private link resource required member names. </param>
        /// <param name="requiredZoneNames"> The required zone names for private link resource. </param>
        /// <returns> A new <see cref="PurviewPrivateLinkResourceProperties"/> instance for mocking. </returns>
        public static PurviewPrivateLinkResourceProperties PurviewPrivateLinkResourceProperties(string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null)
        {
            return new PurviewPrivateLinkResourceProperties(
                groupId,
                requiredMembers?.ToList(),
                requiredZoneNames?.ToList(),
                null);
        }
    }
}
