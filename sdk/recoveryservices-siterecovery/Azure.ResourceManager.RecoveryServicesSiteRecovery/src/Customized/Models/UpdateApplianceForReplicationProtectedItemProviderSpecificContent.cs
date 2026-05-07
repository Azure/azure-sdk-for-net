// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    // Back-compat: the MTG generator emits only a `private protected` constructor on
    // abstract discriminator bases, which makes the type effectively sealed to external
    // consumers and trips ApiCompat (CannotSealType + CannotMakeMemberNonVirtual). The
    // baseline AutoRest-generated SDK exposed a `protected` parameterless constructor here.
    // Restore it so that derived subclasses authored outside this assembly remain
    // binary-compatible.
    public abstract partial class UpdateApplianceForReplicationProtectedItemProviderSpecificContent
    {
        /// <summary> Initializes a new instance of <see cref="UpdateApplianceForReplicationProtectedItemProviderSpecificContent"/> for deserialization. </summary>
        protected UpdateApplianceForReplicationProtectedItemProviderSpecificContent()
        {
        }
    }
}
