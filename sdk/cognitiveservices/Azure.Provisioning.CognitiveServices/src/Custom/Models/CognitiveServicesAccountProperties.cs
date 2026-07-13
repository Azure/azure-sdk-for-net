// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CognitiveServices
{
    public partial class CognitiveServicesAccountProperties
    {
        private BicepList<CognitiveServicesPrivateEndpointConnection> _privateEndpointConnectionResources;

#pragma warning disable CS0618 // Compatibility shim intentionally exposes the obsolete model type.
        private BicepList<CognitiveServicesPrivateEndpointConnectionData> _privateEndpointConnectionData;
#pragma warning restore CS0618

        /// <summary> Gets the PrivateEndpointConnectionResources. </summary>
        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<CognitiveServicesPrivateEndpointConnection> PrivateEndpointConnectionResources
        {
            get
            {
                Initialize();
                return _privateEndpointConnectionResources;
            }
        }

        /// <summary> Gets the PrivateEndpointConnections. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use PrivateEndpointConnectionResources instead.")]
#pragma warning disable CS0618 // Compatibility shim intentionally exposes the obsolete model type.
        public BicepList<CognitiveServicesPrivateEndpointConnectionData> PrivateEndpointConnections
#pragma warning restore CS0618
        {
            get
            {
                Initialize();
                return _privateEndpointConnectionData;
            }
        }

        /// <summary> Define additional provisionable properties for CognitiveServicesAccountProperties that are not part of the generated code. </summary>
        partial void DefineAdditionalProperties()
        {
            _privateEndpointConnectionResources = DefineListProperty<CognitiveServicesPrivateEndpointConnection>(nameof(PrivateEndpointConnectionResources), new string[] { "privateEndpointConnections" }, isOutput: true);
#pragma warning disable CS0618 // Compatibility shim intentionally wires the obsolete property/model.
            _privateEndpointConnectionData = DefineListProperty<CognitiveServicesPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "privateEndpointConnections" }, isOutput: true);
#pragma warning restore CS0618
        }
    }
}
