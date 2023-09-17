// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("ScoringRuleOptions")]
    public partial class ScoringRuleOptions
    {
        internal ScoringRuleOptions()
        {
            ScoringParameters = new ChangeTrackingList<ScoringRuleParameterSelector>();
        }

        /// <summary>
        /// (Optional) List of extra parameters from the job that will be sent as part of the payload to scoring rule.
        /// If not set, the job&apos;s labels (sent in the payload as `job`) and the job&apos;s worker selectors (sent in the payload as `selectors`)
        /// are added to the payload of the scoring rule by default.
        /// Note: Worker labels are always sent with scoring payload.
        /// </summary>
        public IList<ScoringRuleParameterSelector> ScoringParameters { get; }
    }
}
