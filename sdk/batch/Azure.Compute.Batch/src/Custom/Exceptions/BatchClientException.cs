// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Compute.Batch.Custom;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// An exception thrown by the Batch client.
    /// </summary>
    public class BatchClientException : BatchException
    {
        internal BatchClientException(string message = null, Exception inner = null) : base(null, message, inner)
        {
        }
    }
}
