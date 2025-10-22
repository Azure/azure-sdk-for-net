// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using static Azure.AI.ContentUnderstanding.Samples.SampleHelper;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Sample: Classify content using binary file classification API.
    ///
    /// This sample demonstrates:
    /// 1. Authenticate with Azure AI Content Understanding
    /// 2. Read a binary file from disk
    /// 3. Classify the content using a content classifier
    /// 4. Print the classification results
    /// </summary>
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Load configuration from appsettings.json and environment variables
            var config = LoadConfiguration();

            string? endpoint = config.Endpoint;
            if (string.IsNullOrEmpty(endpoint))
            {
                Console.WriteLine("❌ Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is not set.");
                Console.WriteLine("Please set it in appsettings.json or as an environment variable.");
                return;
            }

            try
            {
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

                // Create a classifier first
                string classifierId = $"sample-binary-classifier-{DateTime.Now:yyyyMMdd-HHmmss}";
                Console.WriteLine($"🔧 Creating classifier: {classifierId}");

                var categories = new Dictionary<string, ClassifierCategoryDefinition>
                {
                    ["Invoice"] = new ClassifierCategoryDefinition { Description = "Invoice documents" },
                    ["Receipt"] = new ClassifierCategoryDefinition { Description = "Receipt documents" },
                    ["Contract"] = new ClassifierCategoryDefinition { Description = "Contract documents" }
                };

                var classifier = new ContentClassifier(categories)
                {
                    Description = "Sample binary classifier for document classification"
                };

                var createOperation = await client.GetContentClassifiersClient()
                    .CreateOrReplaceAsync(
                        waitUntil: WaitUntil.Completed,
                        classifierId: classifierId,
                        resource: classifier);

                Console.WriteLine($"✅ Classifier created successfully!");

                // Load sample file for classification
                string sampleFilePath = Path.Combine("sample_files", "sample_document.pdf");
                if (!File.Exists(sampleFilePath))
                {
                    Console.WriteLine($"❌ Error: Sample file not found at {sampleFilePath}");
                    Console.WriteLine("Please ensure the sample file exists in the sample_files directory.");
                    return;
                }

                Console.WriteLine($"📄 Using sample file: {sampleFilePath}");
                byte[] fileBytes = await File.ReadAllBytesAsync(sampleFilePath);
                BinaryData fileData = new BinaryData(fileBytes);
                Console.WriteLine($"✅ File loaded successfully ({fileBytes.Length} bytes)");

                // Start the classification operation
                Console.WriteLine($"🚀 Starting content classification...");
                var classifyOperation = await client.GetContentClassifiersClient()
                    .ClassifyBinaryAsync(
                        waitUntil: WaitUntil.Completed,
                        classifierId: classifierId,
                        contentType: "application/pdf",
                        input: fileData);

                Console.WriteLine($"✅ Classification completed successfully!");

                // Get the classification result using SDK wrapper
                var classifyResult = classifyOperation.Value;
                Console.WriteLine($"🔍 Classification Results:");
                Console.WriteLine($"   Classifier ID: {classifyResult.ClassifierId}");

                // Display warnings if any
                if (classifyResult.Warnings != null && classifyResult.Warnings.Count > 0)
                {
                    Console.WriteLine($"⚠️  Warnings ({classifyResult.Warnings.Count}):");
                    foreach (var warning in classifyResult.Warnings)
                    {
                        Console.WriteLine($"   - {warning.Message}");
                    }
                }

                // Process and display classification results
                Console.WriteLine($"\n📊 Classification Results:");
                foreach (var content in classifyResult.Contents)
                {
                    Console.WriteLine($"\n📄 Content Type: {content.GetType().Name}");
                    Console.WriteLine($"   Category: {content.Category}");
                }

                // Clean up: delete the classifier
                Console.WriteLine($"\n🧹 Cleaning up...");
                await client.GetContentClassifiersClient()
                    .DeleteAsync(classifierId);
                Console.WriteLine($"✅ Classifier deleted successfully!");

                Console.WriteLine($"\n💡 Next steps:");
                Console.WriteLine($"   - To analyze content from URL: see AnalyzeUrl sample");
                Console.WriteLine($"   - To analyze binary files: see AnalyzeBinary sample");
                Console.WriteLine($"   - To create a custom classifier: see CreateOrReplaceClassifier sample");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ An error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}
