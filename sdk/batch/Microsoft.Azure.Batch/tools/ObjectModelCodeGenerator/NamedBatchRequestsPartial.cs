// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace ObjectModelCodeGenerator
{
    using System.Collections.Generic;
    using ProxyLayerParser;

    public partial class NamedBatchRequests
    {
        public NamedBatchRequests(IEnumerable<BatchRequestGroup> batchRequests)
        {
            this._batchRequestsField = batchRequests;
        }
    }
}
