// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("StaticRule")]
    public partial class StaticRule : RouterRule
    {
        /// <summary> Initializes a new instance of StaticRule. </summary>
        /// <param name="value"> The static value this rule always returns. </param>
        public StaticRule(object value) : this(null, value)
        {
        }
    }
}
