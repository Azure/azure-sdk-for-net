// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Resources.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.PrivateDns
{
    // Suppress the generated WritableSubResource property to preserve the shipped ResourceIdentifier API while using the generated wrapper internally.
    [CodeGenSuppressAttribute("VirtualNetworkId")]
    public partial class VirtualNetworkLinkData
    {
        /// <summary> The reference of the virtual network. </summary>
        [WirePath("properties.virtualNetwork.id")]
        public ResourceIdentifier VirtualNetworkId
        {
            get => Properties is null ? default : Properties.VirtualNetworkId?.Id;
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualNetworkLinkProperties();
                }

                Properties.VirtualNetworkId = value is null ? default : new WritableSubResource { Id = value };
            }
        }
    }
}
