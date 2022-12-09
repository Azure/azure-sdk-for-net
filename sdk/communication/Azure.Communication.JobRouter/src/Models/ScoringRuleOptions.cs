// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    public partial class ScoringRuleOptions
    {
        /// <summary>
        /// (Optional) List of extra parameters from the job that will be sent as part of the payload to scoring rule.
        /// If not set, the job&apos;s labels (sent in the payload as `job`) and the job&apos;s worker selectors (sent in the payload as `selectors`)
        /// are added to the payload of the scoring rule by default.
        /// Note: Worker labels are always sent with scoring payload.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<ScoringRuleParameterSelector> ScoringParameters { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
