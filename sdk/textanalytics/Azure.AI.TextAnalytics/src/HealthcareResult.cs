// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("HealthcareResult")]
    public partial class HealthcareResult
    {
        [CodeGenMember("Documents")]
        internal IReadOnlyList<DocumentHealthcareEntities> Documents { get; }

        [CodeGenMember("Errors")]
        internal IReadOnlyList<DocumentError> Errors { get; }

    }
}
