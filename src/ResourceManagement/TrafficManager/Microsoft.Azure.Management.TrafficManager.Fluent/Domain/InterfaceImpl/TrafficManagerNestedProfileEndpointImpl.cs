// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class TrafficManagerNestedProfileEndpointImpl 
    {
        /// <summary>
        /// Gets the number of child endpoints to be online to consider nested profile as healthy.
        /// </summary>
        int Microsoft.Azure.Management.Trafficmanager.Fluent.ITrafficManagerNestedProfileEndpoint.MinimumChildEndpointCount
        {
            get
            {
                return this.MinimumChildEndpointCount();
            }
        }

        /// <summary>
        /// Gets the nested traffic manager profile resource id.
        /// </summary>
        string Microsoft.Azure.Management.Trafficmanager.Fluent.ITrafficManagerNestedProfileEndpoint.NestedProfileId
        {
            get
            {
                return this.NestedProfileId();
            }
        }

        /// <summary>
        /// Gets the location of the traffic that the endpoint handles.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Trafficmanager.Fluent.ITrafficManagerNestedProfileEndpoint.SourceTrafficLocation
        {
            get
            {
                return this.SourceTrafficLocation() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }
    }
}