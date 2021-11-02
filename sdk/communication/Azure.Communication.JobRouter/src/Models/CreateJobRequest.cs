// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("CreateJobRequest")]
    internal partial class CreateJobRequest
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

        public LabelCollection Labels { get; set; }
        /// <summary> A collection of label selectors a worker must satisfy in order to process this job. </summary>
        public IEnumerable<LabelSelector> WorkerSelectors { get; set; }
    }
}
