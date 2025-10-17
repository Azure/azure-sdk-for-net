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
    /// Sample: Create a custom analyzer using CreateOrReplace API.
    ///
    /// This sample demonstrates:
    /// 1. Authenticating with Azure AI Content Understanding
    /// 2. Creating a custom analyzer with field schema using object model
    /// 3. Waiting for analyzer creation to complete
    /// 4. Cleaning up the created analyzer
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
            string analyzerId = $"sdk-sample-custom-analyzer-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            // Create a custom analyzer using object model
            var customAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-documentAnalyzer",
                Description = "Custom analyzer for extracting company information",
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
                        ["company_name"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Method = GenerationMethod.Extract,
                            Description = "Name of the company"
                        },
                        ["total_amount"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.Number,
                            Method = GenerationMethod.Extract,
                            Description = "Total amount on the document"
                        }
                    })
                {
                    Name = "company_schema",
                    Description = "Schema for extracting company information"
                }
            };

            Console.WriteLine($"🔧 Creating custom analyzer '{analyzerId}'...");

            // Start the create or replace operation
            var analyzerOperation = await client.GetContentAnalyzersClient()
                .CreateOrReplaceAsync(
                    waitUntil: WaitUntil.Completed,
                    analyzerId: analyzerId,
                    resource: customAnalyzer);

            // Get the result
            ContentAnalyzer result = analyzerOperation.Value;
            Console.WriteLine($"✅ Analyzer '{analyzerId}' created successfully!");
            Console.WriteLine($"   Status: {result.Status}");
            Console.WriteLine($"   Created At: {result.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");
            Console.WriteLine($"   Base Analyzer: {result.BaseAnalyzerId}");
            Console.WriteLine($"   Description: {result.Description}");

            // Display field schema information
            if (result.FieldSchema != null)
            {
                Console.WriteLine($"\n📋 Field Schema: {result.FieldSchema.Name}");
                Console.WriteLine($"   {result.FieldSchema.Description}");
                Console.WriteLine($"   Fields:");
                foreach (var field in result.FieldSchema.Fields)
                {
                    Console.WriteLine($"      - {field.Key}: {field.Value.Type} ({field.Value.Method})");
                    Console.WriteLine($"        {field.Value.Description}");
                }
            }

            // Display any warnings
            if (result.Warnings != null && result.Warnings.Count > 0)
            {
                Console.WriteLine($"\n⚠️  Warnings:");
                foreach (var warning in result.Warnings)
                {
                    Console.WriteLine($"      - {warning.Code}: {warning.Message}");
                }
            }

            // Clean up the created analyzer (demo cleanup)
            Console.WriteLine($"\n🗑️  Deleting analyzer '{analyzerId}' (demo cleanup)...");
            await client.GetContentAnalyzersClient().DeleteAsync(analyzerId);
            Console.WriteLine($"✅ Analyzer '{analyzerId}' deleted successfully!");

            Console.WriteLine("\n💡 Next steps:");
            Console.WriteLine("   - To retrieve an analyzer: see GetAnalyzer sample");
            Console.WriteLine("   - To use the analyzer for analysis: see AnalyzeBinary sample");
            Console.WriteLine("   - To delete an analyzer: see DeleteAnalyzer sample");
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

