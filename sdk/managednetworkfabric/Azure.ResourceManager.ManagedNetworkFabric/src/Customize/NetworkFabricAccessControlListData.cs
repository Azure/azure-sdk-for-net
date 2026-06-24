// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // The generator places configurationType under Properties and makes the constructor parameter non-nullable
    // because the service marks the wire property as required. These shims preserve the shipped nullable
    // constructor and flattened property; removing them would change constructor and property compatibility.
    [CodeGenSuppress("NetworkFabricAccessControlListData", typeof(AzureLocation), typeof(NetworkFabricConfigurationType))]
    public partial class NetworkFabricAccessControlListData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricAccessControlListData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkFabricAccessControlListData(AzureLocation location) : this(location, default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricAccessControlListData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="configurationType"> Input method to configure Access Control List. </param>
        public NetworkFabricAccessControlListData(AzureLocation location, NetworkFabricConfigurationType? configurationType) : base(location)
        {
            Properties = configurationType.HasValue ? new AccessControlListProperties(configurationType.Value) : new AccessControlListProperties();
        }

        /// <summary> Input method to configure Access Control List. </summary>
        [CodeGenMember("ConfigurationType")]
        public NetworkFabricConfigurationType? ConfigurationType
        {
            get
            {
                return Properties is null ? default : Properties.ConfigurationType;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new AccessControlListProperties();
                }
                Properties.ConfigurationType = value.GetValueOrDefault();
            }
        }
    }
}
