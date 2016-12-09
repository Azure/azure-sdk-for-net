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
        /// <return>The location of the traffic that the endpoint handles.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region SourceTrafficLocation { get; }

        /// <return>The fully qualified DNS name of the external endpoint.</return>
        string Fqdn { get; }
    }
}