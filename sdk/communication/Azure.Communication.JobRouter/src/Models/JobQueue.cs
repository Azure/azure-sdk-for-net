// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("JobQueue")]
    public partial class JobQueue
    {
        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels?.ToDictionary(x => x.Key, x => x.Value);
            }
            set
            {
                Labels = LabelCollection.BuildFromRawValues(value);
            }
        }

        internal JobQueue(string id, string name, string distributionPolicyId, LabelCollection labels, string exceptionPolicyId)
        {
            Id = id;
            Name = name;
            DistributionPolicyId = distributionPolicyId;
            Labels = labels;
            ExceptionPolicyId = exceptionPolicyId;
        }

        public LabelCollection Labels { get; set; }
    }
}
