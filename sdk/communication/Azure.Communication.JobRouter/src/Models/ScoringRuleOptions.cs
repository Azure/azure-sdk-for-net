// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ScoringRuleOptions
    {
        /// <summary> Initializes a new instance of ScoringRuleOptions. </summary>
        public ScoringRuleOptions()
        {
            ScoringParameters = new ChangeTrackingList<ScoringRuleParameterSelector>();
        }

        /// <summary>
        /// List of extra parameters from a job that will be sent as part of the payload to scoring rule.
        /// If not set, a job's labels (sent in the payload as `job`) and a job's worker selectors (sent in the payload as `selectors`) are added to the payload of the scoring rule by default.
        /// Note: Worker labels are always sent with scoring payload.
        /// </summary>
        public IList<ScoringRuleParameterSelector> ScoringParameters { get; } = new List<ScoringRuleParameterSelector>();

        /// <summary>
        /// Set batch size when AllowScoringBatchOfWorkers is set to true.
        /// Defaults to 20 if not configured.
        /// </summary>
        public int? BatchSize { get; set; }

        /// <summary>
        /// If set to true, will score workers in batches, and the parameter name of the worker labels will be sent as `workers`.
        /// By default, set to false and the parameter name for the worker labels will be sent as `worker`.
        /// Note: If enabled, use BatchSize to set batch size.
        /// </summary>
        public bool? IsBatchScoringEnabled { get; set; }

        /// <summary>
        /// If false, will sort scores by ascending order. By default, set to true.
        /// </summary>
        public bool? DescendingOrder { get; set; }
    }
}
