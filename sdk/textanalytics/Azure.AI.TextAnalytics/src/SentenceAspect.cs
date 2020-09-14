// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("SentenceAspect")]
    internal partial class SentenceAspect
    {
        // Transform from enum TokenSentimentValue to string so we can parse it into a TextSentiment
        public string Sentiment { get; }
    }
}
