// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
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
    /// Provides a compatibility shim for the SecurityConnectorGovernanceRuleCollection class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityConnectorGovernanceRuleCollection : ArmCollection, IEnumerable<SecurityConnectorGovernanceRuleResource>, IAsyncEnumerable<SecurityConnectorGovernanceRuleResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityConnectorGovernanceRuleCollection"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected SecurityConnectorGovernanceRuleCollection()
        {
        }
        internal SecurityConnectorGovernanceRuleCollection(ArmClient client, ResourceIdentifier scope) : base(client, scope)
        {
        }

        private GovernanceRuleCollection Current => Client.GetGovernanceRules(Id);

        private SecurityConnectorGovernanceRuleResource Convert(GovernanceRuleResource source)
            => new SecurityConnectorGovernanceRuleResource(Client, source);

        /// <summary>
        /// Provides a compatibility shim for the Exists operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Response<bool> Exists(string ruleId, CancellationToken cancellationToken = default)
            => Current.Exists(ruleId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the ExistsAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Task<Response<bool>> ExistsAsync(string ruleId, CancellationToken cancellationToken = default)
            => Current.ExistsAsync(ruleId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Response<SecurityConnectorGovernanceRuleResource> Get(string ruleId, CancellationToken cancellationToken = default)
        {
            Response<GovernanceRuleResource> response = Current.Get(ruleId, cancellationToken);
            return Response.FromValue(Convert(response.Value), response.GetRawResponse());
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual async Task<Response<SecurityConnectorGovernanceRuleResource>> GetAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            Response<GovernanceRuleResource> response = await Current.GetAsync(ruleId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(Convert(response.Value), response.GetRawResponse());
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAll operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Pageable<SecurityConnectorGovernanceRuleResource> GetAll(CancellationToken cancellationToken = default)
            => new PageableWrapper<GovernanceRuleResource, SecurityConnectorGovernanceRuleResource>(Current.GetAll(cancellationToken), Convert);
        /// <summary>
        /// Provides a compatibility shim for the GetAllAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual AsyncPageable<SecurityConnectorGovernanceRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
            => new AsyncPageableWrapper<GovernanceRuleResource, SecurityConnectorGovernanceRuleResource>(Current.GetAllAsync(cancellationToken), Convert);

        IAsyncEnumerator<SecurityConnectorGovernanceRuleResource> IAsyncEnumerable<SecurityConnectorGovernanceRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);

        IEnumerator<SecurityConnectorGovernanceRuleResource> IEnumerable<SecurityConnectorGovernanceRuleResource>.GetEnumerator()
            => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetAll().GetEnumerator();
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorGovernanceRuleCollection class.
    /// </summary>
    public partial class SecurityConnectorGovernanceRuleCollection
    {
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdate operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ArmOperation<GovernanceRuleResource> operation = Current.CreateOrUpdate(waitUntil, ruleId, data, cancellationToken);
            return new MappedArmOperation<GovernanceRuleResource, SecurityConnectorGovernanceRuleResource>(operation, Convert);
        }
        /// <summary>
        /// Provides a compatibility shim for the CreateOrUpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public virtual async System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ArmOperation<GovernanceRuleResource> operation = await Current.CreateOrUpdateAsync(waitUntil, ruleId, data, cancellationToken).ConfigureAwait(false);
            return new MappedArmOperation<GovernanceRuleResource, SecurityConnectorGovernanceRuleResource>(operation, Convert);
        }
    }
}
