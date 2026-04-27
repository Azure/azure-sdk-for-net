// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute.Mocking
{
    // Backward-compat overloads that accept the legacy "*Options" bag types.
    // The new TypeSpec generator no longer emits option-bag overloads (it produces
    // a single multi-parameter method instead), but the previous public surface
    // exposed bag-accepting versions of these methods. These overloads forward to
    // the multi-parameter generated implementation to preserve source compatibility.
    public partial class MockableComputeSubscriptionResource
    {
        /// <summary> Gets a list of virtual machine images. </summary>
        public virtual Pageable<VirtualMachineImageBase> GetVirtualMachineImages(SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetVirtualMachineImages(options.Location, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images. </summary>
        public virtual AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesAsync(SubscriptionResourceGetVirtualMachineImagesOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetVirtualMachineImagesAsync(options.Location, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a virtual machine image in an edge zone. </summary>
        public virtual Response<VirtualMachineImage> GetVirtualMachineImagesEdgeZone(SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetVirtualMachineImagesEdgeZone(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Version, cancellationToken);
        }

        /// <summary> Gets a virtual machine image in an edge zone. </summary>
        public virtual async Task<Response<VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return await GetVirtualMachineImagesEdgeZoneAsync(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Version, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a list of virtual machine images in an edge zone. </summary>
        public virtual Pageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetVirtualMachineImagesEdgeZones(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images in an edge zone. </summary>
        public virtual AsyncPageable<VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetVirtualMachineImagesEdgeZonesAsync(options.Location, options.EdgeZone, options.PublisherName, options.Offer, options.Skus, options.Expand, options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images with their detailed properties. </summary>
        public virtual Pageable<VirtualMachineImage> GetVirtualMachineImagesWithProperties(SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetVirtualMachineImagesWithProperties(options.Location, options.PublisherName, options.Offer, options.Skus, options.GetExpandValue(), options.Top, options.Orderby, cancellationToken);
        }

        /// <summary> Gets a list of virtual machine images with their detailed properties. </summary>
        public virtual AsyncPageable<VirtualMachineImage> GetVirtualMachineImagesWithPropertiesAsync(SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions options, CancellationToken cancellationToken = default)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return GetVirtualMachineImagesWithPropertiesAsync(options.Location, options.PublisherName, options.Offer, options.Skus, options.GetExpandValue(), options.Top, options.Orderby, cancellationToken);
        }
    }
}
