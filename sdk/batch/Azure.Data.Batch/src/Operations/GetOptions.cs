// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Data.Batch
{
    public class GetOptions : BaseOptions
    {
        public string Select { get; set; }
        public string Expand { get; set; }
    }
}
