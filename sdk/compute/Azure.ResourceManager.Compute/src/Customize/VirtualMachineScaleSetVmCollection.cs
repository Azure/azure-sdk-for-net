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
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetVmCollection
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineScaleSetVmResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, instanceId, data, null, null, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineScaleSetVmResource> CreateOrUpdate(WaitUntil waitUntil, string instanceId, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, instanceId, data, null, null, cancellationToken);
    }
}
