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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<VirtualMachineResource>> UpdateAsync(WaitUntil waitUntil, VirtualMachinePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(waitUntil, patch, null, null, cancellationToken).ConfigureAwait(false);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<VirtualMachineResource> Update(WaitUntil waitUntil, VirtualMachinePatch patch, CancellationToken cancellationToken)
            => Update(waitUntil, patch, null, null, cancellationToken);
    }
}
