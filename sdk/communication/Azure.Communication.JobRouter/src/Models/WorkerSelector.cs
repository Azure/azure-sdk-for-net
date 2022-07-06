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
    [CodeGenSuppress("WorkerSelector", typeof(string), typeof(LabelOperator), typeof(object))]
    public partial class WorkerSelector
    {
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
        /// <param name="ttlSeconds"> Describes how long this label selector is valid in seconds. </param>
        /// <param name="expedite"> Pushes the job to the front of the queue as long as this selector is active. </param>
        public WorkerSelector(string key, LabelOperator labelOperator, LabelValue value, double? ttlSeconds = default, bool? expedite = default)
        {
            Key = key;
            LabelOperator = labelOperator;
            Value = value;
            TtlSeconds = ttlSeconds;
            Expedite = expedite;
        }

        /// <summary> Initializes a new instance of WorkerSelector. Used for deserializing raw json. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value defined on the label selector. </param>
        /// <param name="value"> The value to compare against the actual label value with the given operator. </param>
        /// <param name="ttlSeconds"> Describes how long this label selector is valid in seconds. </param>
        /// <param name="expedite"> Pushes the job to the front of the queue as long as this selector is active. </param>
        private WorkerSelector(string key, LabelOperator labelOperator, object value, double? ttlSeconds = default, bool? expedite = default)
        {
            Key = key;
            LabelOperator = labelOperator;
            Value = new LabelValue(value);
            TtlSeconds = ttlSeconds;
            Expedite = expedite;
        }
    }
}
