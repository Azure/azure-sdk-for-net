// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Keep stale placeholder and active compatibility shim together for this legacy type.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // TODO: stale customization no longer needed after TypeSpec regeneration.
    public partial class MicrosoftMachineLearningServicesPrivateEndpointConnectionData
    {
    }
    [CodeGenSuppress("PrivateEndpoint")]
    public partial class MachineLearningPrivateEndpointConnectionData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningPrivateEndpointConnectionData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPrivateEndpointConnectionData(AzureLocation location)
            : base(location)
        {
        }

        /// <summary> The connection state. </summary>
        [WirePath("properties.privateLinkServiceConnectionState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPrivateLinkServiceConnectionState ConnectionState
        {
            get => PrivateLinkServiceConnectionState;
            set => PrivateLinkServiceConnectionState = value;
        }

        /// <summary> The private endpoint resource identifier. </summary>
        [WirePath("properties.privateEndpoint.id")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SubResourceId => PrivateEndpoint?.Id;

        /// <summary> Gets or sets the PrivateEndpoint. </summary>
        [WirePath("properties.privateEndpoint")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPrivateEndpoint PrivateEndpoint
        {
            get
            {
                if (Properties?.PrivateEndpoint is null)
                {
                    return default;
                }

                return new MachineLearningPrivateEndpoint(
                    Properties.PrivateEndpoint.Id is null ? null : new ResourceIdentifier(Properties.PrivateEndpoint.Id),
                    Properties.PrivateEndpoint.SubnetArmId is null ? null : new ResourceIdentifier(Properties.PrivateEndpoint.SubnetArmId),
                    serializedAdditionalRawData: null);
            }
            set
            {
                Properties ??= new PrivateEndpointConnectionProperties();
                Properties.PrivateEndpoint = value is null ? null : new WorkspacePrivateEndpointResource(value.Id?.ToString(), value.SubnetArmId?.ToString(), additionalBinaryDataProperties: null);
            }
        }
    }
}

#pragma warning restore SA1402
