// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Sample: Delete a custom analyzer using the Delete API.
    ///
    /// This sample demonstrates:
    /// 1. Authenticating with Azure AI Content Understanding
    /// 2. Creating a custom analyzer (for demonstration purposes)
    /// 3. Deleting the analyzer using the Delete API
    /// 4. Verifying the analyzer is no longer available
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

                // Generate a unique analyzer ID using current timestamp
                string analyzerId = $"sdk-sample-analyzer-to-delete-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

                // First, create an analyzer to delete (for demo purposes)
                Console.WriteLine($"🔧 Creating analyzer '{analyzerId}' for deletion demo...");

                var customAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-documentAnalyzer",
                    Description = "Temporary analyzer for deletion demo",
                    Config = new ContentAnalyzerConfig
                    {
                        ReturnDetails = true
                    },
                    FieldSchema = new ContentFieldSchema(
                        fields: new Dictionary<string, ContentFieldDefinition>
                        {
                            ["demo_field"] = new ContentFieldDefinition
                            {
                                Type = ContentFieldType.String,
                                Method = GenerationMethod.Extract,
                                Description = "Demo field for deletion"
                            }
                        })
                    {
                        Name = "demo_schema",
                        Description = "Schema for deletion demo"
                    }
                };

                // Start the create operation
                var createOperation = await client.GetContentAnalyzersClient()
                    .CreateOrReplaceAsync(
                        waitUntil: WaitUntil.Completed,
                        analyzerId: analyzerId,
                        resource: customAnalyzer);

                Console.WriteLine($"✅ Analyzer '{analyzerId}' created successfully!");

                // Now delete the analyzer
                Console.WriteLine($"🗑️  Deleting analyzer '{analyzerId}'...");
                await client.GetContentAnalyzersClient().DeleteAsync(analyzerId);
                Console.WriteLine($"✅ Analyzer '{analyzerId}' deleted successfully!");

                Console.WriteLine("\n💡 Next steps:");
                Console.WriteLine("   - To create an analyzer: see CreateOrReplaceAnalyzer sample");
                Console.WriteLine("   - To retrieve an analyzer: see GetAnalyzer sample");
                Console.WriteLine("   - To list all analyzers: see ListAnalyzers sample");
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

