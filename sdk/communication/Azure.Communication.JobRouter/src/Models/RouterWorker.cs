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
        /// <summary> Initializes a new instance of RouterWorker. </summary>
        internal RouterWorker()
        {
            _queueAssignments = new ChangeTrackingDictionary<string, object>();
            Labels = new ChangeTrackingDictionary<string, Value>();
            Tags = new ChangeTrackingDictionary<string, Value>();
            _channelConfigurations = new ChangeTrackingDictionary<string, ChannelConfiguration>();
            Offers = new ChangeTrackingList<RouterJobOffer>();
            AssignedJobs = new ChangeTrackingList<RouterWorkerAssignment>();
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        [CodeGenMember("Labels")]
        public IDictionary<string, Value> Labels { get; }

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
        [CodeGenMember("Tags")]
        public IDictionary<string, Value> Tags { get; }

        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IDictionary<string, ChannelConfiguration> ChannelConfigurations { get; } = new Dictionary<string, ChannelConfiguration>();

        /// <summary> The queue(s) that this worker can receive work from. </summary>
        public IDictionary<string, RouterQueueAssignment> QueueAssignments { get; } = new Dictionary<string, RouterQueueAssignment>();

        /// <summary> The total capacity score this worker has to manage multiple concurrent jobs. </summary>
        public int? TotalCapacity { get; internal set; }

        /// <summary> A flag indicating this worker is open to receive offers or not. </summary>
        public bool? AvailableForOffers { get; internal set; }

        [CodeGenMember("ChannelConfigurations")]
        internal IDictionary<string, ChannelConfiguration> _channelConfigurations {
            get
            {
                return ChannelConfigurations ?? new ChangeTrackingDictionary<string, ChannelConfiguration>();
            }
            set
            {
                foreach (var channelConfiguration in value)
                {
                    ChannelConfigurations[channelConfiguration.Key] = new ChannelConfiguration(channelConfiguration.Value.CapacityCostPerJob)
                    {
                        MaxNumberOfJobs = channelConfiguration.Value.MaxNumberOfJobs
                    };
                }
            }
        }

        [CodeGenMember("QueueAssignments")]
        internal IDictionary<string, object> _queueAssignments
        {
            get
            {
                return QueueAssignments != null
                    ? QueueAssignments.ToDictionary(x => x.Key,
                        x => (object)x.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                foreach (var queueAssignment in value)
                {
                    QueueAssignments[queueAssignment.Key] = new RouterQueueAssignment();
                }
            }
        }
    }
}
