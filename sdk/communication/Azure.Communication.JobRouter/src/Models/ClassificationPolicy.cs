// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("ClassificationPolicy")]
    [CodeGenSuppress("ClassificationPolicy")]
    public partial class ClassificationPolicy
    {
        /// <summary> Initializes a new instance of ClassificationPolicy. </summary>
        internal ClassificationPolicy()
        {
            QueueSelectors = new ChangeTrackingList<QueueSelectorAttachment>();
            WorkerSelectors = new ChangeTrackingList<WorkerSelectorAttachment>();
        }

        /// <summary> The queue selectors to resolve a queue for a given job. </summary>
        [CodeGenMember("QueueSelectors")]
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<QueueSelectorAttachment> QueueSelectors { get; set; }

        /// <summary> The worker label selectors to attach to a given job. </summary>
        [CodeGenMember("WorkerSelectors")]
        public IList<WorkerSelectorAttachment> WorkerSelectors { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
