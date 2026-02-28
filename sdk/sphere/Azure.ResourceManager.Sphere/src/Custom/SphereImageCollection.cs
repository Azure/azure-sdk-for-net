// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TODO: This custom code class should be removed after https://github.com/Azure/azure-sdk-for-net/issues/56502 is resolved.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sphere
{
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(string), typeof(int?), typeof(int?), typeof(int?), typeof(CancellationToken))]
    public partial class SphereImageCollection
    {
        /// <summary> List Image resources by Catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SphereImageResource> GetAllAsync(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SphereImageData, SphereImageResource>(new ImagesGetByCatalogAsyncCollectionResultOfT(
                _imagesRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereImageResource(Client, data));
        }

        /// <summary> List Image resources by Catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SphereImageResource> GetAll(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SphereImageData, SphereImageResource>(new ImagesGetByCatalogCollectionResultOfT(
                _imagesRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereImageResource(Client, data));
        }
    }
}
