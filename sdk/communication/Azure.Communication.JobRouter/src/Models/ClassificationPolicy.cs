// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
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
            _queueSelectors = new ChangeTrackingList<QueueSelectorAttachment>();
            _workerSelectors = new ChangeTrackingList<WorkerSelectorAttachment>();
        }

        [CodeGenMember("QueueSelectors")]
        internal IList<QueueSelectorAttachment> _queueSelectors
        {
            get
            {
                return QueueSelectors != null && QueueSelectors.Any()
                    ? QueueSelectors.ToList()
                    : new ChangeTrackingList<QueueSelectorAttachment>();
            }
            set
            {
                QueueSelectors.AddRange(value);
            }
        }

        [CodeGenMember("WorkerSelectors")]
        internal IList<WorkerSelectorAttachment> _workerSelectors
        {
            get
            {
                return WorkerSelectors != null && WorkerSelectors.Any()
                    ? WorkerSelectors.ToList()
                    : new ChangeTrackingList<WorkerSelectorAttachment>();
            }
            set
            {
                WorkerSelectors.AddRange(value);
            }
        }

        /// <summary> The queue selectors to resolve a queue for a given job. </summary>
        public List<QueueSelectorAttachment> QueueSelectors { get; } = new List<QueueSelectorAttachment>();

        /// <summary> The worker label selectors to attach to a given job. </summary>
        public List<WorkerSelectorAttachment> WorkerSelectors { get; } = new List<WorkerSelectorAttachment>();
    }
}
