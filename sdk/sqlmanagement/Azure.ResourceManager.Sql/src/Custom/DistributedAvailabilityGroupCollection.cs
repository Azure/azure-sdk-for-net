// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="DistributedAvailabilityGroupResource"/>.
    /// Kept for backward compatibility; use <see cref="SqlDistributedAvailabilityGroupCollection"/> instead.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release. Use SqlDistributedAvailabilityGroupCollection instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DistributedAvailabilityGroupCollection : ArmCollection, IEnumerable<DistributedAvailabilityGroupResource>, IAsyncEnumerable<DistributedAvailabilityGroupResource>
    {
        private readonly SqlDistributedAvailabilityGroupCollection _inner;

        /// <summary> Initializes a new instance of the <see cref="DistributedAvailabilityGroupCollection"/> class for mocking. </summary>
        protected DistributedAvailabilityGroupCollection()
        {
        }

        internal DistributedAvailabilityGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _inner = new SqlDistributedAvailabilityGroupCollection(client, id);
        }

        /// <summary> Creates or updates a distributed availability group. </summary>
        public virtual ArmOperation<DistributedAvailabilityGroupResource> CreateOrUpdate(WaitUntil waitUntil, string distributedAvailabilityGroupName, DistributedAvailabilityGroupData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("CreateOrUpdate with DistributedAvailabilityGroupData is no longer supported. Use SqlDistributedAvailabilityGroupCollection.CreateOrUpdate instead.");
        }

        /// <summary> Creates or updates a distributed availability group. </summary>
        public virtual Task<ArmOperation<DistributedAvailabilityGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string distributedAvailabilityGroupName, DistributedAvailabilityGroupData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("CreateOrUpdateAsync with DistributedAvailabilityGroupData is no longer supported. Use SqlDistributedAvailabilityGroupCollection.CreateOrUpdateAsync instead.");
        }

        /// <summary> Gets a distributed availability group. </summary>
        public virtual Response<DistributedAvailabilityGroupResource> Get(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Response<SqlDistributedAvailabilityGroupResource> response = _inner.Get(distributedAvailabilityGroupName, cancellationToken);
            return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets a distributed availability group. </summary>
        public virtual async Task<Response<DistributedAvailabilityGroupResource>> GetAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Response<SqlDistributedAvailabilityGroupResource> response = await _inner.GetAsync(distributedAvailabilityGroupName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
        }

        /// <summary> Lists distributed availability groups. </summary>
        public virtual Pageable<DistributedAvailabilityGroupResource> GetAll(CancellationToken cancellationToken = default)
        {
            return PageableHelpers.Wrap<SqlDistributedAvailabilityGroupResource, DistributedAvailabilityGroupResource>(
                _inner.GetAll(cancellationToken),
                inner => new DistributedAvailabilityGroupResource(Client, inner));
        }

        /// <summary> Lists distributed availability groups. </summary>
        public virtual AsyncPageable<DistributedAvailabilityGroupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return PageableHelpers.WrapAsync<SqlDistributedAvailabilityGroupResource, DistributedAvailabilityGroupResource>(
                _inner.GetAllAsync(cancellationToken),
                inner => new DistributedAvailabilityGroupResource(Client, inner));
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            return _inner.Exists(distributedAvailabilityGroupName, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual async Task<Response<bool>> ExistsAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            return await _inner.ExistsAsync(distributedAvailabilityGroupName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<DistributedAvailabilityGroupResource> GetIfExists(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            NullableResponse<SqlDistributedAvailabilityGroupResource> response = _inner.GetIfExists(distributedAvailabilityGroupName, cancellationToken);
            if (!response.HasValue)
                return new NoValueResponse<DistributedAvailabilityGroupResource>(response.GetRawResponse());
            return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual async Task<NullableResponse<DistributedAvailabilityGroupResource>> GetIfExistsAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            NullableResponse<SqlDistributedAvailabilityGroupResource> response = await _inner.GetIfExistsAsync(distributedAvailabilityGroupName, cancellationToken).ConfigureAwait(false);
            if (!response.HasValue)
                return new NoValueResponse<DistributedAvailabilityGroupResource>(response.GetRawResponse());
            return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
        }

        IEnumerator<DistributedAvailabilityGroupResource> IEnumerable<DistributedAvailabilityGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DistributedAvailabilityGroupResource> IAsyncEnumerable<DistributedAvailabilityGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
