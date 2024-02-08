// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RouterWorker
    {
        /// <summary> Initializes a new instance of a worker. </summary>
        /// <param name="workerId"> Id of a worker. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        public RouterWorker(string workerId)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));

            Id = workerId;

            _labels = new ChangeTrackingDictionary<string, BinaryData>();
            _tags = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> Labels { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// A set of non-identifying attributes attached to this worker. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> Tags { get; } = new Dictionary<string, RouterValue>();

        /// <summary> Collection of channel(s) this worker can handle and their impact on the workers capacity. </summary>
        public IList<RouterChannel> Channels { get; } = new List<RouterChannel>();

        /// <summary> Collection of queue(s) that this worker can receive work from. </summary>
        public IList<string> Queues { get; } = new List<string>();

        /// <summary> The total capacity score this worker has to manage multiple concurrent jobs. </summary>
        public int? Capacity { get; set; }

        /// <summary> A flag indicating whether this worker is open to receive offers or not. </summary>
        public bool? AvailableForOffers { get; set; }

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
                        Labels[label.Key] = new RouterValue(label.Value.ToObjectFromJson());
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
                        Tags[tag.Key] = new RouterValue(tag.Value.ToObjectFromJson());
                    }
                }
            }
        }

        /// <summary> The entity tag for this resource. </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; }

        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
