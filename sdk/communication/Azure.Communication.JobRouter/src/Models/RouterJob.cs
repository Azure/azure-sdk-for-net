// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("RouterJob")]
    public partial class RouterJob
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
    }
}
