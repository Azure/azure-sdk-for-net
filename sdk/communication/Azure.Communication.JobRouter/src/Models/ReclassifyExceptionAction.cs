// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ReclassifyExceptionAction")]
    [CodeGenSuppress("ReclassifyExceptionAction")]
    public partial class ReclassifyExceptionAction
    {
        /// <summary>
        /// (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs
        /// </summary>
        [CodeGenMember("LabelsToUpsert")]
        public IDictionary<string, Value> LabelsToUpsert { get; set; }

        /// <summary> Initializes a new instance of ReclassifyExceptionAction. </summary>
        /// <param name="classificationPolicyId"> (optional) The new classification policy that will determine queue, priority and worker selectors. </param>
        /// <param name="labelsToUpsert"> (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs. </param>
        public ReclassifyExceptionAction(string classificationPolicyId, IDictionary<string, Value> labelsToUpsert = default)
            : this(null, classificationPolicyId, null)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            LabelsToUpsert = labelsToUpsert;
        }
    }
}
