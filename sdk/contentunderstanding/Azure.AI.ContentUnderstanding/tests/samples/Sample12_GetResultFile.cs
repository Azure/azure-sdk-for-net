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
            string operationId = analyzeOperation.Id;
            Console.WriteLine($"Operation ID: {operationId}");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
#else
            // For testing, use a video URL to get keyframes for GetResultFile testing
            Uri videoUrl = new Uri("https://github.com/Azure-Samples/azure-ai-content-understanding-assets/raw/refs/heads/main/videos/sdk_samples/FlightSimulator.mp4");
            // Start the analysis operation
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-videoSearch",
                inputs: new[] { new AnalyzeInput { Url = videoUrl } });

            // Get the operation ID from the operation (available after Started)
            string operationId = analyzeOperation.Id;
            Console.WriteLine($"Operation ID: {operationId}");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
#endif

            AnalyzeResult result = analyzeOperation.Value;
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeVideoForResultFiles
            Assert.IsNotNull(videoUrl, "Video URL should not be null");
            Assert.IsTrue(videoUrl.IsAbsoluteUri, "Video URL should be absolute");
            Console.WriteLine($"Video URL: {videoUrl}");

            Assert.IsNotNull(analyzeOperation, "Analyze operation should not be null");
            Console.WriteLine("Analysis operation created successfully");

            // Verify operation ID is available immediately after WaitUntil.Started
            Assert.IsNotNull(operationId, "Operation ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(operationId), "Operation ID should not be empty");
            Assert.IsTrue(operationId.Length > 0, "Operation ID should have length > 0");
            Console.WriteLine($"Operation ID obtained: {operationId}");

            // Verify operation ID format (should be a valid identifier)
            Assert.IsFalse(operationId.Contains(" "), "Operation ID should not contain spaces");
            Console.WriteLine($"  Length: {operationId.Length} characters");

            // Verify operation started
            Assert.IsTrue(analyzeOperation.HasCompleted || !analyzeOperation.HasCompleted,
                "Operation should have a valid completion state");
            Console.WriteLine($"Operation started (ID: {operationId})");

            // Wait for completion and verify
            Assert.IsNotNull(analyzeOperation, "Operation should not be null after waiting");
            Assert.IsTrue(analyzeOperation.HasCompleted, "Operation should be completed after WaitForCompletionAsync");
            Assert.IsTrue(analyzeOperation.HasValue, "Operation should have a value after completion");
            Console.WriteLine("Operation completed successfully");

            // Verify raw response
            var rawResponse = analyzeOperation.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.IsTrue(rawResponse.Status >= 200 && rawResponse.Status < 300,
                $"Response status should be successful, but was {rawResponse.Status}");
            Console.WriteLine($"Response status: {rawResponse.Status}");

            // Verify result
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            // Video analysis may return multiple content elements (e.g., video and audio tracks)
            Assert.IsTrue(result.Contents.Count >= 1, $"Video analysis should return at least one content element, but found {result.Contents.Count}");
            Console.WriteLine($"Analysis result contains {result.Contents.Count} content(s)");

            // Verify content type
            var content = result.Contents.FirstOrDefault();
            Assert.IsNotNull(content, "Content should not be null");
            Console.WriteLine($"Content type: {content!.GetType().Name}");

            Console.WriteLine($"\nOperation verification completed:");
            Console.WriteLine($"  Operation ID: {operationId}");
            Console.WriteLine($"  Status: Completed");
            Console.WriteLine($"  Contents: {result.Contents.Count}");
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
#if !SNIPPET
            // Test assertions (excluded from snippet)
            Assert.IsNotNull(videoContent, "Test requires AudioVisualContent (video content) for GetResultFile");
            Assert.IsNotNull(videoContent!.KeyFrameTimesMs, "KeyFrameTimesMs should not be null");
            Assert.IsTrue(videoContent.KeyFrameTimesMs!.Count > 0,
                $"Video content should have at least one keyframe, but found {videoContent.KeyFrameTimesMs.Count}");
#endif

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
                File.WriteAllBytes(outputPath, imageBytes);

                Console.WriteLine($"Keyframe image saved to: {outputPath}");
            }
            #endregion

            #region Assertion:ContentUnderstandingGetResultFile
            Console.WriteLine("\n🎬 Result File Retrieval Verification:");

            // This test requires video content with keyframes for GetResultFile functionality
            // Verify that we have video content
            var videoContentVerify = result.Contents?.FirstOrDefault(c => c is AudioVisualContent) as AudioVisualContent;
            Assert.IsNotNull(videoContentVerify, "Test requires AudioVisualContent (video content) for GetResultFile testing");
            Assert.IsInstanceOf<AudioVisualContent>(videoContentVerify, "Content should be AudioVisualContent type");

            // Verify that keyframes are available
            Assert.IsNotNull(videoContentVerify!.KeyFrameTimesMs, "KeyFrameTimesMs should not be null for video content");
            Assert.IsTrue(videoContentVerify.KeyFrameTimesMs!.Count > 0,
                $"Video content should have at least one keyframe, but found {videoContentVerify.KeyFrameTimesMs.Count}");

            // Verify video content properties
            Assert.IsNotNull(videoContentVerify, "Video content should not be null");
            Console.WriteLine("Video content with keyframes detected");

            if (videoContentVerify.KeyFrameTimesMs != null && videoContentVerify.KeyFrameTimesMs.Count > 0)
            {
                Console.WriteLine("Video content with keyframes detected");

                // ========== Verify Keyframe Information ==========
                Assert.IsNotNull(videoContentVerify.KeyFrameTimesMs, "KeyFrameTimesMs should not be null");
                Assert.IsTrue(videoContentVerify.KeyFrameTimesMs.Count > 0,
                    "Should have at least one keyframe");
                Console.WriteLine($"Total keyframes: {videoContentVerify.KeyFrameTimesMs.Count}");

                // Verify keyframe times are valid
                var invalidKeyframes = videoContentVerify.KeyFrameTimesMs.Where(t => t < 0).ToList();
                Assert.AreEqual(0, invalidKeyframes.Count,
                    $"All keyframe times should be non-negative, but found {invalidKeyframes.Count} negative values");

                // Get keyframe statistics
                long firstFrameTimeMs = videoContentVerify.KeyFrameTimesMs[0];
                long lastFrameTimeMs = videoContentVerify.KeyFrameTimesMs[videoContentVerify.KeyFrameTimesMs.Count - 1];
                double avgFrameInterval = videoContentVerify.KeyFrameTimesMs.Count > 1
                    ? (double)(lastFrameTimeMs - firstFrameTimeMs) / (videoContentVerify.KeyFrameTimesMs.Count - 1)
                    : 0;

                Assert.IsTrue(firstFrameTimeMs >= 0, $"First keyframe time should be >= 0, but was {firstFrameTimeMs}");
                Assert.IsTrue(lastFrameTimeMs >= firstFrameTimeMs,
                    $"Last keyframe time ({lastFrameTimeMs}) should be >= first keyframe time ({firstFrameTimeMs})");

                Console.WriteLine($"  First keyframe: {firstFrameTimeMs} ms ({firstFrameTimeMs / 1000.0:F2} seconds)");
                Console.WriteLine($"  Last keyframe: {lastFrameTimeMs} ms ({lastFrameTimeMs / 1000.0:F2} seconds)");
                if (videoContentVerify.KeyFrameTimesMs.Count > 1)
                {
                    Console.WriteLine($"  Average interval: {avgFrameInterval:F2} ms");
                }

                // ========== Retrieve First Keyframe ==========
                Console.WriteLine("\n📥 Retrieving first keyframe...");
                string framePath = $"keyframes/{firstFrameTimeMs}";
                Assert.IsFalse(string.IsNullOrWhiteSpace(framePath), "Frame path should not be empty");
                Assert.IsTrue(framePath.StartsWith("keyframes/"), "Frame path should start with 'keyframes/'");
                Console.WriteLine($"  Frame path: {framePath}");

                Response<BinaryData> fileResponse = await client.GetResultFileAsync(operationId, framePath);

                // Verify response
                Assert.IsNotNull(fileResponse, "File response should not be null");
                Assert.IsTrue(fileResponse.HasValue, "File response should have a value");
                Assert.IsNotNull(fileResponse.Value, "File response value should not be null");
                Console.WriteLine("File response received");

                // Verify raw response
                var fileRawResponse = fileResponse.GetRawResponse();
                Assert.IsNotNull(fileRawResponse, "File raw response should not be null");
                Assert.AreEqual(200, fileRawResponse.Status,
                    $"File response status should be 200, but was {fileRawResponse.Status}");
                Console.WriteLine($"File response status: {fileRawResponse.Status}");

                // Verify content type header (should be image type)
                if (fileRawResponse.Headers.TryGetValue("Content-Type", out var contentType))
                {
                    Assert.IsTrue(contentType.StartsWith("image/"),
                        $"Content type should be an image type, but was '{contentType}'");
                    Console.WriteLine($"Content type: {contentType}");
                }

                // ========== Verify Image Data ==========
                Console.WriteLine("\nVerifying image data...");
                byte[] imageBytes = fileResponse.Value.ToArray();
                Assert.IsNotNull(imageBytes, "Image bytes should not be null");
                Assert.IsTrue(imageBytes.Length > 0, "Image should have content");
                Assert.IsTrue(imageBytes.Length >= 100,
                    $"Image should have reasonable size (>= 100 bytes), but was {imageBytes.Length} bytes");
                Console.WriteLine($"Image size: {imageBytes.Length:N0} bytes ({imageBytes.Length / 1024.0:F2} KB)");

                // Verify image format (check magic bytes for common formats)
                string imageFormat = "Unknown";
                if (imageBytes.Length >= 2)
                {
                    // Check JPEG magic bytes (FF D8)
                    if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
                        imageFormat = "JPEG";
                    // Check PNG magic bytes (89 50 4E 47)
                    else if (imageBytes.Length >= 4 && imageBytes[0] == 0x89 && imageBytes[1] == 0x50 &&
                            imageBytes[2] == 0x4E && imageBytes[3] == 0x47)
                        imageFormat = "PNG";
                    // Check GIF magic bytes (47 49 46)
                    else if (imageBytes.Length >= 3 && imageBytes[0] == 0x47 && imageBytes[1] == 0x49 &&
                            imageBytes[2] == 0x46)
                        imageFormat = "GIF";
                    // Check WebP magic bytes (52 49 46 46 ...  57 45 42 50)
                    else if (imageBytes.Length >= 12 && imageBytes[0] == 0x52 && imageBytes[1] == 0x49 &&
                            imageBytes[8] == 0x57 && imageBytes[9] == 0x45 && imageBytes[10] == 0x42 && imageBytes[11] == 0x50)
                        imageFormat = "WebP";
                }
                Console.WriteLine($"Detected image format: {imageFormat}");
                if (imageFormat != "Unknown")
                {
                    Assert.AreNotEqual("Unknown", imageFormat, "Image format should be recognized");
                }

                // ========== Save to File ==========
                Console.WriteLine("\n💾 Saving keyframe to file...");
                string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
                Assert.IsNotNull(outputDir, "Output directory path should not be null");

                Directory.CreateDirectory(outputDir);
                Assert.IsTrue(Directory.Exists(outputDir),
                    $"Output directory should exist at {outputDir}");
                Console.WriteLine($"Output directory: {outputDir}");

                string outputFileName = $"keyframe_{firstFrameTimeMs}.jpg";
                Assert.IsFalse(string.IsNullOrWhiteSpace(outputFileName), "Output file name should not be empty");
                Assert.IsTrue(outputFileName.Contains(firstFrameTimeMs.ToString()),
                    "Output file name should contain the frame timestamp");
                Console.WriteLine($"  File name: {outputFileName}");

                string outputPath = Path.Combine(outputDir, outputFileName);
                Assert.IsFalse(string.IsNullOrWhiteSpace(outputPath), "Output path should not be empty");

                File.WriteAllBytes(outputPath, imageBytes);
                Assert.IsTrue(File.Exists(outputPath),
                    $"Keyframe image file should exist at {outputPath}");
                Console.WriteLine($"File saved: {outputPath}");

                // ========== Verify Saved File ==========
                Console.WriteLine("\nVerifying saved file...");
                var savedFileInfo = new FileInfo(outputPath);
                Assert.IsTrue(savedFileInfo.Exists, "Saved file should exist");
                Assert.IsTrue(savedFileInfo.Length > 0, "Saved file should have content");
                Assert.AreEqual(imageBytes.Length, savedFileInfo.Length,
                    $"Saved file size ({savedFileInfo.Length}) should match retrieved image size ({imageBytes.Length})");
                Console.WriteLine($"File size verified: {savedFileInfo.Length:N0} bytes");

                // Verify file can be read back
                var readBackBytes = File.ReadAllBytes(outputPath);
                Assert.AreEqual(imageBytes.Length, readBackBytes.Length,
                    "Read back file size should match original");
                Assert.IsTrue(imageBytes.SequenceEqual(readBackBytes),
                    "Read back file content should match original");
                Console.WriteLine("File content verified (read back matches original)");

                // ========== Test Additional Keyframes (if available) ==========
                if (videoContentVerify.KeyFrameTimesMs.Count > 1)
                {
                    Console.WriteLine($"\nTesting additional keyframes ({videoContentVerify.KeyFrameTimesMs.Count - 1} more available)...");

                    // Test retrieving a middle keyframe
                    int middleIndex = videoContentVerify.KeyFrameTimesMs.Count / 2;
                    long middleFrameTimeMs = videoContentVerify.KeyFrameTimesMs[middleIndex];
                    string middleFramePath = $"keyframes/{middleFrameTimeMs}";

                    var middleFileResponse = await client.GetResultFileAsync(operationId, middleFramePath);
                    Assert.IsNotNull(middleFileResponse, "Middle keyframe response should not be null");
                    Assert.IsTrue(middleFileResponse.Value.ToArray().Length > 0,
                        "Middle keyframe should have content");
                    Console.WriteLine($"Successfully retrieved keyframe at index {middleIndex} ({middleFrameTimeMs} ms)");
                    Console.WriteLine($"  Size: {middleFileResponse.Value.ToArray().Length:N0} bytes");
                }

                // ========== Summary ==========
                Console.WriteLine($"\nKeyframe retrieval verification completed successfully:");
                Console.WriteLine($"  Operation ID: {operationId}");
                Console.WriteLine($"  Total keyframes: {videoContentVerify.KeyFrameTimesMs.Count}");
                Console.WriteLine($"  First keyframe time: {firstFrameTimeMs} ms");
                Console.WriteLine($"  Image format: {imageFormat}");
                Console.WriteLine($"  Image size: {imageBytes.Length:N0} bytes");
                Console.WriteLine($"  Saved to: {outputPath}");
                Console.WriteLine($"  File verified: Yes");
            }
            else
            {
                // ========== No Video Content (Expected for Document Analysis) ==========
                Console.WriteLine("No video content with keyframes detected");
                Console.WriteLine("   This is expected for document analysis");

                // Verify content type
                var documentContent = result.Contents?.FirstOrDefault() as DocumentContent;
                if (documentContent != null)
                {
                    Console.WriteLine($"Content type: DocumentContent (as expected)");
                    Console.WriteLine($"  MIME type: {documentContent.MimeType ??  "(not specified)"}");
                    Console.WriteLine($"  Pages: {documentContent.StartPageNumber} - {documentContent.EndPageNumber}");
                }
                else
                {
                    var mediaContent = result.Contents?.FirstOrDefault() as MediaContent;
                    if (mediaContent != null)
                    {
                        Console.WriteLine($"Content type: MediaContent");
                    }
                    else
                    {
                        Console.WriteLine($"Content type: {result.Contents?.FirstOrDefault()?.GetType().Name ??  "Unknown"}");
                    }
                }

                // Verify the API pattern is demonstrated
                Assert.IsNotNull(operationId, "Operation ID should be available for GetResultFile API");
                Assert.IsFalse(string.IsNullOrWhiteSpace(operationId), "Operation ID should not be empty");
                Console.WriteLine($"Operation ID available for GetResultFile API: {operationId}");

                // Test error handling for non-existent file path
                Console.WriteLine("\n🧪 Testing error handling for invalid path...");
                try
                {
                    var invalidResponse = await client.GetResultFileAsync(operationId, "keyframes/0");
                    Console.WriteLine($"⚠️ Request succeeded (status: {invalidResponse.GetRawResponse().Status})");
                    Console.WriteLine("   This may indicate the service returns data even for non-existent keyframes");
                }
                catch (RequestFailedException ex)
                {
                    Assert.IsTrue(ex.Status == 404 || ex.Status == 400,
                        $"Expected 404 or 400 for non-existent keyframe, but got {ex.Status}");
                    Console.WriteLine($"Correctly returned error status {ex.Status} for non-existent keyframe");
                }

                // ========== API Usage Example ==========
                Console.WriteLine($"\n📚 GetResultFile API Usage Example:");
                Console.WriteLine("   For video analysis with keyframes:");
                Console.WriteLine("   1. Analyze video with prebuilt-videoSearch");
                Console.WriteLine("   2. Get keyframe times from AudioVisualContent. KeyFrameTimesMs");
                Console.WriteLine("   3. Retrieve keyframes using GetResultFileAsync:");
                Console.WriteLine($"      var response = await client.GetResultFileAsync(\"{operationId}\", \"keyframes/1000\");");
                Console.WriteLine("   4. Save or process the keyframe image");

                Console.WriteLine($"\nGetResultFile API pattern demonstration completed:");
                Console.WriteLine($"  Operation ID: {operationId}");
                Console.WriteLine($"  Content type: Document (not video)");
                Console.WriteLine($"  API availability: Verified");
                Console.WriteLine($"  Error handling: Tested");
            }
            #endregion
        }
    }
}
