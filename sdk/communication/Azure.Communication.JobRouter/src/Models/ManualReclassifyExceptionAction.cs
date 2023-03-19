// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ManualReclassifyExceptionAction")]
#pragma warning disable CA1825 // Avoid zero-length array allocations
    [CodeGenSuppress("ManualReclassifyExceptionAction")]
#pragma warning restore CA1825 // Avoid zero-length array allocations
    [CodeGenSuppress("ManualReclassifyExceptionAction", typeof(string))]
    public partial class ManualReclassifyExceptionAction
    {
        /// <summary> Initializes a new instance of ManualReclassifyExceptionAction. </summary>
        /// <param name="queueId"> Updated QueueId. </param>
        /// <param name="priority"> Updated Priority. </param>
        /// <param name="workerSelectors"> (Optional) Updated WorkerSelectors. </param>
        public ManualReclassifyExceptionAction(string queueId, int priority, IEnumerable<WorkerSelector> workerSelectors = default)
            : this(null, queueId, priority, (workerSelectors ?? Array.Empty<WorkerSelector>()).ToList())
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            Argument.AssertNotNull(priority, nameof(priority));
        }
    }
}
