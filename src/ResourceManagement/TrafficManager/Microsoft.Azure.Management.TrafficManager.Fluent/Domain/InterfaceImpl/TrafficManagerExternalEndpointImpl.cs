// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class TrafficManagerExternalEndpointImpl 
    {
        /// <summary>
        /// Gets the fully qualified DNS name of the external endpoint.
        /// </summary>
        string Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerExternalEndpoint.Fqdn
        {
            get
            {
                return this.Fqdn();
            }
        }

        /// <summary>
        /// Gets the location of the traffic that the endpoint handles.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerExternalEndpoint.SourceTrafficLocation
        {
            get
            {
                return this.SourceTrafficLocation() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }
    }
}