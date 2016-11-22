// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class TrafficManagerNestedProfileEndpointImpl 
    {
        /// <return>The number of child endpoints to be online to consider nested profile as healthy.</return>
        int ITrafficManagerNestedProfileEndpoint.MinimumChildEndpointCount
        {
            get
            {
                return this.MinimumChildEndpointCount();
            }
        }

        /// <return>The nested traffic manager profile resource id.</return>
        string ITrafficManagerNestedProfileEndpoint.NestedProfileId
        {
            get
            {
                return this.NestedProfileId() as string;
            }
        }

        /// <return>The location of the traffic that the endpoint handles.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region ITrafficManagerNestedProfileEndpoint.SourceTrafficLocation
        {
            get
            {
                return this.SourceTrafficLocation() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }
    }
}