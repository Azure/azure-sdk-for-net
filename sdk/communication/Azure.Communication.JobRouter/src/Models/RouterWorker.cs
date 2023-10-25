// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("RouterWorker")]
    public partial class RouterWorker : IUtf8JsonSerializable
    {
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
                        Tags[tag.Key] = new LabelValue(tag.Value.ToObjectFromJson());
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
                    ChannelConfigurations[channelConfiguration.Key] = new ChannelConfiguration(channelConfiguration.Value.CapacityCostPerJob, channelConfiguration.Value.MaxNumberOfJobs);
                }
            }
        }

        [CodeGenMember("QueueAssignments")]
        internal IReadOnlyDictionary<string, RouterQueueAssignment> _queueAssignments
        {
            get
            {
                return QueueAssignments != null
                    ? QueueAssignments.ToDictionary(x => x.Key, x => x.Value)
                    : new ChangeTrackingDictionary<string, RouterQueueAssignment>();
            }
            set
            {
                foreach (var queueAssignment in value)
                {
                    QueueAssignments[queueAssignment.Key] = new RouterQueueAssignment();
                }
            }
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(_queueAssignments))
            {
                writer.WritePropertyName("queueAssignments"u8);
                writer.WriteStartObject();
                foreach (var item in _queueAssignments)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(TotalCapacity))
            {
                writer.WritePropertyName("totalCapacity"u8);
                writer.WriteNumberValue(TotalCapacity.Value);
            }
            if (Optional.IsCollectionDefined(_labels))
            {
                writer.WritePropertyName("labels"u8);
                writer.WriteStartObject();
                foreach (var item in _labels)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue(item.Value.ToObjectFromJson());
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(_tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in _tags)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue(item.Value.ToObjectFromJson());
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(_channelConfigurations))
            {
                writer.WritePropertyName("channelConfigurations"u8);
                writer.WriteStartObject();
                foreach (var item in _channelConfigurations)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(AvailableForOffers))
            {
                writer.WritePropertyName("availableForOffers"u8);
                writer.WriteBooleanValue(AvailableForOffers.Value);
            }
            writer.WriteEndObject();
        }

        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
