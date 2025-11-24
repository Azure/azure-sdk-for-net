// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task AnalyzeReturnRawJsonAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeReturnRawJson
#if SNIPPET
            string filePath = "<filePath>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
#endif
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);

            // Use protocol method to get raw JSON response
            // Note: For production use, prefer the object model approach (AnalyzeBinaryAsync with BinaryData)
            // which returns AnalyzeResult objects that are easier to work with
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                RequestContent.Create(BinaryData.FromBytes(fileBytes)));

            BinaryData responseData = operation.Value;
            #endregion

            #region Snippet:ContentUnderstandingParseRawJson
            // Parse the raw JSON response
            using var jsonDocument = JsonDocument.Parse(responseData);

            // Pretty-print the JSON
            string prettyJson = JsonSerializer.Serialize(
                jsonDocument.RootElement,
                new JsonSerializerOptions { WriteIndented = true });

            // Create output directory if it doesn't exist
            string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
            Directory.CreateDirectory(outputDir);

            // Save to file
            string outputFileName = $"analyze_result_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
            string outputPath = Path.Combine(outputDir, outputFileName);
            await File.WriteAllTextAsync(outputPath, prettyJson);

            Console.WriteLine($"Raw JSON response saved to: {outputPath}");
            Console.WriteLine($"File size: {prettyJson.Length:N0} characters");
            #endregion

            #region Snippet:ContentUnderstandingExtractFromRawJson
            // Extract key information from raw JSON
            var resultElement = jsonDocument.RootElement.GetProperty("result");

            if (resultElement.TryGetProperty("analyzerId", out var analyzerIdElement))
            {
                Console.WriteLine($"Analyzer ID: {analyzerIdElement.GetString()}");
            }

            if (resultElement.TryGetProperty("contents", out var contentsElement) &&
                contentsElement.ValueKind == JsonValueKind.Array)
            {
                Console.WriteLine($"Contents count: {contentsElement.GetArrayLength()}");

                if (contentsElement.GetArrayLength() > 0)
                {
                    var firstContent = contentsElement[0];
                    if (firstContent.TryGetProperty("kind", out var kindElement))
                    {
                        Console.WriteLine($"Content kind: {kindElement.GetString()}");
                    }
                    if (firstContent.TryGetProperty("mimeType", out var mimeTypeElement))
                    {
                        Console.WriteLine($"MIME type: {mimeTypeElement.GetString()}");
                    }
                }
            }
            #endregion
        }
    }
}
