// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile external endpoint.
    /// </summary>
    public interface ITrafficManagerExternalEndpoint  :
        ITrafficManagerEndpoint
    {
        /// <summary>
        /// Gets the location of the traffic that the endpoint handles.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region SourceTrafficLocation { get; }

        /// <summary>
        /// Gets the fully qualified DNS name of the external endpoint.
        /// </summary>
        string Fqdn { get; }
    }
}