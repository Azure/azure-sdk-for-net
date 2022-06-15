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
    public partial class RouterJob
    {
        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels != null
                    ? Labels?.ToDictionary(x => x.Key,
                        x => x.Value)
                    : new ChangeTrackingDictionary<string, object>();
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
                return Tags != null
                    ? Tags?.ToDictionary(x => x.Key,
                        x => x.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                Tags = LabelCollection.BuildFromRawValues(value);
            }
        }

        /// <summary> A set of non-identifying attributes attached to this job. </summary>
        public LabelCollection Tags { get; set; }

        [CodeGenMember("Notes")]
        internal IDictionary<string, string> _notes
        {
            get
            {
                return Notes != null
                    ? Notes?.ToDictionary(x => x.Key.ToString("O", CultureInfo.InvariantCulture),
                        x => x.Value)
                    : new ChangeTrackingDictionary<string, string>();
            }
            set
            {
                Notes = new SortedDictionary<DateTimeOffset, string>(
                    value.ToDictionary(x => DateTimeOffset.ParseExact(x.Key, "O", CultureInfo.InvariantCulture), x => x.Value));
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
