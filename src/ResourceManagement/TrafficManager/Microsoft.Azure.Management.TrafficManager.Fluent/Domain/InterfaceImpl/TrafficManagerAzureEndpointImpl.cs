// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    internal partial class TrafficManagerAzureEndpointImpl 
    {
        /// <return>The type of the target Azure resource.</return>
        TargetAzureResourceType ITrafficManagerAzureEndpoint.TargetResourceType
        {
            get
            {
                return this.TargetResourceType() as TargetAzureResourceType;
            }
        }

        /// <return>The resource id of the target Azure resource.</return>
        string ITrafficManagerAzureEndpoint.TargetAzureResourceId
        {
            get
            {
                return this.TargetAzureResourceId() as string;
            }
        }
    }
}