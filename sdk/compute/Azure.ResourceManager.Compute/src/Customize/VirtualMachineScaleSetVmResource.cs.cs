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
        /// <summary> Update a VirtualMachineScaleSetVm. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSetVMS_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineScaleSetVmResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary> Update a VirtualMachineScaleSetVm. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSetVMS_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineScaleSetVmResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => Update(waitUntil, data, null, cancellationToken);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> Update a VirtualMachineScaleSetVm. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSetVMS_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineScaleSetVmResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> Update a VirtualMachineScaleSetVm. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSetVMS_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineScaleSetVmResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Update(waitUntil, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
    }
}
