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
    // The current TypeSpec uses SecurityConnectorGovernanceRuleData, but GA exposed GovernanceRuleData and resource-level rule operations; keep those signatures and map them to hidden throwing shims.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorGovernanceRuleResource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityConnectorGovernanceRuleResource : ArmResource
    {
        /// <summary>
        /// Gets the ResourceType value preserved from the previous public API surface.
        /// </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Security/securityConnectors/governanceRules";
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityConnectorGovernanceRuleResource"/> type for compatibility with the previous public API surface.
        /// </summary>

        protected SecurityConnectorGovernanceRuleResource()
        {
        }
        internal SecurityConnectorGovernanceRuleResource(ArmClient client, GovernanceRuleResource source) : base(client, source.Id)
        {
            HasData = source.HasData;
            if (source.HasData)
            {
                Data = source.Data;
            }
        }

        private GovernanceRuleResource Current => Client.GetGovernanceRuleResource(Id);

        /// <summary>
        /// Gets the HasData value preserved from the previous public API surface.
        /// </summary>
        public virtual bool HasData { get; }
        /// <summary>
        /// Provides a compatibility shim for the Delete operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => Current.Delete(waitUntil, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the DeleteAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => Current.DeleteAsync(waitUntil, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Response<SecurityConnectorGovernanceRuleResource> Get(CancellationToken cancellationToken = default)
        {
            Response<GovernanceRuleResource> response = Current.Get(cancellationToken);
            return Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, response.Value), response.GetRawResponse());
        }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual async Task<Response<SecurityConnectorGovernanceRuleResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<GovernanceRuleResource> response = await Current.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, response.Value), response.GetRawResponse());
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec uses SecurityConnectorGovernanceRuleData, but GA exposed GovernanceRuleData and resource-level rule operations; keep those signatures and map them to hidden throwing shims.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorGovernanceRuleResource class.
    /// </summary>
    public partial class SecurityConnectorGovernanceRuleResource
    {
        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="resourceGroupName">The value preserved for API compatibility.</param>
        /// <param name="securityConnectorName">The value preserved for API compatibility.</param>
        /// <param name="ruleId">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string securityConnectorName, string ruleId)
            => GovernanceRuleResource.CreateResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}", ruleId);
        /// <summary>
        /// Provides a compatibility shim for the GetRuleExecutionStatus operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="operationId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use GovernanceRuleResource.Execute instead.")]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetRuleExecutionStatus(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use GovernanceRuleResource.Execute instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetRuleExecutionStatusAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="operationId">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [Azure.Core.ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This API is no longer supported by the service. Use GovernanceRuleResource.Execute instead.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetRuleExecutionStatusAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use GovernanceRuleResource.Execute instead."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec uses SecurityConnectorGovernanceRuleData, but GA exposed GovernanceRuleData and resource-level rule operations; keep those signatures and map them to hidden throwing shims.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorGovernanceRuleResource class.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Data")]
    public partial class SecurityConnectorGovernanceRuleResource
    {
        /// <summary>
        /// Gets the Data value preserved from the previous public API surface.
        /// </summary>
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get; }
        /// <summary>
        /// Provides a compatibility shim for the ExecuteRule operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="executeGovernanceRuleParams">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Current.Execute(waitUntil, executeGovernanceRuleParams, cancellationToken);
        /// <summary>
        /// Provides a compatibility shim for the Update operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ArmOperation<GovernanceRuleResource> operation = Current.Update(waitUntil, data, cancellationToken);
            return new SecurityCenterArmOperation<SecurityConnectorGovernanceRuleResource>(Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, operation.Value), operation.GetRawResponse()));
        }
        /// <summary>
        /// Provides a compatibility shim for the UpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual async System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ArmOperation<GovernanceRuleResource> operation = await Current.UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
            return new SecurityCenterArmOperation<SecurityConnectorGovernanceRuleResource>(Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, operation.Value), operation.GetRawResponse()));
        }
        /// <summary>
        /// Provides a compatibility shim for the ExecuteRuleAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="executeGovernanceRuleParams">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Current.ExecuteAsync(waitUntil, executeGovernanceRuleParams, cancellationToken);
    }
}
