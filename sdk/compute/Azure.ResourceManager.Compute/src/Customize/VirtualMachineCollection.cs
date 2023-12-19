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
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, filter, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, null);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), _virtualMachineClientDiagnostics, Pipeline, "VirtualMachineCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary> Lists all of the virtual machines in the specified resource group. Use the nextLink property in the response to get the next page of virtual machines. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<VirtualMachineResource> GetAll(string filter, CancellationToken cancellationToken)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, filter, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, null);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new VirtualMachineResource(Client, VirtualMachineData.DeserializeVirtualMachineData(e)), _virtualMachineClientDiagnostics, Pipeline, "VirtualMachineCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(vmName, nameof(vmName));
            Argument.AssertNotNull(data, nameof(data));
            using var scope = _virtualMachineClientDiagnostics.CreateScope("VirtualMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, vmName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<VirtualMachineResource>(new VirtualMachineOperationSource(Client), _virtualMachineClientDiagnostics, Pipeline, _virtualMachineRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vmName, data).Request, response, OperationFinalStateVia.Location);
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
        public virtual ArmOperation<VirtualMachineResource> CreateOrUpdate(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
        {
            Argument.AssertNotNullOrEmpty(vmName, nameof(vmName));
            Argument.AssertNotNull(data, nameof(data));
            using var scope = _virtualMachineClientDiagnostics.CreateScope("VirtualMachineCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, vmName, data, cancellationToken);
                var operation = new ComputeArmOperation<VirtualMachineResource>(new VirtualMachineOperationSource(Client), _virtualMachineClientDiagnostics, Pipeline, _virtualMachineRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, vmName, data).Request, response, OperationFinalStateVia.Location);
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
