// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    internal partial class AnalyzeResultOperation
    {
        /// <summary> Encountered error during document analysis. </summary>
        [CodeGenMember("Error")]
        private readonly JsonElement _error;

        /// <summary>
        /// Gets the error that occurred during document analysis.
        /// </summary>
        public ResponseError Error => _error.ValueKind == JsonValueKind.Undefined ? null : JsonSerializer.Deserialize<ResponseError>(_error.GetRawText());
    }
}
