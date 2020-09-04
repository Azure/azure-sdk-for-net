// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("PiiTaskParameters")]
    internal partial class PiiTaskParameters
    {
        internal string ModelVersion { get; set; }
        internal StringIndexType? StringIndexType { get; set; }
    }
}
