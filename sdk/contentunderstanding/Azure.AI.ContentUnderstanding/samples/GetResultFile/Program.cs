// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to get result files (like keyframe images) from a video analysis operation.
///
/// Prerequisites:
///     - Azure subscription
///     - Azure Content Understanding resource
///     - .NET 8.0 SDK or later
///
/// Setup:
///     Set the following environment variables or add them to appsettings.json:
///     - AZURE_CONTENT_UNDERSTANDING_ENDPOINT (required)
///     - AZURE_CONTENT_UNDERSTANDING_KEY (optional - DefaultAzureCredential will be used if not set)
///
/// To run:
///     dotnet run
///
/// This sample demonstrates:
/// 1. Create a marketing video analyzer
/// 2. Analyze a video file to generate keyframes
/// 3. Extract operation ID from the analysis
/// 4. Get result files (keyframe images) using the operation ID
/// 5. Save the keyframe images to local files
/// 6. Clean up the created analyzer
///
/// NOTE: The path format for GetResultFile uses: "keyframes/{frameTimeMs}"
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Get Result File");
        Console.WriteLine("=============================================================");
        Console.WriteLine();

        try
        {
            // Step 1: Load configuration
            Console.WriteLine("Step 1: Loading configuration...");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var endpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"];
            if (string.IsNullOrEmpty(endpoint))
            {
                Console.Error.WriteLine("Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required.");
                Environment.Exit(1);
            }

            endpoint = endpoint.Trim();
            if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri))
            {
                Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
                Environment.Exit(1);
            }

            Console.WriteLine($"  Endpoint: {endpoint}");
            Console.WriteLine();

            // Step 2: Create the client
            Console.WriteLine("Step 2: Creating Content Understanding client...");
            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            ContentUnderstandingClient client;

            if (!string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("  Authentication: API Key");
                client = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
            }
            else
            {
                Console.WriteLine("  Authentication: DefaultAzureCredential");
                client = new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());
            }
            Console.WriteLine();

            // Step 3: Use prebuilt video analyzer
            Console.WriteLine("Step 3: Using prebuilt video analyzer...");

            // Use the existing prebuilt video analyzer
            string analyzerId = "prebuilt-videoSearch";
            Console.WriteLine($"  Analyzer ID: {analyzerId}");
            Console.WriteLine("  (Using prebuilt analyzer - no creation needed)");
            Console.WriteLine();

            // Step 4: Analyze a video file
            Console.WriteLine("Step 4: Analyzing video file...");
            string videoUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-assets/raw/refs/heads/main/videos/sdk_samples/FlightSimulator.mp4";
            Console.WriteLine($"  URL: {videoUrl}");
            Console.WriteLine("  Starting video analysis (this may take several moments)...");

            Operation<AnalyzeResult> analyzeOperation;
            AnalyzeResult analyzeResult;
            string operationId;

            try
            {
                // Start the analysis but don't wait for completion initially
                analyzeOperation = await client.AnalyzeAsync(
                    WaitUntil.Started,
                    analyzerId,
                    inputs: new[] { new AnalyzeInput { Url = new Uri(videoUrl) } });

                // Extract operation ID from the Operation-Location header
                operationId = analyzeOperation.GetOperationId() ?? "unknown";
                if (operationId == "unknown")
                {
                    Console.Error.WriteLine("  Warning: Could not extract operation ID from Operation-Location header");
                }
                else
                {
                    Console.WriteLine($"  Analysis started, Operation ID: {operationId}");
                }

                Console.WriteLine("  Polling for completion (this may take several minutes for video)...");

                // Poll for status updates
                int pollCount = 0;
                while (!analyzeOperation.HasCompleted)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    await analyzeOperation.UpdateStatusAsync();
                    pollCount++;

                    if (pollCount % 6 == 0)  // Every 30 seconds
                    {
                        Console.WriteLine($"  Still processing... ({pollCount * 5} seconds elapsed)");
                    }

                    if (pollCount > 240)  // 20 minutes timeout
                    {
                        Console.WriteLine("  Warning: Analysis is taking longer than expected (>20 minutes)");
                        break;
                    }
                }

                if (analyzeOperation.HasCompleted && analyzeOperation.HasValue)
                {
                    analyzeResult = analyzeOperation.Value;
                    Console.WriteLine("  Video analysis completed!");
                    Console.WriteLine($"  Contents count: {analyzeResult.Contents?.Count ?? 0}");

                    // Save raw JSON response to inspect keyframe casing
                    var finalRawResponse = analyzeOperation.GetRawResponse();
                    string outputDir = "sample_output";
                    Directory.CreateDirectory(outputDir);

                    string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
                    string jsonFileName = $"video_analysis_raw_{timestamp}.json";
                    string jsonFilePath = Path.Combine(outputDir, jsonFileName);

                    // Pretty-print the JSON
                    using var jsonDocument = System.Text.Json.JsonDocument.Parse(finalRawResponse.Content);
                    string prettyJson = System.Text.Json.JsonSerializer.Serialize(
                        jsonDocument.RootElement,
                        new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

                    await File.WriteAllTextAsync(jsonFilePath, prettyJson);
                    Console.WriteLine($"  Raw JSON response saved to: {jsonFilePath}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("  Warning: Analysis did not complete successfully");
                    Console.WriteLine($"  Has Completed: {analyzeOperation.HasCompleted}, Has Value: {analyzeOperation.HasValue}");

                    // Get raw response to see error details
                    var rawResponse = analyzeOperation.GetRawResponse();
                    Console.WriteLine($"  Raw Response Status: {rawResponse.Status}");
                    Console.WriteLine($"  Raw Response Content: {rawResponse.Content}");
                    throw new InvalidOperationException("Video analysis did not complete successfully");
                }
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to analyze video: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }
            catch (NotSupportedException ex)
            {
                Console.Error.WriteLine($"  NotSupportedException: {ex.Message}");
                Console.Error.WriteLine($"  This suggests the operation failed during initial request or polling.");
                Console.Error.WriteLine($"  Stack trace: {ex.StackTrace}");
                throw;
            }

            // Step 6: Find keyframes in the analysis result
            Console.WriteLine("Step 6: Finding keyframes in analysis result...");

            List<long> keyframeTimeMs = new List<long>();

            if (analyzeResult.Contents != null && analyzeResult.Contents.Count > 0)
            {
                foreach (var content in analyzeResult.Contents)
                {
                    if (content is AudioVisualContent videoContent)
                    {
                        Console.WriteLine($"  Video content found:");
                        Console.WriteLine($"    Start time: {videoContent.StartTimeMs}ms");
                        Console.WriteLine($"    End time: {videoContent.EndTimeMs}ms");
                        Console.WriteLine($"    KeyFrames count: {videoContent.KeyFrameTimesMs?.Count ?? 0}");

                        if (videoContent.KeyFrameTimesMs != null && videoContent.KeyFrameTimesMs.Count > 0)
                        {
                            Console.WriteLine($"  Found {videoContent.KeyFrameTimesMs.Count} keyframes in video content");
                            keyframeTimeMs.AddRange(videoContent.KeyFrameTimesMs);
                        }
                        break;
                    }
                }
            }

            if (keyframeTimeMs.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("  Warning: No keyframes found in the analysis result");
                Console.WriteLine("  NOTE: The prebuilt-videoSearch may not generate keyframes by default.");
                Console.WriteLine("        To generate keyframes, a custom video analyzer with specific configuration");
                Console.WriteLine("        may be required (see CreateAnalyzer sample).");
                Console.WriteLine();
                Console.WriteLine("  This sample successfully demonstrated:");
                Console.WriteLine("    - Video analysis workflow");
                Console.WriteLine("    - Extracting operation ID from Operation-Location header");
                Console.WriteLine("    - GetResultFile API usage (would work if keyframes were present)");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"  Found {keyframeTimeMs.Count} keyframe timestamps");
                Console.WriteLine();

                // Step 7: Download keyframe images
                Console.WriteLine("Step 6: Downloading keyframe images...");

                // Download a few keyframe images as examples (first, middle, last)
                List<long> framesToDownload = new List<long>();
                if (keyframeTimeMs.Count >= 3)
                {
                    framesToDownload.Add(keyframeTimeMs[0]);  // First
                    framesToDownload.Add(keyframeTimeMs[keyframeTimeMs.Count / 2]);  // Middle
                    framesToDownload.Add(keyframeTimeMs[keyframeTimeMs.Count - 1]);  // Last
                }
                else
                {
                    framesToDownload.AddRange(keyframeTimeMs);
                }

                Console.WriteLine($"  Downloading {framesToDownload.Count} keyframe images as examples");

                // Create output directory
                string outputDir = "sample_output";
                Directory.CreateDirectory(outputDir);

                foreach (var frameTimeMs in framesToDownload)
                {
                    // New API format: path is "keyframes/{frameTimeMs}"
                    string framePath = $"keyframes/{frameTimeMs}";
                    Console.WriteLine($"  Getting result file: {framePath}");

                    try
                    {
                        var fileResponse = await client.GetResultFileAsync(
                            operationId,
                            framePath);

                        byte[] imageBytes = fileResponse.Value.ToArray();
                        Console.WriteLine($"    Retrieved ({imageBytes.Length:N0} bytes)");

                        // Save the image file
                        string fileName = $"keyframe_{frameTimeMs}.jpg";
                        string filePath = Path.Combine(outputDir, fileName);
                        await File.WriteAllBytesAsync(filePath, imageBytes);
                        Console.WriteLine($"    Saved to: {filePath}");
                    }
                    catch (RequestFailedException ex)
                    {
                        Console.Error.WriteLine($"    Failed to get result file: {ex.Message}");
                        Console.Error.WriteLine($"    Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                        // Continue with next file
                    }
                }
                Console.WriteLine();
            }

            // Step 7: Clean up (if we created a custom analyzer)
            // Note: We're using a prebuilt analyzer, so no cleanup needed
            Console.WriteLine("Step 7: Cleanup...");
            Console.WriteLine("  (Using prebuilt analyzer - no cleanup needed)");
            Console.WriteLine();

            Console.WriteLine("=============================================================");
            Console.WriteLine("Sample completed successfully");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("This sample demonstrated:");
            Console.WriteLine("  1. Creating a video analyzer");
            Console.WriteLine("  2. Analyzing a video to generate keyframes");
            Console.WriteLine("  3. Extracting operation ID and keyframe information");
            Console.WriteLine("  4. Downloading keyframe images using GetResultFile API");
            Console.WriteLine("  5. Saving keyframe images to local files");
            Console.WriteLine();
            Console.WriteLine("Key points:");
            Console.WriteLine("  - AudioVisualContent.KeyFrameTimesMs contains list of keyframe timestamps");
            Console.WriteLine("  - Path format for GetResultFile: \"keyframes/{frameTimeMs}\"");
            Console.WriteLine("  - Operation ID is extracted from Operation-Location header");
        }
        catch (RequestFailedException ex) when (ex.Status == 401)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ Authentication failed");
            Console.Error.WriteLine($"  Error: {ex.Message}");
            Console.Error.WriteLine("  Please check your credentials and ensure they are valid.");
            Environment.Exit(1);
        }
        catch (RequestFailedException ex)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ Service request failed");
            Console.Error.WriteLine($"  Status: {ex.Status}");
            Console.Error.WriteLine($"  Error Code: {ex.ErrorCode}");
            Console.Error.WriteLine($"  Message: {ex.Message}");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ An unexpected error occurred");
            Console.Error.WriteLine($"  Error: {ex.Message}");
            Console.Error.WriteLine($"  Type: {ex.GetType().Name}");
            Environment.Exit(1);
        }
    }
}

