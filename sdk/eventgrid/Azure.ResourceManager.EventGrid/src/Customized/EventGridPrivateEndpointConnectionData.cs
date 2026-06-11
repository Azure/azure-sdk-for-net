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
            get => PrivateEndpoint is null ? default : PrivateEndpoint.Id;
            set
            {
                if (PrivateEndpoint is null)
                {
                    EnsureProperties();
                    PrivateEndpoint = new PrivateEndpoint();
                }

                PrivateEndpoint.Id = value;
            }
        }

        internal PrivateEndpoint PrivateEndpoint
        {
            get => Properties is null ? default : Properties.PrivateEndpoint;
            set
            {
                EnsureProperties();
                Properties.PrivateEndpoint = value;
            }
        }

        private void EnsureProperties()
        {
            if (Properties is null)
            {
                Properties = new PrivateEndpointConnectionProperties();
            }
        }
    }
}
