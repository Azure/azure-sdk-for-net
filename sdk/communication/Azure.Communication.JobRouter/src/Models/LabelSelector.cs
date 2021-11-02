// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("LabelSelector")]
    [CodeGenSuppress("LabelSelector", typeof(string), typeof(LabelOperator))]
    public partial class LabelSelector
    {
        public LabelSelector(string key, LabelOperator @operator, object value = null, TimeSpan? ttl = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            Key = key;
            Operator = @operator;
            Value = value;
            Ttl = ttl;
        }
        /// <summary> Describes how long this label selector is valid. </summary>
        public TimeSpan? Ttl { get; set; }
    }
}
