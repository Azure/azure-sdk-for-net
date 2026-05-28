// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal interface ISupportsTenantId
    {
        string TenantId { get; set; }
    }
}
