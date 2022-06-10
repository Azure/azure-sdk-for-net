// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ReclassifyExceptionAction
    {
        [CodeGenMember("LabelsToUpsert")]
        internal IDictionary<string, object> _labelsToUpsert
        {
            get
            {
                return LabelsToUpsert?.ToDictionary(x => x.Key, x => x.Value);
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
    }
}
