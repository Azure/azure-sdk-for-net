// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating distribution policy.
    /// </summary>
    public class CreateDistributionPolicyOptions
    {
        /// <summary> The human readable name of the policy. </summary>
        public string Name { get; set; }
    }
}
