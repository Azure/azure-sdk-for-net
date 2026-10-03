// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.HealthcareApis
{
    internal partial class FhirServiceProperties
    {
        private BicepList<HealthcareApisPrivateEndpointConnection> _privateEndpointConnections;

        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<HealthcareApisPrivateEndpointConnection> PrivateEndpointConnections
        {
            get
            {
                Initialize();
                return _privateEndpointConnections;
            }
        }

        partial void DefineAdditionalProperties()
        {
            _privateEndpointConnections = DefineListProperty<HealthcareApisPrivateEndpointConnection>(nameof(PrivateEndpointConnections), new string[] { "privateEndpointConnections" }, isOutput: true);
        }
    }
}
