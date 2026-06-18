// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the FirewallPolicyResource type. </summary>
    public partial class FirewallPolicyResource
    {
        /// <summary> Invokes the DeployFirewallPolicyDeploymentAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeployFirewallPolicyDeploymentAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => DeployAsync(waitUntil, cancellationToken);
        /// <summary> Invokes the DeployFirewallPolicyDeployment compatibility operation. </summary>

        [ForwardsClientCalls]
        public virtual ArmOperation DeployFirewallPolicyDeployment(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Deploy(waitUntil, cancellationToken);

        /// <summary> Invokes the GetFirewallPolicyIdpsSignatureAsync compatibility operation. </summary>
        public virtual Task<Response<IdpsSignatureListResult>> GetFirewallPolicyIdpsSignatureAsync(IdpsQueryContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetFirewallPolicyIdpsSignature compatibility operation. </summary>
        public virtual Response<IdpsSignatureListResult> GetFirewallPolicyIdpsSignature(IdpsQueryContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetFirewallPolicyIdpsSignaturesFilterValueAsync compatibility operation. </summary>
        public virtual Task<Response<SignatureOverridesFilterValuesResult>> GetFirewallPolicyIdpsSignaturesFilterValueAsync(SignatureOverridesFilterValuesQueryContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetFirewallPolicyIdpsSignaturesFilterValue compatibility operation. </summary>
        public virtual Response<SignatureOverridesFilterValuesResult> GetFirewallPolicyIdpsSignaturesFilterValue(SignatureOverridesFilterValuesQueryContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the UpdateAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<FirewallPolicyResource>> UpdateAsync(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Update compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<FirewallPolicyResource> Update(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken) => default;
    }
}
