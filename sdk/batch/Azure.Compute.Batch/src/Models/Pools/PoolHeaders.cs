// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Compute.Batch.Models
{
    public class PoolHeaders : BaseHeaders
    {
        public PoolHeaders() : base()
        {
        }

        public PoolHeaders(Response response) : base(response)
        {
        }
    }
}
