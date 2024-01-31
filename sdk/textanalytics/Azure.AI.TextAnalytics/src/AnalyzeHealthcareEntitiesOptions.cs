// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        /// <inheritdoc/>
        internal override void CheckSupported(TextAnalyticsClientOptions.ServiceVersion current)
        {
            base.CheckSupported(current);
            Validation.SupportsProperty(this, DisplayName, nameof(DisplayName), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, current);
        }
    }
}
