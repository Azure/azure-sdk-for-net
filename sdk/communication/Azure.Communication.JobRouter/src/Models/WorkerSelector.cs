// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("WorkerSelector")]
    [CodeGenSuppress("WorkerSelector", typeof(string), typeof(LabelOperator))]
    public partial class WorkerSelector
    {
        /// <summary> Describes how long this label selector is valid in seconds. </summary>
        public TimeSpan? Ttl { get; set; }

        [CodeGenMember("TtlSeconds")]
        internal double? _ttlSeconds {
            get
            {
                return Ttl?.TotalSeconds is null or 0 ? null : Ttl?.TotalSeconds;
            }
            set
            {
                Ttl = value != null ? TimeSpan.FromSeconds(value.Value) : null;
            }
        }

        [CodeGenMember("Value")]
        private object _value
        {
            get
            {
                return Value.Value;
            }
            set
            {
                Value = new LabelValue(value);
            }
        }

        /// <summary> The value to compare against the actual label value with the given operator. </summary>
        public LabelValue Value { get; set; }

        /// <summary> Initializes a new instance of WorkerSelector. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value defined on the label selector. </param>
        /// <param name="value"> The value to compare against the actual label value with the given operator. </param>
        /// <param name="ttl"> Describes how long this label selector is valid. </param>
        /// <param name="expedite"> Pushes the job to the front of the queue as long as this selector is active. </param>
        public WorkerSelector(string key, LabelOperator labelOperator, LabelValue value, TimeSpan? ttl = default, bool? expedite = default)
        {
            Key = key;
            LabelOperator = labelOperator;
            Value = value;
            Ttl = ttl;
            Expedite = expedite;
        }
    }
}
