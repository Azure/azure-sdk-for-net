// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("RouterJob")]
    [CodeGenSuppress("RouterJob")]
    public partial class RouterJob
    {
        /// <summary> Initializes a new instance of RouterJob. </summary>
        internal RouterJob()
        {
            _requestedWorkerSelectors = new ChangeTrackingList<WorkerSelector>();
            AttachedWorkerSelectors = new ChangeTrackingList<WorkerSelector>();
            _labels = new ChangeTrackingDictionary<string, object>();
            Assignments = new ChangeTrackingDictionary<string, JobAssignment>();
            _tags = new ChangeTrackingDictionary<string, object>();
            _notes = new ChangeTrackingDictionary<string, string>();
        }

        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels != null && Labels.Count != 0
                    ? Labels?.ToDictionary(x => x.Key, x => x.Value.Value)
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

        /// <summary> A set of non-identifying attributes attached to this job. </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, LabelValue> Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        [CodeGenMember("Notes")]
        internal IDictionary<string, string> _notes
        {
            get
            {
                return Notes != null
                    ? Notes?.ToDictionary(x => x.Key.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture),
                        x => x.Value)
                    : new ChangeTrackingDictionary<string, string>();
            }
            set
            {
                Notes = new SortedDictionary<DateTimeOffset, string>(
                    value.ToDictionary(x => DateTimeOffsetParser.ParseAndGetDateTimeOffset(x.Key), x => x.Value));
            }
        }

        /// <summary> Notes attached to a job, sorted by timestamp. </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public SortedDictionary<DateTimeOffset, string> Notes { get; set; }

        /// <summary> A collection of manually specified label selectors, which a worker must satisfy in order to process this job. </summary>
        public IList<WorkerSelector> RequestedWorkerSelectors { get; set; }

        [CodeGenMember("RequestedWorkerSelectors")]
        internal IList<WorkerSelector> _requestedWorkerSelectors {
            get
            {
                return RequestedWorkerSelectors != null ? RequestedWorkerSelectors.ToList() : new ChangeTrackingList<WorkerSelector>();
            }
            set
            {
                RequestedWorkerSelectors = value;
            } }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
