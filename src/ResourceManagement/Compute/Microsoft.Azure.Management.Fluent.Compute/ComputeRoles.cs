// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Compute
{
    public enum ComputeRoles
    {
        UNKNOWN,

        [EnumName("PaaS")]
        PAAS,

        [EnumName("IaaS")]
        IAAS
    }
}
