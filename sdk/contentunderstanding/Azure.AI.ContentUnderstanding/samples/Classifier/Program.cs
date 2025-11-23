// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to create classifiers that categorize documents and optionally extract fields using custom analyzers.
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
/// 1. Create a basic classifier with contentCategories
/// 2. Create a custom loan analyzer with field schema
/// 3. Create an enhanced classifier that uses the custom analyzer
/// 4. Classify documents and display results
/// 5. Clean up created analyzers
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Classifier");
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
                Console.Error.WriteLine("Please set it in environment variables or appsettings.json");
                Environment.Exit(1);
            }

            endpoint = endpoint.Trim();
            if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri))
            {
                Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
                Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.cognitiveservices.azure.com/)");
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

            // Generate unique IDs
            var classifierId = $"classifier_sample_{Guid.NewGuid():N}";
            var loanAnalyzerId = $"loan_analyzer_{Guid.NewGuid():N}";
            var enhancedClassifierId = $"enhanced_classifier_{Guid.NewGuid():N}";

            // Step 3: Create basic classifier
            Console.WriteLine("Step 3: Creating basic classifier...");
            Console.WriteLine($"  Classifier ID: {classifierId}");

            var basicConfig = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = true
            };

            basicConfig.ContentCategories.Add("Loan application", new ContentCategoryDefinition
            {
                Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
            });
            basicConfig.ContentCategories.Add("Invoice", new ContentCategoryDefinition
            {
                Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
            });
            basicConfig.ContentCategories.Add("Bank_Statement", new ContentCategoryDefinition
            {
                Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
            });

            var basicClassifier = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = $"Custom classifier for classification demo: {classifierId}",
                Config = basicConfig
            };

            basicClassifier.Models.Add("completion", "gpt-4.1");
            basicClassifier.Tags.Add("demo_type", "classification");

            try
            {
                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    classifierId,
                    basicClassifier,
                    allowReplace: true);

                var createdClassifier = createOperation.Value;
                Console.WriteLine($"  Classifier created successfully");
                Console.WriteLine($"  Status: {createdClassifier.Status}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to create classifier: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 4: Classify a document using the basic classifier
            Console.WriteLine("Step 4: Classifying document with basic classifier...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/mixed_financial_docs.pdf";
            Console.WriteLine($"  URL: {fileUrl}");
            Console.WriteLine("  Analyzing...");

            try
            {
                if (!Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri))
                {
                    throw new ArgumentException($"Invalid URL format: {fileUrl}");
                }

                var analyzeOperation = await client.AnalyzeAsync(
                    WaitUntil.Completed,
                    classifierId,
                    inputs: new[] { new AnalyzeInput { Url = uri } });

                var analyzeResult = analyzeOperation.Value;
                Console.WriteLine("  Analysis completed successfully");
                Console.WriteLine();

                // Display classification results
                DisplayClassificationResults(analyzeResult, "Basic Classifier");
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to classify document: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 5: Create custom loan analyzer
            Console.WriteLine("Step 5: Creating custom loan analyzer...");
            Console.WriteLine($"  Analyzer ID: {loanAnalyzerId}");

            var loanFieldSchema = new ContentFieldSchema(
                new Dictionary<string, ContentFieldDefinition>
                {
                    ["ApplicationDate"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.Date,
                        Method = GenerationMethod.Generate,
                        Description = "The date when the loan application was submitted."
                    },
                    ["ApplicantName"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Generate,
                        Description = "Full name of the loan applicant or company."
                    },
                    ["LoanAmountRequested"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.Number,
                        Method = GenerationMethod.Generate,
                        Description = "The total loan amount requested by the applicant."
                    },
                    ["LoanPurpose"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Generate,
                        Description = "The stated purpose or reason for the loan."
                    },
                    ["CreditScore"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.Number,
                        Method = GenerationMethod.Generate,
                        Description = "Credit score of the applicant, if available."
                    },
                    ["Summary"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Generate,
                        Description = "A brief summary overview of the loan application details."
                    }
                });

            var loanConfig = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableLayout = true,
                EstimateFieldSourceAndConfidence = true
            };

            var loanAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Loan application analyzer - extracts key information from loan applications",
                Config = loanConfig,
                FieldSchema = loanFieldSchema
            };

            loanAnalyzer.Models.Add("completion", "gpt-4.1");
            loanAnalyzer.Tags.Add("demo", "loan-application");

            try
            {
                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    loanAnalyzerId,
                    loanAnalyzer,
                    allowReplace: true);

                var createdAnalyzer = createOperation.Value;
                Console.WriteLine($"  Loan analyzer created successfully");
                Console.WriteLine($"  Status: {createdAnalyzer.Status}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to create loan analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 6: Create enhanced classifier with custom analyzer
            Console.WriteLine("Step 6: Creating enhanced classifier with custom analyzer...");
            Console.WriteLine($"  Classifier ID: {enhancedClassifierId}");

            var enhancedConfig = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = true
            };

            enhancedConfig.ContentCategories.Add("Loan application", new ContentCategoryDefinition
            {
                Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation.",
                AnalyzerId = loanAnalyzerId
            });
            enhancedConfig.ContentCategories.Add("Invoice", new ContentCategoryDefinition
            {
                Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
            });
            enhancedConfig.ContentCategories.Add("Bank_Statement", new ContentCategoryDefinition
            {
                Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
            });

            var enhancedClassifier = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = $"Enhanced classifier with custom loan analyzer: {enhancedClassifierId}",
                Config = enhancedConfig
            };

            enhancedClassifier.Models.Add("completion", "gpt-4.1");
            enhancedClassifier.Tags.Add("demo_type", "enhanced_classification");

            try
            {
                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    enhancedClassifierId,
                    enhancedClassifier,
                    allowReplace: true);

                var createdClassifier = createOperation.Value;
                Console.WriteLine($"  Enhanced classifier created successfully");
                Console.WriteLine($"  Status: {createdClassifier.Status}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to create enhanced classifier: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 7: Classify a document using the enhanced classifier
            Console.WriteLine("Step 7: Classifying document with enhanced classifier...");
            Console.WriteLine($"  URL: {fileUrl}");
            Console.WriteLine("  Analyzing...");

            try
            {
                if (!Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri))
                {
                    throw new ArgumentException($"Invalid URL format: {fileUrl}");
                }

                var analyzeOperation = await client.AnalyzeAsync(
                    WaitUntil.Completed,
                    enhancedClassifierId,
                    inputs: new[] { new AnalyzeInput { Url = uri } });

                var analyzeResult = analyzeOperation.Value;
                Console.WriteLine("  Analysis completed successfully");
                Console.WriteLine();

                // Display classification results with extracted fields
                DisplayClassificationResults(analyzeResult, "Enhanced Classifier");
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to classify document: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 8: Clean up
            Console.WriteLine("Step 8: Cleaning up...");
            try
            {
                await client.DeleteAnalyzerAsync(classifierId);
                Console.WriteLine($"  Deleted classifier: {classifierId}");
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to delete classifier {classifierId}: {ex.Message}");
            }

            try
            {
                await client.DeleteAnalyzerAsync(loanAnalyzerId);
                Console.WriteLine($"  Deleted analyzer: {loanAnalyzerId}");
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to delete analyzer {loanAnalyzerId}: {ex.Message}");
            }

            try
            {
                await client.DeleteAnalyzerAsync(enhancedClassifierId);
                Console.WriteLine($"  Deleted classifier: {enhancedClassifierId}");
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to delete classifier {enhancedClassifierId}: {ex.Message}");
            }

            Console.WriteLine();

            Console.WriteLine("=============================================================");
            Console.WriteLine("Sample completed successfully");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("This sample demonstrated:");
            Console.WriteLine("  1. Creating a basic classifier with contentCategories");
            Console.WriteLine("  2. Creating a custom loan analyzer with field schema");
            Console.WriteLine("  3. Creating an enhanced classifier that uses the custom analyzer");
            Console.WriteLine("  4. Classifying documents and displaying results");
            Console.WriteLine("  5. Cleaning up created analyzers");
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

    static void DisplayClassificationResults(AnalyzeResult result, string classifierType)
    {
        Console.WriteLine($"Classification Results ({classifierType}):");
        Console.WriteLine("=============================================================");

        if (result.Contents == null || result.Contents.Count == 0)
        {
            Console.WriteLine("No contents found in classification result.");
            Console.WriteLine();
            return;
        }

        int segmentIndex = 0;
        foreach (var content in result.Contents)
        {
            if (content is DocumentContent documentContent)
            {
                // Check if this document has segments (from enableSegment)
                if (documentContent.Segments != null && documentContent.Segments.Count > 0)
                {
                    // Display segments
                    foreach (var segment in documentContent.Segments)
                    {
                        segmentIndex++;
                        Console.WriteLine($"\nSegment {segmentIndex}:");
                        Console.WriteLine($"   Category: {segment.Category ?? "(unknown)"}");
                        Console.WriteLine($"   Start Page: {segment.StartPageNumber}");
                        Console.WriteLine($"   End Page: {segment.EndPageNumber}");
                        if (!string.IsNullOrEmpty(segment.SegmentId))
                        {
                            Console.WriteLine($"   Segment ID: {segment.SegmentId}");
                        }

                        // Display extracted fields if available
                        // Note: Fields are on the parent documentContent, not on segments
                        // We would need to find the corresponding content for this segment
                        if (documentContent.Fields != null && documentContent.Fields.Count > 0)
                        {
                            DisplayExtractedFields(documentContent.Fields);
                        }
                    }
                }
                else
                {
                    // Single document classification (no segments)
                    segmentIndex++;
                    Console.WriteLine($"\nDocument {segmentIndex}:");
                    if (!string.IsNullOrEmpty(documentContent.Category))
                    {
                        Console.WriteLine($"   Category: {documentContent.Category}");
                    }
                    else
                    {
                        Console.WriteLine($"   Category: (not classified)");
                    }

                    // Display extracted fields if available
                    if (documentContent.Fields != null && documentContent.Fields.Count > 0)
                    {
                        DisplayExtractedFields(documentContent.Fields);
                    }
                }
            }
        }

        Console.WriteLine("=============================================================");
        Console.WriteLine();
    }

    static void DisplayExtractedFields(IDictionary<string, ContentField> fields)
    {
        if (fields == null || fields.Count == 0)
        {
            return;
        }

        Console.WriteLine($"\n   Extracted Fields ({fields.Count}):");
        foreach (var kvp in fields)
        {
            var fieldName = kvp.Key;
            var field = kvp.Value;

            string? displayValue = null;
            if (field is StringField sf)
            {
                displayValue = sf.ValueString;
            }
            else if (field is NumberField nf)
            {
                displayValue = nf.ValueNumber?.ToString();
            }
            else if (field is DateField df)
            {
                displayValue = df.ValueDate?.ToString("yyyy-MM-dd");
            }
            else if (field is IntegerField inf)
            {
                displayValue = inf.ValueInteger?.ToString();
            }
            else if (field is BooleanField bf)
            {
                displayValue = bf.ValueBoolean?.ToString();
            }

            if (displayValue != null)
            {
                Console.WriteLine($"      {fieldName}: {displayValue}");
            }
        }
    }
}

