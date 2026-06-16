// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public partial class FirewallPolicyResource
    {
        [global::Azure.Core.ForwardsClientCalls]
        public virtual Task<ArmOperation> DeployFirewallPolicyDeploymentAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => DeployAsync(waitUntil, cancellationToken);

        [global::Azure.Core.ForwardsClientCalls]
        public virtual ArmOperation DeployFirewallPolicyDeployment(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Deploy(waitUntil, cancellationToken);

        public virtual Task<Response<IdpsSignatureListResult>> GetFirewallPolicyIdpsSignatureAsync(IdpsQueryContent content, CancellationToken cancellationToken) => default;
        public virtual Response<IdpsSignatureListResult> GetFirewallPolicyIdpsSignature(IdpsQueryContent content, CancellationToken cancellationToken) => default;
        public virtual Task<Response<SignatureOverridesFilterValuesResult>> GetFirewallPolicyIdpsSignaturesFilterValueAsync(SignatureOverridesFilterValuesQueryContent content, CancellationToken cancellationToken) => default;
        public virtual Response<SignatureOverridesFilterValuesResult> GetFirewallPolicyIdpsSignaturesFilterValue(SignatureOverridesFilterValuesQueryContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<FirewallPolicyResource>> UpdateAsync(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<FirewallPolicyResource> Update(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken) => default;
    }
}
