// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
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

        public LabelCollection LabelsToUpsert { get; set; }
    }
}
