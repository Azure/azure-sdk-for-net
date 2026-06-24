// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SubscriptionGovernanceRuleCollection class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SubscriptionGovernanceRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>, System.Collections.IEnumerable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionGovernanceRuleCollection"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected SubscriptionGovernanceRuleCollection() { }
        internal SubscriptionGovernanceRuleCollection(ArmClient client, ResourceIdentifier scope) : base(client, scope)
        {
        }

        private GovernanceRuleCollection Current => Client.GetGovernanceRules(Id);

        private SubscriptionGovernanceRuleResource Convert(GovernanceRuleResource source)
            => new SubscriptionGovernanceRuleResource(Client, source);

        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdate operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ArmOperation<GovernanceRuleResource> operation = Current.CreateOrUpdate(waitUntil, ruleId, data, cancellationToken);
            return new SecurityCenterArmOperation<SubscriptionGovernanceRuleResource>(Response.FromValue(Convert(operation.Value), operation.GetRawResponse()));
        }
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual async System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ArmOperation<GovernanceRuleResource> operation = await Current.CreateOrUpdateAsync(waitUntil, ruleId, data, cancellationToken).ConfigureAwait(false);
            return new SecurityCenterArmOperation<SubscriptionGovernanceRuleResource>(Response.FromValue(Convert(operation.Value), operation.GetRawResponse()));
        }
        /// <summary>
        /// Provides a compatibility shim for the Exists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Response<bool> Exists(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Current.Exists(ruleId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the ExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Current.ExistsAsync(ruleId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Get(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Response<GovernanceRuleResource> response = Current.Get(ruleId, cancellationToken);
            return Response.FromValue(Convert(response.Value), response.GetRawResponse());
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAll operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => new PageableWrapper<GovernanceRuleResource, SubscriptionGovernanceRuleResource>(Current.GetAll(cancellationToken), Convert);
        /// <summary>
        /// Provides a compatibility shim for the GetAllAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => new AsyncPageableWrapper<GovernanceRuleResource, SubscriptionGovernanceRuleResource>(Current.GetAllAsync(cancellationToken), Convert);
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual async System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Response<GovernanceRuleResource> response = await Current.GetAsync(ruleId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(Convert(response.Value), response.GetRawResponse());
        }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>.GetEnumerator()
            => GetAll().GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();
    }
}
