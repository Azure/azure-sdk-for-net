// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task ReadAnalysisDiagnosticsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingReadAnalysisDiagnostics
            Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");

            Operation<AnalysisResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalysisInput { Uri = invoiceUrl } });

            AnalysisResult result = operation.Value;

            // After a completed analysis, diagnostic information is available on the result.
            // Treat diagnostic messages as human-readable text. Use OpenTelemetry when you
            // need structured telemetry for monitoring or automation.
            foreach (ResponseError info in result.Infos)
            {
                Console.WriteLine($"{info.Code}: {info.Message}");
            }
            #endregion

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsNotEmpty(result.Contents);
            Assert.IsNotEmpty(result.Infos);
            Assert.IsTrue(result.Infos.Any(info => info.Code == "LLMStats"));
            Assert.IsTrue(result.Infos
                .Where(info => info.Code == "LLMStats")
                .All(info => !string.IsNullOrWhiteSpace(info.Message)));
        }
    }
}
