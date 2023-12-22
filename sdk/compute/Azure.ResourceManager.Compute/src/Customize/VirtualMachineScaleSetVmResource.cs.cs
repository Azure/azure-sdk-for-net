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
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmResource.Update");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, null, null, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<VirtualMachineScaleSetVmResource>(new VirtualMachineScaleSetVmOperationSource(Client), _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics, Pipeline, _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, null, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> Update(WaitUntil waitUntil, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmResource.Update");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, null, null, cancellationToken);
                var operation = new ComputeArmOperation<VirtualMachineScaleSetVmResource>(new VirtualMachineScaleSetVmOperationSource(Client), _virtualMachineScaleSetVmVirtualMachineScaleSetVmsClientDiagnostics, Pipeline, _virtualMachineScaleSetVmVirtualMachineScaleSetVmsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, null, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
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
