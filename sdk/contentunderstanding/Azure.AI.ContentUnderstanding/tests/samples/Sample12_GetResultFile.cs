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
using NUnit.Framework;

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

            #region Assertion:ContentUnderstandingAnalyzeVideoForResultFiles
            Assert.IsNotNull(analyzeOperation, "Analyze operation should not be null");
            Assert.IsNotNull(operationId, "Operation ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(operationId), "Operation ID should not be empty");

            // Verify operation completed
            Assert.IsTrue(analyzeOperation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(analyzeOperation.HasValue, "Operation should have a value");

            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");

            Console.WriteLine($"✓ Verified operation ID: {operationId}");
            Console.WriteLine($"✓ Verified result with {result.Contents.Count} content(s)");
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

            #region Assertion:ContentUnderstandingGetResultFile
            // This test demonstrates the GetResultFile API pattern
            // Keyframes are only available for video content (AudioVisualContent)
            var videoContentVerify = result.Contents?.FirstOrDefault(c => c is AudioVisualContent) as AudioVisualContent;

            if (videoContentVerify?.KeyFrameTimesMs != null && videoContentVerify.KeyFrameTimesMs.Count > 0)
            {
                // Verify keyframe information
                Assert.IsTrue(videoContentVerify.KeyFrameTimesMs.Count > 0,
                    "Should have at least one keyframe");

                long firstFrameTimeMs = videoContentVerify.KeyFrameTimesMs[0];
                Assert.IsTrue(firstFrameTimeMs >= 0,
                    "Keyframe time should be non-negative");

                // Verify result file was retrieved
                string framePath = $"keyframes/{firstFrameTimeMs}";
                Response<BinaryData> fileResponse = await client.GetResultFileAsync(
                    operationId,
                    framePath);

                Assert.IsNotNull(fileResponse, "File response should not be null");
                Assert.IsNotNull(fileResponse.Value, "File response value should not be null");

                byte[] imageBytes = fileResponse.Value.ToArray();
                Assert.IsNotNull(imageBytes, "Image bytes should not be null");
                Assert.IsTrue(imageBytes.Length > 0, "Image should have content");

                // Verify file was saved
                string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
                Assert.IsTrue(Directory.Exists(outputDir),
                    $"Output directory should exist at {outputDir}");

                string outputFileName = $"keyframe_{firstFrameTimeMs}.jpg";
                string outputPath = Path.Combine(outputDir, outputFileName);
                Assert.IsTrue(File.Exists(outputPath),
                    $"Keyframe image file should exist at {outputPath}");

                var savedFileInfo = new FileInfo(outputPath);
                Assert.IsTrue(savedFileInfo.Length > 0, "Saved file should have content");
                Assert.AreEqual(imageBytes.Length, savedFileInfo.Length,
                    "Saved file size should match retrieved image size");

                Console.WriteLine($"\n✓ Verified keyframe retrieval:");
                Console.WriteLine($"  Total keyframes: {videoContentVerify.KeyFrameTimesMs.Count}");
                Console.WriteLine($"  First keyframe time: {firstFrameTimeMs} ms");
                Console.WriteLine($"  Image size: {imageBytes.Length:N0} bytes");
                Console.WriteLine($"  Saved to: {outputPath}");
            }
            else
            {
                // No video content with keyframes - this is expected for document analysis
                Console.WriteLine("\n✓ Note: No keyframes available (expected for document analysis)");
                Console.WriteLine("  This sample demonstrates the GetResultFile API pattern.");
                Console.WriteLine("  For actual keyframe retrieval, use prebuilt-videoSearch analyzer with video content.");

                // Verify the API pattern is demonstrated
                Assert.IsNotNull(operationId, "Operation ID should be available for GetResultFile API");
                Console.WriteLine($"  Operation ID available: {operationId}");
            }
            #endregion
        }
    }
}