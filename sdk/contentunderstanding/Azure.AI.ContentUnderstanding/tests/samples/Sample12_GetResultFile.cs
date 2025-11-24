// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
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
        public async Task GetResultFileAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeVideoForResultFiles
#if SNIPPET
            Uri videoUrl = new Uri("<videoUrl>");
            // Start the analysis operation
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-videoSearch",
                inputs: new[] { new AnalyzeInput { Url = videoUrl } });

            // Get the operation ID from the operation (available after Started)
            string operationId = analyzeOperation.GetOperationId() ?? throw new InvalidOperationException("Could not extract operation ID from operation");
            Console.WriteLine($"Operation ID: {operationId}");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
#else
            // For testing, use a document URL to get an operation ID
            // In production, use video analysis to get keyframes
            Uri documentUrl = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
            // Start the analysis operation
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = documentUrl } });

            // Get the operation ID from the operation (available after Started)
            string operationId = analyzeOperation.GetOperationId() ?? throw new InvalidOperationException("Could not extract operation ID from operation");
            Console.WriteLine($"Operation ID: {operationId}");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
#endif

            AnalyzeResult result = analyzeOperation.Value;
            #endregion

            #region Snippet:ContentUnderstandingGetResultFile
            // GetResultFile is used to retrieve result files (like keyframe images) from video analysis
            // The path format is: "keyframes/{frameTimeMs}" where frameTimeMs is the timestamp in milliseconds

            // Example: Get a keyframe image (if available)
            // Note: This example demonstrates the API pattern. In production, you would:
            // 1. Analyze a video to get keyframe timestamps
            // 2. Use those timestamps to construct paths like "keyframes/1000" for the frame at 1000ms
            // 3. Call GetResultFileAsync with the operation ID and path

            // For video analysis, keyframes would be found in AudioVisualContent.KeyFrameTimesMs
            var videoContent = result.Contents?.FirstOrDefault(c => c is AudioVisualContent) as AudioVisualContent;
            if (videoContent?.KeyFrameTimesMs != null && videoContent.KeyFrameTimesMs.Count > 0)
            {
                // Print keyframe information
                int totalKeyframes = videoContent.KeyFrameTimesMs.Count;
                long firstFrameTimeMs = videoContent.KeyFrameTimesMs[0];
                Console.WriteLine($"Total keyframes: {totalKeyframes}");
                Console.WriteLine($"First keyframe time: {firstFrameTimeMs} ms");

                // Get the first keyframe as an example
                string framePath = $"keyframes/{firstFrameTimeMs}";

                Console.WriteLine($"Getting result file: {framePath}");

                // Get the result file (keyframe image)
                Response<BinaryData> fileResponse = await client.GetResultFileAsync(
                    operationId,
                    framePath);

                byte[] imageBytes = fileResponse.Value.ToArray();
                Console.WriteLine($"Retrieved keyframe image ({imageBytes.Length:N0} bytes)");

                // Save the keyframe image to sample_output directory
                string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
                Directory.CreateDirectory(outputDir);
                string outputFileName = $"keyframe_{firstFrameTimeMs}.jpg";
                string outputPath = Path.Combine(outputDir, outputFileName);
                await File.WriteAllBytesAsync(outputPath, imageBytes);

                Console.WriteLine($"Keyframe image saved to: {outputPath}");
            }
            else
            {
                Console.WriteLine("Note: This sample demonstrates GetResultFile API usage.");
                Console.WriteLine("      For video analysis with keyframes, use prebuilt-videoSearch analyzer.");
                Console.WriteLine("      Keyframes are available in AudioVisualContent.KeyFrameTimesMs.");
                Console.WriteLine();
                Console.WriteLine($"Example usage with operation ID '{operationId}':");
                Console.WriteLine("  Response<BinaryData> fileResponse = await client.GetResultFileAsync(");
                Console.WriteLine("      operationId, \"keyframes/1000\");");
            }
            #endregion
        }
    }
}
