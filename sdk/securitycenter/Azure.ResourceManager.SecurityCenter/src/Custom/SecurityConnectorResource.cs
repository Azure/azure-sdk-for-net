// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorResource class.
    /// </summary>
    public partial class SecurityConnectorResource
    {
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityConnectorGovernanceRule operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This class is obsolete and will be removed in a future release.", false)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> GetSecurityConnectorGovernanceRule(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetSecurityConnectorGovernanceRules().Get(ruleId, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityConnectorGovernanceRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [System.Obsolete("This class is obsolete and will be removed in a future release.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetSecurityConnectorGovernanceRuleAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => GetSecurityConnectorGovernanceRules().GetAsync(ruleId, cancellationToken);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorResource class.
    /// </summary>
    public partial class SecurityConnectorResource
    {
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityConnectorGovernanceRules operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This class is obsolete and will be removed in a future release.", false)]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules()
            => new SecurityConnectorGovernanceRuleCollection(Client, Id);
    }
}
