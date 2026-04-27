// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    public static partial class ComputeExtensions
    {
        // Backward-compat extension overloads accepting the legacy "*Options" bag types.
        // The new TypeSpec generator no longer emits option-bag overloads (it produces
        // a single multi-parameter method instead); these forwarding overloads keep the
        // old surface working by delegating to the multi-parameter generated extensions.

        /// <summary> Gets a list of virtual machine images. </summary>
        public static Pageable<VirtualMachineImageBase> GetVirtualMachineImages(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return subscriptionResource.GetVirtualMachineImages(options.Location, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images. </summary>
        public static AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return subscriptionResource.GetVirtualMachineImagesAsync(options.Location, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a virtual machine image in an edge zone. </summary>
        public static Response<VirtualMachineImage> GetVirtualMachineImagesEdgeZone(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return subscriptionResource.GetVirtualMachineImagesEdgeZone(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Version, cancellationToken);
        }

        /// <summary> Gets a virtual machine image in an edge zone. </summary>
        public static async Task<Response<VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await subscriptionResource.GetVirtualMachineImagesEdgeZoneAsync(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Version, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a list of virtual machine images in an edge zone. </summary>
        public static Pageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return subscriptionResource.GetVirtualMachineImagesEdgeZones(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images in an edge zone. </summary>
        public static AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return subscriptionResource.GetVirtualMachineImagesEdgeZonesAsync(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images with their detailed properties. </summary>
        public static Pageable<VirtualMachineImage> GetVirtualMachineImagesWithProperties(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return subscriptionResource.GetVirtualMachineImagesWithProperties(options.Location, options.PublisherName, options.Offer, options.Skus, options.GetExpandValue(), options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images with their detailed properties. </summary>
        public static AsyncPageable<VirtualMachineImage> GetVirtualMachineImagesWithPropertiesAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return subscriptionResource.GetVirtualMachineImagesWithPropertiesAsync(options.Location, options.PublisherName, options.Offer, options.Skus, options.GetExpandValue(), options.Top, options.Orderby, cancellationToken);
        }
    }
}
