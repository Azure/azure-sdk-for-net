// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> This class contains the Learning Settings information and the results of the Offline Evaluation using that policy. </summary>
    [CodeGenModel("PolicyResult")]
    public partial class PersonalizerPolicyResult
    {
        /// <summary> The aggregate total of the Offline Evaluation. </summary>
        public PersonalizerPolicyResultSummary TotalSummary { get; }
    }
}
