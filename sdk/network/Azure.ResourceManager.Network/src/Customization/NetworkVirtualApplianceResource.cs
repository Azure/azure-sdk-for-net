// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using LegacyModels = Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVirtualApplianceResource
    {
        /// <summary> Invokes the CreateOrUpdateInboundSecurityRule compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use GetInboundSecurityRules().CreateOrUpdate instead.")]
        public virtual ArmOperation<LegacyModels.InboundSecurityRule> CreateOrUpdateInboundSecurityRule(WaitUntil p0, string p1, LegacyModels.InboundSecurityRule p2, CancellationToken p3) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the CreateOrUpdateInboundSecurityRuleAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Please use GetInboundSecurityRules().CreateOrUpdateAsync instead.")]
        public virtual Task<ArmOperation<LegacyModels.InboundSecurityRule>> CreateOrUpdateInboundSecurityRuleAsync(WaitUntil p0, string p1, LegacyModels.InboundSecurityRule p2, CancellationToken p3) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
