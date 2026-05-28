// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class StaticRouterRule
    {
        /// <summary> The static value this rule always returns. Values must be primitive values - number, string, boolean. </summary>
        public RouterValue Value { get; internal set; }

        [CodeGenMember("Value")]
        internal BinaryData _value
        {
            get
            {
                return BinaryData.FromObjectAsJson(Value.Value);
            }
            set
            {
                Value = new RouterValue(value.ToObjectFromJson());
            }
        }

        /// <summary> Initializes a new instance of StaticRule. </summary>
        /// <param name="value"> The static value this rule always returns. Values must be primitive values - number, string, boolean. </param>
        public StaticRouterRule(RouterValue value)
        {
            Kind = RouterRuleKind.Static;

            Value = value;
        }
    }
}
