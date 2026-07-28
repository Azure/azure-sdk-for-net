// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
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
    public partial class VirtualMachineScaleSetCollection
    {
        /// <summary> Create or update a VM scale set. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSets_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string virtualMachineScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, virtualMachineScaleSetName, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary> Create or update a VM scale set. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSets_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> CreateOrUpdate(WaitUntil waitUntil, string virtualMachineScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, virtualMachineScaleSetName, data, null, cancellationToken);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> Create or update a VM scale set. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSets_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string virtualMachineScaleSetName, VirtualMachineScaleSetData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, virtualMachineScaleSetName, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);

        // Backward-compatibility shim that accepts ifMatch and ifNoneMatch as positional string parameters; new code should use the MatchConditions overload.
        /// <summary> Create or update a VM scale set. <list type="bullet"> <item> <term> Request Path. </term> <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}. </description> </item> <item> <term> Operation Id. </term> <description> VirtualMachineScaleSets_CreateOrUpdate. </description> </item> <item> <term> Default Api Version. </term> <description> 2026-03-01. </description> </item> </list> </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetResource> CreateOrUpdate(WaitUntil waitUntil, string virtualMachineScaleSetName, VirtualMachineScaleSetData data, string ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, virtualMachineScaleSetName, data, ConditionalRequestExtensions.BuildMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
    }
}
