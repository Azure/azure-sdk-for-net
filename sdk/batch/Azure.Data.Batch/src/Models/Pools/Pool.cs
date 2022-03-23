// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Data.Batch.Models
{
    public partial class Pool
    {
        public Pool(string poolId, string displayName, VirtualMachineConfiguration config, string vmSize) : this()
        {
            Id = poolId;
            DisplayName = displayName;
            VirtualMachineConfiguration = config;
            VmSize = vmSize;
        }
    }
}
