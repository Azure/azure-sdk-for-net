// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Compute. </summary>
    public static partial class ComputeExtensions
    {
        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions
        /// Operation Id: VirtualMachineImages_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is null. </exception>
        /// <returns> An async collection of <see cref="VirtualMachineImageBase" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetVirtualMachineImagesAsync(subscriptionResource, new ComputeExtensionsGetVirtualMachineImagesOptions(location, publisherName, offer, skus)
            {
                Expand = expand,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions
        /// Operation Id: VirtualMachineImages_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is null. </exception>
        /// <returns> A collection of <see cref="VirtualMachineImageBase" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineImageBase> GetVirtualMachineImages(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetVirtualMachineImages(subscriptionResource, new ComputeExtensionsGetVirtualMachineImagesOptions(location, publisherName, offer, skus)
            {
                Expand = expand,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, edge zone, publisher, offer, and SKU.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions
        /// Operation Id: VirtualMachineImagesEdgeZone_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="edgeZone"> The name of the edge zone. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="top"> An integer value specifying the number of images to return that matches supplied values. </param>
        /// <param name="orderby"> Specifies the order of the results returned. Formatted as an OData query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is null. </exception>
        /// <returns> An async collection of <see cref="VirtualMachineImageBase" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetVirtualMachineImagesEdgeZonesAsync(subscriptionResource, new ComputeExtensionsGetVirtualMachineImagesEdgeZonesOptions(location, edgeZone, publisherName, offer, skus)
            {
                Expand = expand,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, edge zone, publisher, offer, and SKU.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions
        /// Operation Id: VirtualMachineImagesEdgeZone_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="edgeZone"> The name of the edge zone. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="top"> An integer value specifying the number of images to return that matches supplied values. </param>
        /// <param name="orderby"> Specifies the order of the results returned. Formatted as an OData query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is null. </exception>
        /// <returns> A collection of <see cref="VirtualMachineImageBase" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetVirtualMachineImagesEdgeZones(subscriptionResource, new ComputeExtensionsGetVirtualMachineImagesEdgeZonesOptions(location, edgeZone, publisherName, offer, skus)
            {
                Expand = expand,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// Gets a virtual machine image in an edge zone.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}
        /// Operation Id: VirtualMachineImagesEdgeZone_Get
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="edgeZone"> The name of the edge zone. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is null. </exception>
        public static async Task<Response<VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default) =>
            await GetVirtualMachineImagesEdgeZoneAsync(subscriptionResource, new ComputeExtensionsGetVirtualMachineImagesEdgeZoneOptions(location, edgeZone, publisherName, offer, skus, version), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets a virtual machine image in an edge zone.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}
        /// Operation Id: VirtualMachineImagesEdgeZone_Get
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="edgeZone"> The name of the edge zone. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="version"> A valid image SKU version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="edgeZone"/>, <paramref name="publisherName"/>, <paramref name="offer"/>, <paramref name="skus"/> or <paramref name="version"/> is null. </exception>
        public static Response<VirtualMachineImage> GetVirtualMachineImagesEdgeZone(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default) =>
            GetVirtualMachineImagesEdgeZone(subscriptionResource, new ComputeExtensionsGetVirtualMachineImagesEdgeZoneOptions(location, edgeZone, publisherName, offer, skus, version), cancellationToken);
    }
}
