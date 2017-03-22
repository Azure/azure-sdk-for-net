// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile nested profile endpoint.
    /// </summary>
    public interface ITrafficManagerNestedProfileEndpoint  :
        ITrafficManagerEndpoint
    {
        /// <summary>
        /// Gets the location of the traffic that the endpoint handles.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region SourceTrafficLocation { get; }

        /// <summary>
        /// Gets the number of child endpoints to be online to consider nested profile as healthy.
        /// </summary>
        int MinimumChildEndpointCount { get; }

        /// <summary>
        /// Gets the nested traffic manager profile resource id.
        /// </summary>
        string NestedProfileId { get; }
    }
}