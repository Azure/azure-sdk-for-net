// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.ResourceManager.Models;

// Backward-compat property shims for TypeSpec migration (ApiCompat MembersMustExist):
// - ElasticProfile and UpdateProfile moved to nested Properties in TypeSpec.
// - Identity type changed from ManagedServiceIdentity to NGroupIdentity; shim preserves old type.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class NGroupPatch
    {
        // ApiCompat: old SDK exposed ManagedServiceIdentity; new generation uses NGroupIdentity.
        // Shim preserves the public ManagedServiceIdentity surface while serialization uses NGroupIdentityValue internally.
        /// <summary> The identity of the NGroup, if configured. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity
        {
            get => null;
            set { }
        }

        /// <summary> The elastic profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupElasticProfile ElasticProfile
        {
            get => Properties?.ElasticProfile;
            set
            {
                if (Properties is null)
                    Properties = new NGroupProperties();
                Properties.ElasticProfile = value;
            }
        }

        /// <summary> The update profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NGroupUpdateProfile UpdateProfile
        {
            get => Properties?.UpdateProfile;
            set
            {
                if (Properties is null)
                    Properties = new NGroupProperties();
                Properties.UpdateProfile = value;
            }
        }
    }
}
