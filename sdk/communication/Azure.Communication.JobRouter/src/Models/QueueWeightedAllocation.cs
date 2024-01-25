// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class QueueWeightedAllocation
    {
        /// <summary> Initializes a new instance of QueueWeightedAllocation. </summary>
        /// <param name="weight"> The percentage of this weight, expressed as a fraction of 1. </param>
        /// <param name="queueSelectors">
        /// A collection of queue selectors that will be applied if this allocation is
        /// selected.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueSelectors"/> is null. </exception>
        public QueueWeightedAllocation(double weight, IEnumerable<RouterQueueSelector> queueSelectors)
        {
            Argument.AssertNotNull(queueSelectors, nameof(queueSelectors));

            Weight = weight;
            QueueSelectors = queueSelectors.ToList();
        }
    }
}
