// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("WarningCodeValue")]
    internal enum WarningCodeValue
    {
        /// <summary> LongWordsInDocument. </summary>
        LongWordsInDocument,
        /// <summary> DocumentTruncated. </summary>
        DocumentTruncated
    }
}
