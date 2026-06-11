// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetVmResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, data, null, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => Update(waitUntil, data, null, cancellationToken);

        /// <summary> Backward-compatibility shim that accepts <c>ifMatch</c> and <c>ifNoneMatch</c> as positional string parameters; new code should use the <see cref="MatchConditions"/> overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        /// <summary> Backward-compatibility shim that accepts <c>ifMatch</c> and <c>ifNoneMatch</c> as positional string parameters; new code should use the <see cref="MatchConditions"/> overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
    }
}
