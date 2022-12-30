// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Media.Models;

namespace Azure.ResourceManager.Media
{
    /// <summary>
    /// A class representing a collection of <see cref="MediaAssetResource" /> and their operations.
    /// Each <see cref="MediaAssetResource" /> in the collection will belong to the same instance of <see cref="MediaServicesAccountResource" />.
    /// To get a <see cref="MediaAssetCollection" /> instance call the GetMediaAssets method from an instance of <see cref="MediaServicesAccountResource" />.
    /// </summary>
    public partial class MediaAssetCollection : ArmCollection, IEnumerable<MediaAssetResource>, IAsyncEnumerable<MediaAssetResource>
    {
        /// <summary>
        /// List Assets in the Media Services account with optional filtering and ordering
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets
        /// Operation Id: Assets_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MediaAssetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MediaAssetResource> GetAllAsync(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new MediaAssetCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List Assets in the Media Services account with optional filtering and ordering
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets
        /// Operation Id: Assets_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MediaAssetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MediaAssetResource> GetAll(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new MediaAssetCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
