// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Gets the healthcare entity category inferred by the Text Analytics for Heatlh named entity recognition model.
    /// </summary>
    [CodeGenModel("HealthcareEntityCategory")]
    public partial struct HealthcareEntityCategory
    {
        /// <summary> Age. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HealthcareEntityCategory AGE { get; } = new HealthcareEntityCategory(AgeValue);

        /// <summary> GeneOrProtein. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HealthcareEntityCategory GeneORProtein { get; } = new HealthcareEntityCategory(GeneOrProteinValue);

        /// <summary> SymptomOrSign. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HealthcareEntityCategory SymptomORSign { get; } = new HealthcareEntityCategory(SymptomOrSignValue);
    }
}
