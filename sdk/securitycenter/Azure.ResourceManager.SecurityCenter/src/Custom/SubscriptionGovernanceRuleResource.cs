// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec removed this legacy resource or operation path, so the generator cannot emit the previous GA management-plane method; keep a hidden shim for ApiCompat and throw because the service path is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the SubscriptionGovernanceRuleResource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SubscriptionGovernanceRuleResource : Azure.ResourceManager.ArmResource
    {
        /// <summary>
        /// Gets the ResourceType value preserved from the previous public API surface.
        /// </summary>
        public static readonly Azure.Core.ResourceType ResourceType;
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionGovernanceRuleResource"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected SubscriptionGovernanceRuleResource() { }
        /// <summary>
        /// Gets the Data value preserved from the previous public API surface.
        /// </summary>
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get; } = new Azure.ResourceManager.SecurityCenter.GovernanceRuleData();
        /// <summary>
        /// Gets the HasData value preserved from the previous public API surface.
        /// </summary>
        public virtual bool HasData { get; } = true;
        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ruleId) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the Delete operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the DeleteAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the ExecuteRule operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="executeGovernanceRuleParams">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the ExecuteRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="executeGovernanceRuleParams">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetRuleExecutionStatus operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="operationId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetRuleExecutionStatus(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the GetRuleExecutionStatusAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="operationId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetRuleExecutionStatusAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the Update operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the UpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
