// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The previous GA SDK exposed this subscription-scoped governance rule collection. Current
    // TypeSpec generates the scope-based GovernanceRule collection instead, so this hidden obsolete
    // shim is retained only for ApiCompat.
    [Obsolete("This class is obsolete and will be removed in a future release. Please use GovernanceRuleCollection.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SubscriptionGovernanceRuleCollection : ArmCollection, IAsyncEnumerable<SubscriptionGovernanceRuleResource>, IEnumerable<SubscriptionGovernanceRuleResource>, IEnumerable
    {
        private readonly SecurityConnectorGovernanceRuleCollection _innerCollection;

        protected SubscriptionGovernanceRuleCollection() { }
        internal SubscriptionGovernanceRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _innerCollection = new SecurityConnectorGovernanceRuleCollection(client, id);
        }

        public virtual ArmOperation<SubscriptionGovernanceRuleResource> CreateOrUpdate(WaitUntil waitUntil, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<SubscriptionGovernanceRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<bool> Exists(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<bool>> ExistsAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<SubscriptionGovernanceRuleResource> Get(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [ForwardsClientCalls]
        public virtual Pageable<SubscriptionGovernanceRuleResource> GetAll(CancellationToken cancellationToken = default(CancellationToken))
            => new SubscriptionGovernanceRulePageable(Client, _innerCollection.GetAll(cancellationToken));

        [ForwardsClientCalls]
        public virtual AsyncPageable<SubscriptionGovernanceRuleResource> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
            => new SubscriptionGovernanceRuleAsyncPageable(Client, _innerCollection.GetAllAsync(cancellationToken));

        public virtual Task<Response<SubscriptionGovernanceRuleResource>> GetAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IAsyncEnumerator<SubscriptionGovernanceRuleResource> IAsyncEnumerable<SubscriptionGovernanceRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);

        IEnumerator<SubscriptionGovernanceRuleResource> IEnumerable<SubscriptionGovernanceRuleResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();

        private sealed class SubscriptionGovernanceRulePageable : Pageable<SubscriptionGovernanceRuleResource>
        {
            private readonly ArmClient _client;
            private readonly Pageable<SecurityConnectorGovernanceRuleResource> _inner;

            public SubscriptionGovernanceRulePageable(ArmClient client, Pageable<SecurityConnectorGovernanceRuleResource> inner)
            {
                _client = client;
                _inner = inner;
            }

            public override IEnumerable<Page<SubscriptionGovernanceRuleResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<SecurityConnectorGovernanceRuleResource> page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    yield return Page<SubscriptionGovernanceRuleResource>.FromValues(page.Values.Select(resource => new SubscriptionGovernanceRuleResource(_client, resource)).ToArray(), page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class SubscriptionGovernanceRuleAsyncPageable : AsyncPageable<SubscriptionGovernanceRuleResource>
        {
            private readonly ArmClient _client;
            private readonly AsyncPageable<SecurityConnectorGovernanceRuleResource> _inner;

            public SubscriptionGovernanceRuleAsyncPageable(ArmClient client, AsyncPageable<SecurityConnectorGovernanceRuleResource> inner)
            {
                _client = client;
                _inner = inner;
            }

            public override async IAsyncEnumerable<Page<SubscriptionGovernanceRuleResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<SecurityConnectorGovernanceRuleResource> page in _inner.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    yield return Page<SubscriptionGovernanceRuleResource>.FromValues(page.Values.Select(resource => new SubscriptionGovernanceRuleResource(_client, resource)).ToArray(), page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
