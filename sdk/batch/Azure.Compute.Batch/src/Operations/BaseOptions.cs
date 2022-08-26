// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Compute.Batch
{
    public class BaseOptions
    {
        public int? Timeout { get; set; }
        public Guid? ClientRequestId { get; set; }
        public bool? ReturnClientRequestId { get; set; }
        public DateTimeOffset? OcpDate { get; set; }
        public RequestConditions RequestConditions { get; set; }
        public RequestContext Context { get; set; }
    }
}
