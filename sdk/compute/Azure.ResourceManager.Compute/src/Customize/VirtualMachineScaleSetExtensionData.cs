// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    // this piece of customized code adds back the ability to set name of this class in its constructor
    public partial class VirtualMachineScaleSetExtensionData
    {
        /// <summary> Initializes a new instance of VmssExtensionData. </summary>
        /// <param name="name"> The name. </param>
        public VirtualMachineScaleSetExtensionData(string name) : base(default, name, default, default)
        {
        }
    }
}
