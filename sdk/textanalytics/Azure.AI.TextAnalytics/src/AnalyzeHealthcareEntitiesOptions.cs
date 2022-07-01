// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class AnalyzeHealthcareEntitiesOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeHealthcareEntitiesOptions"/>
        /// class.
        /// </summary>
        public AnalyzeHealthcareEntitiesOptions()
        {
        }

        /// <summary>
        /// The FHIR Spec version that the result will use to format the <see cref="AnalyzeHealthcareEntitiesResult.FhirBundle"/>
        /// on the result object. For additional information see <see href="https://www.hl7.org/fhir/overview.html"/> .
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_04_01_Preview"/> and up.
        /// </remarks>
        public FhirVersion? FhirVersion { get; set; }
    }
}
