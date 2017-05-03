// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition;
    using Microsoft.Rest;

    /// <summary>
    /// Members of ITrafficManagerProfiles that are in Beta.
    /// </summary>
    public interface ITrafficManagerProfilesBeta : IBeta
    {
        /// <summary>
        /// Asynchronously checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>
        /// Observable to response containing whether the DNS is available to be used for a traffic manager profile
        /// and other info if not.
        /// </return>
        Task<Microsoft.Azure.Management.TrafficManager.Fluent.CheckProfileDnsNameAvailabilityResult> CheckDnsNameAvailabilityAsync(string dnsNameLabel, CancellationToken cancellationToken = default(CancellationToken));
    }
}