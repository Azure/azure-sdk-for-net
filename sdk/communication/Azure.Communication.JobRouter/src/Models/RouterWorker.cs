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
                return Labels != null && Labels.Count != 0
                    ? Labels?.ToDictionary(x => x.Key,
                        x => x.Value.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                Labels = value != null && value.Count != 0
                    ? value.ToDictionary(x => x.Key, x => new LabelValue(x.Value))
                    : new Dictionary<string, LabelValue>();
            }
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, LabelValue> Labels { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        [CodeGenMember("Tags")]
        internal IDictionary<string, object> _tags
        {
            get
            {
                return Tags != null && Tags.Count != 0
                    ? Tags?.ToDictionary(x => x.Key,
                        x => x.Value.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                Tags = value != null && value.Count != 0
                    ? value.ToDictionary(x => x.Key, x => new LabelValue(x.Value))
                    : new Dictionary<string, LabelValue>();
            }
        }

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, LabelValue> Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        [CodeGenMember("ChannelConfigurations")]
#pragma warning disable CA2227 // Collection properties should be read only
        internal IDictionary<string, ChannelConfiguration> _channelConfigurations {
            get
            {
                return ChannelConfigurations ?? new ChangeTrackingDictionary<string, ChannelConfiguration>();
            }
            set
            {
                ChannelConfigurations = value;
            }
        }

        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IDictionary<string, ChannelConfiguration> ChannelConfigurations { get; set; }

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
                QueueAssignments = value.ToDictionary(x => x.Key, x => new QueueAssignment());
            }
        }

        /// <summary> The queue(s) that this worker can receive work from. </summary>
        public IDictionary<string, QueueAssignment> QueueAssignments { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
