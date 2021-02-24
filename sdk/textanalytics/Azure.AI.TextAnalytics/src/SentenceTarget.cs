// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("SentenceTarget")]
    internal partial class SentenceTarget
    {
        // Transform from enum TokenSentimentValue to string so we can parse it into a TextSentiment
        public string Sentiment { get; }
    }
}
