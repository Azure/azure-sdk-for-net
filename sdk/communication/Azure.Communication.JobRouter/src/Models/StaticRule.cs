// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("StaticRule")]
    [CodeGenSuppress("StaticRule")]
    public partial class StaticRule : RouterRule
    {
        /// <summary> The static value this rule always returns. </summary>
        public LabelValue Value { get; set; }

        [CodeGenMember("Value")]
        internal object _value {
            get
            {
                return Value.Value;
            }
            set
            {
                Value = new LabelValue(value);
            }
        }

        /// <summary> Initializes a new instance of StaticRule. </summary>
        /// <param name="value"> The static value this rule always returns. </param>
        public StaticRule(LabelValue value) : this(null, value.Value)
        {
        }
    }
}
