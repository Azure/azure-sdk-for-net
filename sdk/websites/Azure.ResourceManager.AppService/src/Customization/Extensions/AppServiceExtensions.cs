// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.AppService. </summary>
    public static partial class AppServiceExtensions
    {
        /// <summary>
        /// Description for List all apps that are assigned to a hostname.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName
        /// Operation Id: ListSiteIdentifiersAssignedToHostName
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/listSitesAssignedToHostName
        /// Operation Id: ListSiteIdentifiersAssignedToHostName
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata
        /// Operation Id: ResourceHealthMetadata_ListByResourceGroup
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/resourceHealthMetadata
        /// Operation Id: ResourceHealthMetadata_ListByResourceGroup
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthMetadataData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResourceHealthMetadataData> GetAllResourceHealthMetadataData(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroupResource).GetAllResourceHealthMetadataData(cancellationToken);
        }

        /// <summary>
        /// Description for Get a list of available geographical regions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/geoRegions
        /// Operation Id: ListGeoRegions
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="sku"> Name of SKU used to filter the regions. </param>
        /// <param name="linuxWorkersEnabled"> Specify &lt;code&gt;true&lt;/code&gt; if you want to filter to only regions that support Linux workers. </param>
        /// <param name="xenonWorkersEnabled"> Specify &lt;code&gt;true&lt;/code&gt; if you want to filter to only regions that support Xenon workers. </param>
        /// <param name="linuxDynamicWorkersEnabled"> Specify &lt;code&gt;true&lt;/code&gt; if you want to filter to only regions that support Linux Consumption Workers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppServiceGeoRegion" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AppServiceGeoRegion> GetGeoRegionsAsync(this SubscriptionResource subscriptionResource, AppServiceSkuName? sku = null, bool? linuxWorkersEnabled = null, bool? xenonWorkersEnabled = null, bool? linuxDynamicWorkersEnabled = null, CancellationToken cancellationToken = default) =>
            GetGeoRegionsAsync(subscriptionResource, new AppServiceExtensionsGetGeoRegionsOptions
            {
                Sku = sku,
                LinuxWorkersEnabled = linuxWorkersEnabled,
                XenonWorkersEnabled = xenonWorkersEnabled,
                LinuxDynamicWorkersEnabled = linuxDynamicWorkersEnabled
            }, cancellationToken);

        /// <summary>
        /// Description for Get a list of available geographical regions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/geoRegions
        /// Operation Id: ListGeoRegions
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="sku"> Name of SKU used to filter the regions. </param>
        /// <param name="linuxWorkersEnabled"> Specify &lt;code&gt;true&lt;/code&gt; if you want to filter to only regions that support Linux workers. </param>
        /// <param name="xenonWorkersEnabled"> Specify &lt;code&gt;true&lt;/code&gt; if you want to filter to only regions that support Xenon workers. </param>
        /// <param name="linuxDynamicWorkersEnabled"> Specify &lt;code&gt;true&lt;/code&gt; if you want to filter to only regions that support Linux Consumption Workers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppServiceGeoRegion" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<AppServiceGeoRegion> GetGeoRegions(this SubscriptionResource subscriptionResource, AppServiceSkuName? sku = null, bool? linuxWorkersEnabled = null, bool? xenonWorkersEnabled = null, bool? linuxDynamicWorkersEnabled = null, CancellationToken cancellationToken = default) =>
            GetGeoRegions(subscriptionResource, new AppServiceExtensionsGetGeoRegionsOptions
            {
                Sku = sku,
                LinuxWorkersEnabled = linuxWorkersEnabled,
                XenonWorkersEnabled = xenonWorkersEnabled,
                LinuxDynamicWorkersEnabled = linuxDynamicWorkersEnabled
            }, cancellationToken);
    }
}
