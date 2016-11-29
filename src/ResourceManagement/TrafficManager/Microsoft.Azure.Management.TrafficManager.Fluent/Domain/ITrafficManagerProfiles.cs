// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using TrafficManagerProfile.Definition;

    /// <summary>
    /// Entry point to traffic manager profile management API in Azure.
    /// </summary>
    public interface ITrafficManagerProfiles  :
        ISupportsCreating<TrafficManagerProfile.Definition.IBlank>,
        ISupportsListing<ITrafficManagerProfile>,
        ISupportsListingByGroup<ITrafficManagerProfile>,
        ISupportsGettingByGroup<ITrafficManagerProfile>,
        ISupportsGettingById<ITrafficManagerProfile>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<ITrafficManagerProfile>
    {
        /// <summary>
        /// Checks that the DNS name is valid for traffic manager profile and is not in use.
        /// </summary>
        /// <param name="dnsNameLabel">The DNS name to check.</param>
        /// <return>Whether the DNS is available to be used for a traffic manager profile and other info if not.</return>
        CheckProfileDnsNameAvailabilityResult CheckDnsNameAvailability(string dnsNameLabel);
    }
}