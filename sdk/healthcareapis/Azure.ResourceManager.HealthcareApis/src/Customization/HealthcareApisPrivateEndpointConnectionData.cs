// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.HealthcareApis.Models;

namespace Azure.ResourceManager.HealthcareApis
{
    public partial class HealthcareApisPrivateEndpointConnectionData
    {
        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        public HealthcareApisPrivateLinkServiceConnectionState ConnectionState
        {
            get
            {
                return Properties is null ? default : Properties.PrivateLinkServiceConnectionState;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PrivateEndpointConnectionProperties(value);
                }
                else
                {
                    Properties.PrivateLinkServiceConnectionState = value;
                }
            }
        }

        /// <summary> The resource identifier of the private endpoint. </summary>
        public ResourceIdentifier PrivateEndpointId
        {
            get
            {
                return Properties is null ? default : Properties.PrivateEndpointId;
            }
        }

        /// <summary> The provisioning state of the private endpoint connection resource. </summary>
        public HealthcareApisPrivateEndpointConnectionProvisioningState? ProvisioningState
        {
            get
            {
                return Properties is null ? default : Properties.ProvisioningState;
            }
        }
    }
}
