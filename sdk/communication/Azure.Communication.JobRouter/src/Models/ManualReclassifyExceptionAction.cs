// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenSuppress("ManualReclassifyExceptionAction", typeof(string))]
    public partial class ManualReclassifyExceptionAction
    {
        /// <summary> Initializes a new instance of ManualReclassifyExceptionAction. </summary>
        /// <param name="id"> Unique Id of the action within the exception rule. </param>
        /// <param name="queueId"> Updated QueueId. </param>
        /// <param name="priority"> Updated Priority. </param>
        /// <param name="workerSelectors"> (Optional) Updated WorkerSelectors. </param>
        public ManualReclassifyExceptionAction(string id, string queueId, int priority, IEnumerable<LabelSelector> workerSelectors = default)
            : this(null, id, queueId, priority, (workerSelectors ?? Array.Empty<LabelSelector>()).ToList())
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
        }
    }
}
