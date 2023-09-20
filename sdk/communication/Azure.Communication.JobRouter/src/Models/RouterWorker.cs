// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            _queueAssignments = new ChangeTrackingDictionary<string, BinaryData>();
            _labels = new ChangeTrackingDictionary<string, BinaryData>();
            _tags = new ChangeTrackingDictionary<string, BinaryData>();
            _channelConfigurations = new ChangeTrackingDictionary<string, ChannelConfiguration>();
            Offers = new ChangeTrackingList<RouterJobOffer>();
            AssignedJobs = new ChangeTrackingList<RouterWorkerAssignment>();
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, LabelValue> Labels { get; } = new Dictionary<string, LabelValue>();

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
        public IDictionary<string, LabelValue> Tags { get; } = new Dictionary<string, LabelValue>();

        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IDictionary<string, ChannelConfiguration> ChannelConfigurations { get; } = new Dictionary<string, ChannelConfiguration>();

        /// <summary> The queue(s) that this worker can receive work from. </summary>
        public IDictionary<string, RouterQueueAssignment> QueueAssignments { get; } = new Dictionary<string, RouterQueueAssignment>();

        /// <summary> The total capacity score this worker has to manage multiple concurrent jobs. </summary>
        public int? TotalCapacity { get; internal set; }

        /// <summary> A flag indicating this worker is open to receive offers or not. </summary>
        public bool? AvailableForOffers { get; internal set; }

        [CodeGenMember("Labels")]
        internal IDictionary<string, BinaryData> _labels
        {
            get
            {
                return Labels != null && Labels.Count != 0
                    ? Labels?.ToDictionary(x => x.Key, x => BinaryData.FromObjectAsJson(x.Value?.Value))
                    : new ChangeTrackingDictionary<string, BinaryData>();
            }
            set
            {
                if (value != null && value.Count != 0)
                {
                    foreach (var label in value)
                    {
                        Labels[label.Key] = new LabelValue(label.Value.ToObjectFromJson());
                    }
                }
            }
        }

        [CodeGenMember("Tags")]
        internal IDictionary<string, BinaryData> _tags
        {
            get
            {
                return Tags != null && Tags.Count != 0
                    ? Tags?.ToDictionary(x => x.Key, x => BinaryData.FromObjectAsJson(x.Value?.Value))
                    : new ChangeTrackingDictionary<string, BinaryData>();
            }
            set
            {
                if (value != null && value.Count != 0)
                {
                    foreach (var tag in value)
                    {
                        Tags[tag.Key] = new LabelValue(tag.Value);
                    }
                }
            }
        }

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
        internal IDictionary<string, BinaryData> _queueAssignments
        {
            get
            {
                return QueueAssignments != null
                    ? QueueAssignments.ToDictionary(x => x.Key,
                        x => BinaryData.FromObjectAsJson( new {}))
                    : new ChangeTrackingDictionary<string, BinaryData>();
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
