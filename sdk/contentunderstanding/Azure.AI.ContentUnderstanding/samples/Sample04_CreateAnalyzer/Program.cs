// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to analyze a document using the prebuilt-documentSearch analyzer.
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
        // Generate a unique analyzer ID
        string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        // Define field schema with custom fields
        // This example demonstrates three extraction methods:
        // - extract: Literal text extraction (requires estimateSourceAndConfidence)
        // - generate: AI-generated values based on content interpretation
        // - classify: Classification against predefined categories
        var fieldSchema = new ContentFieldSchema(
            new Dictionary<string, ContentFieldDefinition>
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
                },
                ["document_summary"] = new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Generate,
                    Description = "A brief summary of the document content"
                },
                ["document_type"] = new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Classify,
                    Description = "Type of document"
                }
            })
        {
            Name = "company_schema",
            Description = "Schema for extracting company information"
        };
        // Add enum values for the classify field
        fieldSchema.Fields["document_type"].Enum.Add("invoice");
        fieldSchema.Fields["document_type"].Enum.Add("receipt");
        fieldSchema.Fields["document_type"].Enum.Add("contract");
        fieldSchema.Fields["document_type"].Enum.Add("report");
        fieldSchema.Fields["document_type"].Enum.Add("other");
        // Create analyzer configuration
        var config = new ContentAnalyzerConfig
        {
            EnableFormula = true,
            EnableLayout = true,
            EnableOcr = true,
            EstimateFieldSourceAndConfidence = true,
            ReturnDetails = true
        };
        // Create the custom analyzer
        var customAnalyzer = new ContentAnalyzer
        {
            BaseAnalyzerId = "prebuilt-document",
            Description = "Custom analyzer for extracting company information",
            Config = config,
            FieldSchema = fieldSchema
        };
        // Add model mappings (required for custom analyzers)
        customAnalyzer.Models.Add("completion", "gpt-4.1");
        customAnalyzer.Models.Add("embedding", "text-embedding-3-large");
        // Create the analyzer
        var operation = await client.CreateAnalyzerAsync(
            WaitUntil.Completed,
            analyzerId,
            customAnalyzer,
            allowReplace: true);
        ContentAnalyzer result = operation.Value;
        Console.WriteLine($"Analyzer '{analyzerId}' created successfully!");

        // Analyze a document using the custom analyzer
        Uri documentUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/changjian-wang/init-content-understanding-dotnet/ContentUnderstanding.Common/data/invoice.pdf");
        var analyzeOperation = await client.AnalyzeAsync(
            WaitUntil.Completed,
            analyzerId,
            inputs: new[] { new AnalyzeInput { Url = documentUrl } });
        var analyzeResult = analyzeOperation.Value;
        // Extract custom fields from the result
        // Since EstimateFieldSourceAndConfidence is enabled, we can access confidence scores and source information
        if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent content)
        {
            // Extract field (literal text extraction)
            if (content.Fields.TryGetValue("company_name", out var companyNameField))
            {
                var companyName = companyNameField is StringField sf ? sf.ValueString : null;
                Console.WriteLine($"Company Name (extract): {companyName ?? "(not found)"}");
                if (companyNameField != null)
                {
                    Console.WriteLine($"  Confidence: {companyNameField.Confidence?.ToString("F2") ?? "N/A"}");
                    Console.WriteLine($"  Source: {companyNameField.Source ?? "N/A"}");
                    if (companyNameField.Spans != null && companyNameField.Spans.Count > 0)
                    {
                        var span = companyNameField.Spans[0];
                        Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                    }
                }
            }
            // Extract field (literal text extraction)
            if (content.Fields.TryGetValue("total_amount", out var totalAmountField))
            {
                var totalAmount = totalAmountField is NumberField nf ? nf.ValueNumber : null;
                Console.WriteLine($"Total Amount (extract): {totalAmount?.ToString("F2") ?? "(not found)"}");
                if (totalAmountField != null)
                {
                    Console.WriteLine($"  Confidence: {totalAmountField.Confidence?.ToString("F2") ?? "N/A"}");
                    Console.WriteLine($"  Source: {totalAmountField.Source ?? "N/A"}");
                    if (totalAmountField.Spans != null && totalAmountField.Spans.Count > 0)
                    {
                        var span = totalAmountField.Spans[0];
                        Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                    }
                }
            }
            // Generate field (AI-generated value)
            if (content.Fields.TryGetValue("document_summary", out var summaryField))
            {
                var summary = summaryField is StringField sf ? sf.ValueString : null;
                Console.WriteLine($"Document Summary (generate): {summary ?? "(not found)"}");
                if (summaryField != null)
                {
                    Console.WriteLine($"  Confidence: {summaryField.Confidence?.ToString("F2") ?? "N/A"}");
                    // Note: Generated fields may not have source information
                    if (!string.IsNullOrEmpty(summaryField.Source))
                    {
                        Console.WriteLine($"  Source: {summaryField.Source}");
                    }
                }
            }
            // Classify field (classification against predefined categories)
            if (content.Fields.TryGetValue("document_type", out var documentTypeField))
            {
                var documentType = documentTypeField is StringField sf ? sf.ValueString : null;
                Console.WriteLine($"Document Type (classify): {documentType ?? "(not found)"}");
                if (documentTypeField != null)
                {
                    Console.WriteLine($"  Confidence: {documentTypeField.Confidence?.ToString("F2") ?? "N/A"}");
                    // Note: Classified fields may not have source information
                    if (!string.IsNullOrEmpty(documentTypeField.Source))
                    {
                        Console.WriteLine($"  Source: {documentTypeField.Source}");
                    }
                }
            }
        }

        // Clean up: delete the analyzer (for testing purposes only)
        // In production, analyzers are typically kept and reused
        await client.DeleteAnalyzerAsync(analyzerId);
        Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
        // === END SNIPPET ===
    }
}
