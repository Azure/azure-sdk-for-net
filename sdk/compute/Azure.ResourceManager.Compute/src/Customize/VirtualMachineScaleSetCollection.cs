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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string virtualMachineScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineScaleSetName, nameof(virtualMachineScaleSetName));
            Argument.AssertNotNull(data, nameof(data));
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, data, null, null, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<VirtualMachineScaleSetResource>(new VirtualMachineScaleSetOperationSource(Client), _virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, data, null, null).Request, response, OperationFinalStateVia.Location);
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
        public virtual ArmOperation<VirtualMachineScaleSetResource> CreateOrUpdate(WaitUntil waitUntil, string virtualMachineScaleSetName, VirtualMachineScaleSetData data, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineScaleSetName, nameof(virtualMachineScaleSetName));
            Argument.AssertNotNull(data, nameof(data));
            using var scope = _virtualMachineScaleSetClientDiagnostics.CreateScope("VirtualMachineScaleSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, data, null, null, cancellationToken);
                var operation = new ComputeArmOperation<VirtualMachineScaleSetResource>(new VirtualMachineScaleSetOperationSource(Client), _virtualMachineScaleSetClientDiagnostics, Pipeline, _virtualMachineScaleSetRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, data, null, null).Request, response, OperationFinalStateVia.Location);
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
