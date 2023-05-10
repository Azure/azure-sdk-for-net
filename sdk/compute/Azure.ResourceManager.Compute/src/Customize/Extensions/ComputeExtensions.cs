﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute
{
    public static partial class ComputeExtensions
    {
        /// <summary> Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<VirtualMachineResource> GetVirtualMachinesAsync(this SubscriptionResource subscriptionResource, string statusOnly, string filter, CancellationToken cancellationToken)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachinesAsync(statusOnly, filter, null, cancellationToken);
        }

        /// <summary> Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<VirtualMachineResource> GetVirtualMachines(this SubscriptionResource subscriptionResource, string statusOnly, string filter, CancellationToken cancellationToken)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachines(statusOnly, filter, null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_List</description>
        /// </item>
        /// </list>
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
        public static AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));

            SubscriptionResourceGetVirtualMachineImagesOptions options = new SubscriptionResourceGetVirtualMachineImagesOptions(location, publisherName, offer, skus);
            options.Expand = expand;
            options.Top = top;
            options.Orderby = orderby;

            return subscriptionResource.GetVirtualMachineImagesAsync(options, cancellationToken);
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImages_List</description>
        /// </item>
        /// </list>
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
        public static Pageable<VirtualMachineImageBase> GetVirtualMachineImages(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));

            SubscriptionResourceGetVirtualMachineImagesOptions options = new SubscriptionResourceGetVirtualMachineImagesOptions(location, publisherName, offer, skus);
            options.Expand = expand;
            options.Top = top;
            options.Orderby = orderby;

            return subscriptionResource.GetVirtualMachineImages(options, cancellationToken);
        }

        /// <summary>
        /// Gets a virtual machine image in an edge zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImagesEdgeZone_Get</description>
        /// </item>
        /// </list>
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
        public static async Task<Response<VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(edgeZone, nameof(edgeZone));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options = new SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions(location, edgeZone, publisherName, offer, skus, version);

            return await subscriptionResource.GetVirtualMachineImagesEdgeZoneAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a virtual machine image in an edge zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImagesEdgeZone_Get</description>
        /// </item>
        /// </list>
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
        public static Response<VirtualMachineImage> GetVirtualMachineImagesEdgeZone(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(edgeZone, nameof(edgeZone));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options = new SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions(location, edgeZone, publisherName, offer, skus, version);

            return subscriptionResource.GetVirtualMachineImagesEdgeZone(options, cancellationToken);
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, edge zone, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImagesEdgeZone_List</description>
        /// </item>
        /// </list>
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
        public static AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(edgeZone, nameof(edgeZone));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));

            SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options = new SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions(location, edgeZone, publisherName, offer, skus);
            options.Expand = expand;
            options.Top = top;
            options.Orderby = orderby;

            return subscriptionResource.GetVirtualMachineImagesEdgeZonesAsync(options, cancellationToken);
        }

        /// <summary>
        /// Gets a list of all virtual machine image versions for the specified location, edge zone, publisher, offer, and SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/edgeZones/{edgeZone}/publishers/{publisherName}/artifacttypes/vmimage/offers/{offer}/skus/{skus}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineImagesEdgeZone_List</description>
        /// </item>
        /// </list>
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
        public static Pageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(this SubscriptionResource subscriptionResource, AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(edgeZone, nameof(edgeZone));
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));
            Argument.AssertNotNullOrEmpty(offer, nameof(offer));
            Argument.AssertNotNullOrEmpty(skus, nameof(skus));

            SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options = new SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions(location, edgeZone, publisherName, offer, skus);
            options.Expand = expand;
            options.Top = top;
            options.Orderby = orderby;

            return subscriptionResource.GetVirtualMachineImagesEdgeZones(options, cancellationToken);
        }
    }
}
