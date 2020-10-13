// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("TextAnalyticsError")]
    internal partial class TextAnalyticsError_internal
    {
        /// <summary> Error code as string </summary>
        [CodeGenMember("Code")]
        public string Code { get; }
    }
}
