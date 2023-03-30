// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Represents one or more documents that have been analyzed by a trained or prebuilt model.
    /// </summary>
    public partial class AnalyzeResult
    {
        private string ApiVersion { get; }

        private StringIndexType StringIndexType { get; }
    }
}
