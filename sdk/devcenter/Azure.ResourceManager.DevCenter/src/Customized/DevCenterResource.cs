// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.ResourceManager.DevCenter
{
    // Backward compatibility: restore GetImages/GetImagesAsync returning Pageable<DevCenterImageResource>
    // to match the baseline SDK.
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
                context,
                "DevCenterResource.GetImages"), data => new DevCenterImageResource(Client, data));
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
                context,
                "DevCenterResource.GetImages"), data => new DevCenterImageResource(Client, data));
        }
    }
}
