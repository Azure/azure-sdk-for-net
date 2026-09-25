// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.HealthcareApis
{
    public partial class FhirService
    {
        /// <summary> Gets the private endpoint connections. </summary>
        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<HealthcareApisPrivateEndpointConnection> PrivateEndpointConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new FhirServiceProperties();
                }
                return Properties.PrivateEndpointConnections;
            }
        }
    }
}
