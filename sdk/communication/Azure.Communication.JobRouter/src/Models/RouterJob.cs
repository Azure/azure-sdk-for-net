// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("RouterJob")]
    public partial class RouterJob
    {
        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels?.ToDictionary(x => x.Key, x => x.Value);
            }
            set
            {
                Labels = LabelCollection.BuildFromRawValues(value);
            }
        }

        internal RouterJob(string id, string channelReference, JobStatus jobStatus, DateTimeOffset? enqueueTimeUtc, string channelId, string classificationPolicyId, string queueId, int? priority, string dispositionCode, IReadOnlyList<LabelSelector> workerSelectors, LabelCollection labels, IReadOnlyDictionary<string, JobAssignment> assignments, IReadOnlyDictionary<string, string> notes)
        {
            Id = id;
            ChannelReference = channelReference;
            JobStatus = jobStatus;
            EnqueueTimeUtc = enqueueTimeUtc;
            ChannelId = channelId;
            ClassificationPolicyId = classificationPolicyId;
            QueueId = queueId;
            Priority = priority;
            DispositionCode = dispositionCode;
            WorkerSelectors = workerSelectors;
            Labels = labels;
            Assignments = assignments;
            Notes = notes;
        }

        public LabelCollection Labels { get; set; }
    }
}
