// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a distributed availability group.
    /// Kept for backward compatibility; use <see cref="SqlDistributedAvailabilityGroupResource"/> instead.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release. Use SqlDistributedAvailabilityGroupResource instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DistributedAvailabilityGroupResource : ArmResource
    {
        /// <summary> The resource type for this resource. </summary>
        public static readonly ResourceType ResourceType = SqlDistributedAvailabilityGroupResource.ResourceType;

        private readonly SqlDistributedAvailabilityGroupResource _inner;

        /// <summary> Initializes a new instance of the <see cref="DistributedAvailabilityGroupResource"/> class for mocking. </summary>
        protected DistributedAvailabilityGroupResource()
        {
        }

        internal DistributedAvailabilityGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _inner = client.GetSqlDistributedAvailabilityGroupResource(id);
        }

        internal DistributedAvailabilityGroupResource(ArmClient client, SqlDistributedAvailabilityGroupResource inner) : base(client, inner.Id)
        {
            _inner = inner;
        }

        /// <summary> Generates a resource identifier for a distributed availability group. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName)
        {
            return SqlDistributedAvailabilityGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, managedInstanceName, distributedAvailabilityGroupName);
        }

        /// <summary> Gets a value indicating whether data is present on this resource. </summary>
        public virtual bool HasData => _inner?.HasData ?? false;

        /// <summary> Gets the data of the distributed availability group. </summary>
        public virtual DistributedAvailabilityGroupData Data => null;

        /// <summary> Gets the distributed availability group. </summary>
        public virtual Response<DistributedAvailabilityGroupResource> Get(CancellationToken cancellationToken = default)
        {
            Response<SqlDistributedAvailabilityGroupResource> response = _inner.Get(cancellationToken);
            return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the distributed availability group. </summary>
        public virtual async Task<Response<DistributedAvailabilityGroupResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<SqlDistributedAvailabilityGroupResource> response = await _inner.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes the distributed availability group. </summary>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return _inner.Delete(waitUntil, cancellationToken);
        }

        /// <summary> Deletes the distributed availability group. </summary>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            return await _inner.DeleteAsync(waitUntil, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Updates a distributed availability group. </summary>
        public virtual ArmOperation<DistributedAvailabilityGroupResource> Update(WaitUntil waitUntil, DistributedAvailabilityGroupData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Update with DistributedAvailabilityGroupData is no longer supported. Use SqlDistributedAvailabilityGroupResource.Update instead.");
        }

        /// <summary> Updates a distributed availability group. </summary>
        public virtual Task<ArmOperation<DistributedAvailabilityGroupResource>> UpdateAsync(WaitUntil waitUntil, DistributedAvailabilityGroupData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("UpdateAsync with DistributedAvailabilityGroupData is no longer supported. Use SqlDistributedAvailabilityGroupResource.UpdateAsync instead.");
        }
    }
}
