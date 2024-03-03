// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class WeightedAllocationQueueSelectorAttachment
    {
        /// <summary> Initializes a new instance of WeightedAllocationQueueSelectorAttachment. </summary>
        /// <param name="allocations"> A collection of percentage based weighted allocations. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="allocations"/> is null. </exception>
        public WeightedAllocationQueueSelectorAttachment(IEnumerable<QueueWeightedAllocation> allocations)
        {
            if (allocations == null)
            {
                throw new ArgumentNullException(nameof(allocations));
            }

            Kind = QueueSelectorAttachmentKind.WeightedAllocation;
            Allocations = allocations.ToList();
        }
    }
}
