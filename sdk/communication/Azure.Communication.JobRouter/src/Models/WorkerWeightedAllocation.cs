// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class WorkerWeightedAllocation
    {
        /// <summary> Initializes a new instance of WorkerWeightedAllocation. </summary>
        /// <param name="weight"> The percentage of this weight, expressed as a fraction of 1. </param>
        /// <param name="workerSelectors">
        /// A collection of worker selectors that will be applied if this allocation is
        /// selected.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerSelectors"/> is null. </exception>
        public WorkerWeightedAllocation(double weight, IEnumerable<RouterWorkerSelector> workerSelectors)
        {
            Argument.AssertNotNull(workerSelectors, nameof(workerSelectors));

            Weight = weight;
            WorkerSelectors = workerSelectors.ToList();
        }
    }
}
