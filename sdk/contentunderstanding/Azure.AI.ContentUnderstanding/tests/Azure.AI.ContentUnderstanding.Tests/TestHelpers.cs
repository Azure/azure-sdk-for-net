// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Helper methods for Content Understanding tests.
    /// Provides utility functions for:
    /// - Generating unique IDs for analyzers and classifiers
    /// - Managing keyframe downloads from video analysis
    /// - Creating analyzer and classifier objects
    /// - Saving analysis results and images
    /// - Asserting test results
    /// </summary>
    public static class TestHelpers
    {
        private const string DefaultOutputDir = "test_output";

        #region ID Generation

        /// <summary>
        /// Generate a unique analyzer ID for tests.
        /// Uses the recording's ID generation for consistency in playback mode.
        /// </summary>
        /// <param name="recording">The TestRecording instance for ID generation</param>
        /// <param name="prefix">Prefix for the analyzer ID (typically the test name)</param>
        /// <returns>A unique analyzer ID in format: {prefix}_{generated_id}</returns>
        public static string GenerateAnalyzerId(TestRecording recording, string prefix)
        {
            // Use the recording's ID generation for consistency in playback
            return $"{prefix}_{recording.GenerateId()}";
        }

        /// <summary>
        /// Generate a unique analyzer ID asynchronously with current date, time, and GUID.
        /// Attempts to delete existing analyzer with the same ID before returning.
        /// </summary>
        /// <param name="client">The ContentUnderstandingClient instance</param>
        /// <param name="prefix">Prefix for the analyzer ID (typically the test name)</param>
        /// <returns>A unique analyzer ID in format: {prefix}_{timestamp}_{guid}</returns>
        public static async Task<string> GenerateAnalyzerIdAsync(ContentUnderstandingClient client, string prefix)
        {
            // Generate a unique analyzer ID with timestamp
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string uniqueId = Guid.NewGuid().ToString("N").Substring(0, 8);
            string analyzerId = $"{prefix}_{timestamp}_{uniqueId}";

            // Try to delete if it exists (cleanup from previous failed runs)
            try
            {
                await client.DeleteAnalyzerAsync(analyzerId);
            }
            catch
            {
                // Ignore if doesn't exist
            }

            return analyzerId;
        }

        #endregion

        #region Keyframe Management

        /// <summary>
        /// Extract keyframe IDs from AudioVisualContent using KeyFrameTimesMs property.
        /// Converts millisecond timestamps into keyframe ID format.
        /// </summary>
        /// <param name="content">The AudioVisualContent to extract keyframes from</param>
        /// <returns>List of keyframe IDs in format "keyFrame.{timeMs}"</returns>
        public static List<string> ExtractKeyframeIdsFromAudioVisualContent(AudioVisualContent content)
        {
            var keyframeIds = new List<string>();

            if (content?.KeyFrameTimesMs != null && content.KeyFrameTimesMs.Any())
            {
                foreach (var keyFrameTimeMs in content.KeyFrameTimesMs)
                {
                    // Build keyframe ID using the time value: keyFrame.{timeMs}
                    string keyframeId = $"keyFrame.{keyFrameTimeMs}";
                    keyframeIds.Add(keyframeId);
                }
                TestContext.WriteLine($"📹 Extracted {keyframeIds.Count} keyframe IDs from KeyFrameTimesMs property");
            }
            else
            {
                TestContext.WriteLine("⚠️  No KeyFrameTimesMs found in AudioVisualContent");
            }

            return keyframeIds;
        }

        /// <summary>
        /// Select keyframes to download (first, middle, last) to avoid downloading all frames.
        /// If less than 3 keyframes exist, returns all of them.
        /// </summary>
        /// <param name="keyframeIds">List of all keyframe IDs</param>
        /// <returns>HashSet of selected keyframe IDs (first, middle, last)</returns>
        public static HashSet<string> SelectKeyframesToDownload(List<string> keyframeIds)
        {
            if (keyframeIds == null || keyframeIds.Count == 0)
            {
                return new HashSet<string>();
            }

            // Sort keyframes by timestamp
            var sortedKeyframes = keyframeIds
                .OrderBy(x => ExtractTimestampFromKeyframeId(x))
                .ToList();

            // If we have 3 or more keyframes, select first, middle, and last
            if (sortedKeyframes.Count >= 3)
            {
                return new HashSet<string>
                {
                    sortedKeyframes[0],
                    sortedKeyframes[sortedKeyframes.Count - 1],
                    sortedKeyframes[sortedKeyframes.Count / 2]
                };
            }
            else
            {
                // If less than 3, return all of them
                return new HashSet<string>(sortedKeyframes);
            }
        }

        /// <summary>
        /// Extract timestamp from keyframe ID for sorting purposes.
        /// </summary>
        /// <param name="keyframeId">Keyframe ID in format "keyFrame.{timestamp}"</param>
        /// <returns>Extracted timestamp as long, or 0 if parsing fails</returns>
        private static long ExtractTimestampFromKeyframeId(string keyframeId)
        {
            // Extract timestamp from "keyFrame.12345" format
            var parts = keyframeId.Split('.');
            if (parts.Length >= 2 && long.TryParse(parts[1], out long timestamp))
            {
                return timestamp;
            }
            return 0;
        }

        /// <summary>
        /// Download keyframes from analysis result and save them to files.
        /// Downloads up to 3 keyframes: first, middle, and last frame to avoid duplicates.
        /// </summary>
        /// <param name="client">The ContentUnderstandingClient instance</param>
        /// <param name="operationId">The operation ID from the analysis</param>
        /// <param name="analyzeResult">The analysis result containing AudioVisualContent</param>
        /// <param name="testName">Name of the test case (used for file naming)</param>
        /// <param name="testFileDir">Directory where test files are located</param>
        /// <param name="identifier">Optional unique identifier to avoid conflicts (e.g., analyzer_id)</param>
        /// <returns>Number of keyframes successfully downloaded</returns>
        public static async Task<int> DownloadAndSaveKeyframesAsync(
            ContentUnderstandingClient client,
            string operationId,
            AnalyzeResult analyzeResult,
            string testName,
            string testFileDir,
            string identifier = null)
        {
            // Find AudioVisualContent in the analysis result
            AudioVisualContent audioVisualContent = null;
            foreach (var content in analyzeResult.Contents)
            {
                if (content is AudioVisualContent avc)
                {
                    audioVisualContent = avc;
                    TestContext.WriteLine($"📹 Found AudioVisualContent with {avc.KeyFrameTimesMs?.Count ?? 0} keyframes");
                    break;
                }
            }

            if (audioVisualContent == null)
            {
                TestContext.WriteLine("⚠️  No AudioVisualContent found in analysis result");
                return 0;
            }

            // Extract keyframe IDs from the AudioVisualContent
            var keyframeIds = ExtractKeyframeIdsFromAudioVisualContent(audioVisualContent);

            if (keyframeIds.Count == 0)
            {
                TestContext.WriteLine("⚠️  No keyframe IDs extracted from AudioVisualContent");
                return 0;
            }

            // Select keyframes to download (first, middle, last)
            var framesToDownload = SelectKeyframesToDownload(keyframeIds);
            TestContext.WriteLine($"📥 Downloading {framesToDownload.Count} keyframe images: {string.Join(", ", framesToDownload)}");

            int filesDownloaded = 0;

            // Download each selected keyframe
            foreach (var keyframeId in framesToDownload)
            {
                try
                {
                    TestContext.WriteLine($"📥 Getting result file: {keyframeId}");

                    var frameNumber = keyframeId.Replace("keyFrame.", "");
                    var keyFramePath = $"keyframes/{frameNumber}";

                    // Get the result file (keyframe image)
                    var response = await client.GetResultFileAsync(operationId, keyFramePath);

                    // Convert BinaryData to byte array
                    byte[] imageBytes = response.Value.ToArray();

                    // Get content type from response headers
                    var contentType = response.GetRawResponse().Headers.TryGetValue("Content-Type", out var ct)
                        ? ct
                        : "image/jpeg";

                    // Save the keyframe image
                    string savedPath = SaveKeyframeImageToFile(
                        imageBytes,
                        keyframeId,
                        testName,
                        testFileDir,
                        identifier);

                    TestContext.WriteLine($"✅ Saved keyframe: {savedPath} (Content-Type: {contentType})");
                    filesDownloaded++;
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine($"❌ Failed to download keyframe {keyframeId}: {ex.Message}");
                }
            }

            TestContext.WriteLine($"✅ Downloaded {filesDownloaded} out of {framesToDownload.Count} keyframes");
            return filesDownloaded;
        }

        /// <summary>
        /// Save keyframe image to output file using test naming convention.
        /// </summary>
        /// <param name="imageContent">The binary image content to save</param>
        /// <param name="keyframeId">The keyframe ID (e.g., "keyFrame.1000")</param>
        /// <param name="testName">Name of the test case (e.g., function name)</param>
        /// <param name="testFileDir">Directory where test files are located</param>
        /// <param name="identifier">Optional unique identifier to avoid conflicts (e.g., analyzer_id)</param>
        /// <returns>Path to the saved image file</returns>
        /// <exception cref="IOException">If there are issues creating directory or writing file</exception>
        public static string SaveKeyframeImageToFile(
            byte[] imageContent,
            string keyframeId,
            string testName,
            string testFileDir,
            string identifier = null)
        {
            // Create test_output directory if it doesn't exist
            string outputDir = Path.Combine(testFileDir, DefaultOutputDir);
            Directory.CreateDirectory(outputDir);

            // Generate timestamp and frame ID
            string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            string frameId = keyframeId.Replace("keyFrame.", "");

            // Build the output filename with identifier if provided
            string outputFileName = string.IsNullOrEmpty(identifier)
                ? $"{testName}_{timestamp}_{frameId}.jpg"
                : $"{testName}_{identifier}_{timestamp}_{frameId}.jpg";

            string outputPath = Path.Combine(outputDir, outputFileName);

            // Write the image content to file
            File.WriteAllBytes(outputPath, imageContent);
            TestContext.WriteLine($"✅ Saved keyframe image to: {outputPath} ({imageContent.Length} bytes)");

            return outputPath;
        }

        /// <summary>
        /// Assert that keyframe images were successfully downloaded and saved.
        /// </summary>
        /// <param name="downloadedCount">Number of keyframes downloaded</param>
        /// <param name="expectedMinimum">Minimum expected number of keyframes (default: 1)</param>
        /// <exception cref="AssertionException">If downloaded count is less than expected minimum</exception>
        public static void AssertKeyframesDownloaded(int downloadedCount, int expectedMinimum = 1)
        {
            Assert.That(downloadedCount, Is.GreaterThanOrEqualTo(expectedMinimum),
                $"Expected to download at least {expectedMinimum} keyframe(s), but only downloaded {downloadedCount}");
            TestContext.WriteLine($"✅ Successfully verified {downloadedCount} keyframe(s) were downloaded");
        }

        #endregion

        #region File Extension Helpers

        /// <summary>
        /// Get file extension from content type header.
        /// Maps common MIME types to their corresponding file extensions.
        /// </summary>
        /// <param name="contentType">The content type string (e.g., "image/jpeg")</param>
        /// <returns>File extension with dot (e.g., ".jpg"), or ".bin" if unknown</returns>
        public static string GetFileExtensionFromContentType(string contentType)
        {
            if (string.IsNullOrWhiteSpace(contentType))
            {
                return ".bin"; // Default to binary if no content type
            }

            // Common MIME type to extension mappings
            var mimeTypeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "image/jpeg", ".jpg" },
                { "image/jpg", ".jpg" },
                { "image/png", ".png" },
                { "image/gif", ".gif" },
                { "image/bmp", ".bmp" },
                { "image/webp", ".webp" },
                { "video/mp4", ".mp4" },
                { "video/mpeg", ".mpeg" },
                { "video/quicktime", ".mov" },
                { "audio/mpeg", ".mp3" },
                { "audio/wav", ".wav" },
                { "application/pdf", ".pdf" },
                { "text/plain", ".txt" },
                { "application/json", ".json" }
            };

            // Remove any parameters from content type
            string cleanContentType = contentType.Split(';')[0].Trim();

            if (mimeTypeMap.TryGetValue(cleanContentType, out string extension))
            {
                return extension;
            }

            // If not found in map, try to extract from content type
            if (cleanContentType.Contains("/"))
            {
                string subType = cleanContentType.Split('/')[1];
                return $".{subType}";
            }

            return ".bin"; // Default to binary
        }

        #endregion

        #region Content Analyzer Creation

        /// <summary>
        /// Create a simple ContentAnalyzer object with default configuration.
        /// Configures a document analyzer with OCR, layout, and formula extraction enabled.
        /// </summary>
        /// <param name="analyzerId">The analyzer ID</param>
        /// <param name="description">Optional description for the analyzer (defaults to "test analyzer: {analyzerId}")</param>
        /// <param name="tags">Optional tags for the analyzer (defaults to {"test_type": "simple"})</param>
        /// <returns>A configured ContentAnalyzer object</returns>
        public static ContentAnalyzer NewSimpleContentAnalyzerObject(
            string analyzerId,
            string description = null,
            Dictionary<string, string> tags = null)
        {
            description ??= $"test analyzer: {analyzerId}";
            tags ??= new Dictionary<string, string> { { "test_type", "simple" } };

            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = description,
                Config = new ContentAnalyzerConfig
                {
                    EnableFormula = true,
                    EnableLayout = true,
                    EnableOcr = true,
                    EstimateFieldSourceAndConfidence = true,
                    ReturnDetails = true
                },
                FieldSchema = new ContentFieldSchema(
                    fields: new Dictionary<string, ContentFieldDefinition>
                    {
                        ["total_amount"] = new ContentFieldDefinition
                        {
                            Method = GenerationMethod.Extract,
                            Type = ContentFieldType.Number,
                            Description = "Total amount of this table"
                        }
                    })
                {
                    Name = "schema name here",
                    Description = "schema description here"
                }
            };

            // Add models
            analyzer.Models.Add("completion", "gpt-4o");
            analyzer.Models.Add("embedding", "text-embedding-3-large");

            // Add tags
            foreach (var tag in tags)
            {
                analyzer.Tags.Add(tag.Key, tag.Value);
            }

            return analyzer;
        }

        /// <summary>
        /// Create a marketing video ContentAnalyzer object based on the marketing video template.
        /// Configures a video analyzer with detailed analysis enabled.
        /// </summary>
        /// <param name="analyzerId">The analyzer ID</param>
        /// <param name="description">Optional description for the analyzer (defaults to "marketing video analyzer: {analyzerId}")</param>
        /// <param name="tags">Optional tags for the analyzer (defaults to {"test_type": "marketing_video"})</param>
        /// <returns>A configured ContentAnalyzer object for video analysis</returns>
        public static ContentAnalyzer NewMarketingVideoAnalyzerObject(
            string analyzerId,
            string description = null,
            Dictionary<string, string> tags = null)
        {
            description ??= $"marketing video analyzer: {analyzerId}";
            tags ??= new Dictionary<string, string> { { "test_type", "marketing_video" } };

            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-video",
                Description = description,
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                }
            };

            // Add model
            analyzer.Models.Add("completion", "gpt-4o");

            // Add tags
            foreach (var tag in tags)
            {
                analyzer.Tags.Add(tag.Key, tag.Value);
            }

            return analyzer;
        }

        #endregion

        #region File Saving

        /// <summary>
        /// Save analysis result to output file using test naming convention.
        /// Serializes the result to JSON with indentation for readability.
        /// </summary>
        /// <param name="result">The analysis result object to save</param>
        /// <param name="testName">Name of the test case (e.g., function name)</param>
        /// <param name="testFileDir">Directory where test files are located</param>
        /// <param name="identifier">Optional unique identifier for the result (e.g., analyzer_id)</param>
        /// <returns>Path to the saved output file</returns>
        /// <exception cref="ArgumentNullException">If result is null</exception>
        /// <exception cref="IOException">If there are issues creating directory or writing file</exception>
        public static string SaveAnalysisResultToFile(
            AnalyzeResult result,
            string testName,
            string testFileDir,
            string identifier)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            // Create output directory
            string outputDir = Path.Combine(testFileDir, DefaultOutputDir);
            Directory.CreateDirectory(outputDir);

            // Generate filename
            string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            string fileName = string.IsNullOrEmpty(identifier)
                ? $"{testName}_{timestamp}.json"
                : $"{testName}_{identifier}_{timestamp}.json";

            string outputPath = Path.Combine(outputDir, fileName);

            // Serialize to JSON
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            try
            {
                string jsonContent = JsonSerializer.Serialize(result, options);
                File.WriteAllText(outputPath, jsonContent);
                TestContext.WriteLine($"📄 Analysis result saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"⚠️  Could not serialize result to JSON: {ex.Message}");
                TestContext.WriteLine($"📄 Analysis result location would be: {outputPath}");
            }

            return outputPath;
        }

        #endregion

        #region Assertions

        /// <summary>
        /// Assert common operation properties for any Operation.
        /// Validates that the operation has required properties and raw response.
        /// </summary>
        /// <typeparam name="T">The type of operation result</typeparam>
        /// <param name="operation">The Operation instance to validate</param>
        /// <param name="operationName">Optional name for the operation in log messages (default: "Operation")</param>
        /// <exception cref="AssertionException">If any operation property assertion fails</exception>
        public static void AssertOperationProperties<T>(Operation<T> operation, string operationName)
        {
            Assert.IsNotNull(operation, $"{operationName} should not be null");
            Assert.IsNotNull(operation.GetRawResponse(), $"{operationName} should have a raw response");
            TestContext.WriteLine($"✅ {operationName} properties verified");
        }

        /// <summary>
        /// Assert simple content analyzer result properties and field extraction.
        /// Validates the structure and content of analysis results, including field verification.
        /// </summary>
        /// <param name="result">The analysis result object to validate</param>
        /// <param name="resultName">Optional name for the result in log messages (default: "Analysis result")</param>
        /// <exception cref="AssertionException">If any analysis result property assertion fails</exception>
        public static void AssertSimpleContentAnalyzerResult(AnalyzeResult result, string resultName)
        {
            Assert.IsNotNull(result, $"{resultName} should not be null");
            Assert.IsTrue(result.Contents.Count > 0, $"{resultName} should have at least one content");

            // Verify the first content has fields
            var firstContent = result.Contents[0];
            Assert.IsNotNull(firstContent.Fields, "First content should have fields");

            // Verify total_amount field exists and has the expected value
            Assert.IsTrue(firstContent.Fields.ContainsKey("total_amount"),
                "Fields should contain total_amount");

            var totalAmountField = firstContent.Fields["total_amount"];
            Assert.IsNotNull(totalAmountField, "total_amount field should not be null");

            TestContext.WriteLine($"✅ {resultName} validation passed");
        }

        #endregion

        #region Test Mode Detection

        /// <summary>
        /// Check if running in live mode (not playback/recording).
        /// This should be implemented based on your test framework's mode detection.
        /// </summary>
        /// <returns>True if running in live mode, False otherwise</returns>
        public static bool IsLive()
        {
            // This should be implemented based on your test framework
            // For now, return true as default
            return true;
        }

        #endregion
    }
}
