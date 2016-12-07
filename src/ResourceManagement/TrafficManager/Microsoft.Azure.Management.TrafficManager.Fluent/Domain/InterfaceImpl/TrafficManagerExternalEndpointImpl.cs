// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class TrafficManagerExternalEndpointImpl 
    {
        /// <return>The fully qualified DNS name of the external endpoint.</return>
        string ITrafficManagerExternalEndpoint.Fqdn
        {
            get
            {
                return this.Fqdn() as string;
            }
        }

        /// <return>The location of the traffic that the endpoint handles.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region ITrafficManagerExternalEndpoint.SourceTrafficLocation
        {
            get
            {
                return this.SourceTrafficLocation();
            }
        }
    }
}