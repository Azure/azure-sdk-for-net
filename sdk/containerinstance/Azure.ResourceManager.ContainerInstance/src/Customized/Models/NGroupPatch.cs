// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class NGroupPatch
    {
        // backward-compat shim: old property returned ContainerGroupElasticProfile, new returns ElasticProfile
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupElasticProfile ElasticProfile
        {
            get => Properties is null ? default : Properties.ElasticProfile as ContainerGroupElasticProfile;
            set
            {
                if (Properties is null)
                    Properties = new NGroupProperties();
                Properties.ElasticProfile = value;
            }
        }

        // backward-compat shim: old property was ManagedServiceIdentity, new is NGroupIdentity
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity
        {
            get => default;
            set => _identity = value;
        }

        // backward-compat shim: old property returned NGroupUpdateProfile, new returns UpdateProfile
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NGroupUpdateProfile UpdateProfile
        {
            get => Properties is null ? default : Properties.UpdateProfile as NGroupUpdateProfile;
            set
            {
                if (Properties is null)
                    Properties = new NGroupProperties();
                Properties.UpdateProfile = value;
            }
        }
    }
}
