// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("HealthcareEntity")]
    internal partial class HealthcareEntity
    {
        /// <summary>
        /// IsNegated
        /// </summary>
        [CodeGenMember("IsNegated")]
        public bool IsNegated { get; }

        /// <summary>
        /// Links
        /// </summary>
        [CodeGenMember("Links")]
        public IReadOnlyList<HealthcareEntityLink> Links { get; }

    }
}
