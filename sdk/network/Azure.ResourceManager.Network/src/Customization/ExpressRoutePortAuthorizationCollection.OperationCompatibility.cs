// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    public partial class ExpressRoutePortAuthorizationCollection : IEnumerable<ExpressRoutePortAuthorizationResource>, IAsyncEnumerable<ExpressRoutePortAuthorizationResource>
    {
        public virtual Task<ArmOperation<ExpressRoutePortAuthorizationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, Id.Name, authorizationName, data, cancellationToken);

        public virtual ArmOperation<ExpressRoutePortAuthorizationResource> CreateOrUpdate(WaitUntil waitUntil, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, Id.Name, authorizationName, data, cancellationToken);

        public virtual Task<Response<ExpressRoutePortAuthorizationResource>> GetAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetAsync(Id.Name, authorizationName, cancellationToken);

        public virtual Response<ExpressRoutePortAuthorizationResource> Get(string authorizationName, CancellationToken cancellationToken = default)
            => Get(Id.Name, authorizationName, cancellationToken);

        public virtual AsyncPageable<ExpressRoutePortAuthorizationResource> GetAllAsync(CancellationToken cancellationToken = default)
            => GetAllAsync(Id.Name, cancellationToken);

        public virtual Pageable<ExpressRoutePortAuthorizationResource> GetAll(CancellationToken cancellationToken = default)
            => GetAll(Id.Name, cancellationToken);

        public virtual Task<Response<bool>> ExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
            => ExistsAsync(Id.Name, authorizationName, cancellationToken);

        public virtual Response<bool> Exists(string authorizationName, CancellationToken cancellationToken = default)
            => Exists(Id.Name, authorizationName, cancellationToken);

        public virtual Task<NullableResponse<ExpressRoutePortAuthorizationResource>> GetIfExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(Id.Name, authorizationName, cancellationToken);

        public virtual NullableResponse<ExpressRoutePortAuthorizationResource> GetIfExists(string authorizationName, CancellationToken cancellationToken = default)
            => GetIfExists(Id.Name, authorizationName, cancellationToken);

        IEnumerator<ExpressRoutePortAuthorizationResource> IEnumerable<ExpressRoutePortAuthorizationResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        IAsyncEnumerator<ExpressRoutePortAuthorizationResource> IAsyncEnumerable<ExpressRoutePortAuthorizationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
