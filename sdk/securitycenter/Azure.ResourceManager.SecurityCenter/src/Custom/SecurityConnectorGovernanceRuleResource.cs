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
