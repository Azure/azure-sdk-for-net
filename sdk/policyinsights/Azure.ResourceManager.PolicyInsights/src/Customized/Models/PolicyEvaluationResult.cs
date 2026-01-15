// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PolicyInsights.Models
{
    public partial class PolicyEvaluationResult
    {
        /// <summary> The detailed results of the policy expressions and values that were evaluated. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PolicyEvaluationDetails EvaluationDetails
        {
            get
            {
                return CheckRestrictionEvaluationDetails != null
                    ? new PolicyEvaluationDetails(CheckRestrictionEvaluationDetails.EvaluatedExpressions, CheckRestrictionEvaluationDetails.IfNotExistsDetails, null)
                    : null;
            }
        }
    }
}
