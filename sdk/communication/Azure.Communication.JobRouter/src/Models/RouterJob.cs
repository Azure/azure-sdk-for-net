// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RouterJob
    {
        /// <summary> Initializes a new instance of a job. </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public RouterJob(string jobId)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Id = jobId;

            _labels = new ChangeTrackingDictionary<string, BinaryData>();
            _tags = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> Labels { get; } = new Dictionary<string, RouterValue>();

        /// <summary> A set of non-identifying attributes attached to this job. Values must be primitive values - number, string, boolean. </summary>
        public IDictionary<string, RouterValue> Tags { get; } = new Dictionary<string, RouterValue>();

        /// <summary> A collection of manually specified worker selectors, which a worker must satisfy in order to process this job. </summary>
        public IList<RouterWorkerSelector> RequestedWorkerSelectors { get; } = new List<RouterWorkerSelector>();

        /// <summary> A collection of notes attached to a job. </summary>
        public IList<RouterJobNote> Notes { get; } = new List<RouterJobNote>();

        /// <summary> Reference to an external parent context, eg. call ID. </summary>
        public string ChannelReference { get; set; }

        /// <summary> The channel identifier. eg. voice, chat, etc. </summary>
        public string ChannelId { get; set; }

        /// <summary> Id of a classification policy used for classifying this job. </summary>
        public string ClassificationPolicyId { get; set; }

        /// <summary> Id of a queue that this job is queued to. </summary>
        public string QueueId { get; set; }

        /// <summary> The priority of this job. </summary>
        public int? Priority { get; set; }

        /// <summary> Indicates the outcome of a job, populate this field with your own custom values. </summary>
        public string DispositionCode { get; set; }

        /// <summary> If provided, will determine how job matching will be carried out. Default mode: QueueAndMatchMode. </summary>
        public JobMatchingMode MatchingMode { get; set; }

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
