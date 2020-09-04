// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("EntitiesTaskParameters")]
    internal partial class EntitiesTaskParameters
    {
        internal string ModelVersion { get; set; }
        internal StringIndexType? StringIndexType { get; set; }

    }
}
