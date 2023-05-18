// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
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
    }
}
