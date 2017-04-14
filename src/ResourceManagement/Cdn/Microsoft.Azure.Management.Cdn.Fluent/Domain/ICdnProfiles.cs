// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Entry point for CDN profile management API.
    /// </summary>
    public interface ICdnProfiles  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<CdnProfile.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Cdn.Fluent.ICdnProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Cdn.Fluent.ICdnManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Cdn.Fluent.IProfilesOperations>
    {
        /// <summary>
        /// Lists all the edge nodes of a CDN service.
        /// </summary>
        /// <return>List of all the edge nodes of a CDN service.</return>
        System.Collections.Generic.IEnumerable<EdgeNode> ListEdgeNodes();

        /// <summary>
        /// Starts an existing stopped CDN endpoint.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        void StartEndpoint(string resourceGroupName, string profileName, string endpointName);

        /// <summary>
        /// Lists all of the available CDN REST API operations.
        /// </summary>
        /// <return>List of available CDN REST operations.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Cdn.Fluent.Operation> ListOperations();

        /// <summary>
        /// Forcibly pre-loads CDN endpoint content. Available for Verizon profiles.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group within the Azure subscription.</param>
        /// <param name="profileName">Name of the CDN profile which is unique within the resource group.</param>
        /// <param name="endpointName">Name of the endpoint under the profile which is unique globally.</param>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void LoadEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths);

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint.
        /// </summary>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The CheckNameAvailabilityResult object if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult CheckEndpointNameAvailability(string name);

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
        /// Check the quota and actual usage of the CDN profiles under the current subscription.
        /// </summary>
        /// <return>Quotas and actual usages of the CDN profiles under the current subscription.</return>
        System.Collections.Generic.IEnumerable<ResourceUsage> ListResourceUsage();

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

        /// <summary>
        /// Checks the availability of a endpoint name without creating the CDN endpoint asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="name">The endpoint resource name to validate.</param>
        /// <return>The Observable to CheckNameAvailabilityResult object if successful.</return>
        Task<Microsoft.Azure.Management.Cdn.Fluent.CheckNameAvailabilityResult> CheckEndpointNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

    }
}