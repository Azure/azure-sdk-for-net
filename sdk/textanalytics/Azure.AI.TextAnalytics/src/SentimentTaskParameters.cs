// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("SentimentTaskParameters")]
    internal partial class SentimentTaskParameters
    {
        internal string ModelVersion { get; set; }
        internal StringIndexType? StringIndexType { get; set; }

    }
}
