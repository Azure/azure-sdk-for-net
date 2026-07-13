// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineResource
    {
        /// <summary> The operation to update a virtual machine. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachinePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, cancellationToken).ConfigureAwait(false);

        /// <summary> The operation to update a virtual machine. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> Update(WaitUntil waitUntil, VirtualMachinePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, cancellationToken);

        /// <summary> Shuts down the virtual machine and releases the compute resources. You are not billed for the compute resources that this virtual machine uses. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/deallocate. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_Deallocate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, bool? hibernate, CancellationToken cancellationToken)
            => await DeallocateAsync(waitUntil, hibernate, null, cancellationToken).ConfigureAwait(false);

        /// <summary> Shuts down the virtual machine and releases the compute resources. You are not billed for the compute resources that this virtual machine uses. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/deallocate. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_Deallocate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, bool? hibernate, CancellationToken cancellationToken)
            => Deallocate(waitUntil, hibernate, null, cancellationToken);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> The operation to update a virtual machine. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachinePatch patch, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil, patch, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> The operation to update a virtual machine. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_Update. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> <item> <term> Resource. </term> <description> <see cref="VirtualMachineResource"/>. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> Update(WaitUntil waitUntil, VirtualMachinePatch patch, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => Update(waitUntil, patch, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
    }
}
