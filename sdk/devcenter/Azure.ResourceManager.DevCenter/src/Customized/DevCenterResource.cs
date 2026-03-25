// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// After generator PR #57161, GetImages returns Pageable<DevCenterImageData> because
// ImageOperationGroupResource now also shares DevCenterImageData. The ApiCompat baseline
// (v1.0.2) expects Pageable<DevCenterImageResource>, so we restore the old generated
// methods using PageableWrapper/AsyncPageableWrapper (also from the old generated code).

using System;
using System.Threading;

namespace Azure.ResourceManager.DevCenter
{
    public partial class DevCenterResource
    {
        /// <summary> Lists images for a devcenter. </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevCenterImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevCenterImageResource> GetImagesAsync(int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<DevCenterImageData, DevCenterImageResource>(new ImagesGetImagesAsyncCollectionResultOfT(
                _imagesRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                top,
                context), data => new DevCenterImageResource(Client, data));
        }

        /// <summary> Lists images for a devcenter. </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevCenterImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevCenterImageResource> GetImages(int? top = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<DevCenterImageData, DevCenterImageResource>(new ImagesGetImagesCollectionResultOfT(
                _imagesRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                top,
                context), data => new DevCenterImageResource(Client, data));
        }
    }
}
