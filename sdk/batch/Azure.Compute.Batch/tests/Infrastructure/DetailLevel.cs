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
    /// Controls the amount of detail requested from the Azure Batch service when listing or
    /// retrieving resources.
    /// </summary>
    /// <remarks>The only supported implementation of DetailLevel is <see cref="ODATADetailLevel"/>.
    /// Other implementations are ignored.</remarks>
    public abstract class DetailLevel
    {
    }
}
