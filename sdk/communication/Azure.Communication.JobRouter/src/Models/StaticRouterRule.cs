// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("StaticRouterRule")]
    public partial class StaticRouterRule : RouterRule
    {
        /// <summary> The static value this rule always returns. </summary>
        public LabelValue Value { get; set; }

        [CodeGenMember("Value")]
        internal BinaryData _value {
            get
            {
                return BinaryData.FromObjectAsJson(Value.Value);
            }
            set
            {
                Value = new LabelValue(value.ToObjectFromJson());
            }
        }

        /// <summary> Initializes a new instance of StaticRule. </summary>
        /// <param name="value"> The static value this rule always returns. </param>
        public StaticRouterRule(LabelValue value) : this(null, BinaryData.FromObjectAsJson(value.Value))
        {
            Kind = "static-rule";
        }
    }
}
