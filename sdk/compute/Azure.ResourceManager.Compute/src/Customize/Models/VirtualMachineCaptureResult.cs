// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineCaptureResult
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineCaptureResult"/>. </summary>
        public VirtualMachineCaptureResult()
        {
            Resources = new ChangeTrackingList<BinaryData>();
        }
    }
}
