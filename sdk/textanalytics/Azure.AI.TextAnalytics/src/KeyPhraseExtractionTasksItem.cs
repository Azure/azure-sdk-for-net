// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// KeyPhraseExtractionTasksItem.
    /// </summary>
    [CodeGenModel("TasksStateTasksKeyPhraseExtractionTasksItem")]
    public partial class KeyPhraseExtractionTasksItem
    {
        internal KeyPhraseResult Results { get; }
    }
}
