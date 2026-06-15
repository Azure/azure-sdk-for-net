// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS1591

using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    [CodeGenSuppress("PrivateEndpointId")]
    public partial class EventGridPrivateEndpointConnectionData
    {
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
