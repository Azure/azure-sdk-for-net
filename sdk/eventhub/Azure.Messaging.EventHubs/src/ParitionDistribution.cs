// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs
{
    ///
    public class ParitionDistribution
    {
        ///
        public int Count { get; set; }

        ///
        public List<PartitionOwnership> PartitionList { get; set; }
    }
}