// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // PrivateEndpointId is a two-level flatten (properties.privateEndpoint.id) that the single-level
    // @@flattenProperty decorator in the spec cannot express; CodeGenMember rebinds it to main's GA shape.
    public partial class EventGridPrivateEndpointConnectionData
    {
        /// <summary> The Id of the private endpoint. </summary>
        [CodeGenMember("PrivateEndpointId")]
        [WirePath("properties.privateEndpoint.id")]
        public ResourceIdentifier PrivateEndpointId
        {
            get => Properties is null ? default : Properties.PrivateEndpointId;
            set
            {
                if (Properties is null)
                {
                    Properties = new PrivateEndpointConnectionProperties();
                }

                Properties.PrivateEndpointId = value;
            }
        }
    }
}
