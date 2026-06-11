// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CA1822 // Compatibility instance members intentionally preserve previous signatures.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    [CodeGenSuppress("Data")]
    public partial class SecurityConnectorGovernanceRuleResource
    {
        public virtual GovernanceRuleData Data { get { throw new NotSupportedException("This API is no longer supported by the service."); } }

        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ExecuteRule(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SecurityConnectorGovernanceRuleResource> Update(WaitUntil waitUntil, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SecurityConnectorGovernanceRuleResource>> UpdateAsync(WaitUntil waitUntil, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        [Obsolete("This API is no longer supported by the service.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation> ExecuteRuleAsync(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
