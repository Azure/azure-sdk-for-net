// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class RestorePointSourceVmStorageProfile
    {
        public IReadOnlyList<RestorePointSourceVmDataDisk> DataDisks => DataDiskList.ToArray();
    }
}
