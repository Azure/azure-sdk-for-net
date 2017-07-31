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
    /// Entry point to traffic manager profile management API in Azure.
    /// </summary>
    public interface ITrafficManagerProfiles  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<TrafficManagerProfile.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.TrafficManager.Fluent.IProfilesOperations>,
        Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfilesBeta
    {
        /// <summary>
        /// Asynchronously checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>A representation of the deferred computation of this call, returning whether the DNS is available to be used for a traffic manager profile and other info if not.</return>
        Task<Microsoft.Azure.Management.TrafficManager.Fluent.CheckProfileDnsNameAvailabilityResult> CheckDnsNameAvailabilityAsync(string dnsNameLabel, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>Whether the DNS is available to be used for a traffic manager profile and other info if not.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.CheckProfileDnsNameAvailabilityResult CheckDnsNameAvailability(string dnsNameLabel);
    }
}