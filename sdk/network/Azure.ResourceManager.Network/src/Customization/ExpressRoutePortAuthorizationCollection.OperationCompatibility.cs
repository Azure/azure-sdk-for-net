// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRoutePortAuthorizationCollection type. </summary>
    public partial class ExpressRoutePortAuthorizationCollection : IEnumerable<ExpressRoutePortAuthorizationResource>, IAsyncEnumerable<ExpressRoutePortAuthorizationResource>
    {
        /// <summary> Invokes the CreateOrUpdateAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<ExpressRoutePortAuthorizationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, Id.Name, authorizationName, data, cancellationToken);

        /// <summary> Invokes the CreateOrUpdate compatibility operation. </summary>
        public virtual ArmOperation<ExpressRoutePortAuthorizationResource> CreateOrUpdate(WaitUntil waitUntil, string authorizationName, ExpressRoutePortAuthorizationData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, Id.Name, authorizationName, data, cancellationToken);

        /// <summary> Invokes the GetAsync compatibility operation. </summary>
        public virtual Task<Response<ExpressRoutePortAuthorizationResource>> GetAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetAsync(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the Get compatibility operation. </summary>
        public virtual Response<ExpressRoutePortAuthorizationResource> Get(string authorizationName, CancellationToken cancellationToken = default)
            => Get(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the GetAllAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRoutePortAuthorizationResource> GetAllAsync(CancellationToken cancellationToken = default)
            => GetAllAsync(Id.Name, cancellationToken);

        /// <summary> Invokes the GetAll compatibility operation. </summary>
        public virtual Pageable<ExpressRoutePortAuthorizationResource> GetAll(CancellationToken cancellationToken = default)
            => GetAll(Id.Name, cancellationToken);

        /// <summary> Invokes the ExistsAsync compatibility operation. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
            => ExistsAsync(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the Exists compatibility operation. </summary>
        public virtual Response<bool> Exists(string authorizationName, CancellationToken cancellationToken = default)
            => Exists(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the GetIfExistsAsync compatibility operation. </summary>
        public virtual Task<NullableResponse<ExpressRoutePortAuthorizationResource>> GetIfExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(Id.Name, authorizationName, cancellationToken);

        /// <summary> Invokes the GetIfExists compatibility operation. </summary>
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
