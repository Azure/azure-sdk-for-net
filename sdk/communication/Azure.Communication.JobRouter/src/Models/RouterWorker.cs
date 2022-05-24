// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
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

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public LabelCollection Labels { get; set; }

        [CodeGenMember("Tags")]
        internal IDictionary<string, object> _tags
        {
            get
            {
                return Tags?.ToDictionary(x => x.Key, x => x.Value);
            }
            set
            {
                Tags = LabelCollection.BuildFromRawValues(value);
            }
        }

        /// <summary>
        /// A set of non-identifying attributes attached to this worker.
        /// </summary>
        public LabelCollection Tags { get; set; }

        /// <summary> The channel(s) this worker can handle and their impact on the workers capacity. </summary>
        [CodeGenMember("ChannelConfigurations")]
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, ChannelConfiguration> ChannelConfigurations { get; set; }

        [CodeGenMember("QueueAssignments")]
        internal IDictionary<string, object> _queueAssignments
        {
            get
            {
                return QueueAssignments.ToDictionary(x => x.Key, x => (object)x.Value);
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
