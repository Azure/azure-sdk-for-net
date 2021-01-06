// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// KeyPhrasesTask.
    /// </summary>
    [CodeGenModel("KeyPhrasesTask")]
    public partial class KeyPhrasesTask
    {
        /// <summary>
        /// Parameters for KeyPhrasesTask
        /// </summary>
        public KeyPhrasesTaskParameters Parameters { get; set; }
    }
}
