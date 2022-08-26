// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Compute.Batch
{
    public class ListOptions : BaseOptions
    {
        public string Select { get; set; }
        public string Expand { get; set; }
        public string Filter { get; set; }
        public int? MaxResults { get; set; }
    }
}
