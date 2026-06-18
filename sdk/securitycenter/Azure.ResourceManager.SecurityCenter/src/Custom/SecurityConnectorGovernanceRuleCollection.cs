// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shim does not need public docs.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.SecurityCenter
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityConnectorGovernanceRuleCollection : ArmCollection, IEnumerable<SecurityConnectorGovernanceRuleResource>, IAsyncEnumerable<SecurityConnectorGovernanceRuleResource>
    {
        protected SecurityConnectorGovernanceRuleCollection()
        {
        }

        public virtual Response<bool> Exists(string ruleId, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual Task<Response<bool>> ExistsAsync(string ruleId, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual Response<SecurityConnectorGovernanceRuleResource> Get(string ruleId, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual Task<Response<SecurityConnectorGovernanceRuleResource>> GetAsync(string ruleId, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual Pageable<SecurityConnectorGovernanceRuleResource> GetAll(CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        public virtual AsyncPageable<SecurityConnectorGovernanceRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        IAsyncEnumerator<SecurityConnectorGovernanceRuleResource> IAsyncEnumerable<SecurityConnectorGovernanceRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        IEnumerator<SecurityConnectorGovernanceRuleResource> IEnumerable<SecurityConnectorGovernanceRuleResource>.GetEnumerator()
            => throw new System.NotSupportedException("This API is no longer supported by the service.");

        IEnumerator IEnumerable.GetEnumerator()
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
    public partial class SecurityConnectorGovernanceRuleCollection
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityConnectorGovernanceRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
