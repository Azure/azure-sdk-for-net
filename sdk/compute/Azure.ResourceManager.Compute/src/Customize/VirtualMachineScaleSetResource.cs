// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetResource
    {
        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> Update a VM scale set. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSets_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineScaleSetResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, patch, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> Update a VM scale set. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSets_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineScaleSetResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetPatch patch, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Update(waitUntil, patch, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
    }
}
