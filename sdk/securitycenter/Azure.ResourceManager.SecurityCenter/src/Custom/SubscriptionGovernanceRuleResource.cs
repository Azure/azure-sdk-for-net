// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
    // The previous GA SDK exposed this legacy governance rule type/member from GovernanceRules swagger.
    // Current TypeSpec emits the updated governance resource shape instead, so this hidden obsolete
    // shim is retained only for ApiCompat.
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SubscriptionGovernanceRuleResource : ArmResource
    {
        public static readonly ResourceType ResourceType;
        protected SubscriptionGovernanceRuleResource() { }
        public virtual GovernanceRuleData Data { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ruleId) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation ExecuteRule(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation> ExecuteRuleAsync(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<SubscriptionGovernanceRuleResource> Get(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<SubscriptionGovernanceRuleResource>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation<ExecuteRuleStatus> GetRuleExecutionStatus(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<ExecuteRuleStatus>> GetRuleExecutionStatusAsync(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation<SubscriptionGovernanceRuleResource> Update(WaitUntil waitUntil, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<SubscriptionGovernanceRuleResource>> UpdateAsync(WaitUntil waitUntil, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
