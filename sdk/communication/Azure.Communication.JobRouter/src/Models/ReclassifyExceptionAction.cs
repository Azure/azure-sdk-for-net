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
        [CodeGenMember("LabelsToUpsert")]
        internal IDictionary<string, object> _labelsToUpsert
        {
            get
            {
                return LabelsToUpsert != null && LabelsToUpsert.Count != 0
                    ? LabelsToUpsert?.ToDictionary(x => x.Key, x => x.Value.As<object>())
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                LabelsToUpsert = value != null && value.Count != 0
                    ? value.ToDictionary(x => x.Key, x => new Value(x.Value))
                    : new Dictionary<string, Value>();
            }
        }

        /// <summary>
        /// (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IDictionary<string, Value> LabelsToUpsert { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

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
