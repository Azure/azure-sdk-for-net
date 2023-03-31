// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.AppService. </summary>
    public static partial class AppServiceExtensions
    {
        /// <summary>
        /// Description for List all apps that are assigned to a hostname.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListSiteIdentifiersAssignedToHostName</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="nameIdentifier"> Hostname information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nameIdentifier"/> is null. </exception>
        /// <returns> An async collection of <see cref="AppServiceIdentifierData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AppServiceIdentifierData> GetAllSiteIdentifierDataAsync(this SubscriptionResource subscriptionResource, AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nameIdentifier, nameof(nameIdentifier));

            return GetExtensionClient(subscriptionResource).GetAllSiteIdentifierDataAsync(nameIdentifier, cancellationToken);
        }

        /// <summary>
        /// Description for List all apps that are assigned to a hostname.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListSiteIdentifiersAssignedToHostName</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="nameIdentifier"> Hostname information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nameIdentifier"/> is null. </exception>
        /// <returns> A collection of <see cref="AppServiceIdentifierData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AppServiceIdentifierData> GetAllSiteIdentifierData(this SubscriptionResource subscriptionResource, AppServiceDomainNameIdentifier nameIdentifier, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nameIdentifier, nameof(nameIdentifier));

            return GetExtensionClient(subscriptionResource).GetAllSiteIdentifierData(nameIdentifier, cancellationToken);
        }

        /// <summary>
        /// Description for List all ResourceHealthMetadata for all sites in the resource group in the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceHealthMetadata_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceHealthMetadataData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResourceHealthMetadataData> GetAllResourceHealthMetadataDataAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroupResource).GetAllResourceHealthMetadataDataAsync(cancellationToken);
        }

        /// <summary>
        /// Description for List all ResourceHealthMetadata for all sites in the resource group in the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceHealthMetadata_ListByResourceGroup</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthMetadataData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResourceHealthMetadataData> GetAllResourceHealthMetadataData(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroupResource).GetAllResourceHealthMetadataData(cancellationToken);
        }
    }
}
