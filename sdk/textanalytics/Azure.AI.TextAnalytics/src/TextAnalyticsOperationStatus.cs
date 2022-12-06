// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// TextAnalyticsOperationStatus.
    /// </summary>
    [CodeGenModel("State")]
    public partial struct TextAnalyticsOperationStatus
    {
        /// <summary> Rejected </summary>
        public static TextAnalyticsOperationStatus Rejected { get; } = new TextAnalyticsOperationStatus("Rejected");
    }
}
