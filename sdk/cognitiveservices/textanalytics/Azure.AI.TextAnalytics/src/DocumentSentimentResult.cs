// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DocumentSentimentResult : DocumentResults<Sentiment>
    {
        // TODO: set DocumentSentiment.Length
        /// <summary>
        /// </summary>
        public Sentiment DocumentSentiment { get; set; }

        /// <summary>
        /// </summary>
        public DocumentResults<Sentiment> SentenceSentiments { get => this; }
    }
}
