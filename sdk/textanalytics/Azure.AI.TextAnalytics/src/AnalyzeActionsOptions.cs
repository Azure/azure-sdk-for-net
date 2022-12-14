// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// <para>For example, whether to include statistics.</para>
    /// </summary>
    public class AnalyzeActionsOptions : IModelValidator
    {
        /// <summary>
        /// Gets or sets a value that, if set to true, indicates that the service
        /// should return statistics with the results of the operation.
        /// </summary>
        public bool? IncludeStatistics { get; set; }

        /// <summary>
        /// The two-letter ISO 639-1 representation of the default language to consider for automatic language
        /// detection (for example, "en" for English or "fr" for French).
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview"/>, and newer.
        /// </remarks>
        public string AutoDetectionDefaultLanguage { get; set; }

        /// <summary>
        /// Checks that the specified <see cref="TextAnalyticsClientOptions.ServiceVersion"/> supports all properties set within this model.
        /// </summary>
        /// <param name="current">The current <see cref="TextAnalyticsClientOptions.ServiceVersion"/> used by the <see cref="TextAnalyticsClient"/>.</param>
        internal void CheckSupported(TextAnalyticsClientOptions.ServiceVersion current)
        {
            Validation.SupportsProperty(this, AutoDetectionDefaultLanguage, nameof(AutoDetectionDefaultLanguage), TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview, current);
        }

        void IModelValidator.CheckSupported(TextAnalyticsClientOptions.ServiceVersion current) => CheckSupported(current);
    }
}
