// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // The generator places configurationType under Properties, but the shipped SDK exposed it on the data
    // object. Removing this flattened member would be a public property removal.
    public partial class NetworkFabricAccessControlListData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricAccessControlListData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public NetworkFabricAccessControlListData(AzureLocation location) : base(location)
        {
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
