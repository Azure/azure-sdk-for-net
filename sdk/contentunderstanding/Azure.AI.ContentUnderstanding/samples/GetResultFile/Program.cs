// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Sample: Get Result File from Analysis Operation
    ///
    /// This sample demonstrates:
    /// 1. Authenticating with Azure AI Content Understanding
    /// 2. Creating a video analyzer using the prebuilt video analyzer
    /// 3. Analyzing a video file to generate keyframes
    /// 4. Extracting the operation ID from the analysis poller
    /// 5. Retrieving result files (keyframe images) using the operation ID
    /// 6. Saving keyframe images to local files
    /// 7. Cleaning up resources by deleting the created analyzer
    /// </summary>
    ///
    /// <remarks>
    /// Prerequisites:
    ///     - Azure AI Content Understanding endpoint configured
    ///     - Azure credentials (Key or DefaultAzureCredential)
    ///
    /// Configuration:
    ///     Set in appsettings.json:
    ///         - AzureContentUnderstanding:Endpoint
    ///         - AzureContentUnderstanding:Key (optional - DefaultAzureCredential will be used if not set)
    ///
    ///     Or use environment variables:
    ///         - AZURE_CONTENT_UNDERSTANDING_ENDPOINT (required)
    ///         - AZURE_CONTENT_UNDERSTANDING_KEY (optional)
    /// </remarks>
    public class Program
    {
        private static string? ExtractOperationIdFromResponse(Operation operation)
        {
            try
            {
                var response = operation.GetRawResponse();
                if (response.Headers.TryGetValue("operation-location", out string operationLocation))
                {
                    var locationHeaderRegex = new Regex(@"[^:]+://[^/]+/contentunderstanding/.+/([^?/]+)", RegexOptions.Compiled);
                    var match = locationHeaderRegex.Match(operationLocation);
                    if (match.Success && match.Groups[1].Success)
                    {
                        return match.Groups[1].Value;
                    }
                }
                if (response.Content is not null)
                {
                    try
                    {
                        using var document = JsonDocument.Parse(response.Content);
                        if (document.RootElement.TryGetProperty("operationId", out JsonElement operationIdProperty))
                        {
                            return operationIdProperty.GetString();
                        }
                        if (document.RootElement.TryGetProperty("id", out JsonElement idProperty))
                        {
                            return idProperty.GetString();
                        }
                    }
                    catch (JsonException) { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️  Warning: Failed to extract operation ID: {ex.Message}");
            }
            return null;
        }

        public static async Task Main(string[] args)
        {
            try
            {
                // Load configuration
                var config = SampleHelper.LoadConfiguration();
                string? endpoint = config.Endpoint;

                if (string.IsNullOrEmpty(endpoint))
                {
                    Console.WriteLine("❌ Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is not set.");
                    Console.WriteLine("   Please set it in appsettings.json or as an environment variable.");
                    return;
                }

                // Create client with appropriate credential type
                Console.WriteLine($"🔧 Creating ContentUnderstandingClient...");
                Console.WriteLine($"   Endpoint: {endpoint}");
                ContentUnderstandingClient client;
                if (!string.IsNullOrEmpty(config.Key))
                {
                    // Use AzureKeyCredential if key is provided
                    Console.WriteLine($"   Using AzureKeyCredential authentication");
                    client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(config.Key));
                }
                else
                {
                    // Use DefaultAzureCredential for enhanced security
                    Console.WriteLine($"   Using DefaultAzureCredential authentication");
                    client = new ContentUnderstandingClient(new Uri(endpoint), new DefaultAzureCredential());
                }
                Console.WriteLine($"✅ ContentUnderstandingClient created successfully");

                // Generate a unique analyzer ID using current timestamp
                string analyzerId = $"sdk-sample-video-{DateTimeOffset.UtcNow:yyyyMMdd-HHmmss}-{Guid.NewGuid().ToString("N")[..8]}";

                // Create a video analyzer using the prebuilt video analyzer
                Console.WriteLine($"🔧 Creating video analyzer configuration...");
                var videoAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-videoAnalyzer",
                    Description = "Video analyzer for extracting keyframes",
                    Config = new ContentAnalyzerConfig
                    {
                        ReturnDetails = true
                    }
                };
                Console.WriteLine($"✅ Video analyzer configuration created");

                Console.WriteLine($"🔧 Creating marketing video analyzer '{analyzerId}'...");
                Console.WriteLine($"   Base Analyzer ID: {videoAnalyzer.BaseAnalyzerId}");
                Console.WriteLine($"   Description: {videoAnalyzer.Description}");

                // Start the create operation
                Console.WriteLine($"📡 Calling CreateOrReplaceAsync...");
                var analyzerOperation = await client.GetContentAnalyzersClient()
                    .CreateOrReplaceAsync(
                        waitUntil: WaitUntil.Completed,
                        analyzerId: analyzerId,
                        resource: videoAnalyzer);
                Console.WriteLine($"✅ CreateOrReplaceAsync completed successfully");

                // Extract operation ID for potential future use
                string creationOperationId = ExtractOperationIdFromResponse(analyzerOperation) ?? "unknown";
                Console.WriteLine($"📋 Extracted creation operation ID: {creationOperationId}");

                Console.WriteLine($"⏳ Waiting for analyzer creation to complete...");
                ContentAnalyzer analyzer = analyzerOperation.Value;
                Console.WriteLine($"✅ Analyzer '{analyzerId}' created successfully!");

                // Use a sample video file URL
                string videoFileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-assets/raw/refs/heads/main/videos/sdk_samples/FlightSimulator.mp4";
                Console.WriteLine($"📹 Using video file from URL: {videoFileUrl}");

                Console.WriteLine($"🎬 Starting video analysis with analyzer '{analyzerId}'...");
                Console.WriteLine($"   Video URL: {videoFileUrl}");

                // Analyze the video using URL
                Console.WriteLine($"📡 Calling AnalyzeAsync with URL...");
                Operation<AnalyzeResult> analysisOperation;
                try
                {
                    analysisOperation = await client.GetContentAnalyzersClient()
                        .AnalyzeAsync(
                            waitUntil: WaitUntil.Completed,
                            analyzerId: analyzerId,
                            url: new Uri(videoFileUrl));
                    Console.WriteLine($"✅ AnalyzeAsync completed successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ AnalyzeAsync failed with exception:");
                    Console.WriteLine($"   Exception Type: {ex.GetType().Name}");
                    Console.WriteLine($"   Message: {ex.Message}");
                    Console.WriteLine($"   Stack Trace: {ex.StackTrace}");
                    throw;
                }

                Console.WriteLine($"⏳ Waiting for video analysis to complete...");
                AnalyzeResult analysisResult = analysisOperation.Value;
                Console.WriteLine($"✅ Video analysis completed successfully!");

                // Extract analysis operation ID
                string analysisOperationId = ExtractOperationIdFromResponse(analysisOperation) ?? "unknown";
                Console.WriteLine($"📋 Extracted analysis operation ID: {analysisOperationId}");

                // Process the analysis result to find keyframes
                Console.WriteLine($"🔍 Using analysis result to find available files...");
                Console.WriteLine($"✅ Analysis result contains {analysisResult.Contents.Count} contents");


                // Debug: Print details about each content
                for (int i = 0; i < analysisResult.Contents.Count; i++)
                {
                    var content = analysisResult.Contents[i];
                    Console.WriteLine($"   Content {i}: Type = {content.GetType().Name}");
                    if (content is AudioVisualContent videoContent)
                    {
                        Console.WriteLine($"     - KeyFrameTimesMs: {(videoContent.KeyFrameTimesMs?.Count ?? 0)} items");
                        Console.WriteLine($"     - CameraShotTimesMs: {(videoContent.CameraShotTimesMs?.Count ?? 0)} items");
                        Console.WriteLine($"     - TranscriptPhrases: {(videoContent.TranscriptPhrases?.Count ?? 0)} items");
                    }
                }

                var keyframeTimesMs = new List<long>();
                foreach (var content in analysisResult.Contents)
                {
                    if (content is AudioVisualContent videoContent)
                    {
                        if (videoContent.KeyFrameTimesMs != null && videoContent.KeyFrameTimesMs.Count > 0)
                        {
                            keyframeTimesMs.AddRange(videoContent.KeyFrameTimesMs);
                            Console.WriteLine($"KeyFrameTimesMs: {string.Join(", ", videoContent.KeyFrameTimesMs)}");
                        }
                    }
                }

                if (keyframeTimesMs.Count == 0)
                {
                    Console.WriteLine("❌ No keyframes found in the analysis result.");
                    return;
                }

                Console.WriteLine($"📹 Found {keyframeTimesMs.Count} keyframes in video content");
                Console.WriteLine($"🖼️  Found {keyframeTimesMs.Count} keyframe times in milliseconds");

                // Create output directory
                string outputDir = Path.Combine("sample_output", "GetResultFile", analyzerId);
                Directory.CreateDirectory(outputDir);

                // Download a subset of keyframe images as examples (limit to 3 for demo)
                var keyframeFiles = keyframeTimesMs
                    .Take(3)
                    .Select(time => $"keyFrame.{time}")
                    .ToList();

                Console.WriteLine($"📥 Downloading {keyframeFiles.Count} keyframe images as examples: [{string.Join(", ", keyframeFiles)}]");

                foreach (var keyframeFile in keyframeFiles)
                {
                    try
                    {
                        Console.WriteLine($"📥 Getting result file: {keyframeFile}");

                        // Get the result file
                        var resultFileResponse = await client.GetContentAnalyzersClient()
                            .GetResultFileAsync(
                                operationId: analysisOperationId,
                                path: keyframeFile);

                        BinaryData imageContent = resultFileResponse.Value;
                        byte[] imageBytes = imageContent.ToArray();

                        Console.WriteLine($"✅ Retrieved image file for {keyframeFile} ({imageBytes.Length} bytes)");

                        // Save the image to file
                        string outputPath = Path.Combine(outputDir, $"{keyframeFile}.jpg");
                        await File.WriteAllBytesAsync(outputPath, imageBytes);

                        Console.WriteLine($"💾 Keyframe image saved to: {outputPath}");
                    }
                    catch (RequestFailedException ex)
                    {
                        Console.WriteLine($"❌ Failed to get result file '{keyframeFile}':");
                        Console.WriteLine($"   Status: {ex.Status}");
                        Console.WriteLine($"   Error Code: {ex.ErrorCode}");
                        Console.WriteLine($"   Message: {ex.Message}");
                    }
                }

                // Clean up the created analyzer (demo cleanup)
                Console.WriteLine($"\n🗑️  Deleting analyzer '{analyzerId}' (demo cleanup)...");
                await client.GetContentAnalyzersClient().DeleteAsync(analyzerId);
                Console.WriteLine($"✅ Analyzer '{analyzerId}' deleted successfully!");

                Console.WriteLine("\n💡 Next steps:");
                Console.WriteLine("   - To analyze content from URL: see AnalyzeUrl sample");
                Console.WriteLine("   - To analyze binary files: see AnalyzeBinary sample");
                Console.WriteLine("   - To create a custom analyzer: see CreateOrReplaceAnalyzer sample");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"❌ Azure service request failed:");
                Console.WriteLine($"   Status: {ex.Status}");
                Console.WriteLine($"   Error Code: {ex.ErrorCode}");
                Console.WriteLine($"   Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ An error occurred: {ex.Message}");
                Console.WriteLine($"   {ex.GetType().Name}");
            }
        }

    }
}
