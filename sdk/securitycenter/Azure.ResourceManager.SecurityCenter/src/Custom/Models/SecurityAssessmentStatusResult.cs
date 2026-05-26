// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserve the GA response model constructor and legacy FirstEvaluatedOn property name.
    public partial class SecurityAssessmentStatusResult
    {
        /// <summary> Initializes a new instance of <see cref="SecurityAssessmentStatusResult"/>. </summary>
        /// <param name="code"> Programmatic code for the status of the assessment. </param>
        public SecurityAssessmentStatusResult(SecurityAssessmentStatusCode code)
            : base(code)
        {
        }

        /// <summary> The time that the assessment was created and first evaluated. Returned as UTC time in ISO 8601 format. </summary>
        public System.DateTimeOffset? FirstEvaluatedOn => FirstEvaluationOn;
    }
}
