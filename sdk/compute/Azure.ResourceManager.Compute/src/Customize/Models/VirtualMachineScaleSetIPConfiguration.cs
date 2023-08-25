// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineScaleSetIPConfiguration : ComputeWriteableSubResourceData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ResourceIdentifier Id { get; set; }
    }
}
