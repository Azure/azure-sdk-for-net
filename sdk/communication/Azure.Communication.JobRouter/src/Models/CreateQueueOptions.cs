// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for creating a job queue.
    /// </summary>
    public class CreateQueueOptions
    {
        /// <summary> The name of this queue. </summary>
        public string Name { get; set; }
        /// <summary> (Optional) The ID of the exception policy that determines various job escalation rules. </summary>
        public string ExceptionPolicyId { get; set; }
        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public LabelCollection Labels { get; set; }
    }
}
