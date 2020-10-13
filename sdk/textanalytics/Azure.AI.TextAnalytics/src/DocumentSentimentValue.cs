// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("DocumentSentimentValue")]
    internal enum DocumentSentimentValue
    {
        Positive = 0,
        Neutral = 1,
        Negative = 2,
        Mixed = 3,
    }
}
