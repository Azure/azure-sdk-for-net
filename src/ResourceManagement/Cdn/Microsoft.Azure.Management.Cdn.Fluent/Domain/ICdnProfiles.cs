// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using System.Collections.Generic;
    using CdnProfile.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Entry point for CDN profile management API.
    /// </summary>
    public interface ICdnProfiles  :
        ISupportsCreating<CdnProfile.Definition.IBlank>,
        ISupportsListing<ICdnProfile>,
        ISupportsListingByGroup<ICdnProfile>,
        ISupportsGettingByGroup<ICdnProfile>,
        ISupportsGettingById<ICdnProfile>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<ICdnProfile>
    {
        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        CheckNameAvailabilityResult CheckEndpointNameAvailability(string name);

        /// <summary>
        /// Lists all of the available CDN REST API operations.
        /// </summary>
        /// <return>List of available CDN REST operations.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Operation> ListOperations();

        /// <summary>
        /// Generates a dynamic SSO URI used to sign in to the CDN supplemental portal.
        /// Supplemental portal is used to configure advanced feature capabilities that are not
        /// yet available in the Azure portal, such as core reports in a standard profile;
        /// rules engine, advanced HTTP reports, and real-time stats and alerts in a premium profile.
        /// The SSO URI changes approximately every 10 minutes.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <return>The Sso Uri string if successful.</return>
        string GenerateSsoUri(string resourceGroupName, string profileName);

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content. Available for Verizon profiles.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void LoadEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths);

        /// <summary>
        /// Starts an existing stopped CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StartEndpoint(string resourceGroupName, string profileName, string endpointName);

        /// <summary>
        /// Forcibly purges CDN endpoint content.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void PurgeEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths);

        /// <summary>
        /// Stops an existing running CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StopEndpoint(string resourceGroupName, string profileName, string endpointName);
    }
}