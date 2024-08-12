// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.DocumentIntelligence
{
    [CodeGenSuppress("FetchAnalyzeResultFromAnalyzeResultOperation", typeof(Response))]
    public partial class DocumentIntelligenceClient
    {
        // CUSTOM CODE NOTE: code generation is mistakenly creating two copies of the
        // FetchAnalyzeResultFromAnalyzeResultOperation method, breaking the build.
        // We're forcibly suppressing their creation with the CodeGenSuppress attribute
        // and adding a single copy here.

        private AnalyzeResult FetchAnalyzeResultFromAnalyzeResultOperation(Response response)
        {
            var resultJsonElement = JsonDocument.Parse(response.Content).RootElement.GetProperty("analyzeResult");
            return AnalyzeResult.DeserializeAnalyzeResult(resultJsonElement);
        }
    }
}
