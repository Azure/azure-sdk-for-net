// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class MultiLabelClassifyOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiLabelClassifyOptions"/>
        /// class.
        /// </summary>
        public MultiLabelClassifyOptions()
        {
        }

        /// <summary>
        /// Gets or sets a value that, if set to true, indicates that the service
        /// should return document and document batch statistics with the results
        /// of the operation.
        /// Returns data for batch document methods only.
        /// </summary>
        public bool? IncludeStatistics { get; set; }

        /// <summary>
        /// The default value of this property is <c>false</c>.
        /// This means that the Language service logs your input text for 48 hours solely to allow for troubleshooting issues.
        /// Setting this property to <c>true</c> disables input logging and may limit our ability to investigate issues that occur.
        /// <para>
        /// Please see Cognitive Services Compliance and Privacy notes at <see href="https://aka.ms/cs-compliance"/> for additional details,
        /// and Microsoft Responsible AI principles at <see href="https://www.microsoft.com/ai/responsible-ai"/>.
        /// </para>
        /// </summary>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// Optional display name for the operation.
        /// </summary>
        public string DisplayName { get; set; }
    }
}
