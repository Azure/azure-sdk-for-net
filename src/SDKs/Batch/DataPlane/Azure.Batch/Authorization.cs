// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Authorization levels available for enforcement of restrictions.
    /// </summary>
    [Flags]
    internal enum AuthorizationLevel { User = 0, Admin = 1}
}
