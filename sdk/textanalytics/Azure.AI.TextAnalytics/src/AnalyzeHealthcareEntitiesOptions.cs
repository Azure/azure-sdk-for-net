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
        /// Optional display name for the operation.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/>, and newer.
        /// </remarks>
        public string DisplayName { get; set; }

        /// <summary>
        /// The version of the FHIR specification that will be used to format the <see cref="AnalyzeHealthcareEntitiesResult.FhirBundle"/>
        /// in the result. If not set, the <see cref="AnalyzeHealthcareEntitiesResult.FhirBundle"/> will not be produced. For additional information, see
        /// <see href="https://www.hl7.org/fhir/overview.html"/>.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview"/>, and newer.
        /// </remarks>
        public WellKnownFhirVersion? FhirVersion { get; set; }

        /// <inheritdoc/>
        internal override void CheckSupported(TextAnalyticsClientOptions.ServiceVersion current)
        {
            base.CheckSupported(current);
            Validation.SupportsProperty(this, DisplayName, nameof(DisplayName), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, current);
            Validation.SupportsProperty(this, FhirVersion, nameof(FhirVersion), TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview, current);
        }
    }
}
