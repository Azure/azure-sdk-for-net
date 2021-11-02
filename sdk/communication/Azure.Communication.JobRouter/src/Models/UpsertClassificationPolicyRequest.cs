// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter.Models
{
    internal partial class UpsertClassificationPolicyRequest
    {
        /// <summary> The rules to attach worker label selectors to a given job. </summary>
        public IEnumerable<LabelSelectorAttachment> WorkerSelectors { get; set; }
    }
}
