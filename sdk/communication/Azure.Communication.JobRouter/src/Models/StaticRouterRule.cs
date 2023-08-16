// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("StaticRouterRule")]
    [CodeGenSuppress("StaticRouterRule")]
    public partial class StaticRouterRule : RouterRule
    {
        /// <summary> The static value this rule always returns. </summary>
        public Value Value { get; set; }

        [CodeGenMember("Value")]
        internal object _value {
            get
            {
                return Value.As<object>();
            }
            set
            {
                Value = new Value(value);
            }
        }

        /// <summary> Initializes a new instance of StaticRule. </summary>
        /// <param name="value"> The static value this rule always returns. </param>
        public StaticRouterRule(Value value) : this(null, value.As<object>())
        {
        }
    }
}
