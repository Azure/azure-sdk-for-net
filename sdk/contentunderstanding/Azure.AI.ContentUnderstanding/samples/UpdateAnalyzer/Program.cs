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
    /// Sample: Update an analyzer's properties using the Update API.
    ///
    /// This sample demonstrates:
    /// 1. Authenticating with Azure AI Content Understanding
    /// 2. Creating an initial analyzer with specific description and tags
    /// 3. Retrieving the analyzer to verify initial state
    /// 4. Updating the analyzer with new description and tags
    /// 5. Verifying the changes by retrieving the analyzer again
    /// 6. Cleaning up the created analyzer
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
    ///
    /// Note: Only description and tags can be updated. Other properties require creating a new analyzer.
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
                string analyzerId = $"sdk-sample-analyzer-for-update-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

                // Create initial analyzer
                Console.WriteLine($"🔧 Creating initial analyzer '{analyzerId}'...");

                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-documentAnalyzer",
                    Description = "Initial description",
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
                                Type = ContentFieldType.Number,
                                Method = GenerationMethod.Extract,
                                Description = "Total amount of this document"
                            },
                            ["company_name"] = new ContentFieldDefinition
                            {
                                Type = ContentFieldType.String,
                                Method = GenerationMethod.Extract,
                                Description = "Name of the company"
                            }
                        })
                    {
                        Name = "update_demo_schema",
                        Description = "Schema for update demo"
                    },
                    Mode = AnalysisMode.Standard,
                    ProcessingLocation = ProcessingLocation.Global
                };

                // Add tags to the analyzer
                initialAnalyzer.Tags["tag1"] = "tag1_initial_value";
                initialAnalyzer.Tags["tag2"] = "tag2_initial_value";

                // Start the create operation
                var createOperation = await client.GetContentAnalyzersClient()
                    .CreateOrReplaceAsync(
                        waitUntil: WaitUntil.Completed,
                        analyzerId: analyzerId,
                        resource: initialAnalyzer);

                Console.WriteLine($"⏳ Waiting for analyzer creation to complete...");
                Console.WriteLine($"✅ Analyzer '{analyzerId}' created successfully!");

                // Get the analyzer before update to verify initial state
                Console.WriteLine($"📋 Getting analyzer '{analyzerId}' before update...");
                var beforeUpdateResponse = await client.GetContentAnalyzersClient().GetAsync(analyzerId);
                var analyzerBeforeUpdate = beforeUpdateResponse.Value;

                Console.WriteLine($"✅ Initial analyzer state verified:");
                Console.WriteLine($"   Description: {analyzerBeforeUpdate.Description}");
                Console.Write($"   Tags: {{");
                if (analyzerBeforeUpdate.Tags != null)
                {
                    Console.Write(string.Join(", ", analyzerBeforeUpdate.Tags.Select(kv => $"'{kv.Key}': '{kv.Value}'")));
                }
                Console.WriteLine("}");

                // Create updated analyzer with only allowed properties (description and tags)
                Console.WriteLine($"🔄 Creating updated analyzer configuration...");
                // Update the value for tag1, remove tag2 by setting it to an empty string, and add tag3
                var updatedAnalyzer = new ContentAnalyzer
                {
                    Description = "Updated description"
                };

                // Modify tags - update tag1, remove tag2 (set to empty), add tag3
                updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
                updatedAnalyzer.Tags["tag2"] = "";  // Remove tag2
                updatedAnalyzer.Tags["tag3"] = "tag3_value";  // Add tag3

                // Update the analyzer using the protocol method
                Console.WriteLine($"📝 Updating analyzer '{analyzerId}' with new description and tags...");
                await client.GetContentAnalyzersClient().UpdateAsync(
                    analyzerId: analyzerId,
                    content: updatedAnalyzer);

                Console.WriteLine($"✅ Analyzer updated successfully!");

                // Get the analyzer after update to verify the changes persisted
                Console.WriteLine($"📋 Getting analyzer '{analyzerId}' after update...");
                var afterUpdateResponse = await client.GetContentAnalyzersClient().GetAsync(analyzerId);
                var analyzerAfterUpdate = afterUpdateResponse.Value;

                Console.WriteLine($"✅ Updated analyzer state verified:");
                Console.WriteLine($"   Description: {analyzerAfterUpdate.Description}");
                Console.Write($"   Tags: {{");
                if (analyzerAfterUpdate.Tags != null)
                {
                    Console.Write(string.Join(", ", analyzerAfterUpdate.Tags.Select(kv => $"'{kv.Key}': '{kv.Value}'")));
                }
                Console.WriteLine("}");

                // Clean up the created analyzer (demo cleanup)
                Console.WriteLine($"\n🗑️  Deleting analyzer '{analyzerId}' (demo cleanup)...");
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

