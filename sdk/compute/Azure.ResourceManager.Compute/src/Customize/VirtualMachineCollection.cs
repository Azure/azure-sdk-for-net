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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, vmName, data, null, null, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> CreateOrUpdate(WaitUntil waitUntil, string vmName, VirtualMachineData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, vmName, data, null, null, cancellationToken);
    }
}
