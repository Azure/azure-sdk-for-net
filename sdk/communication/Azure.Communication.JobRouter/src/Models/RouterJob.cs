// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("RouterJob")]
    [CodeGenSuppress("RouterJob")]
    public partial class RouterJob
    {
        /// <summary> Initializes a new instance of RouterJob. </summary>
        internal RouterJob()
        {
            AttachedWorkerSelectors = new ChangeTrackingList<RouterWorkerSelector>();
            Assignments = new ChangeTrackingDictionary<string, RouterJobAssignment>();
            _requestedWorkerSelectors = new ChangeTrackingList<RouterWorkerSelector>();
            _labels = new ChangeTrackingDictionary<string, BinaryData>();
            _tags = new ChangeTrackingDictionary<string, BinaryData>();
            _notes = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public Dictionary<string, LabelValue> Labels { get; } = new Dictionary<string, LabelValue>();

        /// <summary> A set of non-identifying attributes attached to this job. </summary>
        public Dictionary<string, LabelValue> Tags { get; } = new Dictionary<string, LabelValue>();

        /// <summary> A collection of manually specified label selectors, which a worker must satisfy in order to process this job. </summary>
        public List<RouterWorkerSelector> RequestedWorkerSelectors { get; } = new List<RouterWorkerSelector>();

        /// <summary> A collection of notes attached to a job. </summary>
        public List<RouterJobNote> Notes { get; } = new List<RouterJobNote>();

        /// <summary> Reference to an external parent context, eg. call ID. </summary>
        public string ChannelReference { get; internal set; }

        /// <summary> The channel identifier. eg. voice, chat, etc. </summary>
        public string ChannelId { get; internal set; }

        /// <summary> The Id of the Classification policy used for classifying a job. </summary>
        public string ClassificationPolicyId { get; internal set; }

        /// <summary> The Id of the Queue that this job is queued to. </summary>
        public string QueueId { get; internal set; }

        /// <summary> The priority of this job. </summary>
        public int? Priority { get; internal set; }

        /// <summary> Reason code for cancelled or closed jobs. </summary>
        public string DispositionCode { get; internal set; }

        /// <summary> Gets or sets the matching mode. </summary>
        public JobMatchingMode MatchingMode { get; internal set; }

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
                        Labels[label.Key] = new LabelValue(label.Value);
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

        [CodeGenMember("Notes")]
        internal IDictionary<string, string> _notes
        {
            get
            {
                return Notes != null && Notes.Count != 0
                    ? Notes?.ToDictionary(x => (x.AddedAt ?? DateTimeOffset.UtcNow)
                        .ToUniversalTime().ToString("O", CultureInfo.InvariantCulture), x => x.Message)
                    : new ChangeTrackingDictionary<string, string>();
            }
            set
            {
                foreach (var note in value.ToList())
                {
                    Notes.Add(new RouterJobNote
                    {
                        AddedAt = DateTimeOffsetParser.ParseAndGetDateTimeOffset(note.Key),
                        Message = note.Value
                    });
                }
            }
        }

        [CodeGenMember("RequestedWorkerSelectors")]
        internal IList<RouterWorkerSelector> _requestedWorkerSelectors
        {
            get
            {
                return RequestedWorkerSelectors != null && RequestedWorkerSelectors.Any()
                    ? RequestedWorkerSelectors.ToList()
                    : new ChangeTrackingList<RouterWorkerSelector>();
            }
            set
            {
                RequestedWorkerSelectors.AddRange(value);
            }
        }
    }
}
