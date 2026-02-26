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
    public partial class SphereCertificateCollection
    {
        /// <summary> List Certificate resources by Catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereCertificateResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SphereCertificateResource> GetAllAsync(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SphereCertificateData, SphereCertificateResource>(new CertificatesGetByCatalogAsyncCollectionResultOfT(
                _certificatesRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereCertificateResource(Client, data));
        }

        /// <summary> List Certificate resources by Catalog. </summary>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="top"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SphereCertificateResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SphereCertificateResource> GetAll(string filter = default, int? top = default, int? skip = default, int? maxpagesize = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SphereCertificateData, SphereCertificateResource>(new CertificatesGetByCatalogCollectionResultOfT(
                _certificatesRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                filter,
                top,
                skip,
                maxpagesize,
                context), data => new SphereCertificateResource(Client, data));
        }
    }
}
