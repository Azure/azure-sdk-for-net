// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Represents one or more documents that have been analyzed by a trained or prebuilt model.
    /// </summary>
    [CodeGenModel("AnalyzeResult")]
    public partial class AnalyzeResult
    {
        private ApiVersion ApiVersion { get; }
        private StringIndexType StringIndexType { get; }
    }
}
