// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineCollection
    {
        /// <summary> Lists all of the virtual machines in the specified resource group. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<VirtualMachineResource> GetAllAsync(string filter, CancellationToken cancellationToken)
            => GetAllAsync(filter, null, cancellationToken);

        /// <summary> Lists all of the virtual machines in the specified resource group. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<VirtualMachineResource> GetAll(string filter, CancellationToken cancellationToken)
            => GetAll(filter, null, cancellationToken);

        /// <summary> The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, vmName, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary> The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> CreateOrUpdate(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, vmName, data, null, cancellationToken);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmName, VirtualMachineData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, vmName, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> The operation to create or update a virtual machine. Please note some properties can be set only during virtual machine creation. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachines_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> CreateOrUpdate(WaitUntil waitUntil, string vmName, VirtualMachineData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, vmName, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
    }
}
