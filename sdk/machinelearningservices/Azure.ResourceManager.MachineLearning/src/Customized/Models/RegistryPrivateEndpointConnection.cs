// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore GA flattened aliases and compatibility private-endpoint model over the
    // generated nested RegistryPrivateEndpointConnectionProperties shape.
    [CodeGenSuppress("GroupIds")]
    [CodeGenSuppress("PrivateEndpoint")]
    public partial class RegistryPrivateEndpointConnection
    {
        /// <summary> The group ids. </summary>
        [WirePath("properties.groupIds")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> GroupIds
        {
            get
            {
                Properties ??= new RegistryPrivateEndpointConnectionProperties();
                return Properties.GroupIds;
            }
            set
            {
                Properties ??= new RegistryPrivateEndpointConnectionProperties();
                Properties.GroupIds.Clear();
                if (value is not null)
                {
                    foreach (string item in value)
                    {
                        Properties.GroupIds.Add(item);
                    }
                }
            }
        }

        /// <summary> The PE network resource that is linked to this PE connection. </summary>
        [WirePath("properties.privateEndpoint")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RegistryPrivateEndpoint PrivateEndpoint
        {
            get
            {
                if (Properties?.PrivateEndpoint is null)
                {
                    return default;
                }

                return Properties.PrivateEndpoint is RegistryPrivateEndpoint registryPrivateEndpoint
                    ? registryPrivateEndpoint
                    : new RegistryPrivateEndpoint(Properties.PrivateEndpoint.Id, serializedAdditionalRawData: null, Properties.PrivateEndpoint.SubnetArmId);
            }
            set
            {
                Properties ??= new RegistryPrivateEndpointConnectionProperties();
                Properties.PrivateEndpoint = value;
            }
        }
    }
}
