// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentSpan")]
    public readonly partial struct DocumentSpan
    {
        /// <summary>
        /// Zero-based index of the content represented by the span.
        /// </summary>
        [CodeGenMember("Offset")]
        public int Index { get; }

        /// <summary>
        /// Number of characters in the content represented by the span.
        /// </summary>
        public int Length { get; }
    }
}
