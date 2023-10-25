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
        /// <summary> Deallocates specific virtual machines in a VM scale set. Shuts down the virtual machines and releases the compute resources. You are not billed for the compute resources that this virtual machine scale set deallocates. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeallocateAsync(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds, CancellationToken cancellationToken)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Deallocate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.DeallocateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, null, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeallocateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deallocates specific virtual machines in a VM scale set. Shuts down the virtual machines and releases the compute resources. You are not billed for the compute resources that this virtual machine scale set deallocates. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Deallocate(WaitUntil waitUntil, VirtualMachineScaleSetVmInstanceIds vmInstanceIds , CancellationToken cancellationToken)
        {
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetResource.Deallocate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.Deallocate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, null, cancellationToken);
                var operation = new ComputeArmOperation(_virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateDeallocateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vmInstanceIds, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
