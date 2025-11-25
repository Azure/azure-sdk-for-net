// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to retrieve result files (such as keyframe images) from a video analysis operation.
///
/// Prerequisites:
///     - Azure subscription
///     - Microsoft Foundry resource
///     - .NET 8.0 SDK or later
///
/// Setup:
///     Set the following environment variables or add them to appsettings.json:
///     - AZURE_CONTENT_UNDERSTANDING_ENDPOINT (required)
///     - AZURE_CONTENT_UNDERSTANDING_KEY (optional - DefaultAzureCredential will be used if not set)
///
/// To run:
///     dotnet run
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        // Load configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var endpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"];
        if (string.IsNullOrEmpty(endpoint))
        {
            Console.Error.WriteLine("Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required.");
            Console.Error.WriteLine("Please set it in environment variables or appsettings.json");
            Environment.Exit(1);
        }

        // Trim and validate endpoint
        endpoint = endpoint.Trim();
        if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri))
        {
            Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
            Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.services.ai.azure.com/)");
            Environment.Exit(1);
        }

        // Create client with appropriate authentication
        var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
        ContentUnderstandingClient client;
        if (!string.IsNullOrEmpty(apiKey))
        {
            client = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
        }
        else
        {
            var credential = new DefaultAzureCredential();
            client = new ContentUnderstandingClient(endpointUri, credential);
        }

        // === EXTRACTED SNIPPET CODE ===
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
        AnalyzeResult result = analyzeOperation.Value;

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
        // === END SNIPPET ===
    }
}
