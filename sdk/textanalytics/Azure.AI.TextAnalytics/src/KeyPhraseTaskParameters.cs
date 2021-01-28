// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// KeyPhrasesTaskParameters.
    /// </summary>
    [CodeGenModel("KeyPhrasesTaskParameters")]
    public partial class KeyPhrasesTaskParameters
    {
        /// <summary> ModelVersion. </summary>
        public string ModelVersion { get; set; } = "latest";
    }
}
