// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public readonly partial struct DocumentAnalysisFeature
    {
        /// <summary> Enable the recognition of various font styles. </summary>
        [CodeGenMember("StyleFont")]
        public static DocumentAnalysisFeature FontStyling { get; } = new DocumentAnalysisFeature(FontStylingValue);
    }
}
