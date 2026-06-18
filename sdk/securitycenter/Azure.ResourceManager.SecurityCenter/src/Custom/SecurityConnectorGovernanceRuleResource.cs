// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shim does not need public docs.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.SecurityCenter
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityConnectorGovernanceRuleResource : ArmResource
    {
        public static readonly ResourceType ResourceType = "Microsoft.Security/securityConnectors/governanceRules";

        protected SecurityConnectorGovernanceRuleResource()
        {
        }

        public virtual bool HasData => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual Response<SecurityConnectorGovernanceRuleResource> Get(CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual Task<Response<SecurityConnectorGovernanceRuleResource>> GetAsync(CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    public partial class SecurityConnectorGovernanceRuleResource
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string securityConnectorName, string ruleId) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetRuleExecutionStatus(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetRuleExecutionStatusAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Data")]
    public partial class SecurityConnectorGovernanceRuleResource
    {
#pragma warning disable CS0618 // Type is retained for API compatibility.
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
#pragma warning restore CS0618

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
