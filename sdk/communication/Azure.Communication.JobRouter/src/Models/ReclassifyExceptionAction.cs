// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("ReclassifyExceptionAction")]
    public partial class ReclassifyExceptionAction
    {
        [CodeGenMember("LabelsToUpsert")]
        internal IDictionary<string, object> _labelsToUpsert
        {
            get
            {
                return LabelsToUpsert != null
                    ? LabelsToUpsert?.ToDictionary(x => x.Key,
                        x => x.Value.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                LabelsToUpsert = LabelCollection.BuildFromRawValues(value);
            }
        }

        /// <summary>
        /// (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs
        /// </summary>
        public LabelCollection LabelsToUpsert { get; set; }

        /// <summary> Initializes a new instance of ReclassifyExceptionAction. </summary>
        /// <param name="classificationPolicyId"> (optional) The new classification policy that will determine queue, priority and worker selectors. </param>
        /// <param name="labelsToUpsert"> (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs. </param>
        public ReclassifyExceptionAction(string classificationPolicyId, LabelCollection labelsToUpsert = default)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            ClassificationPolicyId = classificationPolicyId;
            LabelsToUpsert = labelsToUpsert;
        }
    }
}
