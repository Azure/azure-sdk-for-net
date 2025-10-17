// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Sample: List all available analyzers using the List API.
    ///
    /// This sample demonstrates:
    /// 1. Authenticating with Azure AI Content Understanding
    /// 2. Listing all available analyzers
    /// 3. Displaying detailed information about each analyzer
    /// 4. Distinguishing between prebuilt and custom analyzers
    /// 5. Showing summary statistics
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
                ContentUnderstandingClient client;
                if (!string.IsNullOrEmpty(config.Key))
                {
                    // Use AzureKeyCredential if key is provided
                    client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(config.Key));
                }
                else
                {
                    // Use DefaultAzureCredential for enhanced security
                    client = new ContentUnderstandingClient(new Uri(endpoint), new DefaultAzureCredential());
                }

                Console.WriteLine($"📋 Listing all available analyzers...");

                // List all analyzers
                var analyzers = new List<ContentAnalyzer>();
                await foreach (var analyzer in client.GetContentAnalyzersClient().GetAllAsync())
                {
                    analyzers.Add(analyzer);
                }

                Console.WriteLine($"✅ Found {analyzers.Count} analyzers\n");

                // Display detailed information about each analyzer
                int counter = 1;
                foreach (var analyzer in analyzers)
                {
                    Console.WriteLine($"🔍 Analyzer {counter}:");
                    Console.WriteLine($"   ID: {analyzer.AnalyzerId}");
                    Console.WriteLine($"   Description: {analyzer.Description}");
                    Console.WriteLine($"   Status: {analyzer.Status}");
                    Console.WriteLine($"   Created at: {analyzer.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");

                    // Check if it's a prebuilt analyzer
                    if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
                    {
                        Console.WriteLine($"   Type: Prebuilt analyzer");
                    }
                    else
                    {
                        Console.WriteLine($"   Type: Custom analyzer");
                    }

                    // Show tags if available
                    if (analyzer.Tags != null && analyzer.Tags.Count > 0)
                    {
                        Console.WriteLine($"   Tags:");
                        foreach (var tag in analyzer.Tags)
                        {
                            Console.WriteLine($"      - {tag.Key}: {tag.Value}");
                        }
                    }

                    Console.WriteLine();
                    counter++;
                }

                // Check for specific prebuilt analyzers
                var prebuiltAnalyzers = analyzers
                    .Where(a => a.AnalyzerId?.StartsWith("prebuilt-") == true)
                    .Select(a => a.AnalyzerId)
                    .ToList();

                if (prebuiltAnalyzers.Contains("prebuilt-documentAnalyzer"))
                {
                    Console.WriteLine("   ✅ prebuilt-documentAnalyzer is available");
                }
                if (prebuiltAnalyzers.Contains("prebuilt-videoAnalyzer"))
                {
                    Console.WriteLine("   ✅ prebuilt-videoAnalyzer is available");
                }

                Console.WriteLine("\n💡 Next steps:");
                Console.WriteLine("   - To create an analyzer: see CreateOrReplaceAnalyzer sample");
                Console.WriteLine("   - To get a specific analyzer: see GetAnalyzer sample");
                Console.WriteLine("   - To update an analyzer: see UpdateAnalyzer sample");
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

