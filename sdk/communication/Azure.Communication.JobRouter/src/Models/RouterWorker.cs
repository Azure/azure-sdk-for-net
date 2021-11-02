// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("RouterWorker")]
    public partial class RouterWorker
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

        internal RouterWorker(string id, WorkerState state, IReadOnlyList<QueueAssignment> queueAssignments, int totalCapacity, LabelCollection labels, IReadOnlyList<ChannelConfiguration> channelConfigurations, IReadOnlyList<JobOffer> offers, IReadOnlyList<WorkerAssignment> assignedJobs)
        {
            Id = id;
            State = state;
            QueueAssignments = queueAssignments;
            TotalCapacity = totalCapacity;
            Labels = labels;
            ChannelConfigurations = channelConfigurations;
            Offers = offers;
            AssignedJobs = assignedJobs;
        }

        public LabelCollection Labels { get; private set; }
    }
}
