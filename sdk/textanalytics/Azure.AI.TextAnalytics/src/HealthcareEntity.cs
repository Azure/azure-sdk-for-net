// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("HealthcareEntity")]
    internal partial class HealthcareEntity : Entity
    {
        [CodeGenMember("IsNegated")]
        internal bool IsNegated { get; }

        [CodeGenMember("Links")]
        internal IReadOnlyList<HealthcareEntityLink> Links { get; }

    }
}
