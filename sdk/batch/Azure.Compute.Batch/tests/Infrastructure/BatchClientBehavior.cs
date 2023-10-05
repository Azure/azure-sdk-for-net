// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    /// <summary>
    /// Derived classes modify operational behaviors of a Azure Batch Service client.  Derived classes can be called out of order and simultaneously by several threads.  Implementations should be threadsafe.
    /// </summary>
    public abstract class BatchClientBehavior
    {
    }
}
