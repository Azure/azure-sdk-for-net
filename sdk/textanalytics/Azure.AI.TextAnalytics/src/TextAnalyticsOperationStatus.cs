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
        [CodeGenMember("PartiallyCompletedValue")]
        private const string PartiallySucceededValue = "partiallySucceeded";

        /// <summary> partiallyCompleted. </summary>
        public static TextAnalyticsOperationStatus PartiallySucceeded { get; } = new TextAnalyticsOperationStatus(PartiallySucceededValue);
    }
}
