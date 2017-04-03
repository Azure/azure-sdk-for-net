// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;
    using TrafficManagerProfile.Definition;

    /// <summary>
    /// Entry point to traffic manager profile management API in Azure.
    /// </summary>
    public interface ITrafficManagerProfiles  :
        ISupportsCreating<TrafficManagerProfile.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        ISupportsListingByGroup<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        ISupportsGettingById<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        IHasManager<ITrafficManager>,
        IHasInner<IProfilesOperations>
    {
        /// <summary>
        /// Checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>Whether the DNS is available to be used for a traffic manager profile and other info if not.</return>
        CheckProfileDnsNameAvailabilityResult CheckDnsNameAvailability(string dnsNameLabel);


        /// <summary>
        /// Checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>Whether the DNS is available to be used for a traffic manager profile and other info if not.</return>
        Task<CheckProfileDnsNameAvailabilityResult> CheckDnsNameAvailabilityAsync(string dnsNameLabel, CancellationToken cancellationToken = default(CancellationToken));
    }
}