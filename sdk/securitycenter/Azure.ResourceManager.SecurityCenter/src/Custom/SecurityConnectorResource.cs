// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec removed this legacy resource or operation path, so the generator cannot emit the previous GA management-plane method; keep a hidden shim for ApiCompat and throw because the service path is no longer supported.
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
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> GetSecurityConnectorGovernanceRule(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityConnectorGovernanceRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> GetSecurityConnectorGovernanceRuleAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec removed this legacy resource or operation path, so the generator cannot emit the previous GA management-plane method; keep a hidden shim for ApiCompat and throw because the service path is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorResource class.
    /// </summary>
    public partial class SecurityConnectorResource
    {
        /// <summary>
        /// Provides a compatibility shim for the GetSecurityConnectorGovernanceRules operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleCollection GetSecurityConnectorGovernanceRules() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
