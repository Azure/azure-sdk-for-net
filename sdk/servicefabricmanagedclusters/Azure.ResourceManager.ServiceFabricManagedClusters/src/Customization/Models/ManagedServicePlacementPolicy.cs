// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary>
    /// Describes the policy to be used for placement of a Service Fabric service.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="ServicePlacementInvalidDomainPolicy"/>, <see cref="ServicePlacementRequiredDomainPolicy"/>, <see cref="ServicePlacementPreferPrimaryDomainPolicy"/>, <see cref="ServicePlacementRequireDomainDistributionPolicy"/>, and <see cref="ServicePlacementNonPartiallyPlaceServicePolicy"/>.
    /// </summary>
    public abstract partial class ManagedServicePlacementPolicy
    {
        /// <summary> Initializes a new instance of <see cref="ManagedServicePlacementPolicy"/> for deserialization. </summary>
        protected ManagedServicePlacementPolicy()
        {
        }
    }
}
