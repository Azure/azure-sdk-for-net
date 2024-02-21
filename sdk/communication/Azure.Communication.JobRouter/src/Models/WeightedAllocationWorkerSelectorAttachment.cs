// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class WeightedAllocationWorkerSelectorAttachment
    {
        /// <summary> Initializes a new instance of WeightedAllocationWorkerSelectorAttachment. </summary>
        /// <param name="allocations"> A collection of percentage based weighted allocations. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="allocations"/> is null. </exception>
        public WeightedAllocationWorkerSelectorAttachment(IEnumerable<WorkerWeightedAllocation> allocations)
        {
            Argument.AssertNotNull(allocations, nameof(allocations));

            Kind = WorkerSelectorAttachmentKind.WeightedAllocation;
            Allocations = allocations.ToList();
        }
    }
}
