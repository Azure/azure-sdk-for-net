// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.JobRouter
{
    public partial class ManualReclassifyExceptionAction
    {
        /// <summary> Initializes a new instance of ManualReclassifyExceptionAction. </summary>
        public ManualReclassifyExceptionAction()
        {
            Kind = ExceptionActionKind.ManualReclassify;
        }

        /// <summary> Updated QueueId. </summary>
        public string QueueId { get; set; }

        /// <summary> Updated Priority. </summary>
        public int? Priority { get; set; }

        /// <summary> Updated WorkerSelectors. </summary>
        public IList<RouterWorkerSelector> WorkerSelectors { get; } = new List<RouterWorkerSelector>();
    }
}
