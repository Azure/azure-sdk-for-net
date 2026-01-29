// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sphere.Models
{
    public readonly partial struct SphereUpdatePolicy
    {
        /// <summary> No update for 3rd party app policy. </summary>
        public static SphereUpdatePolicy No3RdPartyAppUpdates => No3rdPartyAppUpdates;
    }
}
