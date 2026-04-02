// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat property shims: ElasticProfile and UpdateProfile moved to nested Properties in TypeSpec migration.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class NGroupPatch
    {
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
