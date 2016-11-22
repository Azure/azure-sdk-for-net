// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile nested profile endpoint.
    /// </summary>
    public interface ITrafficManagerNestedProfileEndpoint  :
        ITrafficManagerEndpoint
    {
        /// <return>The location of the traffic that the endpoint handles.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region SourceTrafficLocation { get; }

        /// <return>The number of child endpoints to be online to consider nested profile as healthy.</return>
        int MinimumChildEndpointCount { get; }

        /// <return>The nested traffic manager profile resource id.</return>
        string NestedProfileId { get; }
    }
}