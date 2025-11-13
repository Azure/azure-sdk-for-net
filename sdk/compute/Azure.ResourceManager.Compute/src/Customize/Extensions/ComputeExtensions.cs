// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Compute.Mocking;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    public static partial class ComputeExtensions
    {
        /// <summary> Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<VirtualMachineResource> GetVirtualMachinesAsync(this SubscriptionResource subscriptionResource, string statusOnly, string filter, CancellationToken cancellationToken)
        {
            return GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachinesAsync(statusOnly, filter, cancellationToken);
        }

        /// <summary> Lists all of the virtual machines in the specified subscription. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<VirtualMachineResource> GetVirtualMachines(this SubscriptionResource subscriptionResource, string statusOnly, string filter, CancellationToken cancellationToken)
        {
            return GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachines(statusOnly, filter, cancellationToken);
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
            return GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachineImagesAsync(location, publisherName, offer, skus, expand, top, orderby, cancellationToken);
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
            return GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachineImages(location, publisherName, offer, skus, expand, top, orderby, cancellationToken);
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
            return await GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachineImagesEdgeZoneAsync(location, edgeZone, publisherName, offer, skus, version, cancellationToken).ConfigureAwait(false);
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
            return GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachineImagesEdgeZone(location, edgeZone, publisherName, offer, skus, version, cancellationToken);
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
            return GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachineImagesEdgeZonesAsync(location, edgeZone, publisherName, offer, skus, expand, top, orderby, cancellationToken);
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
            return GetMockableComputeSubscriptionResource(subscriptionResource).GetVirtualMachineImagesEdgeZones(location, edgeZone, publisherName, offer, skus, expand, top, orderby, cancellationToken);
        }

        /// <summary>
        /// Lists all of the capacity reservation groups in the subscription. Use the nextLink property in the response to get the next page of capacity reservation groups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/capacityReservationGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapacityReservationGroups_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CapacityReservationGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply on the operation. Based on the expand param(s) specified we return Virtual Machine or ScaleSet VM Instance or both resource Ids which are associated to capacity reservation group in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="CapacityReservationGroupResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<CapacityReservationGroupResource> GetCapacityReservationGroupsAsync(this SubscriptionResource subscriptionResource, CapacityReservationGroupGetExpand? expand, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeSubscriptionResource(subscriptionResource).GetCapacityReservationGroupsAsync(expand, cancellationToken); // this is important for mocking, we need to call the method with exactly same signature, otherwise we break the existing mocking code.
        }

        /// <summary>
        /// Lists all of the capacity reservation groups in the subscription. Use the nextLink property in the response to get the next page of capacity reservation groups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/capacityReservationGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CapacityReservationGroups_ListBySubscription</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CapacityReservationGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="expand"> The expand expression to apply on the operation. Based on the expand param(s) specified we return Virtual Machine or ScaleSet VM Instance or both resource Ids which are associated to capacity reservation group in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="CapacityReservationGroupResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<CapacityReservationGroupResource> GetCapacityReservationGroups(this SubscriptionResource subscriptionResource, CapacityReservationGroupGetExpand? expand, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeSubscriptionResource(subscriptionResource).GetCapacityReservationGroups(expand, cancellationToken);
        }

        // these methods were added back here because they are previously generated as a resource, but now they are no longer resources
        /// <summary>
        /// Gets an object representing a <see cref="CommunityGalleryResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CommunityGalleryResource.CreateResourceIdentifier" /> to create a <see cref="CommunityGalleryResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeArmClient.GetCommunityGalleryResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CommunityGalleryResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryResource GetCommunityGalleryResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableComputeArmClient(client).GetCommunityGalleryResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CommunityGalleryImageResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CommunityGalleryImageResource.CreateResourceIdentifier" /> to create a <see cref="CommunityGalleryImageResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeArmClient.GetCommunityGalleryImageResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CommunityGalleryImageResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageResource GetCommunityGalleryImageResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableComputeArmClient(client).GetCommunityGalleryImageResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="CommunityGalleryImageVersionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CommunityGalleryImageVersionResource.CreateResourceIdentifier" /> to create a <see cref="CommunityGalleryImageVersionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeArmClient.GetCommunityGalleryImageVersionResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="CommunityGalleryImageVersionResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryImageVersionResource GetCommunityGalleryImageVersionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableComputeArmClient(client).GetCommunityGalleryImageVersionResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SharedGalleryResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SharedGalleryResource.CreateResourceIdentifier" /> to create a <see cref="SharedGalleryResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeArmClient.GetSharedGalleryResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="SharedGalleryResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryResource GetSharedGalleryResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableComputeArmClient(client).GetSharedGalleryResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SharedGalleryImageResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SharedGalleryImageResource.CreateResourceIdentifier" /> to create a <see cref="SharedGalleryImageResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeArmClient.GetSharedGalleryImageResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="SharedGalleryImageResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageResource GetSharedGalleryImageResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableComputeArmClient(client).GetSharedGalleryImageResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SharedGalleryImageVersionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SharedGalleryImageVersionResource.CreateResourceIdentifier" /> to create a <see cref="SharedGalleryImageVersionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeArmClient.GetSharedGalleryImageVersionResource(ResourceIdentifier)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="SharedGalleryImageVersionResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryImageVersionResource GetSharedGalleryImageVersionResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableComputeArmClient(client).GetSharedGalleryImageVersionResource(id);
        }

        /// <summary>
        /// Gets a collection of CommunityGalleryResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSubscriptionResource.GetCommunityGalleries()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An object representing collection of CommunityGalleryResources and their operations over a CommunityGalleryResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommunityGalleryCollection GetCommunityGalleries(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeSubscriptionResource(subscriptionResource).GetCommunityGalleries();
        }

        /// <summary>
        /// Get a community gallery by gallery public name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSubscriptionResource.GetCommunityGalleryAsync(AzureLocation,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <param name="publicGalleryName"> The public name of the community gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="publicGalleryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publicGalleryName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<CommunityGalleryResource>> GetCommunityGalleryAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publicGalleryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeSubscriptionResource(subscriptionResource).GetCommunityGalleryAsync(location, publicGalleryName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a community gallery by gallery public name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSubscriptionResource.GetCommunityGallery(AzureLocation,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <param name="publicGalleryName"> The public name of the community gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="publicGalleryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publicGalleryName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<CommunityGalleryResource> GetCommunityGallery(this SubscriptionResource subscriptionResource, AzureLocation location, string publicGalleryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeSubscriptionResource(subscriptionResource).GetCommunityGallery(location, publicGalleryName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of SharedGalleryResources in the SubscriptionResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSubscriptionResource.GetSharedGalleries(AzureLocation)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An object representing collection of SharedGalleryResources and their operations over a SharedGalleryResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SharedGalleryCollection GetSharedGalleries(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeSubscriptionResource(subscriptionResource).GetSharedGalleries(location);
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SharedGalleryResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSubscriptionResource.GetSharedGalleryAsync(AzureLocation,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="galleryUniqueName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<SharedGalleryResource>> GetSharedGalleryAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableComputeSubscriptionResource(subscriptionResource).GetSharedGalleryAsync(location, galleryUniqueName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a shared gallery by subscription id or tenant id.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SharedGalleries_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SharedGalleryResource"/></description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSubscriptionResource.GetSharedGallery(AzureLocation,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of Azure region. </param>
        /// <param name="galleryUniqueName"> The unique name of the Shared Gallery. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> or <paramref name="galleryUniqueName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="galleryUniqueName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<SharedGalleryResource> GetSharedGallery(this SubscriptionResource subscriptionResource, AzureLocation location, string galleryUniqueName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableComputeSubscriptionResource(subscriptionResource).GetSharedGallery(location, galleryUniqueName, cancellationToken);
        }
    }
}
