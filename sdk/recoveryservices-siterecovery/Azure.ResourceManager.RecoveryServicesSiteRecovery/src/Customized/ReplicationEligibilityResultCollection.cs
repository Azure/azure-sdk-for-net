// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    /// <summary>
    /// A class representing a collection of <see cref="ReplicationEligibilityResultResource"/> and their operations.
    /// Each <see cref="ReplicationEligibilityResultResource"/> in the collection will belong to the same instance of <see cref="Azure.ResourceManager.Resources.ResourceGroupResource"/>.
    /// To get a <see cref="ReplicationEligibilityResultCollection"/> instance call the GetReplicationEligibilityResults method from an instance of <see cref="Azure.ResourceManager.Resources.ResourceGroupResource"/>.
    /// </summary>
    [Obsolete("This collection-shaped accessor is preserved only for backward compatibility. Use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) for the singleton resource directly.", false)]
    public partial class ReplicationEligibilityResultCollection : ArmCollection, IEnumerable<ReplicationEligibilityResultResource>, IAsyncEnumerable<ReplicationEligibilityResultResource>
    {
        private readonly string _virtualMachineName;

        /// <summary> Initializes a new instance of the <see cref="ReplicationEligibilityResultCollection"/> class for mocking. </summary>
        protected ReplicationEligibilityResultCollection()
        {
        }

        internal ReplicationEligibilityResultCollection(ArmClient client, ResourceIdentifier id, string virtualMachineName)
            : base(client, id)
        {
            _virtualMachineName = virtualMachineName;
        }

        private ReplicationEligibilityResultResource GetSingletonResource()
        {
            ResourceIdentifier scopeId = ReplicationEligibilityResultResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, _virtualMachineName);
            return new ReplicationEligibilityResultResource(Client, scopeId);
        }

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        public virtual Response<ReplicationEligibilityResultResource> Get(CancellationToken cancellationToken = default)
            => GetSingletonResource().Get(cancellationToken);

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        public virtual Task<Response<ReplicationEligibilityResultResource>> GetAsync(CancellationToken cancellationToken = default)
            => GetSingletonResource().GetAsync(cancellationToken);

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        public virtual Pageable<ReplicationEligibilityResultResource> GetAll(CancellationToken cancellationToken = default)
        {
            Response<ReplicationEligibilityResultResource> response = Get(cancellationToken);
            Page<ReplicationEligibilityResultResource> page = Page<ReplicationEligibilityResultResource>.FromValues(new[] { response.Value }, null, response.GetRawResponse());
            return Pageable<ReplicationEligibilityResultResource>.FromPages(new[] { page });
        }

        /// <summary> Validates whether a given VM can be protected or not in which case returns list of errors. </summary>
        public virtual AsyncPageable<ReplicationEligibilityResultResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return new SinglePageAsyncPageable(this, cancellationToken);
        }

        private sealed class SinglePageAsyncPageable : AsyncPageable<ReplicationEligibilityResultResource>
        {
            private readonly ReplicationEligibilityResultCollection _collection;

            public SinglePageAsyncPageable(ReplicationEligibilityResultCollection collection, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _collection = collection;
            }

            public override async System.Collections.Generic.IAsyncEnumerable<Page<ReplicationEligibilityResultResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<ReplicationEligibilityResultResource> response = await _collection.GetAsync(CancellationToken).ConfigureAwait(false);
                yield return Page<ReplicationEligibilityResultResource>.FromValues(new[] { response.Value }, null, response.GetRawResponse());
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(CancellationToken cancellationToken = default)
        {
            try
            {
                Response<ReplicationEligibilityResultResource> response = Get(cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return Response.FromValue(false, e.GetRawResponse());
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual async Task<Response<bool>> ExistsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                Response<ReplicationEligibilityResultResource> response = await GetAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return Response.FromValue(false, e.GetRawResponse());
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<ReplicationEligibilityResultResource> GetIfExists(CancellationToken cancellationToken = default)
        {
            try
            {
                Response<ReplicationEligibilityResultResource> response = Get(cancellationToken);
                return response.Value == null
                    ? new NoValueResponse<ReplicationEligibilityResultResource>(response.GetRawResponse())
                    : Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return new NoValueResponse<ReplicationEligibilityResultResource>(e.GetRawResponse());
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual async Task<NullableResponse<ReplicationEligibilityResultResource>> GetIfExistsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                Response<ReplicationEligibilityResultResource> response = await GetAsync(cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? new NoValueResponse<ReplicationEligibilityResultResource>(response.GetRawResponse())
                    : Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                return new NoValueResponse<ReplicationEligibilityResultResource>(e.GetRawResponse());
            }
        }

        IEnumerator<ReplicationEligibilityResultResource> IEnumerable<ReplicationEligibilityResultResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        IAsyncEnumerator<ReplicationEligibilityResultResource> IAsyncEnumerable<ReplicationEligibilityResultResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
