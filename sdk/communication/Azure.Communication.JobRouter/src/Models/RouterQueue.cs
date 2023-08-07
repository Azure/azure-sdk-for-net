// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("RouterQueue")]
    public partial class RouterQueue
    {
        /// <summary> Initializes a new instance of JobQueue. </summary>
        internal RouterQueue()
        {
            Labels = new ChangeTrackingDictionary<string, Value>();
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        [CodeGenMember("Labels")]
        public IDictionary<string, Value> Labels { get; }

        /// <summary> The name of this queue. </summary>
        public string Name { get; internal set; }

        /// <summary> The ID of the distribution policy that will determine how a job is distributed to workers. </summary>
        public string DistributionPolicyId { get; internal set; }

        /// <summary> (Optional) The ID of the exception policy that determines various job escalation rules. </summary>
        public string ExceptionPolicyId { get; internal set; }
    }
}
