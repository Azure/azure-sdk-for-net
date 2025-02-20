// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ReclassifyExceptionAction
    {
        /// <summary> Initializes a new instance of CancelExceptionAction. </summary>
        public ReclassifyExceptionAction()
        {
            Kind = ExceptionActionKind.Reclassify;
            _labelsToUpsert = new ChangeTrackingDictionary<string, BinaryData>();
        }

        [CodeGenMember("LabelsToUpsert")]
        internal IDictionary<string, BinaryData> _labelsToUpsert
        {
            get
            {
                return LabelsToUpsert != null && LabelsToUpsert.Count != 0
                    ? LabelsToUpsert?.ToDictionary(x => x.Key, x => BinaryData.FromObjectAsJson(x.Value?.Value))
                    : new ChangeTrackingDictionary<string, BinaryData>();
            }
            set
            {
                if (value != null && value.Count != 0)
                {
                    foreach (var label in value)
                    {
                        LabelsToUpsert[label.Key] = new RouterValue(label.Value.ToObjectFromJson());
                    }
                }
            }
        }

        /// <summary>
        /// (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> LabelsToUpsert { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// (optional) The new classification policy that will determine queue, priority
        /// and worker selectors.
        /// </summary>
        public string ClassificationPolicyId { get; set; }
    }
}
