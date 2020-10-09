// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    [CodeGenModel("HealthcareResult")]
    public partial class HealthcareEntititesResult
    {
        /// <summary> Documents. </summary>
        [CodeGenMember("Documents")]
        public IReadOnlyList<DocumentHealthcareEntities> Documents { get; }

        /// <summary> Errors. </summary>
        [CodeGenMember("Errors")]
        internal IReadOnlyList<DocumentError> Errors { get; }

    }
}
