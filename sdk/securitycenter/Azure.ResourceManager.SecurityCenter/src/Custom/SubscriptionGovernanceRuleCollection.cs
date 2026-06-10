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
    public partial class SubscriptionGovernanceRuleCollection : ArmCollection, IAsyncEnumerable<SubscriptionGovernanceRuleResource>, IEnumerable<SubscriptionGovernanceRuleResource>, IEnumerable
    {
        protected SubscriptionGovernanceRuleCollection() { }
        public virtual ArmOperation<SubscriptionGovernanceRuleResource> CreateOrUpdate(WaitUntil waitUntil, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<SubscriptionGovernanceRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleId, GovernanceRuleData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<bool> Exists(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<bool>> ExistsAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<SubscriptionGovernanceRuleResource> Get(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Pageable<SubscriptionGovernanceRuleResource> GetAll(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual AsyncPageable<SubscriptionGovernanceRuleResource> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<SubscriptionGovernanceRuleResource>> GetAsync(string ruleId, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IAsyncEnumerator<SubscriptionGovernanceRuleResource> IAsyncEnumerable<SubscriptionGovernanceRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken) { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator<SubscriptionGovernanceRuleResource> IEnumerable<SubscriptionGovernanceRuleResource>.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
        IEnumerator IEnumerable.GetEnumerator() { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
