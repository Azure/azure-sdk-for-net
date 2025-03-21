// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Compute.Batch.Custom;

namespace Azure.Compute.Batch
{
    internal class RunOnceException : BatchException
    {
        internal RunOnceException(string message = null, Exception inner = null)
            : base(null, message, inner)
        {
        }
    }
}
