// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: the generated AvailabilityZoneMapping has only an internal ctor for
// deserialization. The GA SDK exposed a public parameterless ctor; re-expose it here so
// users can still construct mock/test instances.
namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Availability zone mapping. </summary>
    public partial class AvailabilityZoneMapping
    {
        /// <summary> Initializes a new instance of <see cref="AvailabilityZoneMapping"/> for deserialization. </summary>
        public AvailabilityZoneMapping()
        {
        }
    }
}
