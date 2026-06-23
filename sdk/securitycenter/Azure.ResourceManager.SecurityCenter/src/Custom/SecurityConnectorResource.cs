// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) or ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead.")]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> GetSecurityConnectorGovernanceRule(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) or ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityConnectorGovernanceRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) or ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetSecurityConnectorGovernanceRuleAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) or ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead."); }
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) or ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules() { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetGovernanceRules(ResourceIdentifier scope) or ArmClient.GetGovernanceRuleResource(ResourceIdentifier id) instead."); }
    }
}
