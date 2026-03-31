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
        /// <summary> The elastic profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupElasticProfile ElasticProfile
        {
            get
            {
                return Properties?.ElasticProfile as ContainerGroupElasticProfile;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NGroupProperties();
                }
                Properties.ElasticProfile = value;
            }
        }

        /// <summary> Used by the customer to specify the way to update the Container Groups in NGroup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NGroupUpdateProfile UpdateProfile
        {
            get
            {
                return Properties?.UpdateProfile as NGroupUpdateProfile;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NGroupProperties();
                }
                Properties.UpdateProfile = value;
            }
        }

        /// <summary> The identity of the NGroup, if configured. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity
        {
            get => null;
            set => _identity = value;
        }
    }
}
